using GymGestor.Core.Enums;

namespace GymGestor.Core.Entities
{
    public class Contract : BaseEntity
    {
        public Guid MemberId { get; private set; }
        public PlanEnum PlanName { get; private set; }
        public decimal Price { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public bool IsAutoRenew { get; private set; }
    }
}
