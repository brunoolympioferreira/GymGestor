using GymGestor.Application.Models.ViewModels.User;
using GymGestor.Infra.Persistence.UnityOfWork;

namespace GymGestor.Application.Services.User.ReadOnly;
public class UserReadOnlyService(IUnityOfWork unityOfWork) : IUserReadOnlyService
{
    public async Task<List<UserViewModel>> GetAll()
    {
        List<Core.Entities.User> users = await unityOfWork.Users.GetAll();

        List<UserViewModel> viewModels = users.Select(u => new UserViewModel(u)).ToList();

        return viewModels;
    }
}
