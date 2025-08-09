using FluentValidation;
using KalaGenset.ERP.HR.Core.Request.KPAMaster;
using KalaGenset.ERP.HR.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Validation.KPAMaster
{
    public class UpdateKPAMasterValidator : AbstractValidator<UpdateKPAMasterRequest>
    {
        private readonly KalaDbContext context;
        /// <summary>
        /// validation 
        /// </summary>
        /// <param name="context"></param>
        public UpdateKPAMasterValidator(KalaDbContext context)
        {
            this.context = context;
            RuleFor(x => x.Kpaid)
                .GreaterThan(0).WithMessage("KPA ID must be greater than 0.");
            RuleFor(x => x.KpagradeId)
                .GreaterThan(0).WithMessage("KPA Grade ID must be greater than 0.");
            RuleFor(x => x.KpadesignationId)
                .GreaterThan(0).WithMessage("KPA Designation ID must be greater than 0.");
            RuleFor(x => x.Kpatype)
                .NotEmpty().WithMessage("KPA Type is required.")
                .MaximumLength(50).WithMessage("KPA Type cannot exceed 50 characters.");

        }
    }
}
