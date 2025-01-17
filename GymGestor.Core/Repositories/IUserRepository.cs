using GymGestor.Core.Entities;

namespace GymGestor.Core.Repositories;
public interface IUserRepository
{
    Task Add(User user);
    Task<bool> ExistUserWithUsername(string username, Guid id);
    Task<List<User>> GetAll();
    Task<User> GetById(Guid id);
}
