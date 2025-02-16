using GymGestor.Application.Models.ViewModels.User;

namespace GymGestor.Application.Services.User.ReadOnly;
public interface IUserReadOnlyService
{
    Task<List<UserViewModel>> GetAll();
    Task<UserViewModel> GetById(Guid id);
}
