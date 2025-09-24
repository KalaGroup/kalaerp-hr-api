using FluentValidation;
using KalaGenset.ERP.HR.Core.Request.EmployeeLeaveBalance;
using KalaGenset.ERP.HR.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Validation.EmployeeLeaveBalanceValidation
{
    public class InsertEmployeeLeaveBalanceValidator : AbstractValidator <InsertEmployeeLeaveBalanceRequest>
    {
        private readonly KalaDbContext _context;
        public InsertEmployeeLeaveBalanceValidator(KalaDbContext context)
        {
            _context = context;

            RuleFor(x => x.LeaveBalancesEmployeeId)
                    .NotEmpty().WithMessage("Employee ID is required.");

            RuleFor(x => x.LeaveBalancesTypeId)
            .NotEmpty().WithMessage("Balance Type is required.");

            RuleFor(x => x.LeaveBalancesYear)
                    .NotEmpty().WithMessage("Leave Balances Year is required.");
        }
    }
}
