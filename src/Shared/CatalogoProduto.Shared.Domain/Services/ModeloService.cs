using CatalogoProduto.Shared.Domain.Entities;
using CatalogoProduto.Shared.Domain.Abstractions.Services;
using CatalogoProduto.Shared.Domain.Abstractions.Repositories;

namespace CatalogoProduto.Shared.Domain.Services;

public class ModeloService(IModeloRepository repository)
    : EntityService<Modelo>(repository), IModeloService
{
    public async Task<IEnumerable<Modelo>> GetModelosFromProduto(int produtoId)
    {
        return await _repository.GetAll(modelo => modelo.ProdutoId == produtoId);
    }

    public async Task<bool> AtualizarEstoque(int id, int quantidade)
    {
        var modelo = await _repository.GetEntityById(id);
        if (modelo != null)
        {
            modelo.QuantidadeEstoque += quantidade;
            return await UpdateEntity(modelo);
        }
        else
        {
            return false;
        }
    }
}
