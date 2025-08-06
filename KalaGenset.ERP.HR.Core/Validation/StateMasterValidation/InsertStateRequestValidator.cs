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
    public class InsertStateRequestValidator : AbstractValidator<InsertStateRequest>
    {
        private readonly KalaDbContext _context;
        public InsertStateRequestValidator(KalaDbContext context)
        {
            _context = context;

            //RuleFor(x => x.CountryId)
            //    .NotEmpty().WithMessage("Country ID is required.")
            //    .MaximumLength(10)
            //    .Matches("^[a-zA-Z0-9]*$").WithMessage("Country ID must not contain special characters.");

            RuleFor(x => x.StateCode)
                .NotEmpty().WithMessage("State Code is required.")
                .MaximumLength(10)
                .Matches("^[a-zA-Z0-9]*$").WithMessage("State Code must not contain special characters.");

            RuleFor(x => x.StateName)
                .NotEmpty().WithMessage("State name is required.")
                .MustAsync(BeUniqueStateName).WithMessage("State name already exists.")
                .Matches("^[a-zA-Z0-9 ]*$").WithMessage("State name must not contain special characters.")
                .MaximumLength(100);

            RuleFor(x => x.ShortName)
                .NotEmpty().WithMessage("State short name is required.")
                .Matches("^[a-zA-Z0-9]*$").WithMessage("State short name must not contain special characters.")
                .MaximumLength(10);

            RuleFor(x => x.CreatedBy)
                .NotEmpty().WithMessage("CreatedBy is required.");

            RuleFor(x => x.CreatedDate)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Created date can't be in the future.");
        }

        private async Task<bool> BeUniqueStateName(string stateName, CancellationToken cancellationToken)
        {
            return !await _context.StateMasters
                .AnyAsync(c => EF.Functions.Like(c.StateName, stateName), cancellationToken);
        }
    }
}
