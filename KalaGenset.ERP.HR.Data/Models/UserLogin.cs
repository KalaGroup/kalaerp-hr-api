using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class UserLogin
{
    public int UserId { get; set; }

    public Guid UserGuid { get; set; }

    public int UserLoginEmployeeId { get; set; }

    public string PasswordHash { get; set; } = null!;

    public string PasswordSalt { get; set; } = null!;

    public string PasswordAlgorithm { get; set; } = null!;

    public DateTime LastPasswordChange { get; set; }

    public DateTime? PasswordExpiryDate { get; set; }

    public bool MustChangePassword { get; set; }

    public string? PasswordHistory { get; set; }

    public bool IsAccountLocked { get; set; }

    public DateTime? LockoutEndDate { get; set; }

    public int FailedLoginAttempts { get; set; }

    public int MaxFailedAttempts { get; set; }

    public DateTime? LastFailedLoginDate { get; set; }

    public bool TwoFactorEnabled { get; set; }

    public string? TwoFactorSecret { get; set; }

    public string? TwoFactorBackupCodes { get; set; }

    public DateTime? TwoFactorSetupDate { get; set; }

    public bool IsActive { get; set; }

    public bool IsEmailVerified { get; set; }

    public string? EmailVerificationToken { get; set; }

    public DateTime? EmailVerificationExpiry { get; set; }

    public DateTime? LastLoginDate { get; set; }

    public string? LastLoginIp { get; set; }

    public string? LastLoginUserAgent { get; set; }

    public string? LastLoginLocation { get; set; }

    public int LoginCount { get; set; }

    public string? PasswordResetToken { get; set; }

    public DateTime? PasswordResetExpiry { get; set; }

    public int PasswordResetAttempts { get; set; }

    public string TimeZone { get; set; } = null!;

    public string Language { get; set; } = null!;

    public string DateFormat { get; set; } = null!;

    public string Theme { get; set; } = null!;

    public string? SecurityQuestion1 { get; set; }

    public string? SecurityAnswer1Hash { get; set; }

    public string? SecurityQuestion2 { get; set; }

    public string? SecurityAnswer2Hash { get; set; }

    public string? ProfilePictureUrl { get; set; }

    public string? Bio { get; set; }

    public string? PhoneNumber { get; set; }

    public bool IsPhoneVerified { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedBy { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedDate { get; set; }

    public int? DeletedBy { get; set; }

    public virtual ICollection<DailyAttendance> DailyAttendanceCreatedByNavigations { get; set; } = new List<DailyAttendance>();

    public virtual ICollection<DailyAttendance> DailyAttendanceUpdatedByNavigations { get; set; } = new List<DailyAttendance>();

    public virtual ICollection<EmployeeLeaveBalance> EmployeeLeaveBalanceCreatedByNavigations { get; set; } = new List<EmployeeLeaveBalance>();

    public virtual ICollection<EmployeeLeaveBalance> EmployeeLeaveBalanceUpdatedByNavigations { get; set; } = new List<EmployeeLeaveBalance>();

    public virtual ICollection<EmployeeMasterAddressDetail> EmployeeMasterAddressDetails { get; set; } = new List<EmployeeMasterAddressDetail>();

    public virtual ICollection<EmployeeMasterFamilyDetail> EmployeeMasterFamilyDetails { get; set; } = new List<EmployeeMasterFamilyDetail>();

    public virtual ICollection<GatePassType> GatePassTypeCreatedByNavigations { get; set; } = new List<GatePassType>();

    public virtual ICollection<GatePassType> GatePassTypeUpdatedByNavigations { get; set; } = new List<GatePassType>();

    public virtual ICollection<HrauthorisationLog> HrauthorisationLogCreatedByNavigations { get; set; } = new List<HrauthorisationLog>();

    public virtual ICollection<HrauthorisationLog> HrauthorisationLogUpdatedByNavigations { get; set; } = new List<HrauthorisationLog>();

    public virtual ICollection<KalaErppageDetail> KalaErppageDetailCreatedByNavigations { get; set; } = new List<KalaErppageDetail>();

    public virtual ICollection<KalaErppageDetail> KalaErppageDetailUpdatedByNavigations { get; set; } = new List<KalaErppageDetail>();

    public virtual ICollection<LeaveApplication> LeaveApplicationCreatedByNavigations { get; set; } = new List<LeaveApplication>();

    public virtual ICollection<LeaveApplication> LeaveApplicationUpdatedByNavigations { get; set; } = new List<LeaveApplication>();

    public virtual EmployeeMasterPersonalDetail UserLoginEmployee { get; set; } = null!;
}
