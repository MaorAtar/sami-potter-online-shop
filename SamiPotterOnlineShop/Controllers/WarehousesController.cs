using SamiPotterOnlineShop.Data.Services;
using SamiPotterOnlineShop.Data.Static;
using SamiPotterOnlineShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SamiPotterOnlineShop.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class WarehousesController : Controller
    {
        private readonly IWarehousesService _service;

        public WarehousesController(IWarehousesService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allWarehouses = await _service.GetAllAsync();
            return View(allWarehouses);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Warehouse Warehouse)
        {
            if (!ModelState.IsValid) return View(Warehouse);
            await _service.AddAsync(Warehouse);
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var WarehouseDetails = await _service.GetByIdAsync(id);
            if (WarehouseDetails == null) return View("NotFound");
            return View(WarehouseDetails);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var WarehouseDetails = await _service.GetByIdAsync(id);
            if (WarehouseDetails == null) return View("NotFound");
            return View(WarehouseDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")] Warehouse Warehouse)
        {
            if (!ModelState.IsValid) return View(Warehouse);
            await _service.UpdateAsync(id, Warehouse);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var WarehouseDetails = await _service.GetByIdAsync(id);
            if (WarehouseDetails == null) return View("NotFound");
            return View(WarehouseDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var WarehouseDetails = await _service.GetByIdAsync(id);
            if (WarehouseDetails == null) return View("NotFound");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}