using DivinaHamburgueria.Application.Interfaces;
using DivinaHamburgueria.Application.Mappings;
using DivinaHamburgueria.Application.Services;
using DivinaHamburgueria.Domain.Account;
using DivinaHamburgueria.Domain.Interfaces;
using DivinaHamburgueria.Infra.Data.Context;
using DivinaHamburgueria.Infra.Data.Identity;
using DivinaHamburgueria.Infra.Data.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DivinaHamburgueria.Infra.IoC
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();

            services.AddScoped<IUnityRepository, UnityRepository>();
            services.AddScoped<IEatableRepository, EatableRepository>();
            services.AddScoped<IInventoryItemRepository, InventoryItemRepository>();
            services.AddScoped<IProviderRepository, ProviderRepository>();
            services.AddScoped<IPurchaseOrderRepository, PurchaseOrderRepository>();
            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddScoped<IMenuItemRecipeRepository, MenuItemRecipeRepository>();

            services.AddScoped<IUnityService, UnityService>();
            services.AddScoped<IInventoryItemService, InventoryItemService>();
            services.AddScoped<IProviderService, ProviderService>();
            services.AddScoped<IPurchaseOrderService, PurchaseOrderService>();
            services.AddScoped<IInventoryService, InventoryService>();
            services.AddScoped<IMenuItemRecipeService, MenuItemRecipeService>();

            services.AddScoped<IInventoryEnterService, InventoryEnterService>();

            services.AddScoped<IAuthenticate, AuthenticateService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            //var myHandlers = AppDomain.CurrentDomain.Load("DivinaHamburgueria.Application");
            //services.AddMediatR(myHandlers);

            return services;
        }
    }
}
