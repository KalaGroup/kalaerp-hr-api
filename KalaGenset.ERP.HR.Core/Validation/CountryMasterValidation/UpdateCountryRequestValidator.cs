using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using KalaGenset.ERP.HR.Core.Request.Country;
using KalaGenset.ERP.HR.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace KalaGenset.ERP.HR.Core.Validation.CountryValidation
{
    public class UpdateCountryRequestValidator : AbstractValidator<UpdateCountryRequest>
    {
        private readonly KalaDbContext _context;
        public UpdateCountryRequestValidator(KalaDbContext context)
        {
            _context = context;
            RuleFor(x => x.CountryId)
                .GreaterThan(0).WithMessage("Country ID must be greater than 0.")
                .MustAsync(CountryMustExist).WithMessage("Country with this ID does not exist.");
            RuleFor(x => x.CountryCode)
                .MustAsync(BeUniqueCountryCodeForUpdate).WithMessage("Country code already exists for another country. Enter a unique code.")
                .NotEmpty().WithMessage("Country code is required.")
                .Length(3).WithMessage("Country CountryCode must be exactly 3 characters long.")
                .Matches("^[0-9]*$").WithMessage("Country code must be exactly 3 numeric digits (e.g., '001', '002') & must not contain special characters.");
            RuleFor(x => x.CountryName)
                .NotEmpty().WithMessage("Country name is required.")
                .Matches("^[a-zA-Z0-9 -]*$").WithMessage("Country name must not contain special characters.")
                .MaximumLength(100).WithMessage("Country name cannot exceed 100 characters.")
                .Must(BeProperCase).WithMessage("Country name must be in proper case (e.g., 'India', 'United States', 'Sri-Lanka').");
            RuleFor(x => x.CountryShortName)
                .NotEmpty().WithMessage("Country short name is required.")
                .Matches("^[A-Z0-9]*$").WithMessage("Country short name must be uppercase and must not contain special characters.")
                .MaximumLength(10).WithMessage("Country Short Name cannot exceed 10 characters.");
            RuleFor(x => x.CountryCurrencyId)
                .GreaterThan(0).WithMessage("Currency ID must be greater than 0.");
            RuleFor(x => x.CreatedBy)
                .NotEmpty().WithMessage("CreatedBy is required.");
            RuleFor(x => x.CreatedDate)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Created date can't be in the future.");
        }
        private async Task<bool> CountryMustExist(int countryId, CancellationToken cancellationToken)
        {
            return await _context.CountryMasters
                .AnyAsync(c => c.CountryId == countryId, cancellationToken);
        }
        private async Task<bool> BeUniqueCountryCodeForUpdate(UpdateCountryRequest request, string countryCode, CancellationToken cancellationToken)
        {
            return !await _context.CountryMasters
                .AnyAsync(c =>
                    c.CountryCode == countryCode &&
                    c.CountryId != request.CountryId, cancellationToken);
        }
        private bool BeProperCase(string countryName)
        {
            if (string.IsNullOrWhiteSpace(countryName))
                return false;
            // Split by space and hyphen to check each word
            var words = countryName.Split(new char[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in words)
            {
                if (string.IsNullOrEmpty(word))
                    continue;
                // First character should be uppercase
                if (!char.IsUpper(word[0]))
                    return false;
                // Remaining characters should be lowercase (except for abbreviations)
                for (int i = 1; i < word.Length; i++)
                {
                    // Allow uppercase only if it's part of a known pattern (like McName, O'Name)
                    // For simplicity, we'll check if all remaining characters are lowercase
                    if (char.IsLetter(word[i]) && char.IsUpper(word[i]))
                    {
                        // Allow uppercase if previous character is apostrophe or if it's a known pattern
                        if (i > 0 && (word[i - 1] == '\'' || word.Substring(0, 2).ToLower() == "mc"))
                            continue;
                        else
                            return false;
                    }
                }
            }
            return true;
        }
    }
}
