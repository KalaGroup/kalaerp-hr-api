using FluentValidation;
using KalaGenset.ERP.HR.Core.Request.GatePassType;
using KalaGenset.ERP.HR.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace KalaGenset.ERP.HR.Core.Validation.GatePassTypeValidation
{

    public class InsertGatePassTypeValidator : AbstractValidator<InsertGatePassTypeRequest>
    {
        private readonly KalaDbContext _context;

        public InsertGatePassTypeValidator(KalaDbContext context)
        {
            _context = context;

            RuleFor(x => x.GatePassTypesTypeCode)
                .NotEmpty().WithMessage("GatePassType Code is required.")
                .MaximumLength(10).WithMessage("GatePassType Code must not exceed 10 characters.")
                .Matches("^[a-zA-Z0-9]*$").WithMessage("GatePassType Code must not contain special characters.")
                .MustAsync(BeUniqueGatePassTypeCode).WithMessage("GatePassType Code already exists.");

            RuleFor(x => x.GatePassTypesTypeName)
                .NotEmpty().WithMessage("GatePassType Name is required.")
                .MaximumLength(100).WithMessage("GatePassType Name must not exceed 100 characters.")
                .Matches("^[a-zA-Z ]*$").WithMessage("GatePassType Name must not contain special characters.")
                .MustAsync(BeUniqueGatePassTypeName).WithMessage("GatePassType Name already exists.");

            RuleFor(x => x.GatePassTypesDescription)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(250).WithMessage("Description must not exceed 250 characters.");

            RuleFor(x => x.CreatedBy)
                .NotEmpty().WithMessage("CreatedBy is required.");
        }

        private async Task<bool> BeUniqueGatePassTypeCode(string code, CancellationToken cancellationToken)
        {
            return !await _context.GatePassTypes
                .AnyAsync(c => EF.Functions.Like(c.GatePassTypesTypeCode, code), cancellationToken);
        }

        private async Task<bool> BeUniqueGatePassTypeName(string name, CancellationToken cancellationToken)
        {
            return !await _context.GatePassTypes
                .AnyAsync(c => EF.Functions.Like(c.GatePassTypesTypeName, name), cancellationToken);
        }
    }
}
