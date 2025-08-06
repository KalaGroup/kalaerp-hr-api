using FluentValidation;
using KalaGenset.ERP.HR.Core.Request.StateRequest;
using KalaGenset.ERP.HR.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Validation.StateValidator
{
    public class UpdateStateValidator : AbstractValidator<UpdateStateRequest>
    {
        private readonly KalaDbContext _context;

        public UpdateStateValidator(KalaDbContext context)
        {
            _context = context;

            // Primary key check for update
            RuleFor(x => x.StateId)
                .GreaterThan(0).WithMessage("StateId is required for update.");

            // Foreign key checks
            RuleFor(x => x.CountryId)
                .GreaterThan(0).WithMessage("Country ID must be greater than 0.");

            RuleFor(x => x.StateCode)
                .NotEmpty().WithMessage("State code is required.")
                .Length(3, 10).WithMessage("State code must be between 3 and 10 characters.")
                .Matches("^[A-Z0-9]*$").WithMessage("State code must be uppercase alphanumeric only.")
                .MustAsync(BeUniqueStateCodeForUpdate).WithMessage("State code already exists for another Country.");

            RuleFor(x => x.StateName)
                .NotEmpty().WithMessage("State name is required.")
                .MaximumLength(100).WithMessage("State name cannot exceed 100 characters.")
                .Matches("^[a-zA-Z0-9 -]*$").WithMessage("State name must not contain special characters.")
                .Must(BeProperCase).WithMessage("State name must be in proper case (e.g., 'Mumbai', 'New Delhi').");

            RuleFor(x => x.ShortName)
                .NotEmpty().WithMessage("State short name is required.")
                .MaximumLength(10).WithMessage("Short name cannot exceed 10 characters.")
                .Matches("^[A-Z0-9]*$").WithMessage("Short name must be uppercase and alphanumeric.");


            RuleFor(x => x.CreatedBy)
                .NotEmpty().WithMessage("CreatedBy is required.");

            RuleFor(x => x.CreatedDate)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Created date can't be in the future.");
        }


        private async Task<bool> BeUniqueStateCodeForUpdate(UpdateStateRequest model, string stateCode, CancellationToken cancellationToken)
        {
            return !await _context.StateMasters
                .AnyAsync(c => c.StateCode == stateCode && c.StateId != model.StateId, cancellationToken);
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

