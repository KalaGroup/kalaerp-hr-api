using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class DistrictMaster
{
    public int DistrictId { get; set; }

    public int CountryId { get; set; }

    public int StateId { get; set; }

    public string DistrictCode { get; set; } = null!;

    public string DistrictName { get; set; } = null!;

    public string ShortName { get; set; } = null!;

    public bool IsDiscard { get; set; }

    public bool IsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }
}
