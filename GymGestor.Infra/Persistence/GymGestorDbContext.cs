﻿using GymGestor.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GymGestor.Infra.Persistence;
public class GymGestorDbContext : DbContext
{
    public GymGestorDbContext(DbContextOptions<GymGestorDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
