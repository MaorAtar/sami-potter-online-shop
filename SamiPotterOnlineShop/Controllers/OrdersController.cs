using SamiPotterOnlineShop.Data.Cart;
using SamiPotterOnlineShop.Data.Services;
using SamiPotterOnlineShop.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using SamiPotterOnlineShop.Models;
using SamiPotterOnlineShop.Data.Enums;

namespace SamiPotterOnlineShop.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IItemsService _ItemsService;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrdersService _ordersService;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrdersController(IItemsService ItemsService, ShoppingCart shoppingCart, IOrdersService ordersService, UserManager<ApplicationUser> userManager)
        {
            _ItemsService = ItemsService;
            _shoppingCart = shoppingCart;
            _ordersService = ordersService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);
            var orders = await _ordersService.GetOrdersByUserIdAndRoleAsync(userId, userRole);
            return View(orders);
        }

        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(response);
        }

        public async Task<IActionResult> AddItemToShoppingCart(int id)
        {
            var item = await _ItemsService.GetByIdAsync(id);
            if (item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _ItemsService.GetByIdAsync(id);
            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> CompleteOrder()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);
            await _ordersService.StoreOrderAsync(items, userId, userEmailAddress);
            await _shoppingCart.ClearShoppingCartAsync();
            return View("OrderCompleted");
        }



        [AllowAnonymous]
        public IActionResult BuyNow(int id)
        {
            ViewBag.ItemId = id;
            return View("BuyNow");
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CompleteBuyNow(int id, string fullName, string emailAddress, string creditCardNumber)
        {
            var item = await _ItemsService.GetByIdAsync(id);
            if (item == null)
            {
                return View("NotFound");
            }

            var newUser = new ApplicationUser
            {
                UserName = fullName.Replace(" ", ""),
                FullName = fullName,
                Email = emailAddress,
                CreditCardNumber = creditCardNumber
            };

            var result = await _userManager.CreateAsync(newUser);
            if (result.Succeeded)
            {
                _shoppingCart.AddItemToCart(item);
                var items = _shoppingCart.GetShoppingCartItems();
                await _ordersService.StoreOrderAsync(items, newUser.Id, newUser.Email);
                await _shoppingCart.ClearShoppingCartAsync();
                return View("OrderCompleted");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View("BuyNow");
            }
        }
    }
}
