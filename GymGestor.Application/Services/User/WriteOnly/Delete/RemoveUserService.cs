
using GymGestor.Core.Exceptions;
using GymGestor.Infra.Persistence.UnityOfWork;

namespace GymGestor.Application.Services.User.WriteOnly.Delete;
public class RemoveUserService(IUnityOfWork unityOfWork) : IRemoveUserService
{
    public async Task Remove(Guid id)
    {
        Core.Entities.User user = await unityOfWork.Users.GetById(id) ?? 
            throw new NotFoundErrorException($"Usuário com o id {id} não existe na base de dados.");

        unityOfWork.Users.Delete(user);

        await unityOfWork.CompleteAsync();
    }
}
