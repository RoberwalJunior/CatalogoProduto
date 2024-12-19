using CatalogoProduto.Shared.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoProduto.Shared.Infrastructure.EntitiesConfiguration;

public class VendaConfiguration : IEntityTypeConfiguration<Venda>
{
    public void Configure(EntityTypeBuilder<Venda> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.ValorTotal)
            .HasPrecision(10, 2)
            .IsRequired();

        builder.Property(x => x.DataDaCompra)
            .IsRequired();

        builder.Property(x => x.FormaDePagamento)
           .IsRequired();

        builder.HasMany(x => x.Itens)
            .WithOne(x => x.Venda)
            .HasForeignKey(x => x.VendaId);

        builder.HasData(
            new Venda() { Id = 1, DataDaCompra = DateTime.Now.AddDays(-5), FormaDePagamento = Domain.Enums.FormaDePagamento.Débito, ValorTotal = 130 },
            new Venda() { Id = 2, DataDaCompra = DateTime.Now.AddDays(-10), FormaDePagamento = Domain.Enums.FormaDePagamento.Crédito, ValorTotal = 240 }
        );
    }
}
