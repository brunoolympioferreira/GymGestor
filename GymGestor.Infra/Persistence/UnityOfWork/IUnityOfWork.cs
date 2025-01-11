using GymGestor.Core.Repositories;

namespace GymGestor.Infra.Persistence.UnityOfWork;
public interface IUnityOfWork
{
    IUserRepository Users { get; }

    Task<int> CompleteAsync();
}
