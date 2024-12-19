using CatalogoProduto.Shared.Domain.Entities;

namespace CatalogoProduto.Shared.Domain.Abstractions.Services;

public interface IModeloService : IEntityService<Modelo>
{
    public Task<IEnumerable<Modelo>> GetModelosFromProduto(int produtoId);
    public Task<bool> AtualizarEstoque(int id, int quantidade);
}
