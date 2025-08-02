using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class CityMaster
{
    public int CityId { get; set; }

    public int CityCountryId { get; set; }

    public int CityStateId { get; set; }

    public int CityDistrictId { get; set; }

    public string CityCode { get; set; } = null!;

    public string CityName { get; set; } = null!;

    public string CityShortName { get; set; } = null!;

    public double? CityLatitude { get; set; }

    public double? CityLongitude { get; set; }

    public int CityTierTypeId { get; set; }

    public string CityRemark { get; set; } = null!;

    public bool CityAuth { get; set; }

    public bool CityIsDiscard { get; set; }

    public bool CityIsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }
}
