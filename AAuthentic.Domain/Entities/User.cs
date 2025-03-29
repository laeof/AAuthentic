namespace AAuthentic.Domain.Entities;

public class User : EntityBase
{
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public IList<Role> Roles { get; init; } = new List<Role>();
}
