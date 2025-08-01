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

    public virtual DbSet<CountryMaster> CountryMasters { get; set; }
    public virtual DbSet<CurrencyMaster> CurrencyMasters { get; set; }
    public virtual DbSet<DistrictMaster> DistrictMasters { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DistrictMaster>(entity =>
        {
            entity.HasKey(e => e.DistrictId).HasName("PK__District__85FDA4A621B92E27");

            entity
                .ToTable("DistrictMaster")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("DistrictMasterHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.DistrictId).HasColumnName("DistrictID");
            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.Property(e => e.DistrictCode).HasMaxLength(10);
            entity.Property(e => e.DistrictName).HasMaxLength(100);
            entity.Property(e => e.ShortName).HasMaxLength(50);
            entity.Property(e => e.StateId).HasColumnName("StateID");
        });
         
     modelBuilder.Entity<CountryMaster>(entity =>
     {
         entity.HasKey(e => e.CountryId).HasName("PK__CountryM__10D160BF87031573");

         entity
             .ToTable("CountryMaster")
             .ToTable(tb => tb.IsTemporal(ttb =>
                 {
                     ttb.UseHistoryTable("CountryMasterHistory", "dbo");
                     ttb
                         .HasPeriodStart("SysStartTime")
                         .HasColumnName("SysStartTime");
                     ttb
                         .HasPeriodEnd("SysEndTime")
                         .HasColumnName("SysEndTime");
                 }));

         entity.Property(e => e.CountryId).HasColumnName("CountryID");
         entity.Property(e => e.CountryCode).HasMaxLength(50);
         entity.Property(e => e.CountryName).HasMaxLength(100);
         entity.Property(e => e.CountryShortName).HasMaxLength(50);

         entity.HasOne(d => d.CountryCurrency).WithMany(p => p.CountryMasters)
             .HasForeignKey(d => d.CountryCurrencyId)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("FK_CountryID_CountryCurrencyID1");
     });

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
