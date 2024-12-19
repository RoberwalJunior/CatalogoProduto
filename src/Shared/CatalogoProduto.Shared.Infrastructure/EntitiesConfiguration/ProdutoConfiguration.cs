using CatalogoProduto.Shared.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoProduto.Shared.Infrastructure.EntitiesConfiguration;

public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Codigo)
            .IsRequired();

        builder.Property(x => x.Nome)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.PrecoUnitario)
            .HasPrecision(10, 2)
            .IsRequired();

        builder.HasMany(x => x.Modelos)
            .WithOne(x => x.Produto)
            .HasForeignKey(x => x.ProdutoId);

        builder.HasData(
            new Produto() { Id = 1, Codigo = 100, Nome = "Camisa Social", PrecoUnitario = 50 },
            new Produto() { Id = 2, Codigo = 101, Nome = "Calça Social", PrecoUnitario = 80 }
        );
    }
}
