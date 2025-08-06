using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class LocationMaster
{
    public int LocationId { get; set; }

    public string LocationCode { get; set; } = null!;

    public string LocationName { get; set; } = null!;

    public int ProfitcenterLocationId { get; set; }

    public string LocationRemark { get; set; } = null!;

    public string LocationType { get; set; } = null!;

    public string LocationAuthRemark { get; set; } = null!;

    public bool LocationAuth { get; set; }

    public bool LocationIsDiscard { get; set; }

    public bool LocationIsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual ProfitcenterMaster ProfitcenterLocation { get; set; } = null!;
}
