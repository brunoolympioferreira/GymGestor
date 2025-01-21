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

    public void Update(User user)
    {
        dbContext.Users.Update(user);
    }

    public async Task<bool> ExistUserWithUsername(string username, Guid id)
    {
        return await dbContext.Users
            .AsNoTracking()
            .AnyAsync(u => u.Username.Equals(username) && u.Id != id);
    }

    public async Task<List<User>> GetAll()
    {
        var users = await dbContext.Users.AsNoTracking().ToListAsync();

        return users;
    }

    public async Task<User> GetById(Guid id)
    {
        var user = await dbContext.Users
            .AsNoTracking()
            .Where(u => u.Id == id)
            .SingleOrDefaultAsync();

        return user;
    }
}
