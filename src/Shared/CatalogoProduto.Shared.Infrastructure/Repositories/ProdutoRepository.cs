using CatalogoProduto.Shared.Domain.Entities;
using CatalogoProduto.Shared.Domain.Abstractions.Repositories;
using CatalogoProduto.Shared.Infrastructure.Context;

namespace CatalogoProduto.Shared.Infrastructure.Repositories;

public class ProdutoRepository(AppDbContext context)
    : EntityRepository<Produto>(context, produto => produto.Modelos!), IProdutoRepository
{
}
