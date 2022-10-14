using System;
using System.Collections.Generic;
using DivinaHamburgueria.Application.Interfaces;
using DivinaHamburgueria.Application.Mappings;
using DivinaHamburgueria.Application.Services;
using DivinaHamburgueria.Domain.Account;
using DivinaHamburgueria.Domain.Interfaces;
using DivinaHamburgueria.Infra.Data.Context;
using DivinaHamburgueria.Infra.Data.Identity;
using DivinaHamburgueria.Infra.Data.Repository;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

            services.AddScoped<IUnidadeRepository, UnidadeRepository>();
            services.AddScoped<IItemDoEstoqueReceitaRepository, ItemDoEstoqueReceitaRepository>();
            services.AddScoped<IComestivelRepository, ComestivelRepository>();
            services.AddScoped<IItemDoEstoqueRevendaRepository, ItemDoEstoqueRevendaRepository>();

            services.AddScoped<IUnidadeService, UnidadeService>();
            services.AddScoped<IItemDoEstoqueReceitaService, ItemDoEstoqueReceitaService>();
            services.AddScoped<IItemDoEstoqueRevendaService, ItemDoEstoqueRevendaService>();

            services.AddScoped<IAuthenticate, AuthenticateService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            //var myHandlers = AppDomain.CurrentDomain.Load("DivinaHamburgueria.Application");
            //services.AddMediatR(myHandlers);

            return services;
        }
    }
}
