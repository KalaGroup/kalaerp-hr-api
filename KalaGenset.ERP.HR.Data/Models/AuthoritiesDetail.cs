using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class AuthoritiesDetail
{
    public int AuthoritiesDetailsId { get; set; }

    public int DetailsAuthoritiesId { get; set; }

    public int SrNo { get; set; }

    public string AuthoritiesDetailsDescription { get; set; } = null!;

    public virtual AuthoritiesMaster DetailsAuthorities { get; set; } = null!;
}
