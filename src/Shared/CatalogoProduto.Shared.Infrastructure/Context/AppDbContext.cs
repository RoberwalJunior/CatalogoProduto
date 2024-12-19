using Microsoft.EntityFrameworkCore;
using CatalogoProduto.Shared.Domain.Entities;
using CatalogoProduto.Shared.Infrastructure.EntitiesConfiguration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CatalogoProduto.Shared.Infrastructure.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Produto>? Produtos { get; set; }
    public DbSet<Modelo>? Modelos { get; set; }
    public DbSet<Venda>? Vendas { get; set; }
    public DbSet<ItemDeVenda>? ItensDeVendas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
        modelBuilder.ApplyConfiguration(new ModeloConfiguration());
        modelBuilder.ApplyConfiguration(new VendaConfiguration());
        modelBuilder.ApplyConfiguration(new ItemDeVendaConfiguration());
    }
}
