namespace Application.Users.Contracts;

public sealed record CreateUserRequest(string Username, string Password, string Email, DateOnly BirthDate);