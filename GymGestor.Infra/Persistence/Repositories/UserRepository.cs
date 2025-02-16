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

    public void Delete(User user)
    {
        dbContext.Users.Remove(user);
    }

    public async Task<bool> ExistUserWithEmail(string email, Guid id)
    {
        return await dbContext.Users
            .AsNoTracking()
            .AnyAsync(u => u.Email.Equals(email) && u.Id != id);
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

    public async Task<User> GetUserByEmailAndPassword(string email, string password)
    {
        User? user = await dbContext.Users
            .AsNoTracking()
            .SingleOrDefaultAsync(u => u.Email == email && u.Password == password);

        return user;
    }
}
