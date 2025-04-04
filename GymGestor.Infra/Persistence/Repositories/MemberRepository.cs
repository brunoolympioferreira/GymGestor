using GymGestor.Core.Entities;
using GymGestor.Core.Repositories;

namespace GymGestor.Infra.Persistence.Repositories
{
    public class MemberRepository(GymGestorDbContext dbContext) : IMemberRepository
    {
        public async Task Add(Member member)
        {
            await dbContext.AddAsync(member);
        }
    }
}
