using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using CatalogoProduto.Shared.Domain.Entities;
using CatalogoProduto.Shared.Domain.Abstractions.Repositories;
using CatalogoProduto.Shared.Infrastructure.Context;

namespace CatalogoProduto.Shared.Infrastructure.Repositories;

public abstract class EntityRepository<TEntity> : IEntityRepository<TEntity> where TEntity : Entity
{
    protected readonly AppDbContext _context;
    protected readonly DbSet<TEntity> _dbSet;
    protected Expression<Func<TEntity, object>>[] _includes;

    public EntityRepository(AppDbContext context, params Expression<Func<TEntity, object>>[] includes)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
        _includes = includes;
    }

    public async Task<IEnumerable<TEntity>> GetAll(Func<TEntity, bool> predicate = null!)
    {
        if (_dbSet != null)
        {
            try
            {
                return predicate != null ? _dbSet.Where(predicate).ToList() : (await _dbSet.ToListAsync());
            }
            catch (Exception)
            {
                return [];
            }
        }
        else
        {
            return [];
        }
    }

    public async Task<TEntity?> GetEntityById(int entityId)
    {
        if (_dbSet != null)
        {
            try
            {
                IQueryable<TEntity> query = _dbSet.Where(x => x.Id == entityId);

                if (_includes != null)
                {
                    query = _includes.Aggregate(query, (current, include) => current.Include(include));
                }

                return await query
                    .AsNoTracking()
                    .FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }
        else
        {
            return null;
        }
    }

    public async Task<bool> AddEntity(TEntity entity)
    {
        if (_context != null && _dbSet != null && entity != null)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public async Task<bool> UpdateEntity(TEntity entity)
    {
        if (_context != null && entity != null)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public async Task<bool> DeleteEntity(int entityId)
    {
        if (_context != null && _dbSet != null)
        {
            var entity = await GetEntityById(entityId);
            try
            {
                if (entity != null)
                {
                    _dbSet.Remove(entity);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
