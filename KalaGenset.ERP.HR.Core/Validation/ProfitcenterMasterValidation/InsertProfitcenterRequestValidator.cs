using FluentValidation;
using KalaGenset.ERP.HR.Core.Request.ProfitcenterMaster;
using KalaGenset.ERP.HR.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Validation.ProfitcenterMaster
{
    public class InsertProfitcenterRequestValidator:AbstractValidator<InsertProfitcenterRequest>
    {
        private readonly KalaDbContext _context;
        public InsertProfitcenterRequestValidator(KalaDbContext context)
        {
            _context = context;
         

            RuleFor(x => x.ProfitCenterCode)
            .ApplyAlphaNumeric("Profit Center Code", 10, allowSpaces: false)
            .MustAsync(BeUniqueProfitCenterCode).WithMessage("Profit Center Code already exists");

            RuleFor(x => x.ProfitCenterName)
                .ApplyAlphaNumeric("Profit Center Name", 100, allowSpaces: true)
               .MustAsync(BeUniqueProfitCenterName).WithMessage("Profit Center Name already exists.");

            RuleFor(x => x.ProfitCenterRemark)
               .ApplyAlphaNumeric("Remark should not be blank. Remark", 100, allowSpaces: true);

            RuleFor(x => x.CreatedBy)
               .MustBePresentWhenNew("CreatedBy");

            RuleFor(x => x.CreatedDate)
                .MustBePastOrNowWhenNew("Created date");
        }
        private async Task<bool> BeUniqueProfitCenterName(string profiCenterName, CancellationToken cancellationToken)
        {
            return !await _context.ProfitcenterMasters
                .AnyAsync(c => EF.Functions.Like(c.ProfitCenterName, profiCenterName), cancellationToken);
        }
        private async Task<bool> BeUniqueProfitCenterCode(string profitcenterCode, CancellationToken cancellationToken)
        {
            return !await _context.ProfitcenterMasters
                .AnyAsync(c => EF.Functions.Like(c.ProfitCenterCode, profitcenterCode), cancellationToken);
        }



    }
}
