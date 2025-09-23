using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using KalaGenset.ERP.HR.Core.Request;
using KalaGenset.ERP.HR.Core.Request.LeaveTypeMaster;
using KalaGenset.ERP.HR.Data.DbContexts;

namespace KalaGenset.ERP.HR.Core.Validation.LeaveTypeMasterValidation
{
    public class UpdateLeaveTypeMasterRequestValidator : AbstractValidator<UpdateLeaveTypeMasterRequest>
    {
        private readonly KalaDbContext _context;
        public UpdateLeaveTypeMasterRequestValidator(KalaDbContext context)
        {
            _context = context;
            RuleFor(x => x.LeaveTypeMasterId)
                .GreaterThan(0).WithMessage("Leave Type ID must be greater than 0.");

            RuleFor(x => x.LeaveTypeMasterCode)
                .NotEmpty().WithMessage("LeaveType code is required.");

            RuleFor(x => x.LeaveTypeMasterName)
                .NotEmpty().WithMessage("LeaveType Name is required.")
                .Matches("^[a-zA-Z0-9 -]*$").WithMessage("LeaveType Name must not contain special characters.")
                .MaximumLength(100).WithMessage("LeaveType Name cannot exceed 100 characters.");

            RuleFor(x => x.CreatedBy)
                .NotEmpty().WithMessage("CreatedBy is required.");
        }
    }
}
       