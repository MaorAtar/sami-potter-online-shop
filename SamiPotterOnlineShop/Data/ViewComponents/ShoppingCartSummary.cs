﻿using SamiPotterOnlineShop.Data.Cart;
using Microsoft.AspNetCore.Mvc;

namespace SamiPotterOnlineShop.Data.ViewComponents
{
    public class ShoppingCartSummary : ViewComponent
    {
        public readonly ShoppingCart _shoppingCart;

        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            return View(items.Count);
        }
    }
}
