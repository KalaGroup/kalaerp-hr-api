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

    public virtual DbSet<FacilityMaster> FacilityMasters { get; set; }

    public virtual DbSet<GradeFacilityAssignment> GradeFacilityAssignments { get; set; }

    public virtual DbSet<ProfitcenterMaster> ProfitcenterMasters { get; set; }

    public virtual DbSet<StateMaster> StateMasters { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=KalaDbContext");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FacilityMaster>(entity =>
        {
            entity.HasKey(e => e.FacilityId).HasName("PK__Facility__5FB08B9408B4E837");

            entity
                .ToTable("FacilityMaster")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("FacilityMasterHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.FacilityId).HasColumnName("FacilityID");
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.FacilityAuth).HasDefaultValue(true);
            entity.Property(e => e.FacilityIsActive).HasDefaultValue(true);
            entity.Property(e => e.FacilityIsDiscard).HasDefaultValue(true);
            entity.Property(e => e.FacilityName).HasMaxLength(100);
            entity.Property(e => e.FacilityRemark)
                .HasMaxLength(100)
                .HasDefaultValue("Nil");
            entity.Property(e => e.FaciltyCode).HasMaxLength(10);
        });

        modelBuilder.Entity<GradeFacilityAssignment>(entity =>
        {
            entity.HasKey(e => e.GradeFacilityAssignmentId).HasName("PK__GradeFac__345403E20D70C2DF");

            entity
                .ToTable("GradeFacilityAssignment")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("GradeFacilityAssignmentHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.HasOne(d => d.AssignmentFacility).WithMany(p => p.GradeFacilityAssignments)
                .HasForeignKey(d => d.AssignmentFacilityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GradeFacilityAssignmentId_AssignmentFacilityId");
        });

        modelBuilder.Entity<ProfitcenterMaster>(entity =>
        {
            entity.HasKey(e => e.ProfitCenterId).HasName("PK__Profitce__55D36F09C6F29D23");

            entity
                .ToTable("ProfitcenterMaster")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("ProfitCenterMasterHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ParentProfitCenterId).HasColumnName("ParentProfitCenterID");
            entity.Property(e => e.ProfitCenterAuth).HasDefaultValue(true);
            entity.Property(e => e.ProfitCenterAuthRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.ProfitCenterCode).HasMaxLength(10);
            entity.Property(e => e.ProfitCenterIsActive).HasDefaultValue(true);
            entity.Property(e => e.ProfitCenterIsDiscard).HasDefaultValue(true);
            entity.Property(e => e.ProfitCenterName).HasMaxLength(100);
            entity.Property(e => e.ProfitCenterRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");

            entity.HasOne(d => d.ParentProfitCenter).WithMany(p => p.InverseParentProfitCenter)
                .HasForeignKey(d => d.ParentProfitCenterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProfitCenterId_ParentProfitCenterID");
        });

        modelBuilder.Entity<StateMaster>(entity =>
        {
            entity.HasKey(e => e.StateId).HasName("PK__StateMas__C3BA3B5A3D9D549A");

            entity
                .ToTable("StateMaster")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("StateMasterHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.StateId).HasColumnName("StateID");
            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.ShortName).HasMaxLength(50);
            entity.Property(e => e.StateCode).HasMaxLength(10);
            entity.Property(e => e.StateName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
