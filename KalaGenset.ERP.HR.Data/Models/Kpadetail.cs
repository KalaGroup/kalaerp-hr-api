using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class Kpadetail
{
    public int KpadetailsId { get; set; }

    public int DetailsKpaid { get; set; }

    public int SrNo { get; set; }

    public string KpadetailsDescription { get; set; } = null!;

    public int Marks { get; set; }

    public virtual Kpamaster DetailsKpa { get; set; } = null!;
}
