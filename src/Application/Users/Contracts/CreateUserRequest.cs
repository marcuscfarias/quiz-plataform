namespace Application.Users.Contracts;

public sealed record CreateUserRequest(string Name, string Password, string Email, DateOnly BirthDate);