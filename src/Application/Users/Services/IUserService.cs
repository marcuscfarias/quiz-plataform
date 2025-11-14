using Application.Users.Contracts;

namespace Application.Users.Services;

public interface IUserService
{
    Task<int> CreateUserAsync(CreateUserRequest request, CancellationToken cancellationToken);
}