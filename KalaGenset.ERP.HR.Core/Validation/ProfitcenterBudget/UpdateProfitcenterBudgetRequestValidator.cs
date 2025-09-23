using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Validation.ProfitcenterBudget
{
    using FluentValidation;
    using KalaGenset.ERP.HR.Core.Request.ProfitcenterBudget;
    using KalaGenset.ERP.HR.Data.DbContexts;

    public class UpdateProfitcenterBudgetRequestValidator : AbstractValidator<UpdateProfitcenterBudgetRequest>
    {
        private readonly KalaDbContext context;

        public UpdateProfitcenterBudgetRequestValidator(KalaDbContext context)
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
