using GymGestor.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymGestor.Infra.Persistence.Configurations
{
    public class HealthRecordConfiguration : IEntityTypeConfiguration<HealthRecord>
    {
        public void Configure(EntityTypeBuilder<HealthRecord> builder)
        {
            builder.HasKey(hr => hr.Id);

            builder.Property(hr => hr.MemberId)
                .IsRequired();

            builder.Property(hr => hr.Condition)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(hr => hr.Notes)
                .HasMaxLength(1000);

            builder.Property(hr => hr.RecordDate)
                .IsRequired();
        }
    }
}
