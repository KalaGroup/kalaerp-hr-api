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

    public virtual DbSet<QualificationMaster> QualificationMasters { get; set; }

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

        modelBuilder.Entity<QualificationMaster>(entity =>
        {
            entity.HasKey(e => e.QualificationId).HasName("PK__Qualific__C95C128A359B3D6D");

            entity
                .ToTable("QualificationMaster")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("QualificationHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.QualificationId).HasColumnName("QualificationID");
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.MasterQualificationTypeId).HasColumnName("MasterQualificationTypeID");
            entity.Property(e => e.QualificationAuth).HasDefaultValue(true);
            entity.Property(e => e.QualificationCode).HasMaxLength(10);
            entity.Property(e => e.QualificationIsActive).HasDefaultValue(true);
            entity.Property(e => e.QualificationIsDiscard).HasDefaultValue(true);
            entity.Property(e => e.QualificationName).HasMaxLength(100);
            entity.Property(e => e.QualificationRemark)
                .HasMaxLength(100)
                .HasDefaultValue("Nil");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
