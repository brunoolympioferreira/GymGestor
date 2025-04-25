using GymGestor.Core.Entities;
using GymGestor.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GymGestor.Infra.Persistence.Repositories
{
    public class MemberRepository(GymGestorDbContext dbContext) : IMemberRepository
    {
        public async Task Add(Member member)
        {
            await dbContext.AddAsync(member);
        }

        public void Update(Member member)
        {
            dbContext.Update(member);
        }

        public async Task<List<Member>> GetAll()
        {
            List<Member> members = await dbContext.Members
                .Include(m => m.HealthRecords)
                .Include(m => m.Contracts)
                .ToListAsync();

            return members;
        }

        public async Task<Member?> GetById(Guid id)
        {
            Member? member = await dbContext.Members
                .Include(m => m.HealthRecords)
                .Include(m => m.Contracts)
                .FirstOrDefaultAsync(m => m.Id == id);

            return member;
        }
    }
}
