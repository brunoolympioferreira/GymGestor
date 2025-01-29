namespace GymGestor.Application.Models.InputModels.Account;
public class LoginInputModel
{
    public string Username { get; set; }
    public string Password { get; set; }

    public Core.Entities.User ToEntity() => new(Username, Password);
}
