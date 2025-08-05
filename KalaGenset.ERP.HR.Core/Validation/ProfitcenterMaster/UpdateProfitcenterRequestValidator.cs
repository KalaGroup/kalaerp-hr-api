using FluentValidation;
using KalaGenset.ERP.HR.Core.Request.ProfitcenterMaster;
using KalaGenset.ERP.HR.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Validation.ProfitcenterMaster
{
    public class UpdateProfitcenterRequestValidator:AbstractValidator<UpdateProfitcenterRequest>
    {
        private readonly KalaDbContext _context;
        public UpdateProfitcenterRequestValidator(KalaDbContext context)
        {
         
            _context = context;
            RuleFor(x => x.ProfitCenterName)
               .ApplyAlphaNumeric("Profit Center Name ", 100, allowSpaces: true);
            RuleFor(x => x.ProfitCenterId)
                .MustBePresentWhenNew("ProfitCenterId");
            RuleFor(x => x.ProfitCenterRemark)
               .ApplyAlphaNumeric("Remark should not be blank. Remark", 100, allowSpaces: true);
        }

    }
}
