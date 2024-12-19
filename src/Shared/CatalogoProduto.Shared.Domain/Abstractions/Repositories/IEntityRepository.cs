using CatalogoProduto.Shared.Domain.Entities;

namespace CatalogoProduto.Shared.Domain.Abstractions.Repositories;

public interface IEntityRepository<TEntity> : IDisposable where TEntity : Entity
{
    public Task<IEnumerable<TEntity>> GetAll(Func<TEntity, bool> predicate = null!);
    public Task<TEntity?> GetEntityById(int entityId);
    public Task<bool> AddEntity(TEntity entity);
    public Task<bool> UpdateEntity(TEntity entity);
    public Task<bool> DeleteEntity(int entityId);
}
