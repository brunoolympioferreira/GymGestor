using GymGestor.Application.Models.ViewModels.User;
using GymGestor.Core.Exceptions;
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

    public async Task<UserViewModel> GetById(Guid id)
    {
        Core.Entities.User user = await unityOfWork.Users.GetById(id) ?? 
            throw new NotFoundErrorException($"User com o id {id} não existe na base de dados.");

        UserViewModel viewModel = new(user);

        return viewModel;
    }
}
