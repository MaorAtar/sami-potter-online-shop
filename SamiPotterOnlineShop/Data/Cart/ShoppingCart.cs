﻿using SamiPotterOnlineShop.Models;
using Microsoft.EntityFrameworkCore;

namespace SamiPotterOnlineShop.Data.Cart
{
    public class ShoppingCart
    {
        public AppDbContext _context { get; set; }

        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart(AppDbContext context)
        {
            _context = context;
        }

        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddItemToCart(Item item)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Item.Id == item.Id && n.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                if (item.Amount < 1)
                {
                    throw new Exception("Item is not available for purchase.");
                }

                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Item = item,
                    Amount = 1
                };
                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                if (item.Amount < 1)
                {
                    throw new Exception("Item is not available for purchase.");
                }

                shoppingCartItem.Amount++;
            }
            item.Amount--;

            _context.SaveChanges();
        }

        public void RemoveItemFromCart(Item Item)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Item.Id == Item.Id && n.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }
            Item.Amount++;
            _context.SaveChanges();
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Include(n => n.Item).ToList());
        }

        public double GetShoppingCartTotal() => _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Select(n => n.Item.Price * n.Amount).Sum();
        
        public async Task ClearShoppingCartAsync()
        {
            var items = await _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).ToListAsync();
            _context.ShoppingCartItems.RemoveRange(items);
            await _context.SaveChangesAsync();
            ShoppingCartItems = new List<ShoppingCartItem>();
        }
    }
}
