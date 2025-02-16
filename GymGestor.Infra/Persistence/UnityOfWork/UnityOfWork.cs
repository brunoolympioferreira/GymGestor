using GymGestor.Core.Repositories;

namespace GymGestor.Infra.Persistence.UnityOfWork;
public class UnityOfWork(GymGestorDbContext dbContext,
    IUserRepository users
        ) : IUnityOfWork
{
    private GymGestorDbContext _dbContext = dbContext;

    public IUserRepository Users { get; } = users;

    public async Task<int> CompleteAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _dbContext.Dispose();
        }
    }
}
