using GymGestor.Core.Entities;
using GymGestor.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GymGestor.Infra.Persistence.Repositories;
public class UserRepository(GymGestorDbContext dbContext) : IUserRepository
{
    public async Task Add(User user)
    {
        await dbContext.AddAsync(user);
    }

    public async Task<bool> ExistUserWithUsername(string username, Guid id)
    {
        return await dbContext.Users
            .AsNoTracking()
            .AnyAsync(u => u.Username.Equals(username) && u.Id != id);
    }
}
