using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Extensions;

public static class DbSetExtension
{
    public static async Task<T> AddIfNotExistsAsync<T>(this DbSet<T> dbSet, T entity,
        Expression<Func<T, bool>> predicate = null, CancellationToken cancellationToken = default) where T : class
    {
        ArgumentNullException.ThrowIfNull(predicate);

        var existed = await dbSet.AsNoTracking().FirstOrDefaultAsync(predicate, cancellationToken: cancellationToken);

        if (existed != null)
        {
            return existed;
        }

        var created = await dbSet.AddAsync(entity, cancellationToken);

        return created.Entity;
    }
}