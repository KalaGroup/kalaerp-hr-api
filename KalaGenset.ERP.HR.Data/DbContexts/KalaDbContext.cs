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

    public virtual DbSet<CompanyEntityTypeMaster> CompanyEntityTypeMasters { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=KalaDbContext");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CompanyEntityTypeMaster>(entity =>
        {
            entity.HasKey(e => e.CompEntityTypeId).HasName("PK__CompanyE__E5D77CAD72C5B9E2");

            entity
                .ToTable("CompanyEntityTypeMaster")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("CompanyEntityTypeMasterHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.CompEntityTypeId).HasColumnName("CompEntityTypeID");
            entity.Property(e => e.CompanyEntityTypeAuth).HasDefaultValue(true);
            entity.Property(e => e.CompanyEntityTypeIsActive).HasDefaultValue(true);
            entity.Property(e => e.CompanyEntityTypeIsDiscard).HasDefaultValue(true);
            entity.Property(e => e.CompanyEntityTypeName).HasMaxLength(100);
            entity.Property(e => e.CompanyEntityTypeRemark)
                .HasMaxLength(100)
                .HasDefaultValue("Nil");
            entity.Property(e => e.CompanyEntityTypeShortName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
