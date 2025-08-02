using FluentValidation;
using KalaGenset.ERP.HR.Core.Request.City;
using KalaGenset.ERP.HR.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Validation.CityMasterValidation
{
    public class InsertCityRequestValidatior : AbstractValidator<InsertCityRequest>
    {
        private readonly KalaDbContext _context;
        public InsertCityRequestValidatior(KalaDbContext context)
        {
            _context = context;

            RuleFor(x => x.CityCode)
               .MustAsync(BeUniqueCityCode).WithMessage("City Code must be unique Beacuse City Name already Exists")
               .NotEmpty().WithMessage("City Code is required.")
               .MaximumLength(50).WithMessage("City Code cannot exceed 50 characters.")
            .Matches("^[A-Z0-9]*$").WithMessage("City code must be uppercase alphanumeric only.")
            .Length(3, 10).WithMessage("City code must be between 3 and 10 characters.");

            RuleFor(x => x.CityCountryId)
                .GreaterThan(0).WithMessage("Country ID must be greater than 0.");

            RuleFor(x => x.CityStateId)
                .GreaterThan(0).WithMessage("State ID must be greater than 0.");

            RuleFor(x => x.CityDistrictId)
                .GreaterThan(0).WithMessage("District ID must be greater than 0.");             

            RuleFor(x => x.CityName)
                .NotEmpty().WithMessage("City name is required.")
                .MaximumLength(100).WithMessage("City name cannot exceed 100 characters.")
                .Matches("^[a-zA-Z0-9 -]*$").WithMessage("City name must not contain special characters.")
                .Must(BeProperCase).WithMessage("City name must be in proper case (e.g., 'Mumbai', 'New Delhi').");

            RuleFor(x => x.CityShortName)
                .NotEmpty().WithMessage("City short name is required.")
                .MaximumLength(10).WithMessage("Short name cannot exceed 10 characters.");

            RuleFor(x => x.CityTierTypeId)
                .GreaterThan(0).WithMessage("Tier Type ID is required.");

            RuleFor(x => x.CityRemark)
                .NotEmpty().WithMessage("Remark is required.");

            RuleFor(x => x.CreatedBy)
                .GreaterThan(0).WithMessage("CreatedBy is required.");

            RuleFor(x => x.CreatedDate)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Created date can't be in the future.");

            RuleFor(x => x.CityLatitude)
                .GreaterThan(0).WithMessage("Latitude  must be greater than 0.");
            RuleFor(x => x.CityLongitude)
                .GreaterThan(0).WithMessage("Longitude  must be greater than 0.");
        }

        private async Task<bool> BeUniqueCityCode(string CityCode, CancellationToken cancellationToken)
        {
            return !await _context.CityMasters
                .AnyAsync(c => EF.Functions.Like(c.CityCode, CityCode), cancellationToken);
        }

        
        private bool BeProperCase(string cityName)
        {
            if (string.IsNullOrWhiteSpace(cityName))
                return false;

            var words = cityName.Split(new[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in words)
            {
                if (!char.IsUpper(word[0]))
                    return false;

                for (int i = 1; i < word.Length; i++)
                {
                    if (char.IsLetter(word[i]) && char.IsUpper(word[i]))
                    {
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
