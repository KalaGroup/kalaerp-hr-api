using FluentValidation;
using KalaGenset.ERP.HR.Core.Request.DepartmentBudget;
using KalaGenset.ERP.HR.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            RuleFor(x => x)
               .MustAsync(async (request, cancellation) =>
               {
                   return !await context.DepartmentBudgets
                       .AnyAsync(b => b.DepartmentFy == request.DepartmentFy &&
                                      b.DepartmentBudgetHeadId == request.DepartmentBudgetHeadId);
               })
               .WithMessage("A budget for this Financial Year and Department already exists.");

            RuleFor(x => x.DepartmentBudgetAuthRemark)
   .Matches(@"^[a-zA-Z]*$").WithMessage("DepartmentBudget remark contains invalid characters.")
   .MaximumLength(500).WithMessage("Department remark cannot exceed 500 characters.");
            RuleFor(x => x.DepartmentBudgetRemark)
     .Matches(@"^[a-zA-Z]*$").WithMessage("DepartmentBudget remark contains invalid characters.")
     .MaximumLength(500).WithMessage("Department remark cannot exceed 500 characters."); ;
        } 
    }
}
