using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using KalaGenset.ERP.HR.Core.Request.DepartmentBudget;
using KalaGenset.ERP.HR.Data.DbContexts;

namespace KalaGenset.ERP.HR.Core.Validation.DepartmentBudget
{
    public class UpdateDepartmentBudgetRequestValidator : AbstractValidator<UpdateDepartmentBudgetRequest>
    {
        
        private readonly KalaDbContext _context;

        public UpdateDepartmentBudgetRequestValidator(KalaDbContext context)
        {
            _context = context;

            // Primary key check for update
            RuleFor(x => x.DepartmentBudgetId)
                .GreaterThan(0).WithMessage("DepartmentBudget Id is required for update.");

            // Foreign key checks
            RuleFor(x => x.DepartmentBudgetDepartmentId)
                .GreaterThan(0).WithMessage("Department ID must be greater than 0.");

            RuleFor(x => x.DepartmentBudgetHeadId)
                .GreaterThan(0).WithMessage("HeadId must be greater than 0.");

            RuleFor(x => x.DepartmentBudgetAmt)
                          .GreaterThan(0).WithMessage("DepartmentBudget Amount must be greater than 0.")
                          .NotEmpty().WithMessage("DepartmentBudget Amount is required.");
            RuleFor(x => x.DepartmentBudgetAuthRemark)
    .Matches(@"^[a-zA-Z]*$").WithMessage("DepartmentBudget remark contains invalid characters.")
    .MaximumLength(500).WithMessage("Department remark cannot exceed 500 characters.");
            RuleFor(x => x.DepartmentBudgetRemark)
     .Matches(@"^[a-zA-Z]*$").WithMessage("DepartmentBudget remark contains invalid characters.")
     .MaximumLength(500).WithMessage("Department remark cannot exceed 500 characters."); ;
        }

    }
}
