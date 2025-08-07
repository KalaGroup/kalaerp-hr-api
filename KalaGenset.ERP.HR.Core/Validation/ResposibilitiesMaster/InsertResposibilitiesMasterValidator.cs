using FluentValidation;
using KalaERP.HR.Core.Request.DesignationMaster;
using KalaGenset.ERP.HR.Core.Request.ResposibilitiesMaster;
using KalaGenset.ERP.HR.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Validation.DepartmentMaster
{
    public class InsertResposibilitiesMasterValidator: AbstractValidator<InsertResposibilitiesMasterRequest>
    {
        private readonly KalaDbContext context;

        public InsertResposibilitiesMasterValidator(KalaDbContext context)
        {
            this.context = context;
            RuleFor(x => x.ResposibilitiesGradeId)
             .NotEmpty().WithMessage("Responsibilities Grade ID is required.")
             .GreaterThan(0).WithMessage("Responsibilities Grade ID must be greater than 0.");

            RuleFor(x => x.ResposibilitiesType)
                .NotEmpty().WithMessage("Resposibilities Type is required.");

            RuleFor(x => x.ResposibilitiesDesignationId)
                .NotEmpty().WithMessage("Responsibilities Designation ID is required.")
                .GreaterThan(0).WithMessage("Responsibilities Designation ID must be greater than 0.");

        }

    }
}
