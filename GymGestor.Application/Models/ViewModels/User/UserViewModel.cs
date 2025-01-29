using GymGestor.Core.Enums;

namespace GymGestor.Application.Models.ViewModels.User;
public class UserViewModel
{
    public UserViewModel(Core.Entities.User user)
    {
        Id = user.Id;
        Username = user.Username;
        Role = user.Role;
    }

    public Guid Id { get; }
    public string Username { get; }
    public RoleEnum Role { get; }
}
