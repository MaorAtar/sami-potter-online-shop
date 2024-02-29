using SamiPotterOnlineShop.Data.Base;
using SamiPotterOnlineShop.Models;
using Microsoft.EntityFrameworkCore;

namespace SamiPotterOnlineShop.Data.Services
{
    public class ActorsService : EntityBaseRepository<Actor>, IActorsService
    { 
        public ActorsService(AppDbContext context) : base(context) { }
    }
}
