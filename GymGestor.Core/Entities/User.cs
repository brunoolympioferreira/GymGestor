using GymGestor.Core.Enums;

namespace GymGestor.Core.Entities;
public class User : BaseEntity
{
    public User(string username, string password)
    {
        Username = username;
        Password = password;
    }

    public User(string username, string password, RoleEnum role)
    {
        Username = username;
        Password = password;
        Role = role;
    }

    public string Username { get; private set; }
    public string Password { get; private set; }
    public RoleEnum Role { get; set; }

    public void Update(User user)
    {
        Password = user.Password;
        Role = user.Role;
        SetUpdatedAt();
    }
}
