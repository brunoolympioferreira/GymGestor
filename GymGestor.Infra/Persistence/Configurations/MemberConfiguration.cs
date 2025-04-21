using GymGestor.Core.Entities;
using GymGestor.Infra.Persistence.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymGestor.Infra.Persistence.Configurations
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.ToTable("Members");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.FullName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(m => m.DateOfBirth)
                .IsRequired();

            builder.OwnsOne(m => m.Gender, gender =>
            {
                gender.Property(g => g.Value)
                      .HasColumnName("Gender")
                      .IsRequired()
                      .HasMaxLength(50);
            });

            builder.OwnsOne(m => m.CPF, cpf =>
            {
                cpf.Property(c => c.Value)
                   .IsRequired()
                   .HasMaxLength(14)
                   .HasColumnName("Cpf");
            });

            builder.OwnsOne(m => m.Email, email =>
            {
                email.Property(e => e.Value)
                     .IsRequired()
                     .HasMaxLength(150)
                     .HasColumnName("Email");
            });

            builder.Property(m => m.Phone)
                .HasMaxLength(20);

            builder.OwnsOne(m => m.Address, address =>
            {
                address.Property(a => a.Street).HasMaxLength(200).HasColumnName("Street");
                address.Property(a => a.Number).HasMaxLength(10).HasColumnName("Number");
                address.Property(a => a.City).HasMaxLength(100).HasColumnName("City");
                address.Property(a => a.State).HasMaxLength(50).HasColumnName("State");
                address.Property(a => a.ZipCode).HasMaxLength(20).HasColumnName("ZipCode");
            });

            builder.Property(m => m.PhotoUrl)
                .HasMaxLength(255);

            builder.HasMany(m => m.HealthRecords)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(m => m.Contracts)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
