using GymGestor.Application.Models.InputModels.User;

namespace GymGestor.Application.Services.User.WriteOnly.Create;
public interface ICreateUserService
{
    Task Create(CreateUserInputModel model);
}
