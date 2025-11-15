using Domain.Entities;

namespace Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<bool> HasUserByEmailAsync(string email, CancellationToken cancellationToken);
}