using GymGestor.Core.Enums;

namespace GymGestor.Application.Models.InputModels.User;
public class CreateUserInputModel
{
    public string Email { get; set; }
    public string Password { get; set; }
    public RoleEnum Role { get; set; }

    public Core.Entities.User ToEntity(string passwordHash) => new(Email, passwordHash, Role);
}
