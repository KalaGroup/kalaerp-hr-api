using KalaGenset.ERP.HR.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using KalaGenset.ERP.HR.Core.Request.RolesMaster;

namespace KalaGenset.ERP.HR.Core.Validation.RolesMasterValidation
{
    public class InsertRolesMasterValidator : AbstractValidator<InsertRolesMasterRequest>
    {
        private readonly KalaDbContext _context;
        public InsertRolesMasterValidator(KalaDbContext context)
        {
            _context = context;
            RuleFor(x => x.RolesDesignationId)
                .GreaterThan(0).WithMessage("Roles Designation ID must be greater than 0.");
            RuleFor(x => x.RolesRemark)
                .NotEmpty().WithMessage("Roles Remark is required.")
                .MaximumLength(500).WithMessage("Roles Remark cannot exceed 500 characters.");

            //RuleFor(x => x.RolesAuthRemark)
            //    .NotEmpty()
            //    .WithMessage("Roles Auth Remark is required.")
            //    .MaximumLength(500).WithMessage("Roles Auth Remark cannot exceed 500 characters.");
            RuleFor(x => x.RolesRemark)
       .Matches(@"^[a-zA-Z]*$").WithMessage("Role remark contains invalid characters.")
       .MaximumLength(500).WithMessage("Role remark cannot exceed 500 characters.");
            RuleFor(x => x.RolesAuthRemark)
     .Matches(@"^[a-zA-Z]*$").WithMessage("Role remark contains invalid characters.")
     .MaximumLength(500).WithMessage("KPA remark cannot exceed 500 characters.");


        }

    }

}
