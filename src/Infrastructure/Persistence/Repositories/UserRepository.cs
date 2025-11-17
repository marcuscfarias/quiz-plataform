using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;


public class UserRepository(ApplicationDbContext dbContext) : BaseRepository<User>(dbContext), IUserRepository
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task<bool> HasUserByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await _dbContext.Set<User>()
            .AnyAsync(x => x.Email == email, cancellationToken);
    }
}