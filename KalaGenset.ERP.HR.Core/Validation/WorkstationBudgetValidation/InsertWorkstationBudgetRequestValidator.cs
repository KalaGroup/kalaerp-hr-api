using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using KalaGenset.ERP.HR.Core.Request.DepartmentBudget;
using KalaGenset.ERP.HR.Core.Request.WorkstationBudget;
using KalaGenset.ERP.HR.Data.DbContexts;

namespace KalaGenset.ERP.HR.Core.Validation.WorkstationBudgetValidation
{
    public class InsertWorkstationBudgetRequestValidator : AbstractValidator<InsertWorkstationBudgetRequest>
    {
        private readonly KalaDbContext _context;
        public InsertWorkstationBudgetRequestValidator(KalaDbContext context)
        {
            _context = context;

            RuleFor(x => x.WorkstationBudgetAmt)
               .GreaterThan(0).WithMessage("WorkstationBudgetAmt Amount must be greater than 0.")
               .NotEmpty().WithMessage("WorkstationBudgetAmt Amount is required.");

            RuleFor(x => x.WorkstationBudgetWorkstationId)
               .GreaterThan(0).WithMessage("WorkstationBudget ID must be greater than 0.")
               .NotEmpty().WithMessage("WorkstationBudget ID is required.");

            RuleFor(x => x.WorkstationBudgetHeadId)
                .GreaterThan(0).WithMessage("WorkstationBudgetHead ID must be greater than 0.")
                .NotEmpty().WithMessage("WorkstationBudgetHead ID is required.");
        }
    }
}
