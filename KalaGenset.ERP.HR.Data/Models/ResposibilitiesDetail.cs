using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class ResposibilitiesDetail
{
    public int ResposibilitiesDetailsId { get; set; }

    public int DetailsResposibilitiesId { get; set; }

    public int SrNo { get; set; }

    public string ResposibilitiesDetailsDescription { get; set; } = null!;
}
