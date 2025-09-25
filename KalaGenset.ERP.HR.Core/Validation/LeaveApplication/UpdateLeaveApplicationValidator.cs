using FluentValidation;
using KalaGenset.ERP.HR.Core.Request.LeaveApplication;
using KalaGenset.ERP.HR.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Validation.LeaveApplication
{
    public class UpdateLeaveApplicationValidator : AbstractValidator<UpdateLeaveApplicationRequest>
    {
        private readonly KalaDbContext _context;
        public UpdateLeaveApplicationValidator(KalaDbContext context)
        {
            _context = context;


            // EmployeeId must be greater than 0
            RuleFor(x => x.LeaveApplicationsEmployeeId)
                .GreaterThan(0)
                .WithMessage("EmployeeId is required and must be greater than 0.");

            // LeaveTypeId must be greater than 0
            RuleFor(x => x.LeaveApplicationsLeaveTypeId)
                .GreaterThan(0)
                .WithMessage("LeaveTypeId is required and must be greater than 0.");

        }
    }
}
