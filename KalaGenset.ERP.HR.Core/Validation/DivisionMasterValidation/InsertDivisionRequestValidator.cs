using FluentValidation;
using KalaGenset.ERP.HR.Core.Request.DivisionMaster;
using KalaGenset.ERP.HR.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace KalaGenset.ERP.HR.Core.Validation.DivisionMasterValidation
{
    public class InsertDivisionRequestValidator : AbstractValidator<InsertDivisionMasterRequest>
    {
        private readonly KalaDbContext _context;
        public InsertDivisionRequestValidator(KalaDbContext context)
        {
            _context = context;

            RuleFor(x => x.DivisionCode)
                .NotEmpty().WithMessage("Division Code is required.")
                .MaximumLength(10).WithMessage("Division Code cannot be longer than 10 characters.")
                .Matches("^[a-zA-Z0-9]*$").WithMessage("Division Code must not contain special characters.");

            RuleFor(x => x.DivisionName)
                .NotEmpty().WithMessage("Division Name is required.")
                .MaximumLength(100).WithMessage("Division Name cannot be longer than 100 characters.")
                .Matches("^[a-zA-Z ]*$").WithMessage("Division Name must not contain special characters.")
                .MustAsync(BeUniqueDivisionName).WithMessage("Division Name already exists.");

            RuleFor(x => x.DivisionShortName)
                .NotEmpty().WithMessage("Division Short Name is required.")
                .MaximumLength(100).WithMessage("Division Short Name cannot be longer than 100 characters.")
                .Matches("^[a-zA-Z]*$").WithMessage("Division Short Name must not contain special characters.")
                .MustAsync(BeUniqueDivisionShortName).WithMessage("Division Short Name already exists.");

            RuleFor(x => x.DivisionMailId)
                .NotEmpty().WithMessage("Division Mail ID is required.")
                .EmailAddress().WithMessage("Division Mail ID must be a valid email address.");

            RuleFor(x => x.CreatedBy)
                .NotEmpty().WithMessage("CreatedBy is required.")
                .Must(value => int.TryParse(value.ToString(), out _)).WithMessage("CreatedBy must be a number.");



        }

        private async Task<bool> BeUniqueDivisionName(string DivisionName, CancellationToken cancellationToken)
        {
            return !await _context.DivisionMasters
                .AnyAsync(c => EF.Functions.Like(c.DivisionName, DivisionName), cancellationToken);
        }

        private async Task<bool> BeUniqueDivisionShortName(string DivisionShortName, CancellationToken cancellationToken)
        {
            return !await _context.DivisionMasters
                .AnyAsync(c => EF.Functions.Like(c.DivisionShortName, DivisionShortName), cancellationToken);
        }
    }
}

