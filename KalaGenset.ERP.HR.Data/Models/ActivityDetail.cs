using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class ActivityDetail
{
    public int ActivityDetailsId { get; set; }

    public int DetailsActivityId { get; set; }

    public int SrNo { get; set; }

    public string ActivityDetailsDescription { get; set; } = null!;

    public virtual ActivityMaster DetailsActivity { get; set; } = null!;
}
