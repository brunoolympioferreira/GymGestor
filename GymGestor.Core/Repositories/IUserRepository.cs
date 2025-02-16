using GymGestor.Core.Entities;

namespace GymGestor.Core.Repositories;
public interface IUserRepository
{
    Task Add(User user);
    void Update(User user);
    void Delete(User user);
    Task<bool> ExistUserWithEmail(string email, Guid id);
    Task<List<User>> GetAll();
    Task<User> GetById(Guid id);
    Task<User> GetUserByEmailAndPassword(string email, string password);
}
