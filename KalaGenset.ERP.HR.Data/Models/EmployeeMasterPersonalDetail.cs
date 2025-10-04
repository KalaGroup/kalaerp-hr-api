using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class EmployeeMasterPersonalDetail
{
    public int EmployeeMasterId { get; set; }

    public string EmployeeMasterCode { get; set; } = null!;

    public string EmployeeMasterFirstName { get; set; } = null!;

    public string EmployeeMasterMiddleName { get; set; } = null!;

    public string EmployeeMasterLastName { get; set; } = null!;

    public string EmployeeMasterFullName { get; set; } = null!;

    public DateTime EmployeeMasterDateOfBirth { get; set; }

    public string EmployeeMasterGender { get; set; } = null!;

    public int EmployeeMasterNationalityCountryId { get; set; }

    public string EmployeeMasterReligion { get; set; } = null!;

    public string EmployeeMasterReligionCategory { get; set; } = null!;

    public string EmployeeMasterBloodGroup { get; set; } = null!;

    public string EmployeeMasterPhotoAttachment { get; set; } = null!;

    public string EmployeeMasterRemark { get; set; } = null!;

    public string EmployeeMasterAuthRemark { get; set; } = null!;

    public bool EmployeeMasterAuth { get; set; }

    public bool EmployeeMasterIsDiscard { get; set; }

    public bool EmployeeMasterIsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int UpdatedBy { get; set; }

    public DateTime UpdatedDate { get; set; }

    public virtual ICollection<DailyAttendance> DailyAttendances { get; set; } = new List<DailyAttendance>();

    public virtual ICollection<DepartmentBudget> DepartmentBudgets { get; set; } = new List<DepartmentBudget>();

    public virtual ICollection<EmployeeLeaveBalance> EmployeeLeaveBalances { get; set; } = new List<EmployeeLeaveBalance>();

    public virtual ICollection<EmployeeMasterAddressDetail> EmployeeMasterAddressDetails { get; set; } = new List<EmployeeMasterAddressDetail>();

    public virtual ICollection<EmployeeMasterEmploymentDetail> EmployeeMasterEmploymentDetailEmploymentDetailsEmployeeMasters { get; set; } = new List<EmployeeMasterEmploymentDetail>();

    public virtual ICollection<EmployeeMasterEmploymentDetail> EmployeeMasterEmploymentDetailEmploymentDetailsReportDepartmentHods { get; set; } = new List<EmployeeMasterEmploymentDetail>();

    public virtual ICollection<EmployeeMasterEmploymentDetail> EmployeeMasterEmploymentDetailEmploymentDetailsReportTos { get; set; } = new List<EmployeeMasterEmploymentDetail>();

    public virtual ICollection<EmployeeMasterFamilyDetail> EmployeeMasterFamilyDetails { get; set; } = new List<EmployeeMasterFamilyDetail>();

    public virtual CountryMaster EmployeeMasterNationalityCountry { get; set; } = null!;

    public virtual ICollection<LeaveApplication> LeaveApplications { get; set; } = new List<LeaveApplication>();

    public virtual ICollection<ProfitcenterBudget> ProfitcenterBudgets { get; set; } = new List<ProfitcenterBudget>();

    public virtual ICollection<RecruitmentMaster> RecruitmentMasters { get; set; } = new List<RecruitmentMaster>();

    public virtual ICollection<UserLogin> UserLogins { get; set; } = new List<UserLogin>();

    public virtual ICollection<WorkstationBudget> WorkstationBudgets { get; set; } = new List<WorkstationBudget>();
}
