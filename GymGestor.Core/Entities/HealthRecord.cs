namespace GymGestor.Core.Entities
{
    public class HealthRecord : BaseEntity
    {
        public Guid MemberId { get; private set; }
        public string Condition { get; private set; }
        public string Notes { get; private set; }
        public DateTime RecordDate { get; private set; }

        public HealthRecord(Guid memberId, string condition, string notes, DateTime recordDate)
        {
            MemberId = memberId;
            Condition = condition;
            Notes = notes;
            RecordDate = recordDate;
        }
    }
}
