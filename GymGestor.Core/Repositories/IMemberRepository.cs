using GymGestor.Core.Entities;

namespace GymGestor.Core.Repositories
{
    public interface IMemberRepository
    {
        Task Add(Member member);
        Task<List<Member>> GetAll();
    }
}
