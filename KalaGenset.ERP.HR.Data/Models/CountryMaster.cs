using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class CountryMaster
{
    public int CountryId { get; set; }

    public string CountryCode { get; set; } = null!;

    public string CountryName { get; set; } = null!;

    public string CountryShortName { get; set; } = null!;

    public int CountryCurrencyId { get; set; }

    public bool IsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual ICollection<CityMaster> CityMasters { get; set; } = new List<CityMaster>();

    public virtual CurrencyMaster CountryCurrency { get; set; } = null!;

    public virtual ICollection<DistrictMaster> DistrictMasters { get; set; } = new List<DistrictMaster>();

    public virtual ICollection<StateMaster> StateMasters { get; set; } = new List<StateMaster>();
}
