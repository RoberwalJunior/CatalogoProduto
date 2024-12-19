using CatalogoProduto.Shared.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoProduto.Shared.Infrastructure.EntitiesConfiguration;

public class ModeloConfiguration : IEntityTypeConfiguration<Modelo>
{
    public void Configure(EntityTypeBuilder<Modelo> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Descricao)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(x => x.QuantidadeEstoque)
           .IsRequired();

        builder.HasData(
            new Modelo() { Id = 1, Descricao = "Tamanho P", QuantidadeEstoque = 100, ProdutoId = 1 },
            new Modelo() { Id = 2, Descricao = "Tamanho M", QuantidadeEstoque = 150, ProdutoId = 1 },
            new Modelo() { Id = 3, Descricao = "Tamanho G", QuantidadeEstoque = 50, ProdutoId = 1 },
            new Modelo() { Id = 4, Descricao = "Tamanho P", QuantidadeEstoque = 20, ProdutoId = 2 },
            new Modelo() { Id = 5, Descricao = "Tamanho M", QuantidadeEstoque = 50, ProdutoId = 2 },
            new Modelo() { Id = 6, Descricao = "Tamanho G", QuantidadeEstoque = 70, ProdutoId = 2 }
        );
    }
}
