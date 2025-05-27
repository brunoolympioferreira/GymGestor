using GymGestor.Core.Entities;

namespace GymGestor.Core.Repositories
{
    public interface IMemberRepository
    {
        Task Add(Member member);
        void Update(Member member);
        Task<List<Member>> GetAll();
        Task<Member?> GetById(Guid id);
    }
}
