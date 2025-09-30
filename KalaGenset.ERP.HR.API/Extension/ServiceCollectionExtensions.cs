using KalaERP.HR.Core.Interface;
using KalaERP.HR.Core.Services;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Services;

namespace KalaGenset.ERP.HR.API.Extension
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //User & Authentication Services
            services.AddScoped<IUserLogin, UserLoginServices>();

            //Master Data Services - Location Related
            services.AddScoped<ICountryMaster, CountryMasterService>();
            services.AddScoped<IStateMaster, StateMasterService>();
            services.AddScoped<IDistrictMaster, DistrictMasterService>();
            services.AddScoped<ICityMaster, CityMasterService>();
            services.AddScoped<ILocationMaster, LocationMasterService>();

            //Master Data Services - Company Related
            services.AddScoped<ICompanyMaster, CompanyMasterServices>();
            services.AddScoped<ICompanyEntityTypeMaster, CompanyEntityTypeMasterServices>();
            services.AddScoped<IFacilityMaster, FacilityMasterService>();
            services.AddScoped<IProfitcenterMaster, ProfitcenterMasterService>();
            services.AddScoped<IDivisionMaster, DivisionMasterService>();

            //Master Data Services - HR Structure
            services.AddScoped<IDepartmentMaster, DepartmentMasterService>();
            services.AddScoped<IDesignationMaster, DesignationMasterServices>();
            services.AddScoped<IPositionMaster, PositionMasterService>();
            services.AddScoped<IPositionDetails, PositionDetailService>();
            services.AddScoped<IWorkstationMaster, WorkstationMasterService>();
            services.AddScoped<IShiftMaster, ShiftMasterService>();

           // Master Data Services - Employee Related
            services.AddScoped<IEmployeeTypeMaster, EmployeeTypeMasterService>();
            services.AddScoped<IGradeFacilityAssignment, GradeFacilityAssignmentService>();
            services.AddScoped<IEmployeeMasterUpdationForMaster, EmployeeMasterUpdationForMasterService>();

            //Master Data Services - Financial
            services.AddScoped<ICurrencyMaster, CurrencyMasterServices>();
            services.AddScoped<IClassOfTravelMaster, ClassOfTravelMasterService>();
            services.AddScoped<ICTCStructureMaster, CTCStructureMasterServices>();
            services.AddScoped<IPetrolAllowanceMaster, PetrolAllowanceMasterService>();

            //Master Data Services - Qualifications
            services.AddScoped<IQualificationMaster, QualificationMasterService>();
            services.AddScoped<IQualificationTypeMaster, QualificationTypeMasterService>();

            //Master Data Services - KPA & Authorities
            services.AddScoped<IKPAMaster, KPAMasterServices>();
            services.AddScoped<IKpadetail, KPADetailsServices>();
            services.AddScoped<IAuthoritieMaster, AuthoritieMasterServices>();
            services.AddScoped<IAuthoritiesDetail, AuthoritiesDetailServices>();
            services.AddScoped<IResposibilitiesMaster, ResposibilitiesMasterServices>();
            services.AddScoped<IResposibilitiesDetail, ResposibilitiesDetailsServices>();

            //Master Data Services - Activities
            services.AddScoped<IActivityMaster, ActivityMasterServices>();
            services.AddScoped<IActivityDetails, ActivityDetailsServices>();
            services.AddScoped<IHolidayMaster, HolidayMasterService>();

            //Recruitment Services
            services.AddScoped<IRecruitmentMaster, RecruitmentMasterService>();
            services.AddScoped<IRecruitmentAttributeMaster, RecruitmentAttributeMasterService>();
            services.AddScoped<IRecruitmentStageStatusMaster, RecruitmentStageStatusMasterServices>();
            services.AddScoped<IRecruitmentReferenceMaster, RecruitmentReferenceMasterServices>();
            services.AddScoped<IOfferLetter, OfferLetterServices>();

            //Budget Services
            services.AddScoped<IProfitcenterBudget, ProfitcenterBudgetService>();
            services.AddScoped<IDepartmentBudget, DepartmentBudgetService>();
            services.AddScoped<IWorkstationBudget, WorkstationBudgetService>();

            //Leave Management Services
            services.AddScoped<ILeaveTypeMaster, LeaveTypeMasterService>();
            services.AddScoped<IEmployeeLeaveBalance, EmployeeLeaveBalanceService>();
            services.AddScoped<ILeaveApplication, LeaveApplicationServices>();

            //Attendance Services
            services.AddScoped<IDailyAttendance, DailyAttendanceServices>();

            //Security & Roles
            services.AddScoped<IRolesMaster, RolesMasterService>();
            services.AddScoped<IRoleDetails, RoleDetailsService>();

            //ERP Configuration
            services.AddScoped<IERPPageDetails, ERPPageDetailsService>();

            return services;
        }
    }
}
