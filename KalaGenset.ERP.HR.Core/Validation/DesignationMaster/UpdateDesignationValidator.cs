using FluentValidation;
using KalaERP.HR.Core.Request.DesignationMaster;
using KalaGenset.ERP.HR.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                .MaximumLength(20).WithMessage("Designation Code cannot exceed 20 characters.")
                .MustAsync(BeUniqueDesignationCode).WithMessage("Designation Code must be unique.");

            RuleFor(x => x.DesignationName)
                .NotEmpty().WithMessage("Designation Name is required.")
                .MaximumLength(200).WithMessage("Designation Name cannot exceed 200 characters.");

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
