using GymGestor.Core.Enums;

namespace GymGestor.Application.Models.InputModels.User;
public class UpdateUserInputModel
{
    public string? Password { get; set; }
    public Core.Entities.User ToEntity(string username, string passwordHash) => new(username, passwordHash);
}
