using Application.Users.Contracts;
using Application.Users.Mappers;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Users.Services;


public class UserService(IUserRepository userRepository) : IUserService
{
    public async Task<int> CreateUserAsync(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var hasUserRegistered = await userRepository.HasUserByEmailAsync(request.Email, cancellationToken);
        if (hasUserRegistered)
            throw new ApplicationException("User with that email already exists");

        //TODO: add hashedPassword service
        var hashedPassword = ""; //do the service
        var newUser = request.ToDomainWithHashedPassword(hashedPassword);
        
        var newUserId = await userRepository.AddAsync(newUser, cancellationToken);
        
        return newUserId;
    }
}