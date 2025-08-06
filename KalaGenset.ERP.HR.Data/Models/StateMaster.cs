using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class StateMaster
{
    public int StateId { get; set; }

    public int CountryId { get; set; }

    public string StateCode { get; set; } = null!;

    public string StateName { get; set; } = null!;

    public string ShortName { get; set; } = null!;

    public bool IsDiscard { get; set; }

    public bool IsActive { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public virtual ICollection<CityMaster> CityMasters { get; set; } = new List<CityMaster>();

    public virtual CountryMaster Country { get; set; } = null!;

    public virtual ICollection<DistrictMaster> DistrictMasters { get; set; } = new List<DistrictMaster>();
}
