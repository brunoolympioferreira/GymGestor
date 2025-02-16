namespace GymGestor.Application.Services.User.WriteOnly.Delete;
public interface IRemoveUserService
{
    Task Remove(Guid id);
}
