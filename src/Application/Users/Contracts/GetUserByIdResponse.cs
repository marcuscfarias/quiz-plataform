namespace Application.Users.Contracts;

public sealed record GetUserByIdResponse(string Username, string Email, DateOnly BirthDate);