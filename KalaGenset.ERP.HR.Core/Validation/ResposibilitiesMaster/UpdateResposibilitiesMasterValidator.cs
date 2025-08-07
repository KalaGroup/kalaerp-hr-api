using FluentValidation;
using KalaGenset.ERP.HR.Core.Request.ResposibilitiesMaster;
using KalaGenset.ERP.HR.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Validation.DepartmentMaster
{
    public class UpdateResposibilitiesMasterValidator: AbstractValidator<UpdateResposibilitiesMasterRequest>
    {
        private readonly KalaDbContext context;

        public UpdateResposibilitiesMasterValidator(KalaDbContext context)
        {
            this.context = context;
                 RuleFor(x => x.ResposibilitiesGradeId)
                .GreaterThan(0).WithMessage("Resposibilities Grade ID must be greater than 0.");

                 RuleFor(x => x.ResposibilitiesDesignationId)
                .GreaterThan(0).WithMessage("Resposibilities Designation ID must be greater than 0.");

                 RuleFor(x => x.ResposibilitiesRemark)
                .MaximumLength(500).WithMessage("Resposibilities Remark cannot exceed 500 characters.");

                 RuleFor(x => x.ResposibilitiesType)
                .NotEmpty().WithMessage("Resposibilities Type is required.")
                .MaximumLength(50).WithMessage("Resposibilities Type cannot exceed 50 characters.");

                 RuleFor(x => x.ResposibilitiesAuthRemark)
                .MaximumLength(500).WithMessage("Resposibilities Auth Remark cannot exceed 500 characters.");
        }
    }
}
