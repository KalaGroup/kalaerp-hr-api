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

    public virtual DbSet<ActivityDetail> ActivityDetails { get; set; }

    public virtual DbSet<ActivityMaster> ActivityMasters { get; set; }

    public virtual DbSet<AuthoritiesDetail> AuthoritiesDetails { get; set; }

    public virtual DbSet<AuthoritiesMaster> AuthoritiesMasters { get; set; }

    public virtual DbSet<CityMaster> CityMasters { get; set; }

    public virtual DbSet<ClassOfTravelMaster> ClassOfTravelMasters { get; set; }

    public virtual DbSet<CompanyEntityTypeMaster> CompanyEntityTypeMasters { get; set; }

    public virtual DbSet<CompanyMaster> CompanyMasters { get; set; }

    public virtual DbSet<CountryMaster> CountryMasters { get; set; }

    public virtual DbSet<CtcstructureMaster> CtcstructureMasters { get; set; }

    public virtual DbSet<CurrencyMaster> CurrencyMasters { get; set; }

    public virtual DbSet<DailyAttendance> DailyAttendances { get; set; }

    public virtual DbSet<DepartmentBudget> DepartmentBudgets { get; set; }

    public virtual DbSet<DepartmentMaster> DepartmentMasters { get; set; }

    public virtual DbSet<DesignationMaster> DesignationMasters { get; set; }

    public virtual DbSet<DistrictMaster> DistrictMasters { get; set; }

    public virtual DbSet<DivisionMaster> DivisionMasters { get; set; }

    public virtual DbSet<EmployeeLeaveBalance> EmployeeLeaveBalances { get; set; }

    public virtual DbSet<EmployeeMasterAddressDetail> EmployeeMasterAddressDetails { get; set; }

    public virtual DbSet<EmployeeMasterFamilyDetail> EmployeeMasterFamilyDetails { get; set; }

    public virtual DbSet<EmployeeMasterPersonalDetail> EmployeeMasterPersonalDetails { get; set; }

    public virtual DbSet<EmployeeMasterUpdationForMaster> EmployeeMasterUpdationForMasters { get; set; }

    public virtual DbSet<EmployeeTypeMaster> EmployeeTypeMasters { get; set; }

    public virtual DbSet<FacilityMaster> FacilityMasters { get; set; }

    public virtual DbSet<GradeFacilityAssignment> GradeFacilityAssignments { get; set; }

    public virtual DbSet<GradeMaster> GradeMasters { get; set; }

    public virtual DbSet<HolidayMaster> HolidayMasters { get; set; }

    public virtual DbSet<HrauthorisationLog> HrauthorisationLogs { get; set; }

    public virtual DbSet<KalaErppageDetail> KalaErppageDetails { get; set; }

    public virtual DbSet<Kpadetail> Kpadetails { get; set; }

    public virtual DbSet<Kpamaster> Kpamasters { get; set; }

    public virtual DbSet<LeaveApplication> LeaveApplications { get; set; }

    public virtual DbSet<LeaveTypeMaster> LeaveTypeMasters { get; set; }

    public virtual DbSet<LocationMaster> LocationMasters { get; set; }

    public virtual DbSet<OfferLetter> OfferLetters { get; set; }

    public virtual DbSet<OfferLetterCtc> OfferLetterCtcs { get; set; }

    public virtual DbSet<PetrolAllowanceMaster> PetrolAllowanceMasters { get; set; }

    public virtual DbSet<PositionMaster> PositionMasters { get; set; }

    public virtual DbSet<PositionMasterQualificationDetail> PositionMasterQualificationDetails { get; set; }

    public virtual DbSet<ProfitcenterBudget> ProfitcenterBudgets { get; set; }

    public virtual DbSet<ProfitcenterMaster> ProfitcenterMasters { get; set; }

    public virtual DbSet<QualificationMaster> QualificationMasters { get; set; }

    public virtual DbSet<QualificationTypeMaster> QualificationTypeMasters { get; set; }

    public virtual DbSet<RecruitmentAttributeMaster> RecruitmentAttributeMasters { get; set; }

    public virtual DbSet<RecruitmentDetail> RecruitmentDetails { get; set; }

    public virtual DbSet<RecruitmentMaster> RecruitmentMasters { get; set; }

    public virtual DbSet<RecruitmentReferenceMaster> RecruitmentReferenceMasters { get; set; }

    public virtual DbSet<RecruitmentStageStatusMaster> RecruitmentStageStatusMasters { get; set; }

    public virtual DbSet<ResponsibilitiesDetail> ResponsibilitiesDetails { get; set; }

    public virtual DbSet<ResponsibilitiesMaster> ResponsibilitiesMasters { get; set; }

    public virtual DbSet<RolesDetail> RolesDetails { get; set; }

    public virtual DbSet<RolesMaster> RolesMasters { get; set; }

    public virtual DbSet<ShiftMaster> ShiftMasters { get; set; }

    public virtual DbSet<StateMaster> StateMasters { get; set; }

    public virtual DbSet<UserLogin> UserLogins { get; set; }

    public virtual DbSet<WorkStationMaster> WorkStationMasters { get; set; }

    public virtual DbSet<WorkstationBudget> WorkstationBudgets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=KalaDbContext");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActivityDetail>(entity =>
        {
            entity.HasKey(e => e.ActivityDetailsId).HasName("PK__Activity__FE7AB5A2821758CF");

            entity.ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("ActivityDetailsHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.ActivityDetailsDescription)
                .HasMaxLength(500)
                .HasDefaultValue("Nil");

            entity.HasOne(d => d.DetailsActivity).WithMany(p => p.ActivityDetails)
                .HasForeignKey(d => d.DetailsActivityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ActivityDetailsId_DetailsActivityId");
        });

        modelBuilder.Entity<ActivityMaster>(entity =>
        {
            entity.HasKey(e => e.ActivityId).HasName("PK__Activity__45F4A79190DD534C");

            entity
                .ToTable("ActivityMaster")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("ActivityMasterHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.ActivityAuth).HasDefaultValue(true);
            entity.Property(e => e.ActivityAuthRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.ActivityIsActive).HasDefaultValue(true);
            entity.Property(e => e.ActivityIsDiscard).HasDefaultValue(true);
            entity.Property(e => e.ActivityRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.ActivityDesignation).WithMany(p => p.ActivityMasters)
                .HasForeignKey(d => d.ActivityDesignationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ActivityId_ActivityDesignationId");

            entity.HasOne(d => d.ActivityDivision).WithMany(p => p.ActivityMasters)
                .HasForeignKey(d => d.ActivityDivisionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ActivityId_ActivityDivisionId");

            entity.HasOne(d => d.ActivityGrade).WithMany(p => p.ActivityMasters)
                .HasForeignKey(d => d.ActivityGradeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ActivityId_ActivityGradeId");
        });

        modelBuilder.Entity<AuthoritiesDetail>(entity =>
        {
            entity.HasKey(e => e.AuthoritiesDetailsId).HasName("PK__Authorit__9F5D971FA0956502");

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
            entity.HasKey(e => e.AuthoritiesId).HasName("PK__Authorit__0B0FAE9D8F22946B");

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
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.AuthoritiesDesignation).WithMany(p => p.AuthoritiesMasters)
                .HasForeignKey(d => d.AuthoritiesDesignationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AuthoritiesId_AuthoritiesDesignationId");

            entity.HasOne(d => d.AuthoritiesDivision).WithMany(p => p.AuthoritiesMasters)
                .HasForeignKey(d => d.AuthoritiesDivisionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AuthoritiesId_AuthoritiesDivisionId");

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
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");

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
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");

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
            entity.Property(e => e.UpdatedBy).HasDefaultValueSql("('1')");
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");
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
            entity.Property(e => e.CompanyRemark2).HasMaxLength(200);
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
            entity.Property(e => e.UpdatedBy).HasDefaultValue(1);
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Website).HasMaxLength(200);

            entity.HasOne(d => d.CompanyCurrency).WithMany(p => p.CompanyMasters)
                .HasForeignKey(d => d.CompanyCurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CompanyID_CompanyCurrencyID");

            entity.HasOne(d => d.CompanyMasterEntityType).WithMany(p => p.CompanyMasters)
                .HasForeignKey(d => d.CompanyMasterEntityTypeId)
                .HasConstraintName("FK_CompanyMaster_CompanyMasterEntityTypeID");

            entity.HasOne(d => d.CorporateCity).WithMany(p => p.CompanyMasterCorporateCities)
                .HasForeignKey(d => d.CorporateCityId)
                .HasConstraintName("FK_CompanyID_CorporateCityID");

            entity.HasOne(d => d.CorporateCountry).WithMany(p => p.CompanyMasterCorporateCountries)
                .HasForeignKey(d => d.CorporateCountryId)
                .HasConstraintName("FK_CompanyId_CorporateCountryID");

            entity.HasOne(d => d.CorporateDistrict).WithMany(p => p.CompanyMasterCorporateDistricts)
                .HasForeignKey(d => d.CorporateDistrictId)
                .HasConstraintName("FK_CompanyID_CorporateDistrictID");

            entity.HasOne(d => d.CorporateState).WithMany(p => p.CompanyMasterCorporateStates)
                .HasForeignKey(d => d.CorporateStateId)
                .HasConstraintName("FK_CompanyID_CorporateStateID");

            entity.HasOne(d => d.ParentCompany).WithMany(p => p.InverseParentCompany)
                .HasForeignKey(d => d.ParentCompanyId)
                .HasConstraintName("FK_CompanyId_ParentCompanyID");

            entity.HasOne(d => d.RegisteredCity).WithMany(p => p.CompanyMasterRegisteredCities)
                .HasForeignKey(d => d.RegisteredCityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CompanyID_RegisteredCityID");

            entity.HasOne(d => d.RegisteredCountry).WithMany(p => p.CompanyMasterRegisteredCountries)
                .HasForeignKey(d => d.RegisteredCountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CompanyMaster_RegisteredCountryID");

            entity.HasOne(d => d.RegisteredDistrict).WithMany(p => p.CompanyMasterRegisteredDistricts)
                .HasForeignKey(d => d.RegisteredDistrictId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CompanyID_RegisteredDistrictID");

            entity.HasOne(d => d.RegisteredState).WithMany(p => p.CompanyMasterRegisteredStates)
                .HasForeignKey(d => d.RegisteredStateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CompanyID_RegisteredStateID");
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
            entity.Property(e => e.UpdatedBy).HasDefaultValue(1);
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.CountryCurrency).WithMany(p => p.CountryMasters)
                .HasForeignKey(d => d.CountryCurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CountryID_CountryCurrencyID1");
        });

        modelBuilder.Entity<CtcstructureMaster>(entity =>
        {
            entity.HasKey(e => e.CtcstructureId).HasName("PK__CTCStruc__4BBE2399DE46CA8F");

            entity
                .ToTable("CTCStructureMaster")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("CTCStructureMasterHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.CtcstructureId).HasColumnName("CTCStructureId");
            entity.Property(e => e.CtcmasterBasic).HasColumnName("CTCMasterBasic");
            entity.Property(e => e.CtcmasterBonus).HasColumnName("CTCMasterBonus");
            entity.Property(e => e.CtcmasterCarAllowance).HasColumnName("CTCMasterCarAllowance");
            entity.Property(e => e.CtcmasterCityCompensatoryAlowance).HasColumnName("CTCMasterCityCompensatoryAlowance");
            entity.Property(e => e.CtcmasterConvAllowance).HasColumnName("CTCMasterConvAllowance");
            entity.Property(e => e.CtcmasterDa).HasColumnName("CTCMasterDA");
            entity.Property(e => e.CtcmasterDriverAllowance).HasColumnName("CTCMasterDriverAllowance");
            entity.Property(e => e.CtcmasterEsic).HasColumnName("CTCMasterEsic");
            entity.Property(e => e.CtcmasterFuelAllowance).HasColumnName("CTCMasterFuelAllowance");
            entity.Property(e => e.CtcmasterGradeId).HasColumnName("CTCMasterGradeId");
            entity.Property(e => e.CtcmasterGraduity).HasColumnName("CTCMasterGraduity");
            entity.Property(e => e.CtcmasterGross).HasColumnName("CTCMasterGross");
            entity.Property(e => e.CtcmasterHra).HasColumnName("CTCMasterHRA");
            entity.Property(e => e.CtcmasterLeaveTravelAllowance).HasColumnName("CTCMasterLeaveTravelAllowance");
            entity.Property(e => e.CtcmasterMedicalInsurance).HasColumnName("CTCMasterMedicalInsurance");
            entity.Property(e => e.CtcmasterMiscAllowance).HasColumnName("CTCMasterMisc.Allowance");
            entity.Property(e => e.CtcmasterMlwf).HasColumnName("CTCMasterMLWF");
            entity.Property(e => e.CtcmasterPerformanceKpa).HasColumnName("CTCMasterPerformanceKPA");
            entity.Property(e => e.CtcmasterPfemployee).HasColumnName("CTCMasterPFEmployee");
            entity.Property(e => e.CtcmasterPfemployer).HasColumnName("CTCMasterPFEmployer");
            entity.Property(e => e.CtcmasterPt).HasColumnName("CTCMasterPT");

            entity.HasOne(d => d.CtcmasterGrade).WithMany(p => p.CtcstructureMasters)
                .HasForeignKey(d => d.CtcmasterGradeId)
                .HasConstraintName("FK_CTCStructuretId_CTCMasterGradeID");
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
            entity.Property(e => e.UpdatedBy).HasDefaultValue(1);
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<DailyAttendance>(entity =>
        {
            entity.HasKey(e => e.AttendanceId).HasName("PK__DailyAtt__8B69261CA8D3BA4A");

            entity
                .ToTable("DailyAttendance")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("DailyAttendanceHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.AttendanceCompanyId).HasColumnName("AttendanceCompanyID");
            entity.Property(e => e.AttendanceEmployeeId).HasColumnName("AttendanceEmployeeID");
            entity.Property(e => e.AttendanceInTimeAuthRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.AttendanceIsActive).HasDefaultValue(true);
            entity.Property(e => e.AttendanceIsDiscard).HasDefaultValue(true);
            entity.Property(e => e.AttendanceOutTimeAuthRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.AttendanceRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.AttendanceStatus).HasMaxLength(10);
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.AttendanceCompany).WithMany(p => p.DailyAttendances)
                .HasForeignKey(d => d.AttendanceCompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AttendanceId_AttendanceCompanyID");

            entity.HasOne(d => d.AttendanceEmployee).WithMany(p => p.DailyAttendances)
                .HasForeignKey(d => d.AttendanceEmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AttendanceId_AttendanceEmployeeID");

            entity.HasOne(d => d.AttendanceShift).WithMany(p => p.DailyAttendances)
                .HasForeignKey(d => d.AttendanceShiftId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AttendanceId_AttendanceShiftId");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.DailyAttendanceCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AttendanceId_CreatedBy");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.DailyAttendanceUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AttendanceId_UpdatedBy");
        });

        modelBuilder.Entity<DepartmentBudget>(entity =>
        {
            entity.HasKey(e => e.DepartmentBudgetId).HasName("PK__Departme__7078F333B1DFEABF");

            entity
                .ToTable("DepartmentBudget")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("DepartmentBudgetHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DepartmentBudgetAuth).HasDefaultValue(true);
            entity.Property(e => e.DepartmentBudgetAuthRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.DepartmentBudgetHeadId).HasColumnName("DepartmentBudgetHeadID");
            entity.Property(e => e.DepartmentBudgetIsActive).HasDefaultValue(true);
            entity.Property(e => e.DepartmentBudgetIsDiscard).HasDefaultValue(true);
            entity.Property(e => e.DepartmentBudgetRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.DepartmentFy)
                .HasMaxLength(20)
                .HasColumnName("DepartmentFY");
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.DepartmentBudgetDepartment).WithMany(p => p.DepartmentBudgets)
                .HasForeignKey(d => d.DepartmentBudgetDepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DepartmentBudgetId_DepartmentBudgetDepartmentId");

            entity.HasOne(d => d.DepartmentBudgetHead).WithMany(p => p.DepartmentBudgets)
                .HasForeignKey(d => d.DepartmentBudgetHeadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DepartmentBudgetId_DepartmentBudgetHeadID");
        });

        modelBuilder.Entity<DepartmentMaster>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BED98BCA5E2");

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
            entity.Property(e => e.DepartmentDivisionId).HasColumnName("DepartmentDivisionID");
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
            entity.Property(e => e.UpdatedBy).HasDefaultValue(1);
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.DepartmentDivision).WithMany(p => p.DepartmentMasters)
                .HasForeignKey(d => d.DepartmentDivisionId)
                .HasConstraintName("FK_DepartmentId_DepartmentDivisionID");

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
            entity.Property(e => e.DistrictMasterAuth).HasDefaultValue(true);
            entity.Property(e => e.DistrictMasterAuthRemark)
                .HasMaxLength(500)
                .HasDefaultValue("Nil");
            entity.Property(e => e.DistrictMasterRemark)
                .HasMaxLength(500)
                .HasDefaultValue("Nil");
            entity.Property(e => e.DistrictName).HasMaxLength(100);
            entity.Property(e => e.ShortName).HasMaxLength(50);
            entity.Property(e => e.StateId).HasColumnName("StateID");
            entity.Property(e => e.UpdatedBy).HasDefaultValue(1);
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Country).WithMany(p => p.DistrictMasters)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DistrictId_CountryId");

            entity.HasOne(d => d.State).WithMany(p => p.DistrictMasters)
                .HasForeignKey(d => d.StateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DistrictId_StateId");
        });

        modelBuilder.Entity<DivisionMaster>(entity =>
        {
            entity.HasKey(e => e.DivisionId).HasName("PK__Division__20EFC6A89A11F1C4");

            entity
                .ToTable("DivisionMaster")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("DivisionMasterHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.DivisionAuthRemark).HasMaxLength(200);
            entity.Property(e => e.DivisionCode).HasMaxLength(10);
            entity.Property(e => e.DivisionMailId).HasMaxLength(200);
            entity.Property(e => e.DivisionName).HasMaxLength(100);
            entity.Property(e => e.DivisionRemark).HasMaxLength(200);
            entity.Property(e => e.DivisionShortName).HasMaxLength(100);
            entity.Property(e => e.UpdatedBy).HasDefaultValue(1);
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<EmployeeLeaveBalance>(entity =>
        {
            entity.HasKey(e => e.LeaveBalancesId).HasName("PK__Employee__12E9A31476882650");

            entity.ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("EmployeeLeaveBalancesHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.LeaveBalancesId).HasColumnName("LeaveBalancesID");
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.LeaveBalancesAuth).HasDefaultValue(true);
            entity.Property(e => e.LeaveBalancesAuthRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.LeaveBalancesIsActive).HasDefaultValue(true);
            entity.Property(e => e.LeaveBalancesIsDiscard).HasDefaultValue(true);
            entity.Property(e => e.LeaveBalancesRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.EmployeeLeaveBalanceCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LeaveBalancesId_CreatedBy");

            entity.HasOne(d => d.LeaveBalancesEmployee).WithMany(p => p.EmployeeLeaveBalances)
                .HasForeignKey(d => d.LeaveBalancesEmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LeaveBalancesId_LeaveBalancesEmployeeId");

            entity.HasOne(d => d.LeaveBalancesType).WithMany(p => p.EmployeeLeaveBalances)
                .HasForeignKey(d => d.LeaveBalancesTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LeaveBalancesId_LeaveBalancesTypeId");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.EmployeeLeaveBalanceUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LeaveBalancesId_UpdatedBy");
        });

        modelBuilder.Entity<EmployeeMasterAddressDetail>(entity =>
        {
            entity.HasKey(e => e.EmployeeMasterAddressDetailsId).HasName("PK__Employee__5FDB10C89241C603");

            entity.ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("EmployeeMasterAddressDetailsHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.AddressDetailsEmployeeMasterAuthRemark)
                .HasMaxLength(500)
                .HasDefaultValue("Nil");
            entity.Property(e => e.AddressDetailsEmployeeMasterPermanantAdress).HasMaxLength(500);
            entity.Property(e => e.AddressDetailsEmployeeMasterPresentAdress).HasMaxLength(500);
            entity.Property(e => e.UpdatedBy).HasDefaultValue(1);
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.AddressDetailsEmployeeMaster).WithMany(p => p.EmployeeMasterAddressDetails)
                .HasForeignKey(d => d.AddressDetailsEmployeeMasterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeMasterAddressDetailsId_AddressDetailsEmployeeMasterId");

            entity.HasOne(d => d.AddressDetailsEmployeeMasterPermanantCity).WithMany(p => p.EmployeeMasterAddressDetailAddressDetailsEmployeeMasterPermanantCities)
                .HasForeignKey(d => d.AddressDetailsEmployeeMasterPermanantCityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeMasterAddressDetailsId_AddressDetailsEmployeeMasterPermanantCityId");

            entity.HasOne(d => d.AddressDetailsEmployeeMasterPermanantCountry).WithMany(p => p.EmployeeMasterAddressDetailAddressDetailsEmployeeMasterPermanantCountries)
                .HasForeignKey(d => d.AddressDetailsEmployeeMasterPermanantCountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeMasterAddressDetailsId_AddressDetailsEmployeeMasterPermanantCountryId");

            entity.HasOne(d => d.AddressDetailsEmployeeMasterPermanantState).WithMany(p => p.EmployeeMasterAddressDetailAddressDetailsEmployeeMasterPermanantStates)
                .HasForeignKey(d => d.AddressDetailsEmployeeMasterPermanantStateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeMasterAddressDetailsId_AddressDetailsEmployeeMasterPermanantStateId");

            entity.HasOne(d => d.AddressDetailsEmployeeMasterPresentCityt).WithMany(p => p.EmployeeMasterAddressDetailAddressDetailsEmployeeMasterPresentCityts)
                .HasForeignKey(d => d.AddressDetailsEmployeeMasterPresentCitytId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeMasterAddressDetailsId_AddressDetailsEmployeeMasterPresentCitytId");

            entity.HasOne(d => d.AddressDetailsEmployeeMasterPresentCountry).WithMany(p => p.EmployeeMasterAddressDetailAddressDetailsEmployeeMasterPresentCountries)
                .HasForeignKey(d => d.AddressDetailsEmployeeMasterPresentCountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeMasterAddressDetailsId_AddressDetailsEmployeeMasterPresentCountryId");

            entity.HasOne(d => d.AddressDetailsEmployeeMasterPresentDistrict).WithMany(p => p.EmployeeMasterAddressDetails)
                .HasForeignKey(d => d.AddressDetailsEmployeeMasterPresentDistrictId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeMasterAddressDetailsId_AddressDetailsEmployeeMasterPermanantDistrictId");

            entity.HasOne(d => d.AddressDetailsEmployeeMasterPresentState).WithMany(p => p.EmployeeMasterAddressDetailAddressDetailsEmployeeMasterPresentStates)
                .HasForeignKey(d => d.AddressDetailsEmployeeMasterPresentStateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeMasterAddressDetailsId_AddressDetailsEmployeeMasterPresentStateId");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.EmployeeMasterAddressDetails)
                .HasForeignKey(d => d.UpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeMasterAddressDetailsId_UpdatedBy");
        });

        modelBuilder.Entity<EmployeeMasterFamilyDetail>(entity =>
        {
            entity.HasKey(e => e.EmployeeMasterFamilyDetailsId).HasName("PK__Employee__AD5C9C74281848AF");

            entity.ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("EmployeeMasterFamilyDetailsHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.FamilyDetailsEmployeeMasterAuthRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.FamilyDetailsEmployeeMasterFatherHusbandName).HasMaxLength(10);
            entity.Property(e => e.FamilyDetailsEmployeeMasterMartialStatus).HasMaxLength(20);
            entity.Property(e => e.FamilyDetailsEmployeeMasterMotherName).HasMaxLength(200);
            entity.Property(e => e.FamilyDetailsEmployeeMasterRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.FamilyDetailsEmployeeMasterSpouseAadharNumber).HasMaxLength(200);
            entity.Property(e => e.FamilyDetailsEmployeeMasterSpouseAadharNumberAttachment).HasMaxLength(500);
            entity.Property(e => e.FamilyDetailsEmployeeMasterSpouseName).HasMaxLength(200);
            entity.Property(e => e.UpdatedBy).HasDefaultValue(1);
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.FamilyDetailsEmployeeMaster).WithMany(p => p.EmployeeMasterFamilyDetails)
                .HasForeignKey(d => d.FamilyDetailsEmployeeMasterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeMasterFamilyDetailsId_FamilyDetailsEmployeeMasterId");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.EmployeeMasterFamilyDetails)
                .HasForeignKey(d => d.UpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeMasterFamilyDetailsId_UpdatedBy");
        });

        modelBuilder.Entity<EmployeeMasterPersonalDetail>(entity =>
        {
            entity.HasKey(e => e.EmployeeMasterId).HasName("PK__Employee__EE32E139BB7BFF48");

            entity.ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("EmployeeMasterPersonalDetailsHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.EmployeeMasterAuth).HasDefaultValue(true);
            entity.Property(e => e.EmployeeMasterAuthRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.EmployeeMasterBloodGroup).HasMaxLength(10);
            entity.Property(e => e.EmployeeMasterCode).HasMaxLength(10);
            entity.Property(e => e.EmployeeMasterFirstName).HasMaxLength(100);
            entity.Property(e => e.EmployeeMasterFullName).HasMaxLength(100);
            entity.Property(e => e.EmployeeMasterGender).HasMaxLength(10);
            entity.Property(e => e.EmployeeMasterIsActive).HasDefaultValue(true);
            entity.Property(e => e.EmployeeMasterIsDiscard).HasDefaultValue(true);
            entity.Property(e => e.EmployeeMasterLastName).HasMaxLength(100);
            entity.Property(e => e.EmployeeMasterMiddleName).HasMaxLength(100);
            entity.Property(e => e.EmployeeMasterPhotoAttachment).HasMaxLength(500);
            entity.Property(e => e.EmployeeMasterReligion).HasMaxLength(100);
            entity.Property(e => e.EmployeeMasterReligionCategory).HasMaxLength(100);
            entity.Property(e => e.EmployeeMasterRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.UpdatedBy).HasDefaultValue(1);
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.EmployeeMasterNationalityCountry).WithMany(p => p.EmployeeMasterPersonalDetails)
                .HasForeignKey(d => d.EmployeeMasterNationalityCountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeMasterId_EmployeeMasterNationalityCountryId");
        });

        modelBuilder.Entity<EmployeeMasterUpdationForMaster>(entity =>
        {
            entity.HasKey(e => e.EmployeeMasterUpdationForId).HasName("PK__Employee__F3D1C5434D59270C");

            entity
                .ToTable("EmployeeMasterUpdationForMaster")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("EmployeeMasterUpdationForMasterHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.EmployeeMasterUpdationForAuth).HasDefaultValue(true);
            entity.Property(e => e.EmployeeMasterUpdationForAuthRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.EmployeeMasterUpdationForIsActive).HasDefaultValue(true);
            entity.Property(e => e.EmployeeMasterUpdationForIsDiscard).HasDefaultValue(true);
            entity.Property(e => e.EmployeeMasterUpdationForName).HasMaxLength(200);
            entity.Property(e => e.EmployeeMasterUpdationForRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.UpdatedBy).HasDefaultValue(1);
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<EmployeeTypeMaster>(entity =>
        {
            entity.HasKey(e => e.EmployeeTypeId).HasName("PK__Employee__1F1B6AB4D8C90F02");

            entity
                .ToTable("EmployeeTypeMaster")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("EmployeeTypeMasterHistory", "dbo");
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
            entity.Property(e => e.EmployeeTypeDescription).HasMaxLength(100);
            entity.Property(e => e.EmployeeTypeIsActive).HasDefaultValue(true);
            entity.Property(e => e.EmployeeTypeIsDiscard).HasDefaultValue(true);
            entity.Property(e => e.EmployeeTypeName)
                .HasMaxLength(100)
                .HasDefaultValue("Kala Employee");
            entity.Property(e => e.EmployeeTypeRemark)
                .HasMaxLength(100)
                .HasDefaultValue("Nil");
            entity.Property(e => e.UpdatedBy).HasDefaultValue(1);
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");
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
            entity.Property(e => e.UpdatedBy).HasDefaultValue(1);
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");
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
            entity.Property(e => e.ExperiencedRemark)
                .HasMaxLength(100)
                .HasDefaultValue("Nil");
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
            entity.Property(e => e.UpdatedBy).HasDefaultValue(1);
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.GradeCurrency).WithMany(p => p.GradeMasters)
                .HasForeignKey(d => d.GradeCurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GradeId_GradeCurrencyId");
        });

        modelBuilder.Entity<HolidayMaster>(entity =>
        {
            entity.HasKey(e => e.HolidayId).HasName("PK__HolidayM__2D35D57AA9CBAA9D");

            entity
                .ToTable("HolidayMaster")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("HolidayMasterHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.HolidayAuth).HasDefaultValue(true);
            entity.Property(e => e.HolidayAuthRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.HolidayFor).HasMaxLength(100);
            entity.Property(e => e.HolidayFy)
                .HasMaxLength(20)
                .HasColumnName("HolidayFY");
            entity.Property(e => e.HolidayIsActive).HasDefaultValue(true);
            entity.Property(e => e.HolidayIsDiscard).HasDefaultValue(true);
            entity.Property(e => e.HolidayRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.UpdatedBy).HasDefaultValue(1);
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.HolidayCompany).WithMany(p => p.HolidayMasters)
                .HasForeignKey(d => d.HolidayCompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HolidayId_HolidayCompanyId");
        });

        modelBuilder.Entity<HrauthorisationLog>(entity =>
        {
            entity.HasKey(e => e.HrauthLogId).HasName("PK__HRAuthor__4B4FB687AB7A1052");

            entity
                .ToTable("HRAuthorisationLog")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("HRAuthorisationLogHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.HrauthLogId).HasColumnName("HRAuthLogID");
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.HrauthLogIsActive)
                .HasDefaultValue(true)
                .HasColumnName("HRAuthLogIsActive");
            entity.Property(e => e.HrauthLogIsDiscard)
                .HasDefaultValue(true)
                .HasColumnName("HRAuthLogIsDiscard");
            entity.Property(e => e.HrauthLogRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil")
                .HasColumnName("HRAuthLogRemark");
            entity.Property(e => e.HrauthLogTranactionNo)
                .HasMaxLength(50)
                .HasColumnName("HRAuthLogTranactionNo");
            entity.Property(e => e.HrauthLogTransactionPageName).HasColumnName("HRAuthLogTransactionPageName");
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.HrauthorisationLogCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HRAuthLogID_CreatedBy");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.HrauthorisationLogUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HRAuthLogID_UpdatedBy");
        });

        modelBuilder.Entity<KalaErppageDetail>(entity =>
        {
            entity.HasKey(e => e.KalaErppageDetailsId).HasName("PK__KalaERPP__D93D0346D377300C");

            entity
                .ToTable("KalaERPPageDetails")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("KalaERPPageDetailsHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.KalaErppageDetailsId).HasColumnName("KalaERPPageDetailsID");
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.KalaErppageDetailsAuth).HasColumnName("KalaERPPageDetailsAuth");
            entity.Property(e => e.KalaErppageDetailsAuthRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil")
                .HasColumnName("KalaERPPageDetailsAuthRemark");
            entity.Property(e => e.KalaErppageDetailsDivisionId).HasColumnName("KalaERPPageDetailsDivisionID");
            entity.Property(e => e.KalaErppageDetailsIsActive)
                .HasDefaultValue(true)
                .HasColumnName("KalaERPPageDetailsIsActive");
            entity.Property(e => e.KalaErppageDetailsIsDiscard)
                .HasDefaultValue(true)
                .HasColumnName("KalaERPPageDetailsIsDiscard");
            entity.Property(e => e.KalaErppageDetailsRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil")
                .HasColumnName("KalaERPPageDetailsRemark");
            entity.Property(e => e.PageIsonumber)
                .HasMaxLength(200)
                .HasColumnName("PageISONumber");
            entity.Property(e => e.PageTittle).HasMaxLength(200);
            entity.Property(e => e.PageUrl)
                .HasMaxLength(400)
                .HasColumnName("PageURL");
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.KalaErppageDetailCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KalaERPPageDetailsId_CreatedBy");

            entity.HasOne(d => d.KalaErppageDetailsDivision).WithMany(p => p.KalaErppageDetails)
                .HasForeignKey(d => d.KalaErppageDetailsDivisionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KalaERPPageDetailsId_KalaERPPageDetailsDivisionID");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.KalaErppageDetailUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KalaERPPageDetailsId_UpdatedBy");
        });

        modelBuilder.Entity<Kpadetail>(entity =>
        {
            entity.HasKey(e => e.KpadetailsId).HasName("PK__KPADetai__FEFE184C23066192");

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
            entity.HasKey(e => e.Kpaid).HasName("PK__KPAMaste__6C148942A4717B17");

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
            entity.Property(e => e.KpadivisionId).HasColumnName("KPADivisionId");
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
            entity.Property(e => e.UpdatedBy).HasDefaultValue(1);
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Kpadesignation).WithMany(p => p.Kpamasters)
                .HasForeignKey(d => d.KpadesignationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KPAId_KPADesignationId");

            entity.HasOne(d => d.Kpadivision).WithMany(p => p.Kpamasters)
                .HasForeignKey(d => d.KpadivisionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KPAId_KPADivisionId");

            entity.HasOne(d => d.Kpagrade).WithMany(p => p.Kpamasters)
                .HasForeignKey(d => d.KpagradeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KPAId_KPAGradeId");
        });

        modelBuilder.Entity<LeaveApplication>(entity =>
        {
            entity.HasKey(e => e.LeaveApplicationId).HasName("PK__LeaveApp__038EC20D6D63CC6A");

            entity.ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("LeaveApplicationsHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.LeaveApplicationId).HasColumnName("LeaveApplicationID");
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.LeaveApplicationsAuthRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.LeaveApplicationsEmployeeId).HasColumnName("LeaveApplicationsEmployeeID");
            entity.Property(e => e.LeaveApplicationsIsActive).HasDefaultValue(true);
            entity.Property(e => e.LeaveApplicationsIsDiscard).HasDefaultValue(true);
            entity.Property(e => e.LeaveApplicationsLeaveTypeId).HasColumnName("LeaveApplicationsLeaveTypeID");
            entity.Property(e => e.LeaveApplicationsRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.LeaveApplicationCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LeaveApplicationsId_CreatedBy");

            entity.HasOne(d => d.LeaveApplicationsEmployee).WithMany(p => p.LeaveApplications)
                .HasForeignKey(d => d.LeaveApplicationsEmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LeaveApplicationsId_LeaveApplicationsEmployeeID");

            entity.HasOne(d => d.LeaveApplicationsLeaveType).WithMany(p => p.LeaveApplications)
                .HasForeignKey(d => d.LeaveApplicationsLeaveTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LeaveApplicationsId_LeaveApplicationsLeaveTypeID");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.LeaveApplicationUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LeaveApplicationsId_UpdatedBy");
        });

        modelBuilder.Entity<LeaveTypeMaster>(entity =>
        {
            entity.HasKey(e => e.LeaveTypeMasterId).HasName("PK__LeaveTyp__8C7B9B206718126E");

            entity
                .ToTable("LeaveTypeMaster")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("LeaveTypeMasterHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.LeaveTypeMasterId).HasColumnName("LeaveTypeMasterID");
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.LeaveTypeMasterAuth).HasDefaultValue(true);
            entity.Property(e => e.LeaveTypeMasterAuthRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.LeaveTypeMasterCode).HasMaxLength(50);
            entity.Property(e => e.LeaveTypeMasterIsActive).HasDefaultValue(true);
            entity.Property(e => e.LeaveTypeMasterIsDiscard).HasDefaultValue(true);
            entity.Property(e => e.LeaveTypeMasterLeaveTypeRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.LeaveTypeMasterName).HasMaxLength(50);
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");
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
            entity.Property(e => e.UpdatedBy).HasDefaultValue(1);
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.ProfitcenterLocation).WithMany(p => p.LocationMasters)
                .HasForeignKey(d => d.ProfitcenterLocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LocationId_ProfitcenterLocationID");
        });

        modelBuilder.Entity<OfferLetter>(entity =>
        {
            entity.HasKey(e => e.OfferLetterId).HasName("PK__OfferLet__94C85047A44BA7A4");

            entity
                .ToTable("OfferLetter")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("OfferLetterHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.OfferLetterAuth1Remark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.OfferLetterAuth2Remark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.OfferLetterAuth3Remark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.OfferLetterIsActive).HasDefaultValue(true);
            entity.Property(e => e.OfferLetterIsDiscard).HasDefaultValue(true);
            entity.Property(e => e.OfferLetterRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.OfferLetterPosition).WithMany(p => p.OfferLetters)
                .HasForeignKey(d => d.OfferLetterPositionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OfferLetterId_OfferLetterPositionId");

            entity.HasOne(d => d.OfferLetterRecruitment).WithMany(p => p.OfferLetters)
                .HasForeignKey(d => d.OfferLetterRecruitmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OfferLetterId_OfferLetterRecruitmentId");
        });

        modelBuilder.Entity<OfferLetterCtc>(entity =>
        {
            entity.HasKey(e => e.OfferLetterCtcid).HasName("PK__OfferLet__B657EDD3968ECE04");

            entity
                .ToTable("OfferLetterCTC")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("OfferLetterCTCHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.OfferLetterCtcid).HasColumnName("OfferLetterCTCId");
            entity.Property(e => e.OfferLetterCtcofferLetterId).HasColumnName("OfferLetterCTCOfferLetterId");
            entity.Property(e => e.OfferLetterDa).HasColumnName("OfferLetterDA");
            entity.Property(e => e.OfferLetterHra).HasColumnName("OfferLetterHRA");
            entity.Property(e => e.OfferLetterMlwf).HasColumnName("OfferLetterMLWF");
            entity.Property(e => e.OfferLetterPerformanceKpa).HasColumnName("OfferLetterPerformanceKPA");
            entity.Property(e => e.OfferLetterPfemployee).HasColumnName("OfferLetterPFEmployee");
            entity.Property(e => e.OfferLetterPfemployer).HasColumnName("OfferLetterPFEmployer");
            entity.Property(e => e.OfferLetterPt).HasColumnName("OfferLetterPT");

            entity.HasOne(d => d.OfferLetterCtcofferLetter).WithMany(p => p.OfferLetterCtcs)
                .HasForeignKey(d => d.OfferLetterCtcofferLetterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OfferLetterCTCId_OfferLetterCTCOfferLetterId");
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
            entity.Property(e => e.UpdatedBy).HasDefaultValue(1);
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<PositionMaster>(entity =>
        {
            entity.HasKey(e => e.PositionMasterId).HasName("PK__Position__7F6D914680EFE228");

            entity
                .ToTable("PositionMaster")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("PositionMasterHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.PositionMasterAuth).HasDefaultValue(true);
            entity.Property(e => e.PositionMasterAuthRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.PositionMasterCode).HasMaxLength(50);
            entity.Property(e => e.PositionMasterIsActive).HasDefaultValue(true);
            entity.Property(e => e.PositionMasterIsDiscard).HasDefaultValue(true);
            entity.Property(e => e.PositionMasterKpaid).HasColumnName("PositionMasterKPAId");
            entity.Property(e => e.PositionMasterName).HasMaxLength(50);
            entity.Property(e => e.PositionMasterRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.UpdatedBy).HasDefaultValue(1);
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.PositionMasterActivity).WithMany(p => p.PositionMasters)
                .HasForeignKey(d => d.PositionMasterActivityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PositionMasterId_PositionMasterActivityId");

            entity.HasOne(d => d.PositionMasterAuthorities).WithMany(p => p.PositionMasters)
                .HasForeignKey(d => d.PositionMasterAuthoritiesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PositionMasterId_PositionMasterAuthoritiesId");

            entity.HasOne(d => d.PositionMasterCompany).WithMany(p => p.PositionMasters)
                .HasForeignKey(d => d.PositionMasterCompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PositionMasterId_PositionMasterCompanyID");

            entity.HasOne(d => d.PositionMasterDepartment).WithMany(p => p.PositionMasters)
                .HasForeignKey(d => d.PositionMasterDepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PositionMasterId_PositionMasterDepartmentId");

            entity.HasOne(d => d.PositionMasterDesignation).WithMany(p => p.PositionMasters)
                .HasForeignKey(d => d.PositionMasterDesignationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PositionMasterId_PositionMasterDesignationId");

            entity.HasOne(d => d.PositionMasterDivision).WithMany(p => p.PositionMasters)
                .HasForeignKey(d => d.PositionMasterDivisionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PositionMasterId_PositionMasterDivisionId");

            entity.HasOne(d => d.PositionMasterEmployeeType).WithMany(p => p.PositionMasters)
                .HasForeignKey(d => d.PositionMasterEmployeeTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PositionMasterId_PositionMasterEmployeeTypeId");

            entity.HasOne(d => d.PositionMasterGrade).WithMany(p => p.PositionMasters)
                .HasForeignKey(d => d.PositionMasterGradeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PositionMasterId_PositionMasterGradeId");

            entity.HasOne(d => d.PositionMasterKpa).WithMany(p => p.PositionMasters)
                .HasForeignKey(d => d.PositionMasterKpaid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PositionMasterId_PositionMasterKPAId");

            entity.HasOne(d => d.PositionMasterProfitcenter).WithMany(p => p.PositionMasters)
                .HasForeignKey(d => d.PositionMasterProfitcenterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PositionMasterId_PositionMasterProfitcenterId");

            entity.HasOne(d => d.PositionMasterResponsibilities).WithMany(p => p.PositionMasters)
                .HasForeignKey(d => d.PositionMasterResponsibilitiesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PositionMasterId_PositionMasterResponsibilitiesId");

            entity.HasOne(d => d.PositionMasterRoles).WithMany(p => p.PositionMasters)
                .HasForeignKey(d => d.PositionMasterRolesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PositionMasterId_PositionMasterRolesId");

            entity.HasOne(d => d.PositionMasterWorkStation).WithMany(p => p.PositionMasters)
                .HasForeignKey(d => d.PositionMasterWorkStationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PositionMasterId_PositionMasterWorkStationId");
        });

        modelBuilder.Entity<PositionMasterQualificationDetail>(entity =>
        {
            entity.HasKey(e => e.PositionQualificationDetailsId).HasName("PK__Position__F86A6ECD285FF762");

            entity.ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("PositionMasterQualificationDetailsHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.PositionMasterQualificationDetailsDescription)
                .HasMaxLength(500)
                .HasDefaultValue("Nil");

            entity.HasOne(d => d.DetailsPositionMaster).WithMany(p => p.PositionMasterQualificationDetails)
                .HasForeignKey(d => d.DetailsPositionMasterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PositionQualificationDetailsId_DetailsPositionMasterId");

            entity.HasOne(d => d.PositionQualification).WithMany(p => p.PositionMasterQualificationDetails)
                .HasForeignKey(d => d.PositionQualificationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PositionQualificationDetailsId_PositionQualificationId");
        });

        modelBuilder.Entity<ProfitcenterBudget>(entity =>
        {
            entity.HasKey(e => e.ProfitcenterBudgetId).HasName("PK__Profitce__05AA9BA01773A468");

            entity
                .ToTable("ProfitcenterBudget")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("ProfitcenterBudgetHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ProfitCenterBudgetAuth).HasDefaultValue(true);
            entity.Property(e => e.ProfitCenterBudgetAuthRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.ProfitCenterBudgetHeadId).HasColumnName("ProfitCenterBudgetHeadID");
            entity.Property(e => e.ProfitCenterBudgetIsActive).HasDefaultValue(true);
            entity.Property(e => e.ProfitCenterBudgetIsDiscard).HasDefaultValue(true);
            entity.Property(e => e.ProfitCenterBudgetRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.ProfitcenterFy)
                .HasMaxLength(20)
                .HasColumnName("ProfitcenterFY");
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.ProfitCenterBudgetHead).WithMany(p => p.ProfitcenterBudgets)
                .HasForeignKey(d => d.ProfitCenterBudgetHeadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProfitcenterBudgetId_ProfitCenterBudgetHeadID");

            entity.HasOne(d => d.ProfitcenterBudgetProfitcenter).WithMany(p => p.ProfitcenterBudgets)
                .HasForeignKey(d => d.ProfitcenterBudgetProfitcenterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProfitcenterBudgetId_ProfitcenterBudgetProfitcenterId");
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
            entity.Property(e => e.UpdatedBy).HasDefaultValue(1);
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.ParentProfitCenter).WithMany(p => p.InverseParentProfitCenter)
                .HasForeignKey(d => d.ParentProfitCenterId)
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
            entity.Property(e => e.UpdatedBy).HasDefaultValue(1);
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");

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
            entity.Property(e => e.UpdatedBy).HasDefaultValue(1);
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<RecruitmentAttributeMaster>(entity =>
        {
            entity.HasKey(e => e.RecruitmentAttributeId).HasName("PK__Recruitm__38F60A95899B5357");

            entity
                .ToTable("RecruitmentAttributeMaster")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("RecruitmentAttributeMasterHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.RecruitmentAttributeAuth).HasDefaultValue(true);
            entity.Property(e => e.RecruitmentAttributeAuthRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.RecruitmentAttributeIsActive).HasDefaultValue(true);
            entity.Property(e => e.RecruitmentAttributeIsDiscard).HasDefaultValue(true);
            entity.Property(e => e.RecruitmentAttributeName).HasMaxLength(200);
            entity.Property(e => e.RecruitmentAttributeRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.UpdatedBy).HasDefaultValue(1);
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<RecruitmentDetail>(entity =>
        {
            entity.HasKey(e => e.RecruitmentDetailsId).HasName("PK__Recruitm__60BE10A4033F50D5");

            entity.ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("RecruitmentDetailsHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.HasOne(d => d.DetailsRecruitmentMaster).WithMany(p => p.RecruitmentDetails)
                .HasForeignKey(d => d.DetailsRecruitmentMasterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RecruitmentDetailsId_DetailsRecruitmentMasterId");

            entity.HasOne(d => d.RecruitmentDetailsAttribute).WithMany(p => p.RecruitmentDetails)
                .HasForeignKey(d => d.RecruitmentDetailsAttributeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RecruitmentDetailsId_RecruitmentDetailsAttributeId");
        });

        modelBuilder.Entity<RecruitmentMaster>(entity =>
        {
            entity.HasKey(e => e.RecruitmentMasterId).HasName("PK__Recruitm__CE10C6E0F434E4BD");

            entity
                .ToTable("RecruitmentMaster")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("RecruitmentMasterHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.RecruitmentMasterAppropriateForJobRole).HasMaxLength(50);
            entity.Property(e => e.RecruitmentMasterAuth).HasDefaultValue(true);
            entity.Property(e => e.RecruitmentMasterAuthRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.RecruitmentMasterCandidateContactNumber).HasMaxLength(50);
            entity.Property(e => e.RecruitmentMasterCandidateEmailId).HasMaxLength(50);
            entity.Property(e => e.RecruitmentMasterCode).HasMaxLength(50);
            entity.Property(e => e.RecruitmentMasterCurrentCtcpa).HasColumnName("RecruitmentMasterCurrentCTCPA");
            entity.Property(e => e.RecruitmentMasterExpectedCtcpa).HasColumnName("RecruitmentMasterExpectedCTCPA");
            entity.Property(e => e.RecruitmentMasterHrcomment)
                .HasMaxLength(100)
                .HasColumnName("RecruitmentMasterHRComment");
            entity.Property(e => e.RecruitmentMasterInterviewerComment).HasMaxLength(100);
            entity.Property(e => e.RecruitmentMasterIsActive).HasDefaultValue(true);
            entity.Property(e => e.RecruitmentMasterIsDiscard).HasDefaultValue(true);
            entity.Property(e => e.RecruitmentMasterNameOfCandidates).HasMaxLength(100);
            entity.Property(e => e.RecruitmentMasterOfferLetterStatus).HasMaxLength(10);
            entity.Property(e => e.RecruitmentMasterRecommendedCtcpa).HasColumnName("RecruitmentMasterRecommendedCTCPA");
            entity.Property(e => e.RecruitmentMasterRecruitmentStageStatusId).HasColumnName("RecruitmentMasterRecruitmentStageStatusID");
            entity.Property(e => e.RecruitmentMasterReferenceCode).HasMaxLength(10);
            entity.Property(e => e.RecruitmentMasterReferenceName).HasMaxLength(100);
            entity.Property(e => e.RecruitmentMasterRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.UpdatedBy).HasDefaultValue(1);
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.RecruitmentMasterCity).WithMany(p => p.RecruitmentMasters)
                .HasForeignKey(d => d.RecruitmentMasterCityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RecruitmentMasterId_RecruitmentMasterCityId");

            entity.HasOne(d => d.RecruitmentMasterCompany).WithMany(p => p.RecruitmentMasters)
                .HasForeignKey(d => d.RecruitmentMasterCompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RecruitmentMasterId_RecruitmentMasterCompanyID");

            entity.HasOne(d => d.RecruitmentMasterDesignation).WithMany(p => p.RecruitmentMasters)
                .HasForeignKey(d => d.RecruitmentMasterDesignationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RecruitmentMasterId_RecruitmentMasterDesignationId");

            entity.HasOne(d => d.RecruitmentMasterGrade).WithMany(p => p.RecruitmentMasters)
                .HasForeignKey(d => d.RecruitmentMasterGradeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RecruitmentMasterId_RecruitmentMasterGradeId");

            entity.HasOne(d => d.RecruitmentMasterInterviewerEmployee).WithMany(p => p.RecruitmentMasters)
                .HasForeignKey(d => d.RecruitmentMasterInterviewerEmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RecruitmentMasterId_RecruitmentMasterInterviewerEmployeeId");

            entity.HasOne(d => d.RecruitmentMasterPosition).WithMany(p => p.RecruitmentMasters)
                .HasForeignKey(d => d.RecruitmentMasterPositionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RecruitmentMasterId_RecruitmentMasterPositionId");

            entity.HasOne(d => d.RecruitmentMasterRecruitmentStageStatus).WithMany(p => p.RecruitmentMasters)
                .HasForeignKey(d => d.RecruitmentMasterRecruitmentStageStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RecruitmentMasterId_RecruitmentMasterRecruitmentStageStatusID");

            entity.HasOne(d => d.RecruitmentMasterReference).WithMany(p => p.RecruitmentMasters)
                .HasForeignKey(d => d.RecruitmentMasterReferenceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RecruitmentMasterId_RecruitmentMasterReferenceId");
        });

        modelBuilder.Entity<RecruitmentReferenceMaster>(entity =>
        {
            entity.HasKey(e => e.RecruitmentReferenceId).HasName("PK__Recruitm__09FF1BA185BC8E68");

            entity
                .ToTable("RecruitmentReferenceMaster")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("RecruitmentReferenceMasterHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.RecruitmentReferenceAuth).HasDefaultValue(true);
            entity.Property(e => e.RecruitmentReferenceAuthRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.RecruitmentReferenceIsActive).HasDefaultValue(true);
            entity.Property(e => e.RecruitmentReferenceIsDiscard).HasDefaultValue(true);
            entity.Property(e => e.RecruitmentReferenceName).HasMaxLength(200);
            entity.Property(e => e.RecruitmentReferenceRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.UpdatedBy).HasDefaultValue(1);
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<RecruitmentStageStatusMaster>(entity =>
        {
            entity.HasKey(e => e.RecruitmentStageStatusId).HasName("PK__Recruitm__BA9AE646A7D23D5C");

            entity
                .ToTable("RecruitmentStageStatusMaster")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("RecruitmentStageStatusMasterHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.RecruitmentStageStatusAuth).HasDefaultValue(true);
            entity.Property(e => e.RecruitmentStageStatusAuthRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.RecruitmentStageStatusIsActive).HasDefaultValue(true);
            entity.Property(e => e.RecruitmentStageStatusIsDiscard).HasDefaultValue(true);
            entity.Property(e => e.RecruitmentStageStatusName).HasMaxLength(200);
            entity.Property(e => e.RecruitmentStageStatusRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.UpdatedBy).HasDefaultValue(1);
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<ResponsibilitiesDetail>(entity =>
        {
            entity.HasKey(e => e.ResponsibilitiesDetailsId).HasName("PK__Responsi__32CE58DE9AFFFE2E");

            entity.ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("MSSQL_TemporalHistoryFor_439672614", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.ResponsibilitiesDetailsDescription)
                .HasMaxLength(500)
                .HasDefaultValue("Nil");

            entity.HasOne(d => d.DetailsResposibilities).WithMany(p => p.ResponsibilitiesDetails)
                .HasForeignKey(d => d.DetailsResposibilitiesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ResponsibilitiesDetailsId_DetailsResposibilitiesId");
        });

        modelBuilder.Entity<ResponsibilitiesMaster>(entity =>
        {
            entity.HasKey(e => e.ResponsibilitiesId).HasName("PK__Responsi__0B2E60F259F147BE");

            entity
                .ToTable("ResponsibilitiesMaster")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("ResponsibilitiesMasterHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ResponsibilitiesAuth).HasDefaultValue(true);
            entity.Property(e => e.ResponsibilitiesAuthRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.ResponsibilitiesIsActive).HasDefaultValue(true);
            entity.Property(e => e.ResponsibilitiesIsDiscard).HasDefaultValue(true);
            entity.Property(e => e.ResponsibilitiesRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.UpdatedBy).HasDefaultValue(1);
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.ResponsibilitiesDesignation).WithMany(p => p.ResponsibilitiesMasters)
                .HasForeignKey(d => d.ResponsibilitiesDesignationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ResponsibilitiesId_ResponsibilitiesDesignationId");

            entity.HasOne(d => d.ResponsibilitiesDivision).WithMany(p => p.ResponsibilitiesMasters)
                .HasForeignKey(d => d.ResponsibilitiesDivisionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ResponsibilitiesId_ResponsibilitiesDivisionId");

            entity.HasOne(d => d.ResponsibilitiesGrade).WithMany(p => p.ResponsibilitiesMasters)
                .HasForeignKey(d => d.ResponsibilitiesGradeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ResponsibilitiesId_ResponsibilitiesGradeId");
        });

        modelBuilder.Entity<RolesDetail>(entity =>
        {
            entity.HasKey(e => e.RolesDetailsId).HasName("PK__RolesDet__A8CC7A1E98985D13");

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
            entity.HasKey(e => e.RolesId).HasName("PK__RolesMas__C4B278401DD391BB");

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
            entity.Property(e => e.UpdatedBy).HasDefaultValue(1);
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.RolesDesignation).WithMany(p => p.RolesMasters)
                .HasForeignKey(d => d.RolesDesignationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RolesId_RolesDesignationId");

            entity.HasOne(d => d.RolesDivision).WithMany(p => p.RolesMasters)
                .HasForeignKey(d => d.RolesDivisionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RolesId_RolesDivisionId");

            entity.HasOne(d => d.RolesGrade).WithMany(p => p.RolesMasters)
                .HasForeignKey(d => d.RolesGradeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RolesId_RolesGradeId");
        });

        modelBuilder.Entity<ShiftMaster>(entity =>
        {
            entity.HasKey(e => e.ShiftMasterId).HasName("PK__ShiftMas__2F438FEA3C5D1AC1");

            entity
                .ToTable("ShiftMaster")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("ShiftMasterHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ShiftMasterAliseName).HasMaxLength(50);
            entity.Property(e => e.ShiftMasterAuth).HasDefaultValue(true);
            entity.Property(e => e.ShiftMasterAuthRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.ShiftMasterIsActive).HasDefaultValue(true);
            entity.Property(e => e.ShiftMasterIsDiscard).HasDefaultValue(true);
            entity.Property(e => e.ShiftMasterName).HasMaxLength(50);
            entity.Property(e => e.ShiftMasterRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.UpdatedBy).HasDefaultValue(1);
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.ShiftMasterCompany).WithMany(p => p.ShiftMasters)
                .HasForeignKey(d => d.ShiftMasterCompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ShiftMasterId_ShiftMasterCompanyID");

            entity.HasOne(d => d.ShiftMasterEmployeeType).WithMany(p => p.ShiftMasters)
                .HasForeignKey(d => d.ShiftMasterEmployeeTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ShiftMasterId_ShiftMasterEmployeeTypeId");
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
            entity.Property(e => e.UpdatedBy).HasDefaultValue(1);
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Country).WithMany(p => p.StateMasters)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StateId_CountryId");
        });

        modelBuilder.Entity<UserLogin>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UserLogi__1788CCAC9E4AB0BF");

            entity
                .ToTable("UserLogin")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("UserLoginHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.HasIndex(e => e.EmailVerificationToken, "IX_UserLogin_EmailVerificationToken");

            entity.HasIndex(e => e.PasswordResetToken, "IX_UserLogin_PasswordResetToken");

            entity.HasIndex(e => e.UserGuid, "IX_UserLogin_UserGUID").IsUnique();

            entity.HasIndex(e => e.UserLoginEmployeeId, "IX_UserLogin_UserLoginEmployeeId");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Bio).HasMaxLength(1000);
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DateFormat)
                .HasMaxLength(20)
                .HasDefaultValue("MM/dd/yyyy");
            entity.Property(e => e.EmailVerificationToken).HasMaxLength(255);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Language)
                .HasMaxLength(10)
                .HasDefaultValue("en-US");
            entity.Property(e => e.LastLoginIp)
                .HasMaxLength(45)
                .HasColumnName("LastLoginIP");
            entity.Property(e => e.LastLoginLocation).HasMaxLength(200);
            entity.Property(e => e.LastLoginUserAgent).HasMaxLength(500);
            entity.Property(e => e.LastPasswordChange).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.MaxFailedAttempts).HasDefaultValue(5);
            entity.Property(e => e.PasswordAlgorithm)
                .HasMaxLength(20)
                .HasDefaultValue("SHA256");
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.PasswordResetToken).HasMaxLength(255);
            entity.Property(e => e.PasswordSalt).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.ProfilePictureUrl)
                .HasMaxLength(500)
                .HasColumnName("ProfilePictureURL");
            entity.Property(e => e.SecurityAnswer1Hash).HasMaxLength(255);
            entity.Property(e => e.SecurityAnswer2Hash).HasMaxLength(255);
            entity.Property(e => e.SecurityQuestion1).HasMaxLength(200);
            entity.Property(e => e.SecurityQuestion2).HasMaxLength(200);
            entity.Property(e => e.Theme)
                .HasMaxLength(20)
                .HasDefaultValue("default");
            entity.Property(e => e.TimeZone)
                .HasMaxLength(50)
                .HasDefaultValue("UTC");
            entity.Property(e => e.TwoFactorBackupCodes).HasMaxLength(500);
            entity.Property(e => e.TwoFactorSecret).HasMaxLength(100);
            entity.Property(e => e.UserGuid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("UserGUID");

            entity.HasOne(d => d.UserLoginEmployee).WithMany(p => p.UserLogins)
                .HasForeignKey(d => d.UserLoginEmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserLogin_UserLoginEmployeeId");
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
            entity.Property(e => e.UpdatedBy).HasDefaultValue(1);
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");
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

            entity.HasOne(d => d.WorkStationProfitcenter).WithMany(p => p.WorkStationMasters)
                .HasForeignKey(d => d.WorkStationProfitcenterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkStationId_WorkStationProfitcenterID");
        });

        modelBuilder.Entity<WorkstationBudget>(entity =>
        {
            entity.HasKey(e => e.WorkstationBudgetId).HasName("PK__Workstat__1EF64F0E612F450A");

            entity
                .ToTable("WorkstationBudget")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("WorkstationBudgetHistory", "dbo");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.WorkstationBudgetAuth).HasDefaultValue(true);
            entity.Property(e => e.WorkstationBudgetAuthRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.WorkstationBudgetHeadId).HasColumnName("WorkstationBudgetHeadID");
            entity.Property(e => e.WorkstationBudgetIsActive).HasDefaultValue(true);
            entity.Property(e => e.WorkstationBudgetIsDiscard).HasDefaultValue(true);
            entity.Property(e => e.WorkstationBudgetRemark)
                .HasMaxLength(200)
                .HasDefaultValue("Nil");
            entity.Property(e => e.WorkstationFy)
                .HasMaxLength(20)
                .HasColumnName("WorkstationFY");

            entity.HasOne(d => d.WorkstationBudgetHead).WithMany(p => p.WorkstationBudgets)
                .HasForeignKey(d => d.WorkstationBudgetHeadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkstationBudgetId_WorkstationBudgetHeadID");

            entity.HasOne(d => d.WorkstationBudgetWorkstation).WithMany(p => p.WorkstationBudgets)
                .HasForeignKey(d => d.WorkstationBudgetWorkstationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkstationBudgetId_WorkstationBudgetWorkstationId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
