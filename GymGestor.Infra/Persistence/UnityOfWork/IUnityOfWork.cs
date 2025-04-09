using GymGestor.Core.Repositories;

namespace GymGestor.Infra.Persistence.UnityOfWork;
public interface IUnityOfWork
{
    IUserRepository Users { get; }
    IMemberRepository Members { get; }

    Task<int> CompleteAsync();
}
