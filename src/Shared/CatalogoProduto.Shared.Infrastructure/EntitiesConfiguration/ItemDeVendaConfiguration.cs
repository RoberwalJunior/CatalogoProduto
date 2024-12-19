using CatalogoProduto.Shared.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoProduto.Shared.Infrastructure.EntitiesConfiguration;

public class ItemDeVendaConfiguration : IEntityTypeConfiguration<ItemDeVenda>
{
    public void Configure(EntityTypeBuilder<ItemDeVenda> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Quantidade)
            .IsRequired();

        builder.Property(x => x.Valor)
            .HasPrecision(10, 2)
            .IsRequired();

        builder.HasOne(x => x.Modelo)
            .WithMany(x => x.Itens)
            .HasForeignKey(x => x.ModeloId);

        builder.HasOne(x => x.Modelo)
            .WithMany(x => x.Itens)
            .OnDelete(DeleteBehavior.ClientNoAction);

        builder.HasData(
            new ItemDeVenda() { Id = 1, VendaId = 1, ModeloId = 1, Valor = 50, Quantidade = 1 },
            new ItemDeVenda() { Id = 2, VendaId = 1, ModeloId = 4, Valor = 80, Quantidade = 1 },
            new ItemDeVenda() { Id = 3, VendaId = 2, ModeloId = 2, Valor = 100, Quantidade = 2 },
            new ItemDeVenda() { Id = 4, VendaId = 2, ModeloId = 5, Valor = 140, Quantidade = 2 }
        );
    }
}
