using CatalogoProduto.Shared.Domain.Entities;
using CatalogoProduto.Shared.Domain.Abstractions.Services;
using CatalogoProduto.Shared.Domain.Abstractions.Repositories;

namespace CatalogoProduto.Shared.Domain.Services;

public class ProdutoService(IProdutoRepository repository)
    : EntityService<Produto>(repository), IProdutoService
{
}
