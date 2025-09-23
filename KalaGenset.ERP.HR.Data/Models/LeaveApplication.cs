using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class LeaveApplication
{
    public int LeaveApplicationId { get; set; }

    public int LeaveApplicationsEmployeeId { get; set; }

    public int LeaveApplicationsLeaveTypeId { get; set; }

    public int LeaveApplicationsLeaveCount { get; set; }

    public string LeaveApplicationsRemark { get; set; } = null!;

    public string LeaveApplicationsAuthRemark { get; set; } = null!;

    public bool LeaveApplicationsIsDiscard { get; set; }

    public bool LeaveApplicationsIsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int UpdatedBy { get; set; }

    public DateTime UpdatedDate { get; set; }

    public virtual UserLogin CreatedByNavigation { get; set; } = null!;

    public virtual EmployeeMasterPersonalDetail LeaveApplicationsEmployee { get; set; } = null!;

    public virtual LeaveTypeMaster LeaveApplicationsLeaveType { get; set; } = null!;

    public virtual UserLogin UpdatedByNavigation { get; set; } = null!;
}
