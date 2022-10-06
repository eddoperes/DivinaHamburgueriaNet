using DivinaHamburgueria.Domain.Entities;
using DivinaHamburgueria.Infra.Data.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivinaHamburgueria.Infra.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
             : base(options)
        {
        }

        public DbSet<Cardapio> Cardapios { get; set; }

        public DbSet<CardapioItemDoCardapio> CardapiosItensDoCardapio { get; set; }

        public DbSet<ItemDoCardapioReceita> ItensDoCardapioReceita { get; set; }

        public DbSet<ItemDoCardapioReceita> ItensDoCardapioRevenda { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

    }
}
