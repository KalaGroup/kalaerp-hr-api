using FluentValidation;
using KalaGenset.ERP.HR.Core.Request.Workstation;
using KalaGenset.ERP.HR.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Validation.WorkstationMasterValidation
{
    public class UpdateWorkstationMasterValidator : AbstractValidator<UpdateWorkstationRequest>
    {
        private readonly KalaDbContext context;
        public UpdateWorkstationMasterValidator(KalaDbContext context)
        {
            this.context = context;

            RuleFor(x => x.WorkStationName)
                .NotEmpty().WithMessage("WorkStation name is required.")
                .MaximumLength(100).WithMessage("WorkStation name cannot exceed 100 characters.")
                .Matches("^[a-zA-Z0-9 -]*$").WithMessage("WorkStation name must not contain special characters.");

            RuleFor(x => x.WorkStationShortName)
                 .NotEmpty().WithMessage("WorkStation short name is required.")
                .MaximumLength(10).WithMessage("WorkStation name cannot exceed 10 characters.")
                .Matches("^[A-Z0-9]*$").WithMessage("WorkStation name must be uppercase and alphanumeric.");

            RuleFor(x => x.WorkStationCode)
                 .NotEmpty().WithMessage("WorkStation Code is required.")
                .MaximumLength(10).WithMessage("WorkStation Code cannot exceed 10 characters.");

            RuleFor(x => x.WorkStationType)
                .NotEmpty().WithMessage("State short name is required.")
                .MaximumLength(10).WithMessage("Short name cannot exceed 10 characters.");

            RuleFor(x => x.CreatedBy)
                .NotEmpty().WithMessage("CreatedBy is required.");

            RuleFor(x => x.CreatedDate)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Created date can't be in the future.");
        }
    }
}
