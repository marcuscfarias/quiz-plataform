using Application.Users.Contracts;
using Domain.Entities;

namespace Application.Users.Mappers;

public static class UserDomainToResponseMapper
{
    public static GetUserByIdResponse ToResponse(this User user)
    {
        return new GetUserByIdResponse(user.Username, user.Email, user.BirthDate);
    }
}