using GymGestor.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GymGestor.Infra.Persistence;
public class GymGestorDbContext : DbContext
{
    public GymGestorDbContext(DbContextOptions<GymGestorDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    //public DbSet<Member> Members { get; set; }
    //public DbSet<HealthRecord> HealthRecords { get; set; }
    //public DbSet<Contract> Contracts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
