using GymGestor.Application.Models.InputModels.User;
using GymGestor.Infra.Authentication;
using GymGestor.Infra.Persistence.UnityOfWork;

namespace GymGestor.Application.Services.User.WriteOnly.Update;
public class UpdateUserService(IUnityOfWork unityOfWork, IAuthService authService) : IUpdateUserService
{
    public async Task Update(UpdateUserInputModel model, Guid id)
    {
        var user = await unityOfWork.Users.GetById(id);

        var passwordHash = user.Password;
        if (!string.IsNullOrEmpty(model.Password))
        {
            passwordHash = authService.ComputeSha256Hash(model.Password);
        }

        var userUpdated = model.ToEntity(user.Email, passwordHash, user.Role);

        user.Update(userUpdated);

        unityOfWork.Users.Update(user);

        await unityOfWork.CompleteAsync();
    }
}
