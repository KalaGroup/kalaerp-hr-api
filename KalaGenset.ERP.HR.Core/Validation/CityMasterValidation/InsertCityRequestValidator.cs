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
    public class InsertCityRequestValidator : AbstractValidator<InsertCityRequest>
    {
        private readonly KalaDbContext _context;
        public InsertCityRequestValidator(KalaDbContext context)
        {
            _context = context;

            RuleFor(x => x.CityCode)
               .NotEmpty().WithMessage("City Code is required.")
               .MaximumLength(50).WithMessage("City Code cannot exceed 10 characters.")
           .Matches("^[A-Za-z0-9]*$").WithMessage("Code must contain only letters and numbers, no special characters.")
            .Length(2, 10).WithMessage("City code must be between 2 and 10 characters.");

            RuleFor(x => x.CityCountryId)
                .GreaterThan(0).WithMessage("Country ID must be greater than 0.");

            RuleFor(x => x.CityStateId)
                .GreaterThan(0).WithMessage("State ID must be greater than 0.");

            RuleFor(x => x.CityDistrictId)
                .GreaterThan(0).WithMessage("District ID must be greater than 0.");
            RuleFor(x => x.CityName)
     .NotEmpty().WithMessage("City name is required.")
     .MaximumLength(100).WithMessage("City name cannot exceed 100 characters.")
     .Matches("^[A-Za-z ]+$").WithMessage("City name must contain only letters and spaces.")
     .MustAsync(BeUniqueCityName).WithMessage("City name must be unique because it already exists.")
     .Must(BeProperCase).WithMessage("City name must be in proper case (e.g., 'Mumbai', 'New Delhi').");



            RuleFor(x => x.CityShortName)
      .NotEmpty().WithMessage("City short name is required.")
      .MaximumLength(10).WithMessage("Short name cannot exceed 10 characters.")
      .Matches("^[a-zA-Z]+$").WithMessage("City short name must be in capital letters.");


            RuleFor(x => x.CityTierTypeId)
                .GreaterThan(0).WithMessage("Tier Type ID is required.");

            RuleFor(x => x.CityRemark)
                .NotEmpty().WithMessage("Remark is required.")
                 .Matches(@"^[a-zA-Z]*$").WithMessage("city remark contains invalid characters.")
    .MaximumLength(500).WithMessage("city remark cannot exceed 500 characters.");

         
            RuleFor(x => x.CityLatitude)
                .GreaterThan(0).WithMessage("Latitude  must be greater than 0.");
            RuleFor(x => x.CityLongitude)
                .GreaterThan(0).WithMessage("Longitude  must be greater than 0.");
        }

        private async Task<bool> BeUniqueCityName(string cityName, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(cityName))
                return false;

            cityName = cityName.Trim();

            return !await _context.CityMasters
                .AnyAsync(c => c.CityName.ToLower() == cityName.ToLower(), cancellationToken);
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
