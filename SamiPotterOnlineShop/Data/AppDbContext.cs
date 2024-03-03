using SamiPotterOnlineShop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SamiPotterOnlineShop.Data
{
    public class AppDbContext: IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Item>().HasKey(am => new
            {
                am.ActorId,
                am.ItemId
            });

            modelBuilder.Entity<Actor_Item>().HasOne(m => m.Item).WithMany(am => am.Actors_Items).HasForeignKey(m => m.ItemId);
            modelBuilder.Entity<Actor_Item>().HasOne(m => m.Actor).WithMany(am => am.Actors_Items).HasForeignKey(m => m.ActorId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Actor> Actors { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Warehouse> Warehouses { get; set; }

        public DbSet<Producer> Producers { get; set; }

        public DbSet<Actor_Item> Actors_Items { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
