using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class DepartmentBudget
{
    public int DepartmentBudgetId { get; set; }

    public int DepartmentBudgetDepartmentId { get; set; }

    public string DepartmentFy { get; set; } = null!;

    public double DepartmentBudgetAmt { get; set; }

    public int DepartmentBudgetHeadId { get; set; }

    public string DepartmentBudgetRemark { get; set; } = null!;

    public string DepartmentBudgetAuthRemark { get; set; } = null!;

    public bool DepartmentBudgetAuth { get; set; }

    public bool DepartmentBudgetIsDiscard { get; set; }

    public bool DepartmentBudgetIsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int UpdatedBy { get; set; }

    public DateTime UpdatedDate { get; set; }

    public virtual DepartmentMaster DepartmentBudgetDepartment { get; set; } = null!;

    public virtual EmployeeMasterPersonalDetail DepartmentBudgetHead { get; set; } = null!;
}
