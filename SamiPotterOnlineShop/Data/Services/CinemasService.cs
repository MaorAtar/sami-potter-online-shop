using SamiPotterOnlineShop.Data.Base;
using SamiPotterOnlineShop.Models;

namespace SamiPotterOnlineShop.Data.Services
{
    public class CinemasService : EntityBaseRepository<Cinema>, ICinemasService
    {
        public CinemasService(AppDbContext context) : base(context)
        { 
        }
    }
}
