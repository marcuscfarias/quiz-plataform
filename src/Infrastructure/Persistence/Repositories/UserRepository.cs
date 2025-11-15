using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class UserRepository(ApplicationDbContext dbContext) : BaseRepository<User>(dbContext), IUserRepository
{
    public async Task<bool> HasUserByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await dbContext.Set<User>()
            .AnyAsync(x => x.Email == email, cancellationToken);
    }
}