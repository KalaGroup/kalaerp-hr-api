using FluentValidation;
using KalaERP.HR.Core.Request.DesignationMaster;
using KalaGenset.ERP.HR.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace KalaERP.HR.Core.Validation.DesignationMaster
{
    public class UpdateDesignationValidator: AbstractValidator<UpdateDesignationMasterRequest>
    {
        private readonly KalaDbContext context;
        public UpdateDesignationValidator(KalaDbContext context)
        {
            this.context = context;

            RuleFor(x => x.DesignationCode)
                .NotEmpty().WithMessage("Designation Code is required.")
                           .Matches("^[A-Za-z0-9]*$").WithMessage("Code must contain only letters and numbers, no special characters.")

                .MaximumLength(20).WithMessage("Designation Code cannot exceed 20 characters.")
                .MustAsync(BeUniqueDesignationCode).WithMessage("Designation Code must be unique.");

            RuleFor(x => x.DesignationName)
                .NotEmpty().WithMessage("Designation Name is required.")
                .MaximumLength(200).WithMessage("Designation Name cannot exceed 200 characters.")
                    .Matches("^[A-Za-z ]+$")
   .WithMessage("Designation name must contain only letters.");

            RuleFor(x => x.DesignationDescription)
                .MaximumLength(500).WithMessage("Designation Description cannot exceed 500 characters.");
        }

        private async Task<bool> BeUniqueDesignationCode(UpdateDesignationMasterRequest dto, string designationCode, CancellationToken token)
        {
            return !await context.DesignationMasters
                .AnyAsync(d =>
                    d.DesignationCode == designationCode &&
                    d.DesignationId != dto.DesignationId, token);
        }

    }
}
