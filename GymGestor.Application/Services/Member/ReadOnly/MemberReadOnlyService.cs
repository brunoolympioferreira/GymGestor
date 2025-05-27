using GymGestor.Application.Models.ViewModels.Member;
using GymGestor.Core.Exceptions;
using GymGestor.Infra.Persistence.UnityOfWork;

namespace GymGestor.Application.Services.Member.ReadOnly;
public class MemberReadOnlyService(IUnityOfWork unityOfWork) : IMemberReadOnlyService
{
    public async Task<List<MemberViewModel>> GetAll()
    {
        var members = await unityOfWork.Members.GetAll();

        List<MemberViewModel> membersViewModels = [.. members.Select(MemberViewModel.FromEntity)];

        return membersViewModels;
    }

    public async Task<MemberDetailsViewModel> GetById(Guid id)
    {
        var member = await unityOfWork.Members.GetById(id) ?? 
            throw new NotFoundErrorException($"Member {id} not found");

        MemberDetailsViewModel memberViewModel = MemberDetailsViewModel.FromEntity(member);

        return memberViewModel;
    }
}
