using FluentValidation;
using KalaGenset.ERP.HR.Core.Request.ProfitcenterBudget;
using KalaGenset.ERP.HR.Core.Request.ProfitcenterMaster;
using KalaGenset.ERP.HR.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Validation.ProfitcenterBudget
{
    public class InsertProfitcenterBudgetRequestValidator : AbstractValidator<InsertProfitcenterBudgetRequest>
    {
        private readonly KalaDbContext context;
        public InsertProfitcenterBudgetRequestValidator(KalaDbContext context)
        {
            this.context = context;

            RuleFor(x => x.ProfitcenterBudgetProfitcenterId)
            .GreaterThan(0).WithMessage("Profit Center is required.");

            RuleFor(x => x.ProfitcenterFy)
                .NotEmpty().WithMessage("Financial Year is required.");


            RuleFor(x => x.ProfitcenterBudgetBudgetAmt)
                .GreaterThan(0).WithMessage("Budget Amount must be greater than 0.");

            RuleFor(x => x.ProfitCenterBudgetHeadId)
                .GreaterThan(0).WithMessage("Budget Head is required.");

        }
    }
}
