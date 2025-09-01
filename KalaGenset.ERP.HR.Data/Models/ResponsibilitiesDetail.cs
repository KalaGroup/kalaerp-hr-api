using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class ResponsibilitiesDetail
{
    public int ResponsibilitiesDetailsId { get; set; }

    public int DetailsResposibilitiesId { get; set; }

    public int SrNo { get; set; }

    public string ResponsibilitiesDetailsDescription { get; set; } = null!;

    public virtual ResponsibilitiesMaster DetailsResposibilities { get; set; } = null!;
}
