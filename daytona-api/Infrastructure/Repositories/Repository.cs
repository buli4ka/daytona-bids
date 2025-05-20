using Core.Entities.Common;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal abstract class Repository<TEntity, TEntityId>
    where TEntity : Entity<TEntityId>
    where TEntityId : class
{
    
    protected readonly ApplicationDbContext DbContext;
    
    protected Repository(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public Task<TEntity?> GetByIdAsync(TEntityId id)
    {
        return DbContext.Set<TEntity>().SingleOrDefaultAsync(e => e.Id == id);
    }
    
    public void AddAsync(TEntity entity)
    {
        DbContext.Set<TEntity>().Add(entity);
    }    
    
    public void UpdateAsync(TEntity entity)
    {
        DbContext.Set<TEntity>().Update(entity);
    }    
    
    public void RemoveAsync(TEntity entity)
    {
        DbContext.Set<TEntity>().Remove(entity);
    }
    
}