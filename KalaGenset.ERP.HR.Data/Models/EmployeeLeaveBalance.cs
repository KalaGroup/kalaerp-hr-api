using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class EmployeeLeaveBalance
{
    public int LeaveBalancesId { get; set; }

    public int LeaveBalancesEmployeeId { get; set; }

    public int LeaveBalancesTypeId { get; set; }

    public int LeaveBalancesYear { get; set; }

    public int LeaveBalancesOpening { get; set; }

    public int LeaveBalancesCredited { get; set; }

    public int LeaveBalancesUtilized { get; set; }

    public int LeaveBalancesEncashed { get; set; }

    public int LeaveBalancesClosing { get; set; }

    public string LeaveBalancesRemark { get; set; } = null!;

    public string LeaveBalancesAuthRemark { get; set; } = null!;

    public bool LeaveBalancesAuth { get; set; }

    public bool LeaveBalancesIsDiscard { get; set; }

    public bool LeaveBalancesIsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int UpdatedBy { get; set; }

    public DateTime UpdatedDate { get; set; }

    public virtual UserLogin CreatedByNavigation { get; set; } = null!;

    public virtual EmployeeMasterPersonalDetail LeaveBalancesEmployee { get; set; } = null!;

    public virtual LeaveTypeMaster LeaveBalancesType { get; set; } = null!;

    public virtual UserLogin UpdatedByNavigation { get; set; } = null!;
}
