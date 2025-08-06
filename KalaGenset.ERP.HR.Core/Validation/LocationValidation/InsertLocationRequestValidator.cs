using FluentValidation;
using KalaGenset.ERP.HR.Core.Request.LocationRequest;
using KalaGenset.ERP.HR.Core.Request.QualificationRequest;
using KalaGenset.ERP.HR.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Validation.LocationValidator
{
    public class InsertLocationRequestValidator : AbstractValidator<InsertLocationRequest>
    {
        private readonly KalaDbContext _context;
        public InsertLocationRequestValidator(KalaDbContext context)
        {
            _context = context;

            RuleFor(x => x.LocationCode)
                    .NotEmpty().WithMessage("Location Code is required.")
                    .MaximumLength(10)
                    .Matches("^[a-zA-Z0-9]*$").WithMessage("Location Code must not contain special characters.");

            RuleFor(x => x.LocationName)
                    .NotEmpty().WithMessage("Location name is required.")
                    .MustAsync(BeUniqueStateName).WithMessage("Location name already exists.")
                    .Matches("^[a-zA-Z0-9 ]*$").WithMessage("Location name must not contain special characters.")
                    .MaximumLength(100);

            RuleFor(x => x.LocationType)
                .NotEmpty().WithMessage("LocationType is required.")
                .MaximumLength(10)
                .Matches("^[a-zA-Z0-9]*$").WithMessage("LocationType must not contain special characters.");

            RuleFor(x => x.CreatedBy)
                .NotEmpty().WithMessage("CreatedBy is required.")
                .GreaterThan(0).WithMessage("CreatedBy must be a positive number.");
        }

        private async Task<bool> BeUniqueStateName(string locationName, CancellationToken cancellationToken)
        {
            return !await _context.LocationMasters
                .AnyAsync(c => EF.Functions.Like(c.LocationName, locationName), cancellationToken);
        }
    }
}