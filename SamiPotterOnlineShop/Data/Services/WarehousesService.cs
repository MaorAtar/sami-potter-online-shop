using SamiPotterOnlineShop.Data.Base;
using SamiPotterOnlineShop.Models;

namespace SamiPotterOnlineShop.Data.Services
{
    public class WarehousesService : EntityBaseRepository<Warehouse>, IWarehousesService
    {
        public WarehousesService(AppDbContext context) : base(context)
        { 
        }
    }
}
