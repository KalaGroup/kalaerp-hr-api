using FluentValidation;
using KalaGenset.ERP.HR.Core.Request.RolesMaster;
using KalaGenset.ERP.HR.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Validation.RolesMasterValidation
{
    public class UpdateRolesMasterValidator : AbstractValidator<UpdateRolesMasterRequest>
    {
        private readonly KalaDbContext _context;
        public UpdateRolesMasterValidator(KalaDbContext context)
        {
            _context = context;
            RuleFor(x => x.RolesId)
                .GreaterThan(0).WithMessage("Roles ID must be greater than 0.");
            RuleFor(x => x.RolesDesignationId)
                .GreaterThan(0).WithMessage("Roles Designation ID must be greater than 0.");
            RuleFor(x => x.RolesRemark)
                .NotEmpty().WithMessage("Roles Remark is required.")
                .MaximumLength(500).WithMessage("Roles Remark cannot exceed 500 characters.");
          
            RuleFor(x => x.RolesAuthRemark)
                .NotEmpty().WithMessage("Roles Auth Remark is required.")
                .MaximumLength(500).WithMessage("Roles Auth Remark cannot exceed 500 characters.");
            RuleFor(x => x.RolesIsDiscard)
                .NotNull().WithMessage("Roles Is Discard must be specified.");
            RuleFor(x => x.CreatedBy)
                .GreaterThan(0).WithMessage("Updated By must be greater than 0.");
            RuleFor(x => x.CreatedDate)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Updated date can't be in the future.");
        }
    }
}
