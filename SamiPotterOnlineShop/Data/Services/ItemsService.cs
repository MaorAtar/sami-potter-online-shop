using SamiPotterOnlineShop.Data.Base;
using SamiPotterOnlineShop.Data.ViewModels;
using SamiPotterOnlineShop.Models;
using Microsoft.EntityFrameworkCore;

namespace SamiPotterOnlineShop.Data.Services
{
    public class ItemsService : EntityBaseRepository<Item>, IItemsService
    {
        private readonly AppDbContext _context;

        public ItemsService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewItemAsync(NewItemVM data)
        {
            var newItem = new Item()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                WarehouseId = data.WarehouseId,
                StartDate = data.StartDate,
                Amount = data.Amount,
                ItemCategory = data.ItemCategory,
                ProducerId = data.ProducerId
            };
            await _context.Items.AddAsync(newItem);
            await _context.SaveChangesAsync();

            foreach (var actorId in data.ActorIds)
            {
                var newActorItem = new Actor_Item()
                {
                    ItemId = newItem.Id,
                    ActorId = actorId
                };
                await _context.Actors_Items.AddAsync(newActorItem);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Item> GetItemByIdAsync(int id)
        {
            var ItemDetails = await _context.Items
                .Include(c => c.Warehouse)
                .Include(p => p.Producer)
                .Include(am => am.Actors_Items).ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n => n.Id == id);

            return ItemDetails;
        }

        public async Task<NewItemDropdownsVM> GetNewItemDropdownsValues()
        {
            var response = new NewItemDropdownsVM()
            {
                Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync(),
                Warehouses = await _context.Warehouses.OrderBy(n => n.Name).ToListAsync(),
                Producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync()
            };
            return response;
        }

        public async Task UpdateItemAsync(NewItemVM data)
        {
            var dbItem = await _context.Items.FirstOrDefaultAsync(n => n.Id == data.Id);
            if(dbItem != null)
            {
                dbItem.Name = data.Name;
                dbItem.Description = data.Description;
                dbItem.Price = data.Price;
                dbItem.ImageURL = data.ImageURL;
                dbItem.WarehouseId = data.WarehouseId;
                dbItem.StartDate = data.StartDate;
                dbItem.Amount = data.Amount;
                dbItem.ItemCategory = data.ItemCategory;
                dbItem.ProducerId = data.ProducerId;
                await _context.SaveChangesAsync();
            }
            var existingActorDb = _context.Actors_Items.Where(n => n.ItemId == data.Id).ToList();
            _context.Actors_Items.RemoveRange(existingActorDb);
            await _context.SaveChangesAsync();

            foreach (var actorId in data.ActorIds)
            {
                var newActorItem = new Actor_Item()
                {
                    ItemId = data.Id,
                    ActorId = actorId
                };
                await _context.Actors_Items.AddAsync(newActorItem);
            }
            await _context.SaveChangesAsync();
        }
    }
}