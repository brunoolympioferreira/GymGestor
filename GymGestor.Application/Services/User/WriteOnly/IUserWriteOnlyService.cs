using GymGestor.Application.Models.InputModels.User;

namespace GymGestor.Application.Services.User.WriteOnly;
public interface IUserWriteOnlyService
{
    Task Create(CreateUserInputModel model);
}
