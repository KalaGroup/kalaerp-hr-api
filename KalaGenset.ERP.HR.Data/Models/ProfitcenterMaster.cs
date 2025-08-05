using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class ProfitcenterMaster
{
    public int ProfitCenterId { get; set; }

    public string ProfitCenterCode { get; set; } = null!;

    public string ProfitCenterName { get; set; } = null!;

    public int ProfitCenterCompanyId { get; set; }

    public int ParentProfitCenterId { get; set; }

    public string ProfitCenterRemark { get; set; } = null!;

    public string ProfitCenterAuthRemark { get; set; } = null!;

    public bool ProfitCenterAuth { get; set; }

    public bool ProfitCenterIsDiscard { get; set; }

    public bool ProfitCenterIsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual ICollection<ProfitcenterMaster> InverseParentProfitCenter { get; set; } = new List<ProfitcenterMaster>();

    public virtual ProfitcenterMaster ParentProfitCenter { get; set; } = null!;
}
