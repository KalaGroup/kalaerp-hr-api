using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using KalaGenset.ERP.HR.Core.Request.WorkstationBudget;
using KalaGenset.ERP.HR.Data.DbContexts;

namespace KalaGenset.ERP.HR.Core.Validation.WorkstationBudgetValidation
{
    public class UpdateWorkstationBudgetRequestValidator : AbstractValidator<UpdateWorkstaionBudgetRequest>
    {
        private readonly KalaDbContext _context;

        public UpdateWorkstationBudgetRequestValidator(KalaDbContext context)
        {
            _context = context;

            // Primary key check for update
            RuleFor(x => x.WorkstationBudgetId)
                .GreaterThan(0).WithMessage("WorkstationBudget Id is required for update.");

            // Foreign key checks
            RuleFor(x => x.WorkstationBudgetWorkstationId)
                .GreaterThan(0).WithMessage("Workstation ID must be greater than 0.");

            RuleFor(x => x.WorkstationBudgetHeadId)
                .GreaterThan(0).WithMessage("HeadId must be greater than 0.");

            RuleFor(x => x.WorkstationBudgetAmt)
                          .GreaterThan(0).WithMessage("WorkstationBudget Amount must be greater than 0.")
                          .NotEmpty().WithMessage("WorkstationBudgetAmt Amount is required.");

            RuleFor(x => x.CreatedBy)
                .NotEmpty().WithMessage("CreatedBy is required.");

            RuleFor(x => x.CreatedDate)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Created date can't be in the future.");
        }
    }
}
