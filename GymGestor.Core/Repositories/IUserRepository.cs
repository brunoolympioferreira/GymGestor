using GymGestor.Core.Entities;

namespace GymGestor.Core.Repositories;
public interface IUserRepository
{
    Task Add(User user);
}
