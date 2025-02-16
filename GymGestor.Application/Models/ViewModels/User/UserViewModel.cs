using GymGestor.Core.Enums;

namespace GymGestor.Application.Models.ViewModels.User;
public class UserViewModel
{
    public UserViewModel(Core.Entities.User user)
    {
        Id = user.Id;
        Email = user.Email;
        Role = user.Role;
    }

    public Guid Id { get; }
    public string Email { get; }
    public RoleEnum Role { get; }
}
