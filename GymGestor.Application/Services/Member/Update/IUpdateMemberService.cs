using GymGestor.Application.Models.InputModels.Member;

namespace GymGestor.Application.Services.Member.Update;
public interface IUpdateMemberService
{
    Task Update(UpdateMemberInputModel model, Guid id);
}
