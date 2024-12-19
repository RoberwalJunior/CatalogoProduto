using CatalogoProduto.Shared.Domain.Entities;
using CatalogoProduto.Shared.Domain.Abstractions.Repositories;
using CatalogoProduto.Shared.Infrastructure.Context;

namespace CatalogoProduto.Shared.Infrastructure.Repositories;

public class ItemDeVendaRepository(AppDbContext context)
    : EntityRepository<ItemDeVenda>(context, item => item.Venda!, item => item.Modelo!), IItemDeVendaRepository
{
}
