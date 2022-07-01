// -----------------------------------------------------------------------
//  <copyright project="FirefighterStats-API" file="ApplicationDbContext.cs" company="syuko">
//  Copyright (c) syuko. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

#pragma warning disable CS8618
namespace FirefighterStats.Data;

using FirefighterStats.Entities;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<PaySlip> PaySlips { get; set; }

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PaySlip>().Navigation(static c => c.Lines).AutoInclude();

        base.OnModelCreating(modelBuilder);
    }
}