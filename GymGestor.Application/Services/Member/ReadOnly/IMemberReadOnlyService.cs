using GymGestor.Application.Models.ViewModels.Member;

namespace GymGestor.Application.Services.Member.ReadOnly;
public interface IMemberReadOnlyService
{
    Task<List<MemberViewModel>> GetAll();
    Task<MemberDetailsViewModel> GetById(Guid id);
}
