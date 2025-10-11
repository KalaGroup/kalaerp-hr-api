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
            RuleFor(x => x.Kparemark)
     .Matches(@"^[a-zA-Z]*$").WithMessage("KPA remark contains invalid characters.")
     .MaximumLength(500).WithMessage("KPA remark cannot exceed 500 characters.");
            RuleFor(x => x.KpaauthRemark)
     .Matches(@"^[a-zA-Z]*$").WithMessage("KPA remark contains invalid characters.")
     .MaximumLength(500).WithMessage("KPA remark cannot exceed 500 characters.");


        }
    }
}
