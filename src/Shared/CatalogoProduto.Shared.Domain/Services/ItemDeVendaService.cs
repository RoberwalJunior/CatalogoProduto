using CatalogoProduto.Shared.Domain.Entities;
using CatalogoProduto.Shared.Domain.Abstractions.Services;
using CatalogoProduto.Shared.Domain.Abstractions.Repositories;

namespace CatalogoProduto.Shared.Domain.Services;

public class ItemDeVendaService(IItemDeVendaRepository repository)
    : EntityService<ItemDeVenda>(repository), IItemDeVendaService
{
    public async Task<IEnumerable<ItemDeVenda>> GetItemsFromVenda(int vendaId)
    {
        return await _repository.GetAll(venda => venda.VendaId == vendaId);
    }
}
