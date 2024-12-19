using CatalogoProduto.Shared.Domain.Entities;

namespace CatalogoProduto.Shared.Domain.Abstractions.Services;

public interface IItemDeVendaService : IEntityService<ItemDeVenda>
{
    public Task<IEnumerable<ItemDeVenda>> GetItemsFromVenda(int vendaId);
}
