using SamiPotterOnlineShop.Data.Base;
using SamiPotterOnlineShop.Data.ViewModels;
using SamiPotterOnlineShop.Models;

namespace SamiPotterOnlineShop.Data.Services
{
    public interface IItemsService : IEntityBaseRepository<Item>
    {
        Task<Item> GetItemByIdAsync(int id);
        Task<NewItemDropdownsVM> GetNewItemDropdownsValues();
        Task AddNewItemAsync(NewItemVM data);
        Task UpdateItemAsync(NewItemVM data);
    }
}
