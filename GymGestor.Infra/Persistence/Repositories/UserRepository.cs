using GymGestor.Core.Entities;
using GymGestor.Core.Repositories;

namespace GymGestor.Infra.Persistence.Repositories;
public class UserRepository(GymGestorDbContext dbContext) : IUserRepository
{
    public async Task Add(User user)
    {
        await dbContext.AddAsync(user);
    }
}
