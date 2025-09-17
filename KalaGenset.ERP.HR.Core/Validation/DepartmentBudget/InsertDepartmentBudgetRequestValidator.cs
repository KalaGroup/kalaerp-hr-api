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
    public class InsertDepartmentBudgetRequestValidator : AbstractValidator<InsertDepartmentBudgetRequest>
    {
        private readonly KalaDbContext _context;
        public InsertDepartmentBudgetRequestValidator(KalaDbContext context)
        {
            _context = context;

            RuleFor(x => x.DepartmentBudgetAmt)
               .GreaterThan(0).WithMessage("DepartmentBudget Amount must be greater than 0.")
               .NotEmpty().WithMessage("DepartmentBudget Amount is required.");

            RuleFor(x => x.DepartmentBudgetDepartmentId)
               .GreaterThan(0).WithMessage("DepartmentBudget ID must be greater than 0.")
               .NotEmpty().WithMessage("DepartmentBudget ID is required.");

            RuleFor(x => x.DepartmentBudgetHeadId)
                .GreaterThan(0).WithMessage("DepartmentBudgetHead ID must be greater than 0.")
                .NotEmpty().WithMessage("DepartmentBudgetHead ID is required.");
        } 
    }
}
