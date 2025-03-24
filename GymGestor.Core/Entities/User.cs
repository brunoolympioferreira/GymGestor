using GymGestor.Core.Enums;

namespace GymGestor.Core.Entities;
public class User : BaseEntity
{
    public User(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public User(string email, string password, RoleEnum role)
    {
        Email = email;
        Password = password;
        Role = role;
    }

    public string Email { get; private set; }
    public string Password { get; private set; }
    public RoleEnum Role { get; set; }

    public void Update(User user)
    {
        Password = user.Password;
        SetUpdatedAt();
    }
}
