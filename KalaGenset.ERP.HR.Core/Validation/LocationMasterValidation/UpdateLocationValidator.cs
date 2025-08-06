using FluentValidation;
using KalaGenset.ERP.HR.Core.Request.LocationRequest;
using KalaGenset.ERP.HR.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Validation.LocationValidator
{
    public class UpdateLocationValidator : AbstractValidator<UpdateLocationRequest>
    {
        private readonly KalaDbContext _context;

        public UpdateLocationValidator(KalaDbContext context)
        {
            _context = context;

            // Primary key check for update
            RuleFor(x => x.LocationId)
                .GreaterThan(0).WithMessage("Location Id is required for update.");

            RuleFor(x => x.LocationCode)
                .NotEmpty().WithMessage("Location code is required.")
                .Matches("^[A-Z0-9]*$").WithMessage("Location code must be uppercase alphanumeric only.")
                .MustAsync(BeUniqueLocationCodeForUpdate).WithMessage("Location code already exists for another Country.");

            RuleFor(x => x.LocationName)
                .NotEmpty().WithMessage("Location name is required.")
                .MaximumLength(100).WithMessage("Location name cannot exceed 100 characters.")
                .Matches("^[a-zA-Z0-9 -]*$").WithMessage("Location name must not contain special characters.");

            RuleFor(x => x.ProfitcenterLocationId)
                 .GreaterThan(0).WithMessage("Profitcenter Location Id is required")
                .NotEmpty().WithMessage("ProfitcenterLocationId is required.");

            RuleFor(x => x.LocationType)
                .NotEmpty().WithMessage("Location Type is required.")
                .MaximumLength(100).WithMessage("Location Type cannot exceed 100 characters.")
                .Matches("^[a-zA-Z0-9 -]*$").WithMessage("Location Type must not contain special characters.");

            RuleFor(x => x.CreatedBy)
                .NotEmpty().WithMessage("CreatedBy is required.");
        }


        private async Task<bool> BeUniqueLocationCodeForUpdate(UpdateLocationRequest model, string locationCode, CancellationToken cancellationToken)
        {
            return !await _context.LocationMasters
                .AnyAsync(c => c.LocationCode == locationCode && c.LocationId != model.LocationId, cancellationToken);

        }


    }
}
