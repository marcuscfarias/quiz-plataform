using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public abstract class BaseRepository<TEntity>(ApplicationDbContext context) : IBaseRepository<TEntity>
    where TEntity : BaseEntity
{
    public Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return context.Set<TEntity>()
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<int> AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        var user = await context.Set<TEntity>().AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return user.Entity.Id;
    }

    public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(TEntity entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}