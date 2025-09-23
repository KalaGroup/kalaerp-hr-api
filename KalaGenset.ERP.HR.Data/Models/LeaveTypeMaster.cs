using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class LeaveTypeMaster
{
    public int LeaveTypeMasterId { get; set; }

    public string LeaveTypeMasterCode { get; set; } = null!;

    public string LeaveTypeMasterName { get; set; } = null!;

    public int LeaveTypeMasterMaxDaysPer { get; set; }

    public int LeaveTypeMasterContinuosDaysPerYear { get; set; }

    public bool LeaveTypeMasterCanCarryForward { get; set; }

    public bool LeaveTypeMasterCanEnCash { get; set; }

    public int LeaveTypeMasterRequiredServiceMonths { get; set; }

    public string LeaveTypeMasterLeaveTypeRemark { get; set; } = null!;

    public string LeaveTypeMasterAuthRemark { get; set; } = null!;

    public bool LeaveTypeMasterAuth { get; set; }

    public bool LeaveTypeMasterIsDiscard { get; set; }

    public bool LeaveTypeMasterIsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int UpdatedBy { get; set; }

    public DateTime UpdatedDate { get; set; }

    public virtual ICollection<EmployeeLeaveBalance> EmployeeLeaveBalances { get; set; } = new List<EmployeeLeaveBalance>();

    public virtual ICollection<LeaveApplication> LeaveApplications { get; set; } = new List<LeaveApplication>();
}
