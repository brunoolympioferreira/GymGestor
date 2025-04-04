using GymGestor.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymGestor.Infra.Persistence.Configurations
{
    public class ContractConfiguration : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.MemberId)
                .IsRequired();

            builder.Property(c => c.PlanName)
                .IsRequired()
                .HasConversion<string>();

            builder.Property(c => c.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(c => c.StartDate)
                .IsRequired();

            builder.Property(c => c.EndDate)
                .IsRequired();

            builder.Property(c => c.IsAutoRenew)
                .IsRequired();
        }
    }
}
