using SamiPotterOnlineShop.Data.Services;
using SamiPotterOnlineShop.Data.Static;
using SamiPotterOnlineShop.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;

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
