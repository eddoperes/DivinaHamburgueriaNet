using DivinaHamburgueria.Domain.Entities;
using DivinaHamburgueria.Domain.ValueObjects;
using DivinaHamburgueria.Infra.Data.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DivinaHamburgueria.Infra.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
             : base(options)
        {
        }

        public DbSet<Menu>? Menus { get; set; }

        public DbSet<MenuMenuItem>? MenuMenuItems { get; set; }

        public DbSet<MenuItemRecipe>? MenuItemsRecipe { get; set; }

        public DbSet<MenuItemResale>? MenuItemsResale { get; set; }

        public DbSet<PurchaseOrder>? PurchaseOrders { get; set; }

        public DbSet<DeliveryOrder>? DeliveryOrders { get; set; }

        public DbSet<DeliveryOrderMenuItem>? DeliveryOrdersMenuItems { get; set; }

        public DbSet<HallOrder>? HallOrders { get; set; }

        public DbSet<HallOrderMenuItem>? HallOrdersMenuItems { get; set; }

        public DbSet<Inventory>? Inventories { get; set; }

        public DbSet<Unity>? Units { get; set; }

        public DbSet<InventoryItem>? InventoryItems { get; set; }

        public DbSet<Eatable>? Eatables { get; set; }

        public DbSet<Provider>? Providers { get; set; }

        public DbSet<Customer>? Customers { get; set; }

        public DbSet<User>? CustomUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

    }
}
