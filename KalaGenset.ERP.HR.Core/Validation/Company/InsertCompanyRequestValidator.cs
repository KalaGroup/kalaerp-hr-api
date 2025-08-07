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

            RuleFor(x => x.CompanyCode)
                .NotEmpty().WithMessage("Company Code is required.")
                .MaximumLength(20).WithMessage("Company Code cannot exceed 20 characters.")
                .MustAsync(BeUniqueCompanyCode).WithMessage("Company Code must be unique.");

            RuleFor(x => x.CompanyName)
                .NotEmpty().WithMessage("Company Name is required.")
                .MaximumLength(200).WithMessage("Company Name cannot exceed 200 characters.");

            RuleFor(x => x.EmailId)
                .NotEmpty().WithMessage("Email ID is required.")
                .EmailAddress().WithMessage("Invalid Email ID format.")
                .MaximumLength(100).WithMessage("Email ID cannot exceed 100 characters.")
                .MustAsync(BeUniqueEmailId).WithMessage("Email ID must be unique.");

            RuleFor(x => x.RegisteredCountryId)
               .GreaterThan(0).WithMessage("Registered Country ID must be greater than 0.");

            RuleFor(x => x.CorporateAddress)
                .MaximumLength(500).WithMessage("Corporate Address cannot exceed 100 characters.");

            RuleFor(x => x.RegisteredAddress)
                .MaximumLength(500).WithMessage("Registered Address cannot exceed 100 characters.");

            RuleFor(x => x.ShortName)
                .MaximumLength(50).WithMessage("Short Name cannot exceed 50 characters.")
                .Matches(@"^[a-zA-Z0-9\s]*$").WithMessage("Short Name must not contain special characters or spaces.");
           
            RuleFor(x => x.Website)
                .MaximumLength(100).WithMessage("Website cannot exceed 100 characters.")
                .Matches(@"^(https?://)?([\da-z.-]+)\.([a-z.]{2,6})([/\w .-]*)*/?$").WithMessage("Invalid Website format.");

            RuleFor(x => x.SocialMedialink)
                .MaximumLength(100).WithMessage("Social Media link cannot exceed 100 characters.");
                //.Matches(@"^(https?://)?([\da-z.-]+)\.([a-z.]{2,6})([/\w .-]*)*/?$").WithMessage("Invalid Social Media link format.");
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
