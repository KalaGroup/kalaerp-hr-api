using FluentValidation;
using KalaERP.HR.Core.Request.CompanyMaster;

using KalaGenset.ERP.HR.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace KalaERP.HR.Core.Validation.Company
{

    /// <summary>
    /// validates the InsertCompanyRequest for creating a new company.
    /// 
    /// </summary>
    public class InsertCompanyRequestValidator : AbstractValidator<InsertCompanyRequest>
    {
        private readonly KalaDbContext context;

        public InsertCompanyRequestValidator(KalaDbContext context)
        {
            this.context = context;
            
            RuleFor(x => x.CompanyName)
                .NotEmpty().WithMessage("Company Name is required.")
             .Matches("^[A-Za-z ]+$").WithMessage("Company Name must contain only letters.")
                .MaximumLength(200).WithMessage("Company Name cannot exceed 200 characters.");

            RuleFor(x => x.ShortName)
                .MaximumLength(50).WithMessage("Short Name cannot exceed 50 characters.");

            RuleFor(x => x.EmailId)
                .NotEmpty().WithMessage("Email ID is required.")
                .EmailAddress().WithMessage("Invalid Email ID format.")
                .MaximumLength(100).WithMessage("Email ID cannot exceed 100 characters.")
                .MustAsync(BeUniqueEmailId).WithMessage("Email ID must be unique.");

            RuleFor(x => x.RegisteredCountryId)
                .GreaterThan(0).WithMessage("Registered Country ID must be greater than 0.");

            RuleFor(x => x.CorporateAddress)
                .NotEmpty().WithMessage("Corporate Address is required.")
                .MaximumLength(500).WithMessage("Corporate Address cannot exceed 100 characters.");

            RuleFor(x => x.RegisteredAddress)
                .NotEmpty().WithMessage("Registered Address is required.")
                .MaximumLength(500).WithMessage("Registered Address cannot exceed 100 characters.");

            RuleFor(x => x.Pan)
                .NotEmpty().WithMessage("PAN number is required.")
                .MaximumLength(20).WithMessage("PAN number cannot exceed 20 characters.");

            RuleFor(x => x.Gst)
                .NotEmpty().WithMessage("GST number is required.")
                .MaximumLength(20).WithMessage("GST number cannot exceed 20 characters.");

            RuleFor(x => x.Cin)
                .NotEmpty().WithMessage("CIN number is required.")
                .MaximumLength(30).WithMessage("CIN number cannot exceed 30 characters.");

            RuleFor(x => x.Website)
                .MaximumLength(100).WithMessage("Website cannot exceed 100 characters.")
                .Matches(@"^(https?://)?([\da-z.-]+)\.([a-z.]{2,6})([/\w .-]*)*/?$").WithMessage("Invalid Website format.");

            RuleFor(x => x.CompanyMasterEntityTypeId)
                .GreaterThan(0).When(x => x.CompanyMasterEntityTypeId.HasValue)
                .WithMessage("Invalid Company Master Entity Type ID.");


            RuleFor(x => x.RegisteredCountryId)
            .GreaterThan(0).WithMessage("Registered Country ID is required.");

            RuleFor(x => x.RegisteredStateId)
                .GreaterThan(0).WithMessage("Registered State ID is required.");

            RuleFor(x => x.RegisteredDistrictId)
                .GreaterThan(0).WithMessage("Registered District ID is required.");

            RuleFor(x => x.RegisteredCityId)
                .GreaterThan(0).WithMessage("Registered City ID is required.");

            RuleFor(x => x.RegisteredPinCode)
                .NotEmpty().WithMessage("Registered Pin Code is required.");

            RuleFor(x => x.CompanyCurrencyId)
                .GreaterThan(0).WithMessage("Company Currency ID is required.");

            RuleFor(x => x.FiscalYearStart)
                .NotEmpty().WithMessage("Fiscal Year Start is required.");

            RuleFor(x => x.PredictiveAnalyticsLevel)
                .NotEmpty().WithMessage("Predictive Analytics Level is required.");

        }
        private async Task<bool> BeUniqueCompanyCode(string companyCode, CancellationToken token)
        {
            return !await context.CompanyMasters        
                .AnyAsync(c => c.CompanyCode == companyCode, token);
        }
        private async Task<bool> BeUniqueEmailId(string emailId, CancellationToken token)
        {
            return !await context.CompanyMasters
                .AnyAsync(c => c.EmailId == emailId, token);
        }
    }
}
