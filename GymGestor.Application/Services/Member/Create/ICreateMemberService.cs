using GymGestor.Application.Models.InputModels.Member;

namespace GymGestor.Application.Services.Member.Create
{
    public interface ICreateMemberService
    {
        Task Create(CreateMemberInputModel model);
    }
}
