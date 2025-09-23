using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class ShiftMaster
{
    public int ShiftMasterId { get; set; }

    public int ShiftMasterCompanyId { get; set; }

    public int ShiftMasterEmployeeTypeId { get; set; }

    public string ShiftMasterName { get; set; } = null!;

    public string ShiftMasterAliseName { get; set; } = null!;

    public TimeOnly ShiftMasterStartTime { get; set; }

    public TimeOnly ShiftMasterEndTime { get; set; }

    public TimeOnly ShiftMasterLunchStartTime { get; set; }

    public TimeOnly ShiftMasterLunchEndTime { get; set; }

    public string ShiftMasterRemark { get; set; } = null!;

    public string ShiftMasterAuthRemark { get; set; } = null!;

    public bool ShiftMasterAuth { get; set; }

    public bool ShiftMasterIsDiscard { get; set; }

    public bool ShiftMasterIsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int UpdatedBy { get; set; }

    public DateTime UpdatedDate { get; set; }

    public virtual CompanyMaster ShiftMasterCompany { get; set; } = null!;

    public virtual EmployeeTypeMaster ShiftMasterEmployeeType { get; set; } = null!;
}
