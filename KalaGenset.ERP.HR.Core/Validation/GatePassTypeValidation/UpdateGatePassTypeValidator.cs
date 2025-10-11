using FluentValidation;
using KalaGenset.ERP.HR.Core.Request.GatePassType;
using KalaGenset.ERP.HR.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Validation.GatePassTypeValidation
{
    public class UpdateGatePassTypeValidator : AbstractValidator<UpdateGatePassTypeRequest>
    {
        private readonly KalaDbContext _context;

        public UpdateGatePassTypeValidator(KalaDbContext context)
        {
            _context = context;

            RuleFor(x => x.GatePassTypeId)
                .NotEmpty().WithMessage("GatePassTypeId is required.")
                .MustAsync(async (id, cancellationToken) =>
                    await _context.GatePassTypes.AnyAsync(c => c.GatePassTypeId == id, cancellationToken))
                .WithMessage("GatePassType does not exist.");

            RuleFor(x => x.GatePassTypesTypeCode)
                .NotEmpty().WithMessage("GatePassType Code is required.")
                .MaximumLength(10).WithMessage("GatePassType Code must not exceed 10 characters.")
                .Matches("^[a-zA-Z0-9]*$").WithMessage("GatePassType Code must not contain special characters.")
                .MustAsync(async (request, code, cancellationToken) =>
                    !await _context.GatePassTypes.AnyAsync(c =>
                        c.GatePassTypesTypeCode == code && c.GatePassTypeId != request.GatePassTypeId, cancellationToken))
                .WithMessage("GatePassType Code already exists.");

            RuleFor(x => x.GatePassTypesTypeName)
                .NotEmpty().WithMessage("GatePassType Name is required.")
                .MaximumLength(100).WithMessage("GatePassType Name must not exceed 100 characters.")
                .Matches("^[a-zA-Z0 ]*$").WithMessage("GatePassType Name must not contain special characters.")
                .MustAsync(async (request, name, cancellationToken) =>
                    !await _context.GatePassTypes.AnyAsync(c =>
                        c.GatePassTypesTypeName == name && c.GatePassTypeId != request.GatePassTypeId, cancellationToken));
              

            RuleFor(x => x.GatePassTypesDescription)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(250).WithMessage("Description must not exceed 250 characters.");

            RuleFor(x => x.UpdatedBy)
                .NotEmpty().WithMessage("UpdatedBy is required.");
        }
    }
}
