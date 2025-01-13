using GymGestor.Core.Entities;

namespace GymGestor.Core.Repositories;
public interface IUserRepository
{
    Task Add(User user);
    Task<bool> ExistUserWithUsername(string username, Guid id);
}
