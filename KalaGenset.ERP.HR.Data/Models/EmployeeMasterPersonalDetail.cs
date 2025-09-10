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

    public virtual CountryMaster EmployeeMasterNationalityCountry { get; set; } = null!;

    public virtual ICollection<UserLogin> UserLogins { get; set; } = new List<UserLogin>();
}
