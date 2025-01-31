using GymGestor.Application.Models.InputModels.Account;
using GymGestor.Application.Models.ViewModels.Account;
using GymGestor.Core.Exceptions;
using GymGestor.Infra.Authentication;
using GymGestor.Infra.Persistence.UnityOfWork;

namespace GymGestor.Application.Services.Account;
public class LoginService(IUnityOfWork unityOfWork, IAuthService authService) : ILoginService
{
    public async Task<LoginViewModel> Login(LoginInputModel model)
    {
        string passwordHash = authService.ComputeSha256Hash(model.Password);

        Core.Entities.User user = await unityOfWork.Users.GetUserByEmailAndPassword(model.Email, passwordHash) ??
            throw new NotFoundErrorException("Nome de usuário e/ou senha inválido");

        string token = authService.GenerateJwtToken(user);

        return new LoginViewModel(token);
    }
}
