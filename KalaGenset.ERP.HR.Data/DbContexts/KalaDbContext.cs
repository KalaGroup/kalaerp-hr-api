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

    public virtual DbSet<CityMaster> CityMasters { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=KalaDbContext");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CityMaster>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PK__CityMast__F2D21A9674749603");

            entity
                .ToTable("CityMaster")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("CityMasterHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.CityAuth).HasDefaultValue(true);
            entity.Property(e => e.CityCode).HasMaxLength(10);
            entity.Property(e => e.CityCountryId).HasColumnName("CityCountryID");
            entity.Property(e => e.CityDistrictId).HasColumnName("CityDistrictID");
            entity.Property(e => e.CityIsActive).HasDefaultValue(true);
            entity.Property(e => e.CityIsDiscard).HasDefaultValue(true);
            entity.Property(e => e.CityName).HasMaxLength(100);
            entity.Property(e => e.CityRemark)
                .HasMaxLength(100)
                .HasDefaultValue("Nil");
            entity.Property(e => e.CityShortName).HasMaxLength(50);
            entity.Property(e => e.CityStateId).HasColumnName("CityStateID");
            entity.Property(e => e.CityTierTypeId).HasColumnName("CityTierTypeID");
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
