using Application.Users.Contracts;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Users.Services;


public class UserService(IUserRepository userRepository) : IUserService
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<int> CreateUserAsync(CreateUserRequest request, CancellationToken cancellationToken)
    {
        // string email = request.Email;
        // User? existingUser = await _userRepository.GetUserByEmailAsync(email, cancellationToken);
        //
        // if (existingUser is not null)
        //     throw new ApplicationException("User with this email already exists.");

        //TODO: add hashpassword
        User newUser = new(request.Name, request.Password, request.Email, request.BirthDate, true);
        
        return await _userRepository.AddAsync(newUser, cancellationToken);
    }
}