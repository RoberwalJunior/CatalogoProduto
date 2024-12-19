using CatalogoProduto.Shared.Domain.Entities;
using CatalogoProduto.Shared.Domain.Abstractions.Services;
using CatalogoProduto.Shared.Domain.Abstractions.Repositories;

namespace CatalogoProduto.Shared.Domain.Services;

public abstract class EntityService<TEntity>(IEntityRepository<TEntity> repository)
    : IEntityService<TEntity> where TEntity : Entity
{
    protected readonly IEntityRepository<TEntity> _repository = repository;

    public async Task<IEnumerable<TEntity>> GetAll()
    {
        return await _repository.GetAll();
    }

    public async Task<TEntity?> GetEntityById(int id)
    {
        return await _repository.GetEntityById(id);
    }

    public async Task<bool> AddEntity(TEntity entity)
    {
        return await _repository.AddEntity(entity);
    }

    public async Task<bool> UpdateEntity(TEntity entity)
    {
        return await _repository.UpdateEntity(entity);
    }

    public async Task<bool> DeleteEntity(int id)
    {
        return await _repository.DeleteEntity(id);
    }
}
