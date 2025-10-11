using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using KalaGenset.ERP.HR.Core.Request.QualificationRequest;
using KalaGenset.ERP.HR.Core.Request.ShiftMaster;
using KalaGenset.ERP.HR.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace KalaGenset.ERP.HR.Core.Validation.ShiftMasterValidation
{
    public class UpdateShiftMasterRequestValidator : AbstractValidator<UpdateShiftMasterRequest>
    {
        private readonly KalaDbContext _context;

        public UpdateShiftMasterRequestValidator(KalaDbContext context)
        {
            _context = context;

            // Primary key check for update
            RuleFor(x => x.ShiftMasterId)
                .GreaterThan(0).WithMessage("Shift Id is required for update.");

            // Foreign key checks
            RuleFor(x => x.ShiftMasterCompanyId)
                .GreaterThan(0).WithMessage("Master company ID must be greater than 0.");

            RuleFor(x => x.ShiftMasterEmployeeTypeId)
                .GreaterThan(0).WithMessage("Master EmployeeType ID must be greater than 0.");

            RuleFor(x => x.ShiftMasterName)
                .NotEmpty().WithMessage("ShiftMaster name is required.")
                .MaximumLength(100).WithMessage("ShiftMaster name cannot exceed 100 characters.")
              
                .Matches("^[a-zA-Z]*$").WithMessage("ShiftMaster name must not contain special characters.");

            RuleFor(x => x.ShiftMasterAliseName)
               .NotEmpty().WithMessage("ShiftMasterAliseName is required.")
               .MaximumLength(10)
               .Matches("^[a-zA-Z]*$").WithMessage("ShiftMasterAliseName must not contain special characters.");

            RuleFor(x => x.CreatedBy)
                .NotEmpty().WithMessage("CreatedBy is required.");

            RuleFor(x => x.CreatedDate)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Created date can't be in the future.");
        }


        private async Task<bool> BeUniqueShiftName(UpdateShiftMasterRequest model, string ShiftMasterName, CancellationToken cancellationToken)
        {
            return !await _context.ShiftMasters
                .AnyAsync(c => c.ShiftMasterName == ShiftMasterName && c.ShiftMasterId != model.ShiftMasterId, cancellationToken);
        }
    }
}

    

