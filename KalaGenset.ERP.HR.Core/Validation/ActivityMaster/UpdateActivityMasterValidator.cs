using FluentValidation;
using KalaGenset.ERP.HR.Core.Request.ActivityMaster;
using KalaGenset.ERP.HR.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Validation.ActivityMaster
{
    public class UpdateActivityMasterValidator: AbstractValidator<UpdateActivityMasterRequest>
    {
        private readonly KalaDbContext context;
        /// <summary>
        /// constructor for initializing the InsertAuthoritieMasterValidator with the database context.
        /// </summary>
        /// <param name="context"></param>
        /// 
        public UpdateActivityMasterValidator(KalaDbContext context)
        {
            this.context = context;
            RuleFor(x => x.ActivityId)
             .GreaterThan(0).WithMessage("Activity Grade ID must be greater than 0.");
            RuleFor(x => x.ActivityGradeId)
              .GreaterThan(0).WithMessage("Activity Grade ID must be greater than 0.");
            RuleFor(x => x.ActivityDesignationId)
                .GreaterThan(0).WithMessage("Activity Designation ID must be greater than 0.");

            RuleFor(x => x.ActivityDivisionId)
                 .GreaterThan(0).WithMessage("Activity Grade ID must be greater than 0.");
            RuleFor(x => x.ActivityRemark)
     .Matches(@"^[a-zA-Z]*$").WithMessage("Activity remark contains invalid characters.")
     .MaximumLength(500).WithMessage("Activity remark cannot exceed 500 characters.");
            RuleFor(x => x.ActivityAuthRemark)
     .Matches(@"^[a-zA-Z]*$").WithMessage("Activity remark contains invalid characters.")
     .MaximumLength(500).WithMessage("Activity remark cannot exceed 500 characters.");
        }
    }
}
