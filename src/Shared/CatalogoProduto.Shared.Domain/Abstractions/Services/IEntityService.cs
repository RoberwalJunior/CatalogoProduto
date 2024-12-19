using CatalogoProduto.Shared.Domain.Entities;

namespace CatalogoProduto.Shared.Domain.Abstractions.Services;

public interface IEntityService<TEntity> where TEntity : Entity
{
    public Task<IEnumerable<TEntity>> GetAll();
    public Task<TEntity?> GetEntityById(int id);
    public Task<bool> AddEntity(TEntity entity);
    public Task<bool> UpdateEntity(TEntity entity);
    public Task<bool> DeleteEntity(int id);
}
