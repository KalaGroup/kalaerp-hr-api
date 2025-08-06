using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class CompanyMaster
{
    public int CompanyId { get; set; }

    public string CompanyCode { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public string? ShortName { get; set; }

    public string? RegisteredAddress { get; set; }

    public int RegisteredCountryId { get; set; }

    public int RegisteredStateId { get; set; }

    public int RegisteredDistrictId { get; set; }

    public int RegisteredCityId { get; set; }

    public string RegisteredPinCode { get; set; } = null!;

    public string? CorporateAddress { get; set; }

    public int? CorporateCountryId { get; set; }

    public int? CorporateStateId { get; set; }

    public int? CorporateDistrictId { get; set; }

    public int? CorporateCityId { get; set; }

    public string? CorporatePinCode { get; set; }

    public string? PhoneNumber { get; set; }

    public string EmailId { get; set; } = null!;

    public string? Website { get; set; }

    public string? SocialMedialink { get; set; }

    public string? Pan { get; set; }

    public string? Gst { get; set; }

    public string? Cin { get; set; }

    public DateOnly? EstablishedDate { get; set; }

    public int? CompanyMasterEntityTypeId { get; set; }

    public int? ParentCompanyId { get; set; }

    public decimal OwnershipPercentage { get; set; }

    public int CompanyCurrencyId { get; set; }

    public DateOnly FiscalYearStart { get; set; }

    public byte[]? Logo { get; set; }

    public bool AiinsightsEnabled { get; set; }

    public string PredictiveAnalyticsLevel { get; set; } = null!;

    public bool InterCompanyTransactions { get; set; }

    public decimal? LocationAdvantageScore { get; set; }

    public decimal? TalentAccessibilityScore { get; set; }

    public decimal? CostEfficiencyRating { get; set; }

    public string CompanyRemark { get; set; } = null!;

    public bool CompanyIsAuth { get; set; }

    public bool CompanyIsDiscard { get; set; }

    public bool CompanyIsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual ICollection<ProfitcenterMaster> ProfitcenterMasters { get; set; } = new List<ProfitcenterMaster>();
}
