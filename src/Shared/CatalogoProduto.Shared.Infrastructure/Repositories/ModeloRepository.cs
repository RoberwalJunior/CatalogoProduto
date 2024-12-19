using CatalogoProduto.Shared.Domain.Entities;
using CatalogoProduto.Shared.Domain.Abstractions.Repositories;
using CatalogoProduto.Shared.Infrastructure.Context;

namespace CatalogoProduto.Shared.Infrastructure.Repositories;

public class ModeloRepository(AppDbContext context)
    : EntityRepository<Modelo>(context, modelo => modelo.Produto!), IModeloRepository
{
}
