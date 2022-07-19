// -----------------------------------------------------------------------
//  <copyright project="FirefighterStats-API" file="ApplicationDbContext.cs" company="syuko">
//  Copyright (c) syuko. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

#pragma warning disable CS8618
namespace FirefighterStats.Data;

using FirefighterStats.Entities;
using FirefighterStats.Entities.Activities;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    [UsedImplicitly]
    public DbSet<Activity> Activities { get; set; }

    [UsedImplicitly]
    public DbSet<FirefighterActivity> FirefighterActivities { get; set; }

    [UsedImplicitly]
    public DbSet<Intervention> Interventions { get; set; }

    [UsedImplicitly]
    public DbSet<PaySlip> PaySlips { get; set; }

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PaySlip>().Navigation(static c => c.Lines).AutoInclude();

        modelBuilder.Entity<FirefighterActivity>().Property(static p => p.Rate).HasConversion(static rate => (double) rate, static percentage => percentage);

        base.OnModelCreating(modelBuilder);
    }
}