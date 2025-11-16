using Application.Users.Contracts;
using Domain.Entities;

namespace Application.Users.Mappers;

public static class UserRequestToUserDomainMapper
{
    public static User ToDomainWithHashedPassword(this CreateUserRequest request, string password)
    {
        return new User(request.Username, password, request.Email, request.BirthDate, true);
    }
}