using GymGestor.Application.Models.ViewModels.Member;
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
}
