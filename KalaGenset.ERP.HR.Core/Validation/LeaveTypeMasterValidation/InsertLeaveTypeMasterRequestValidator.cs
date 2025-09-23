using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using KalaGenset.ERP.HR.Core.Request.LeaveTypeMaster;
using KalaGenset.ERP.HR.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace KalaGenset.ERP.HR.Core.Validation.LeaveTypeMasterValidation
{
    public class InsertLeaveTypeMasterRequestValidator : AbstractValidator<InsertleaveTypeMasterRequest>
    {
        private readonly KalaDbContext _context;
        public InsertLeaveTypeMasterRequestValidator(KalaDbContext context)
        {
            _context = context;

            RuleFor(x => x.LeaveTypeMasterCode)
                .ApplyAlphaNumeric("LeaveType code", 10, allowSpaces: false);

            RuleFor(x => x.LeaveTypeMasterName)
                .ApplyAlphaNumeric("LeaveType Name", 100, allowSpaces: true)
                .MustAsync(BeUniqueLeaveTypeMasterName).WithMessage("LeaveTypeMasterName already exists.");

            RuleFor(x => x.CreatedBy)
               .MustBePresentWhenNew("CreatedBy");

        }
        private async Task<bool> BeUniqueLeaveTypeMasterName(string LeaveTypeMasterName, CancellationToken cancellationToken)
        {
            return !await _context.LeaveTypeMasters
                .AnyAsync(c => EF.Functions.Like(c.LeaveTypeMasterName, LeaveTypeMasterName), cancellationToken);
        }
    }
}
