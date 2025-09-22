using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class EmployeeMasterUpdationForMaster
{
    public int EmployeeMasterUpdationForId { get; set; }

    public string EmployeeMasterUpdationForName { get; set; } = null!;

    public string EmployeeMasterUpdationForRemark { get; set; } = null!;

    public string EmployeeMasterUpdationForAuthRemark { get; set; } = null!;

    public bool EmployeeMasterUpdationForAuth { get; set; }

    public bool EmployeeMasterUpdationForIsDiscard { get; set; }

    public bool EmployeeMasterUpdationForIsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int UpdatedBy { get; set; }

    public DateTime UpdatedDate { get; set; }
}
