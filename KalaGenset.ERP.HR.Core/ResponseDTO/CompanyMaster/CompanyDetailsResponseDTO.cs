using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.ResponseDTO.Company
{
    public class CompanyDetailsResponseDTO
    {
        public int CompanyId { get; set; }

        public string CompanyCode { get; set; } = null!;

        public string CompanyName { get; set; } = null!;

        public string? ShortName { get; set; }

        public string? RegisteredAddress { get; set; }

        public string RegisteredCountryName { get; set; } = null!; 

        public string RegisteredStateName { get; set; } = null!; 

        public string RegisteredDistrictName { get; set; } = null!; 

        public string RegisteredCityName { get; set; } = null!; 

        public string RegisteredPinCode { get; set; } = null!;
 
        public string? CorporateAddress { get; set; }

        public string? CorporateCountryName { get; set; } 

        public string? CorporateStateName { get; set; } 

        public string? CorporateDistrictName { get; set; } 

        public string? CorporateCityName { get; set; } 

        public string? CorporatePinCode { get; set; }

        public string? PhoneNumber { get; set; }

        public string EmailId { get; set; } = null!;

        public string? Website { get; set; }

        public string? SocialMedialink { get; set; }

        public string? Pan { get; set; }

        public string? Gst { get; set; }

        public string? Cin { get; set; }

        public DateOnly? EstablishedDate { get; set; }

        public string? CompanyEntityTypeName { get; set; } 

        public string? ParentCompanyName { get; set; } 

        public decimal OwnershipPercentage { get; set; }

        public string CurrencyName { get; set; } = null!;

        public DateOnly FiscalYearStart { get; set; }

        public byte[]? Logo { get; set; }

        public bool AiinsightsEnabled { get; set; }

        public string PredictiveAnalyticsLevel { get; set; } = null!;

        public bool InterCompanyTransactions { get; set; }

        public decimal? LocationAdvantageScore { get; set; }

        public decimal? TalentAccessibilityScore { get; set; }

        public decimal? CostEfficiencyRating { get; set; }

        public string CompanyRemark { get; set; } = null!;

        public string? CompanyRemark2 { get; set; }

        public bool CompanyIsAuth { get; set; }

        public bool CompanyIsDiscard { get; set; }

        public bool CompanyIsActive { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
