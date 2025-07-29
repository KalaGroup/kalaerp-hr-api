using System;
using System.Collections.Generic;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace KalaGenset.ERP.HR.Data.DbContexts;

public partial class KalaDbContext : DbContext
{
    public KalaDbContext()
    {
    }

    public KalaDbContext(DbContextOptions<KalaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CurrencyMaster> CurrencyMasters { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=KalaDbContext");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CurrencyMaster>(entity =>
        {
            entity.HasKey(e => e.CurrencyId).HasName("PK__Currency__14470AF05972C444");

            entity
                .ToTable("CurrencyMaster")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("CurrencyMasterHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.CurrencyName)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.CurrencyRemark)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.CurrencySymbol)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
