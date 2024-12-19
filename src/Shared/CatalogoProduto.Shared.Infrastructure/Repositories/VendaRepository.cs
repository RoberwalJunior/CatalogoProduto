using CatalogoProduto.Shared.Domain.Entities;
using CatalogoProduto.Shared.Domain.Abstractions.Repositories;
using CatalogoProduto.Shared.Infrastructure.Context;

namespace CatalogoProduto.Shared.Infrastructure.Repositories;

public class VendaRepository(AppDbContext context)
    : EntityRepository<Venda>(context, venda => venda.Itens!), IVendaRepository
{
}
