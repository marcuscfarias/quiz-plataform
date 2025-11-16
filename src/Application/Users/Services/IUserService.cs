using Application.Users.Contracts;
using Domain.Entities;

namespace Application.Users.Services;

public interface IUserService
{
    Task<int> CreateUserAsync(CreateUserRequest request, CancellationToken cancellationToken);
    Task<GetUserByIdResponse> GetUserByIdAsync(int userId, CancellationToken cancellationToken);
}