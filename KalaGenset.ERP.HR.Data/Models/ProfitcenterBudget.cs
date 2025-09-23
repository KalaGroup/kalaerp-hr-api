using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class ProfitcenterBudget
{
    public int ProfitcenterBudgetId { get; set; }

    public int ProfitcenterBudgetProfitcenterId { get; set; }

    public string ProfitcenterFy { get; set; } = null!;

    public double ProfitcenterBudgetBudgetAmt { get; set; }

    public int ProfitCenterBudgetHeadId { get; set; }

    public string ProfitCenterBudgetRemark { get; set; } = null!;

    public string ProfitCenterBudgetAuthRemark { get; set; } = null!;

    public bool ProfitCenterBudgetAuth { get; set; }

    public bool ProfitCenterBudgetIsDiscard { get; set; }

    public bool ProfitCenterBudgetIsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int UpdatedBy { get; set; }

    public DateTime UpdatedDate { get; set; }

    public virtual EmployeeMasterPersonalDetail ProfitCenterBudgetHead { get; set; } = null!;

    public virtual ProfitcenterMaster ProfitcenterBudgetProfitcenter { get; set; } = null!;
}
