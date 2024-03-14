using SamiPotterOnlineShop.Data.Services;
using SamiPotterOnlineShop.Data.Static;
using SamiPotterOnlineShop.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SamiPotterOnlineShop.Data.Enums;
using Microsoft.AspNetCore.Identity;
using SamiPotterOnlineShop.Models;
using System.Security.Claims;

namespace SamiPotterOnlineShop.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ItemsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IItemsService _service;

        public ItemsController(UserManager<ApplicationUser> userManager, IItemsService service)
        {
            _userManager = userManager;
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["PriceDecSortParm"] = sortOrder == "Price Decrease" ? "price_decr" : "Price Decrease";
            ViewData["PriceIncSortParm"] = sortOrder == "Price Increase" ? "price_incr" : "Price Increase";
            ViewData["CategorySortParm"] = sortOrder == "Category" ? "category_desc" : "Category";

            var allItems = await _service.GetAllAsync(n => n.Warehouse);

            switch (sortOrder)
            {
                case "name_desc":
                    allItems = allItems.OrderByDescending(s => s.Name);
                    break;
                case "Date":
                    allItems = allItems.OrderBy(s => s.StartDate);
                    break;
                case "date_desc":
                    allItems = allItems.OrderByDescending(s => s.StartDate);
                    break;
                case "Price Decrease":
                    allItems = allItems.OrderByDescending(s => s.Price);
                    break;
                case "price_decr":
                    allItems = allItems.OrderByDescending(s => s.Price);
                    break;
                case "Price Increase":
                    allItems = allItems.OrderBy(s => s.Price);
                    break;
                case "price_incr":
                    allItems = allItems.OrderBy(s => s.Price);
                    break;
                case "Category":
                    allItems = allItems.OrderBy(s => s.ItemCategory);
                    break;
                case "category_desc":
                    allItems = allItems.OrderByDescending(s => s.ItemCategory);
                    break;
                default:
                    allItems = allItems.OrderBy(s => s.Name);
                    break;
            }

            return View(allItems.ToList());
        }


        [AllowAnonymous]
        public async Task<IActionResult> FilterByCategory(string categoryFilter)
        {
            var allItems = await _service.GetAllAsync(n => n.Warehouse);

            if (!string.IsNullOrEmpty(categoryFilter))
            {
                allItems = allItems.Where(n => n.ItemCategory.ToString().ToLower() == categoryFilter.ToLower());
            }

            return View("Index", allItems.ToList());
        }

        [AllowAnonymous]
        public async Task<IActionResult> FilterByDate(string dateFilter)
        {
            var allItems = await _service.GetAllAsync(n => n.Warehouse);

            if (!string.IsNullOrEmpty(dateFilter))
            {
                allItems = allItems.Where(n => n.StartDate.ToString().ToLower() == dateFilter.ToLower());
            }

            return View("Index", allItems.ToList());
        }

        [AllowAnonymous]
        public async Task<IActionResult> FilterOnSale(string onSaleFilter)
        {
            var allItems = await _service.GetAllAsync(n => n.Warehouse);

            if (!string.IsNullOrEmpty(onSaleFilter))
            {
                bool onSaleValue = onSaleFilter.ToLower() == "true";
                allItems = allItems.Where(n => n.Price < n.OriginalPrice == onSaleValue);
            }

            foreach (var item in allItems)
            {
                if (item.Price < item.OriginalPrice)
                {
                    item.OnSale = true;
                }
            }

            return View("Index", allItems.ToList());
        }

        [AllowAnonymous]
        public async Task<IActionResult> FilterByPrice(double? minPrice, double? maxPrice)
        {
            var allItems = await _service.GetAllAsync(n => n.Warehouse);

            if (minPrice.HasValue && maxPrice.HasValue)
            {
                allItems = allItems.Where(item => item.Price >= minPrice && item.Price <= maxPrice).ToList();
            }

            return View("Index", allItems);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> FilterMostPopular()
        {
            var allItems = await _service.GetAllAsync(n => n.Warehouse);

            allItems = allItems.Where(n => n.MostPopular.ToString().ToLower() == MostPopularCategory.Yes.ToString().ToLower());

            return View("Index", allItems.ToList());
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
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null && user.Notified == true)
            {
                user.Notified = false;
                await _userManager.UpdateAsync(user);
            }
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
                OriginalPrice = ItemDeatils.Price,
                OnSale = ItemDeatils.OnSale,
                MostPopular = ItemDeatils.MostPopular,
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

        [AllowAnonymous]
        public async Task<IActionResult> NotifyIfAvailable(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);

            if (user != null)
            {
                user.Notified = true;
                user.NotifyItemId = id;
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("NotFound");
            }
        }
    }
}