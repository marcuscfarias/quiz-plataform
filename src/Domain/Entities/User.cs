namespace Domain.Entities;

public class User(string username, string password, string email, DateOnly birthDate, bool isActive)
    : BaseEntity
{
    public string Username { get; private set; } = username ?? throw new ArgumentNullException(nameof(username));
    public string Password { get; private set; } = password ?? throw new ArgumentNullException(nameof(password));
    public string Email { get; private set; } = email ?? throw new ArgumentNullException(nameof(email));
    public DateOnly BirthDate { get; private set; } = birthDate;
    public bool IsActive { get; private set; } = isActive;
}