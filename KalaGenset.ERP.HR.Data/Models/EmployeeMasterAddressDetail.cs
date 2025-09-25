using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class EmployeeMasterAddressDetail
{
    public int EmployeeMasterAddressDetailsId { get; set; }

    public int AddressDetailsEmployeeMasterId { get; set; }

    public string AddressDetailsEmployeeMasterPresentAdress { get; set; } = null!;

    public int AddressDetailsEmployeeMasterPresentCountryId { get; set; }

    public int AddressDetailsEmployeeMasterPresentStateId { get; set; }

    public int AddressDetailsEmployeeMasterPresentDistrictId { get; set; }

    public int AddressDetailsEmployeeMasterPresentCitytId { get; set; }

    public int AddressDetailsEmployeeMasterPresentPinCode { get; set; }

    public bool AddressDetailsEmployeeMasterPemanantAddresssameAsPresent { get; set; }

    public string AddressDetailsEmployeeMasterPermanantAdress { get; set; } = null!;

    public int AddressDetailsEmployeeMasterPermanantCountryId { get; set; }

    public int AddressDetailsEmployeeMasterPermanantStateId { get; set; }

    public int AddressDetailsEmployeeMasterPermanantDistrictId { get; set; }

    public int AddressDetailsEmployeeMasterPermanantCityId { get; set; }

    public int AddressDetailsEmployeeMasterPermanantPinCode { get; set; }

    public string AddressDetailsEmployeeMasterAuthRemark { get; set; } = null!;

    public bool AddressDetailsEmployeeMasterAuth { get; set; }

    public DateTime UpdatedDate { get; set; }

    public int UpdatedBy { get; set; }

    public virtual EmployeeMasterPersonalDetail AddressDetailsEmployeeMaster { get; set; } = null!;

    public virtual CityMaster AddressDetailsEmployeeMasterPermanantCity { get; set; } = null!;

    public virtual CountryMaster AddressDetailsEmployeeMasterPermanantCountry { get; set; } = null!;

    public virtual StateMaster AddressDetailsEmployeeMasterPermanantState { get; set; } = null!;

    public virtual CityMaster AddressDetailsEmployeeMasterPresentCityt { get; set; } = null!;

    public virtual CountryMaster AddressDetailsEmployeeMasterPresentCountry { get; set; } = null!;

    public virtual DistrictMaster AddressDetailsEmployeeMasterPresentDistrict { get; set; } = null!;

    public virtual StateMaster AddressDetailsEmployeeMasterPresentState { get; set; } = null!;

    public virtual UserLogin UpdatedByNavigation { get; set; } = null!;
}
