using SamiPotterOnlineShop.Data.Services;
using SamiPotterOnlineShop.Data.Static;
using SamiPotterOnlineShop.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SamiPotterOnlineShop.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ItemsController : Controller
    {
        private readonly IItemsService _service;

        public ItemsController(IItemsService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allItems = await _service.GetAllAsync(n => n.Warehouse);
            return View(allItems);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allItems = await _service.GetAllAsync(n => n.Warehouse);
            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allItems.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) ||
                n.Description.ToLower().Contains(searchString.ToLower()) || n.Id.ToString().ToLower().Contains(searchString.ToLower())).ToList();
                return View("Index", filteredResult);
            }
            return View("Index", allItems);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var ItemDetail = await _service.GetItemByIdAsync(id);
            return View(ItemDetail);
        }

        public async Task<IActionResult> Create()
        {
            var ItemDropdownsData = await _service.GetNewItemDropdownsValues();
            ViewBag.Warehouses = new SelectList(ItemDropdownsData.Warehouses, "Id", "Name");
            ViewBag.Producers = new SelectList(ItemDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(ItemDropdownsData.Actors, "Id", "FullName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewItemVM Item)
        {
            if (!ModelState.IsValid)
            {
                var ItemDropdownsData = await _service.GetNewItemDropdownsValues();
                ViewBag.Warehouses = new SelectList(ItemDropdownsData.Warehouses, "Id", "Name");
                ViewBag.Producers = new SelectList(ItemDropdownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(ItemDropdownsData.Actors, "Id", "FullName");
                return View(Item);
            }
            await _service.AddNewItemAsync(Item);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var ItemDeatils = await _service.GetItemByIdAsync(id);
            if (ItemDeatils == null) return View("NotFound");
            var response = new NewItemVM()
            {
                Id = ItemDeatils.Id,
                Name = ItemDeatils.Name,
                Description = ItemDeatils.Description,
                Price = ItemDeatils.Price,
                StartDate = ItemDeatils.StartDate,
                Amount = ItemDeatils.Amount,
                ImageURL = ItemDeatils.ImageURL,
                ItemCategory = ItemDeatils.ItemCategory,
                WarehouseId = ItemDeatils.WarehouseId,
                ProducerId = ItemDeatils.ProducerId,
                ActorIds = ItemDeatils.Actors_Items.Select(n => n.ActorId).ToList()
            };
            var ItemDropdownsData = await _service.GetNewItemDropdownsValues();
            ViewBag.Warehouses = new SelectList(ItemDropdownsData.Warehouses, "Id", "Name");
            ViewBag.Producers = new SelectList(ItemDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(ItemDropdownsData.Actors, "Id", "FullName");
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewItemVM Item)
        {
            if (id != Item.Id) return View("NotFound");
            if (!ModelState.IsValid)
            {
                var ItemDropdownsData = await _service.GetNewItemDropdownsValues();
                ViewBag.Warehouses = new SelectList(ItemDropdownsData.Warehouses, "Id", "Name");
                ViewBag.Producers = new SelectList(ItemDropdownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(ItemDropdownsData.Actors, "Id", "FullName");
                return View(Item);
            }
            await _service.UpdateItemAsync(Item);
            return RedirectToAction(nameof(Index));
        }
    }
}
