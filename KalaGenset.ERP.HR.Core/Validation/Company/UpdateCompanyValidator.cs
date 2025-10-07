using FluentValidation;
using KalaERP.HR.Core.Request.CompanyMaster;
using KalaGenset.ERP.HR.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace KalaERP.HR.Core.Validation.Company
{
    /// <summary>
    /// validates the UpdateCompanyRequest for updating an existing company.
    /// checks for unique company code and email ID, and validates other fields.
    /// </summary>
    public class UpdateCompanyValidator : AbstractValidator<UpdateCompanyRequest>
    {
        private readonly KalaDbContext _context;// Database context for accessing company data

        public UpdateCompanyValidator(KalaDbContext context)// Constructor to initialize the context
        {
            _context = context;

            RuleFor(x => x.CompanyId)
                .GreaterThan(0).WithMessage("Company ID must be greater than 0.");

            RuleFor(x => x.CompanyCode)
               .NotEmpty().WithMessage("Company Code is required.");
            //    .MaximumLength(20).WithMessage("Company Code cannot exceed 20 characters.")
            //    .MustAsync(BeUniqueCompanyCode).WithMessage("Company Code must be unique.");

            RuleFor(x => x.CompanyName)
                .NotEmpty().WithMessage("Company Name is required.")
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
        /// <summary>
        /// validates that the company code is unique in the database.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="companyCode"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        private async Task<bool> BeUniqueCompanyCode(UpdateCompanyRequest request, string companyCode, CancellationToken token)
        {
            return !await _context.CompanyMasters
                .AnyAsync(c => c.CompanyCode == companyCode && c.CompanyId != request.CompanyId, token);
        }

        private async Task<bool> BeUniqueEmailId(UpdateCompanyRequest request, string emailId, CancellationToken token)
        {
            return !await _context.CompanyMasters
                .AnyAsync(c => c.EmailId == emailId && c.CompanyId != request.CompanyId, token);
        }
    }
}
