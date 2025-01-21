using GymGestor.Core.Enums;

namespace GymGestor.Core.Entities;
public class User(string username, string password, RoleEnum role) : BaseEntity
{
    public string Username { get; private set; } = username;
    public string Password { get; private set; } = password;
    public RoleEnum Role { get; set; } = role;

    public void Update(User user)
    {
        Password = user.Password;
        Role = user.Role;
        SetUpdatedAt();
    }
}
