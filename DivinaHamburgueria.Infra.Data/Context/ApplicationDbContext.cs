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

        public DbSet<Cardapio>? Cardapios { get; set; }

        public DbSet<CardapioItemDoCardapio>? CardapiosItensDoCardapio { get; set; }

        public DbSet<ItemDoCardapioReceita>? ItensDoCardapioReceita { get; set; }

        public DbSet<ItemDoCardapioRevenda>? ItensDoCardapioRevenda { get; set; }

        public DbSet<PedidoDeCompra>? PedidosDeCompra { get; set; }

        public DbSet<PedidoDelivery>? PedidosDelivery { get; set; }

        public DbSet<PedidoDeliveryItemDoCardapio>? PedidosDeliveryItensDoCardapio { get; set; }

        public DbSet<PedidoSalao>? PedidosSalao { get; set; }

        public DbSet<PedidoSalaoItemDoCardapio>? PedidosSalaoItensDoCardapio { get; set; }

        public DbSet<Estoque>? Estoques { get; set; }

        public DbSet<EnderecoCliente>? EnderecosClientes { get; set; }

        public DbSet<EnderecoFornecedor>? EnderecosFornecedores { get; set; }

        public DbSet<TelefoneCliente>? TelefonesClientes { get; set; }

        public DbSet<TelefoneFornecedor>? TelefonesFornecedores { get; set; }

        public DbSet<Unidade>? Unidades { get; set; }

        public DbSet<ItemDoEstoqueReceita>? ItensDoEstoqueReceita { get; set; }

        public DbSet<ItemDoEstoqueRevenda>? ItensDoEstoqueRevenda { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

    }
}
