using GymGestor.Application.Models.InputModels.Account;
using GymGestor.Application.Models.ViewModels.Account;

namespace GymGestor.Application.Services.Account;
public interface ILoginService
{
    Task<LoginViewModel> Login(LoginInputModel model);
}
