using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class HrauthorisationLog
{
    public int HrauthLogId { get; set; }

    public int HrauthLogTransactionPageName { get; set; }

    public string HrauthLogTranactionNo { get; set; } = null!;

    public string HrauthLogRemark { get; set; } = null!;

    public bool HrauthLogIsDiscard { get; set; }

    public bool HrauthLogIsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int UpdatedBy { get; set; }

    public DateTime UpdatedDate { get; set; }

    public virtual UserLogin CreatedByNavigation { get; set; } = null!;

    public virtual UserLogin UpdatedByNavigation { get; set; } = null!;
}
