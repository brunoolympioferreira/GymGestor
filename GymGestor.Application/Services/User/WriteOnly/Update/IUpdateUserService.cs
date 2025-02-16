using GymGestor.Application.Models.InputModels.User;

namespace GymGestor.Application.Services.User.WriteOnly.Update;
public interface IUpdateUserService
{
    Task Update(UpdateUserInputModel model, Guid id);
}
