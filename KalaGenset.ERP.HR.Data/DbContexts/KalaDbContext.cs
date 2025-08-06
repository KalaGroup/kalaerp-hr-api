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

    public virtual DbSet<AuthoritiesDetail> AuthoritiesDetails { get; set; }

    public virtual DbSet<AuthoritiesMaster> AuthoritiesMasters { get; set; }

    public virtual DbSet<CityMaster> CityMasters { get; set; }

    public virtual DbSet<ClassOfTravelMaster> ClassOfTravelMasters { get; set; }

    public virtual DbSet<CompanyEntityTypeMaster> CompanyEntityTypeMasters { get; set; }

    public virtual DbSet<CompanyMaster> CompanyMasters { get; set; }

    public virtual DbSet<CountryMaster> CountryMasters { get; set; }

    public virtual DbSet<CurrencyMaster> CurrencyMasters { get; set; }

    public virtual DbSet<DepartmentMaster> DepartmentMasters { get; set; }

    public virtual DbSet<DesignationMaster> DesignationMasters { get; set; }

    public virtual DbSet<DistrictMaster> DistrictMasters { get; set; }

    public virtual DbSet<EmployeeTypeMaster> EmployeeTypeMasters { get; set; }

    public virtual DbSet<FacilityMaster> FacilityMasters { get; set; }

    public virtual DbSet<GradeFacilityAssignment> GradeFacilityAssignments { get; set; }

    public virtual DbSet<GradeMaster> GradeMasters { get; set; }

    public virtual DbSet<Kpadetail> Kpadetails { get; set; }

    public virtual DbSet<Kpamaster> Kpamasters { get; set; }

    public virtual DbSet<LocationMaster> LocationMasters { get; set; }

    public virtual DbSet<PetrolAllowanceMaster> PetrolAllowanceMasters { get; set; }

    public virtual DbSet<ProfitcenterMaster> ProfitcenterMasters { get; set; }

    public virtual DbSet<QualificationMaster> QualificationMasters { get; set; }

    public virtual DbSet<QualificationTypeMaster> QualificationTypeMasters { get; set; }

    public virtual DbSet<ResposibilitiesDetail> ResposibilitiesDetails { get; set; }

    public virtual DbSet<ResposibilitiesMaster> ResposibilitiesMasters { get; set; }

    public virtual DbSet<RolesDetail> RolesDetails { get; set; }

    public virtual DbSet<RolesMaster> RolesMasters { get; set; }

    public virtual DbSet<StateMaster> StateMasters { get; set; }

    public virtual DbSet<WorkStationMaster> WorkStationMasters { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=KalaDbContext");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuthoritiesDetail>(entity =>
        {
            entity.HasKey(e => e.AuthoritiesDetailsId).HasName("PK__Authorit__9F5D971FE92BA8EC");

            entity.ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("AuthoritiesDetailsHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.AuthoritiesDetailsDescription)
                .HasMaxLength(500)
                .HasDefaultValue("Nil");

            entity.HasOne(d => d.DetailsAuthorities).WithMany(p => p.AuthoritiesDetails)
                .HasForeignKey(d => d.DetailsAuthoritiesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AuthoritiesDetailsId_DetailsAuthoritiesId");
        });

        modelBuilder.Entity<AuthoritiesMaster>(entity =>
        {
            entity.HasKey(e => e.AuthoritiesId).HasName("PK__Authorit__0B0FAE9D1D5FF0B2");

            entity
                .ToTable("AuthoritiesMaster")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("AuthoritiesMasterHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.AuthoritiesAuth).HasDefaultValue(true);
            entity.Property(e => e.AuthoritiesAuthRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.AuthoritiesIsActive).HasDefaultValue(true);
            entity.Property(e => e.AuthoritiesIsDiscard).HasDefaultValue(true);
            entity.Property(e => e.AuthoritiesRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.AuthoritiesType).HasMaxLength(200);
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.AuthoritiesDesignation).WithMany(p => p.AuthoritiesMasters)
                .HasForeignKey(d => d.AuthoritiesDesignationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AuthoritiesId_AuthoritiesDesignationId");

            entity.HasOne(d => d.AuthoritiesGrade).WithMany(p => p.AuthoritiesMasters)
                .HasForeignKey(d => d.AuthoritiesGradeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AuthoritiesId_AuthoritiesGradeId");
        });

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

            entity.HasOne(d => d.CityCountry).WithMany(p => p.CityMasters)
                .HasForeignKey(d => d.CityCountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CityId_CountryId");

            entity.HasOne(d => d.CityDistrict).WithMany(p => p.CityMasters)
                .HasForeignKey(d => d.CityDistrictId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CityId_DistrictId");

            entity.HasOne(d => d.CityState).WithMany(p => p.CityMasters)
                .HasForeignKey(d => d.CityStateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CityId_StateID");
        });

        modelBuilder.Entity<ClassOfTravelMaster>(entity =>
        {
            entity.HasKey(e => e.ClassOfTravelId).HasName("PK__ClassOfT__812F85F4D3D964F3");

            entity
                .ToTable("ClassOfTravelMaster")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("ClassOfTravelMasterHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.ClassOfTravelId).HasColumnName("ClassOfTravelID");
            entity.Property(e => e.ClassOfTravelCode).HasMaxLength(20);
            entity.Property(e => e.ClassOfTravelIsActive).HasDefaultValue(true);
            entity.Property(e => e.ClassOfTravelIsAuth).HasDefaultValue(true);
            entity.Property(e => e.ClassOfTravelIsDiscard).HasDefaultValue(true);
            entity.Property(e => e.ClassOfTravelName).HasMaxLength(200);
            entity.Property(e => e.ClassOfTravelRemark)
                .HasMaxLength(200)
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DafoodAllowancePerday).HasColumnName("DAFoodAllowancePerday");

            entity.HasOne(d => d.ClassOfTravelGrade).WithMany(p => p.ClassOfTravelMasters)
                .HasForeignKey(d => d.ClassOfTravelGradeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClassOfTravelID_ClassOfTravelGradeId");
        });

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

        modelBuilder.Entity<CompanyMaster>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasName("PK__CompanyM__2D971C4CA0281D8B");

            entity
                .ToTable("CompanyMaster")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("CompanyMasterHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.AiinsightsEnabled)
                .HasDefaultValue(true)
                .HasColumnName("AIInsightsEnabled");
            entity.Property(e => e.Cin)
                .HasMaxLength(21)
                .HasColumnName("CIN");
            entity.Property(e => e.CompanyCode).HasMaxLength(20);
            entity.Property(e => e.CompanyCurrencyId)
                .HasDefaultValueSql("('INR')")
                .HasColumnName("CompanyCurrencyID");
            entity.Property(e => e.CompanyIsActive).HasDefaultValue(true);
            entity.Property(e => e.CompanyIsAuth).HasDefaultValue(true);
            entity.Property(e => e.CompanyIsDiscard).HasDefaultValue(true);
            entity.Property(e => e.CompanyMasterEntityTypeId).HasColumnName("CompanyMasterEntityTypeID");
            entity.Property(e => e.CompanyName).HasMaxLength(200);
            entity.Property(e => e.CompanyRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.CorporateAddress).HasMaxLength(500);
            entity.Property(e => e.CorporateCityId).HasColumnName("CorporateCityID");
            entity.Property(e => e.CorporateCountryId).HasColumnName("CorporateCountryID");
            entity.Property(e => e.CorporateDistrictId).HasColumnName("CorporateDistrictID");
            entity.Property(e => e.CorporatePinCode).HasMaxLength(10);
            entity.Property(e => e.CorporateStateId).HasColumnName("CorporateStateID");
            entity.Property(e => e.CostEfficiencyRating).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.EmailId)
                .HasMaxLength(100)
                .HasColumnName("EmailID");
            entity.Property(e => e.FiscalYearStart).HasDefaultValue(new DateOnly(2025, 4, 1));
            entity.Property(e => e.Gst)
                .HasMaxLength(15)
                .HasColumnName("GST");
            entity.Property(e => e.LocationAdvantageScore).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.OwnershipPercentage)
                .HasDefaultValue(100.00m)
                .HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Pan)
                .HasMaxLength(10)
                .HasColumnName("PAN");
            entity.Property(e => e.ParentCompanyId).HasColumnName("ParentCompanyID");
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.PredictiveAnalyticsLevel)
                .HasMaxLength(20)
                .HasDefaultValue("Basic");
            entity.Property(e => e.RegisteredAddress).HasMaxLength(500);
            entity.Property(e => e.RegisteredCityId).HasColumnName("RegisteredCityID");
            entity.Property(e => e.RegisteredCountryId).HasColumnName("RegisteredCountryID");
            entity.Property(e => e.RegisteredDistrictId).HasColumnName("RegisteredDistrictID");
            entity.Property(e => e.RegisteredPinCode).HasMaxLength(10);
            entity.Property(e => e.RegisteredStateId).HasColumnName("RegisteredStateID");
            entity.Property(e => e.ShortName).HasMaxLength(50);
            entity.Property(e => e.SocialMedialink).HasMaxLength(200);
            entity.Property(e => e.TalentAccessibilityScore).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Website).HasMaxLength(200);
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

        modelBuilder.Entity<DepartmentMaster>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BEDBB90F3B5");

            entity
                .ToTable("DepartmentMaster")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("DepartmentMasterHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DepartmentAuth).HasDefaultValue(true);
            entity.Property(e => e.DepartmentAuthRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.DepartmentCode).HasMaxLength(10);
            entity.Property(e => e.DepartmentIsActive).HasDefaultValue(true);
            entity.Property(e => e.DepartmentIsDiscard).HasDefaultValue(true);
            entity.Property(e => e.DepartmentName).HasMaxLength(100);
            entity.Property(e => e.DepartmentProfitcenterId).HasColumnName("DepartmentProfitcenterID");
            entity.Property(e => e.DepartmentRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.DepartmentShortName).HasMaxLength(100);
            entity.Property(e => e.DepartmentType).HasMaxLength(200);
            entity.Property(e => e.ParentDepartmentId).HasColumnName("ParentDepartmentID");

            entity.HasOne(d => d.DepartmentProfitcenter).WithMany(p => p.DepartmentMasters)
                .HasForeignKey(d => d.DepartmentProfitcenterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DepartmentId_DepartmentProfitcenterID");

            entity.HasOne(d => d.ParentDepartment).WithMany(p => p.InverseParentDepartment)
                .HasForeignKey(d => d.ParentDepartmentId)
                .HasConstraintName("FK_DepartmentId_ParentDepartmentID");
        });

        modelBuilder.Entity<DesignationMaster>(entity =>
        {
            entity.HasKey(e => e.DesignationId).HasName("PK__Designat__BABD603EC54A0619");

            entity
                .ToTable("DesignationMaster")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("DesignationHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.DesignationId).HasColumnName("DesignationID");
            entity.Property(e => e.DesignationCode).HasMaxLength(10);
            entity.Property(e => e.DesignationDescription).HasMaxLength(100);
            entity.Property(e => e.DesignationGradeId).HasColumnName("DesignationGradeID");
            entity.Property(e => e.DesignationName).HasMaxLength(100);
            entity.Property(e => e.DesignationRemark)
                .HasMaxLength(100)
                .HasDefaultValue("Nil");
            entity.Property(e => e.ExperiencedRemark).HasMaxLength(100);
            entity.Property(e => e.GradeQualificationRemark).HasMaxLength(100);
            entity.Property(e => e.RequiredSkills).HasMaxLength(100);

            entity.HasOne(d => d.DesignationGrade).WithMany(p => p.DesignationMasters)
                .HasForeignKey(d => d.DesignationGradeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DesignationId_DesignationGradeID");

            entity.HasOne(d => d.DesignationQualification).WithMany(p => p.DesignationMasters)
                .HasForeignKey(d => d.DesignationQualificationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DesignationId_DesignationQualificationId");
        });

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

            entity.HasOne(d => d.Country).WithMany(p => p.DistrictMasters)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DistrictId_CountryId");

            entity.HasOne(d => d.State).WithMany(p => p.DistrictMasters)
                .HasForeignKey(d => d.StateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DistrictId_StateId");
        });

        modelBuilder.Entity<EmployeeTypeMaster>(entity =>
        {
            entity.HasKey(e => e.EmployeeTypeId).HasName("PK__Employee__1F1B6AB4BB4FA5F6");

            entity
                .ToTable("EmployeeTypeMaster")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("EmployeeTypeHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.EmployeeTypeId).HasColumnName("EmployeeTypeID");
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.EmployeeTypeAuth).HasDefaultValue(true);
            entity.Property(e => e.EmployeeTypeAuthRemark)
                .HasMaxLength(100)
                .HasDefaultValue("Nil");
            entity.Property(e => e.EmployeeTypeCode).HasMaxLength(10);
            entity.Property(e => e.EmployeeTypeDescription).HasMaxLength(100);
            entity.Property(e => e.EmployeeTypeIsActive).HasDefaultValue(true);
            entity.Property(e => e.EmployeeTypeIsDiscard).HasDefaultValue(true);
            entity.Property(e => e.EmployeeTypeName).HasMaxLength(100);
            entity.Property(e => e.EmployeeTypeRemark)
                .HasMaxLength(100)
                .HasDefaultValue("Nil");
        });

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

            entity.HasOne(d => d.AssignmentGrade).WithMany(p => p.GradeFacilityAssignments)
                .HasForeignKey(d => d.AssignmentGradeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GradeFacilityAssignmentId_AssignmentGradeId");
        });

        modelBuilder.Entity<GradeMaster>(entity =>
        {
            entity.HasKey(e => e.GradeId).HasName("PK__GradeMas__54F87A37C7529CB5");

            entity
                .ToTable("GradeMaster")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("GradeHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.GradeId).HasColumnName("GradeID");
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.GradeAuth).HasDefaultValue(true);
            entity.Property(e => e.GradeCode).HasMaxLength(10);
            entity.Property(e => e.GradeDescription).HasMaxLength(100);
            entity.Property(e => e.GradeIsActive).HasDefaultValue(true);
            entity.Property(e => e.GradeIsDiscard).HasDefaultValue(true);
            entity.Property(e => e.GradeLevel).HasMaxLength(100);
            entity.Property(e => e.GradeName).HasMaxLength(100);
            entity.Property(e => e.GradeRemark)
                .HasMaxLength(100)
                .HasDefaultValue("Nil");
            entity.Property(e => e.MaxSalCtc).HasColumnName("MaxSalCTC");
            entity.Property(e => e.MinSalCtc).HasColumnName("MinSalCTC");

            entity.HasOne(d => d.GradeCurrency).WithMany(p => p.GradeMasters)
                .HasForeignKey(d => d.GradeCurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GradeId_GradeCurrencyId");
        });

        modelBuilder.Entity<Kpadetail>(entity =>
        {
            entity.HasKey(e => e.KpadetailsId).HasName("PK__KPADetai__FEFE184CC2C552C9");

            entity
                .ToTable("KPADetails")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("KPADetailsHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.KpadetailsId).HasColumnName("KPADetailsId");
            entity.Property(e => e.DetailsKpaid).HasColumnName("DetailsKPAId");
            entity.Property(e => e.KpadetailsDescription)
                .HasMaxLength(500)
                .HasDefaultValue("Nil")
                .HasColumnName("KPADetailsDescription");

            entity.HasOne(d => d.DetailsKpa).WithMany(p => p.Kpadetails)
                .HasForeignKey(d => d.DetailsKpaid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KPADetailsId_DetailsKPAId");
        });

        modelBuilder.Entity<Kpamaster>(entity =>
        {
            entity.HasKey(e => e.Kpaid).HasName("PK__KPAMaste__6C14894260566ED2");

            entity
                .ToTable("KPAMaster")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("KPAMasterHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.Kpaid).HasColumnName("KPAId");
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Kpaauth)
                .HasDefaultValue(true)
                .HasColumnName("KPAAuth");
            entity.Property(e => e.KpaauthRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil")
                .HasColumnName("KPAAuthRemark");
            entity.Property(e => e.KpadesignationId).HasColumnName("KPADesignationId");
            entity.Property(e => e.KpagradeId).HasColumnName("KPAGradeId");
            entity.Property(e => e.KpaisActive)
                .HasDefaultValue(true)
                .HasColumnName("KPAIsActive");
            entity.Property(e => e.KpaisDiscard)
                .HasDefaultValue(true)
                .HasColumnName("KPAIsDiscard");
            entity.Property(e => e.Kparemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil")
                .HasColumnName("KPARemark");
            entity.Property(e => e.Kpatype)
                .HasMaxLength(200)
                .HasColumnName("KPAType");

            entity.HasOne(d => d.Kpadesignation).WithMany(p => p.Kpamasters)
                .HasForeignKey(d => d.KpadesignationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KPAId_KPADesignationId");

            entity.HasOne(d => d.Kpagrade).WithMany(p => p.Kpamasters)
                .HasForeignKey(d => d.KpagradeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KPAId_KPAGradeId");
        });

        modelBuilder.Entity<LocationMaster>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__Location__E7FEA497C008A149");

            entity
                .ToTable("LocationMaster")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("LocationMasterHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.LocationAuth).HasDefaultValue(true);
            entity.Property(e => e.LocationAuthRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.LocationCode).HasMaxLength(10);
            entity.Property(e => e.LocationIsActive).HasDefaultValue(true);
            entity.Property(e => e.LocationIsDiscard).HasDefaultValue(true);
            entity.Property(e => e.LocationName).HasMaxLength(100);
            entity.Property(e => e.LocationRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.LocationType).HasMaxLength(200);
            entity.Property(e => e.ProfitcenterLocationId).HasColumnName("ProfitcenterLocationID");

            entity.HasOne(d => d.ProfitcenterLocation).WithMany(p => p.LocationMasters)
                .HasForeignKey(d => d.ProfitcenterLocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LocationId_ProfitcenterLocationID");
        });

        modelBuilder.Entity<PetrolAllowanceMaster>(entity =>
        {
            entity.HasKey(e => e.PetrolAllowanceId).HasName("PK__PetrolAl__D4F6B2ED171BFBD7");

            entity
                .ToTable("PetrolAllowanceMaster")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("PetrolAllowanceMasterHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.FourWheelerPerKm)
                .HasMaxLength(200)
                .HasColumnName("FourWheelerPerKM");
            entity.Property(e => e.PetrolAllowanceAuthRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.PetrolAllowanceIsActive).HasDefaultValue(true);
            entity.Property(e => e.PetrolAllowanceIsAuth).HasDefaultValue(true);
            entity.Property(e => e.PetrolAllowanceIsDiscard).HasDefaultValue(true);
            entity.Property(e => e.PetrolAllowanceRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.TwoWheelerPerKm)
                .HasMaxLength(20)
                .HasColumnName("TwoWheelerPerKM");
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

            entity.HasOne(d => d.ProfitCenterCompany).WithMany(p => p.ProfitcenterMasters)
                .HasForeignKey(d => d.ProfitCenterCompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProfitCenterId_ProfitCenterCompanyId");
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

            entity.HasOne(d => d.MasterQualificationType).WithMany(p => p.QualificationMasters)
                .HasForeignKey(d => d.MasterQualificationTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_QualificationId_MasterQualificationTypeID");
        });

        modelBuilder.Entity<QualificationTypeMaster>(entity =>
        {
            entity.HasKey(e => e.QualificationTypeId).HasName("PK__Qualific__6817DF50F1A4EA14");

            entity
                .ToTable("QualificationTypeMaster")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("QualificationTypeHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.QualificationTypeId).HasColumnName("QualificationTypeID");
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.QualificationTypeAuth).HasDefaultValue(true);
            entity.Property(e => e.QualificationTypeCode).HasMaxLength(10);
            entity.Property(e => e.QualificationTypeIsActive).HasDefaultValue(true);
            entity.Property(e => e.QualificationTypeIsDiscard).HasDefaultValue(true);
            entity.Property(e => e.QualificationTypeName).HasMaxLength(100);
            entity.Property(e => e.QualificationTypeRemark)
                .HasMaxLength(100)
                .HasDefaultValue("Nil");
        });

        modelBuilder.Entity<ResposibilitiesDetail>(entity =>
        {
            entity.HasKey(e => e.ResposibilitiesDetailsId).HasName("PK__Resposib__0D28C38AA1BA7148");

            entity.ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("ResposibilitiesDetailsHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.ResposibilitiesDetailsDescription)
                .HasMaxLength(500)
                .HasDefaultValue("Nil");
        });

        modelBuilder.Entity<ResposibilitiesMaster>(entity =>
        {
            entity.HasKey(e => e.ResposibilitiesId).HasName("PK__Resposib__42119AAE21B3135F");

            entity
                .ToTable("ResposibilitiesMaster")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("ResposibilitiesMasterHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ResposibilitiesAuth).HasDefaultValue(true);
            entity.Property(e => e.ResposibilitiesAuthRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.ResposibilitiesIsActive).HasDefaultValue(true);
            entity.Property(e => e.ResposibilitiesIsDiscard).HasDefaultValue(true);
            entity.Property(e => e.ResposibilitiesRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.ResposibilitiesType).HasMaxLength(200);

            entity.HasOne(d => d.ResposibilitiesDesignation).WithMany(p => p.ResposibilitiesMasters)
                .HasForeignKey(d => d.ResposibilitiesDesignationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ResposibilitiesId_ResposibilitiesDesignationId");

            entity.HasOne(d => d.ResposibilitiesGrade).WithMany(p => p.ResposibilitiesMasters)
                .HasForeignKey(d => d.ResposibilitiesGradeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ResposibilitiesId_ResposibilitiesGradeId");
        });

        modelBuilder.Entity<RolesDetail>(entity =>
        {
            entity.HasKey(e => e.RolesDetailsId).HasName("PK__RolesDet__A8CC7A1E6B1EDEFF");

            entity.ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("RolesDetailsHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.RolesDetailsDescription)
                .HasMaxLength(500)
                .HasDefaultValue("Nil");

            entity.HasOne(d => d.DetailsRoles).WithMany(p => p.RolesDetails)
                .HasForeignKey(d => d.DetailsRolesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RolesDetailsId_DetailsRolesId");
        });

        modelBuilder.Entity<RolesMaster>(entity =>
        {
            entity.HasKey(e => e.RolesId).HasName("PK__RolesMas__C4B2784043869C8B");

            entity
                .ToTable("RolesMaster")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("RolesMasterHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.RolesAuth).HasDefaultValue(true);
            entity.Property(e => e.RolesAuthRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.RolesIsActive).HasDefaultValue(true);
            entity.Property(e => e.RolesIsDiscard).HasDefaultValue(true);
            entity.Property(e => e.RolesRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.RolesType).HasMaxLength(200);

            entity.HasOne(d => d.RolesDesignation).WithMany(p => p.RolesMasters)
                .HasForeignKey(d => d.RolesDesignationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RolesId_RolesDesignationId");

            entity.HasOne(d => d.RolesGrade).WithMany(p => p.RolesMasters)
                .HasForeignKey(d => d.RolesGradeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RolesId_RolesGradeId");
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

            entity.HasOne(d => d.Country).WithMany(p => p.StateMasters)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StateId_CountryId");
        });

        modelBuilder.Entity<WorkStationMaster>(entity =>
        {
            entity.HasKey(e => e.WorkStationId).HasName("PK__WorkStat__63488D9D62848E32");

            entity
                .ToTable("WorkStationMaster")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("WorkStationMasterHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.WorkStationAuth).HasDefaultValue(true);
            entity.Property(e => e.WorkStationAuthRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.WorkStationCode).HasMaxLength(10);
            entity.Property(e => e.WorkStationIsActive).HasDefaultValue(true);
            entity.Property(e => e.WorkStationIsDiscard).HasDefaultValue(true);
            entity.Property(e => e.WorkStationName).HasMaxLength(100);
            entity.Property(e => e.WorkStationProfitcenterId).HasColumnName("WorkStationProfitcenterID");
            entity.Property(e => e.WorkStationRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.WorkStationShortName).HasMaxLength(100);
            entity.Property(e => e.WorkStationType).HasMaxLength(200);

            entity.HasOne(d => d.WorkStationProfitcenter).WithMany(p => p.WorkStationMasters)
                .HasForeignKey(d => d.WorkStationProfitcenterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkStationId_WorkStationProfitcenterID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
