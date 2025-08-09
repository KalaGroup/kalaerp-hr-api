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
    public class InsertKPAMasterValidator : AbstractValidator<InsertKPAMasterRequest>
    {
        private readonly KalaDbContext context;

        /// <summary>
        /// connection string
        /// </summary>
        /// <param name="context"></param>
        /// 
        ///validation 
        public InsertKPAMasterValidator(KalaDbContext context)
        {
           
            this.context = context;
            RuleFor(x => x.KpagradeId)
                .GreaterThan(0).WithMessage("KPA Grade ID must be greater than 0.");
            RuleFor(x => x.KpadesignationId)
                .GreaterThan(0).WithMessage("KPA Designation ID must be greater than 0.");
            RuleFor(x => x.Kparemark)
                .NotEmpty().WithMessage("KPA Remark is required.")
                .MaximumLength(500).WithMessage("KPA Remark cannot exceed 500 characters.");
            RuleFor(x => x.Kpatype)
                .NotEmpty().WithMessage("KPA Type is required.")
                .MaximumLength(50).WithMessage("KPA Type cannot exceed 50 characters.");
            RuleFor(x => x.KpaauthRemark)
                .NotEmpty().WithMessage("KPA Auth Remark is required.")
                .MaximumLength(500).WithMessage("KPA Auth Remark cannot exceed 500 characters.");
        }
    }
}
