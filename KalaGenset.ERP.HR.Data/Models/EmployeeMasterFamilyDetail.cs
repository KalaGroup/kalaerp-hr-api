using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class EmployeeMasterFamilyDetail
{
    public int EmployeeMasterFamilyDetailsId { get; set; }

    public int FamilyDetailsEmployeeMasterId { get; set; }

    public string FamilyDetailsEmployeeMasterFatherHusbandName { get; set; } = null!;

    public string FamilyDetailsEmployeeMasterMotherName { get; set; } = null!;

    public string FamilyDetailsEmployeeMasterMartialStatus { get; set; } = null!;

    public string FamilyDetailsEmployeeMasterSpouseName { get; set; } = null!;

    public DateTime FamilyDetailsEmployeeMasterSpouseDateOfBirth { get; set; }

    public string FamilyDetailsEmployeeMasterSpouseAadharNumber { get; set; } = null!;

    public int FamilyDetailsEmployeeMasterNumberofChidren { get; set; }

    public string FamilyDetailsEmployeeMasterSpouseAadharNumberAttachment { get; set; } = null!;

    public string FamilyDetailsEmployeeMasterRemark { get; set; } = null!;

    public string FamilyDetailsEmployeeMasterAuthRemark { get; set; } = null!;

    public bool FamilyDetailsEmployeeMasterAuth { get; set; }

    public DateTime UpdatedDate { get; set; }

    public int UpdatedBy { get; set; }

    public virtual EmployeeMasterPersonalDetail FamilyDetailsEmployeeMaster { get; set; } = null!;

    public virtual UserLogin UpdatedByNavigation { get; set; } = null!;
}
