using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using KalaGenset.ERP.HR.Core.Request.ShiftMaster;
using KalaGenset.ERP.HR.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace KalaGenset.ERP.HR.Core.Validation.ShiftMasterValidation
{
    public class InsertShiftMasterRequestValidator : AbstractValidator<InsertShiftMasterRequest>
    {
        private readonly KalaDbContext _context;
        public InsertShiftMasterRequestValidator(KalaDbContext context)
        {
            _context = context;  

            RuleFor(x => x.ShiftMasterName)
                    .NotEmpty().WithMessage("Shift name is required.")
                    .MustAsync(BeUniqueShiftName).WithMessage("Shift name already exists.")
                    .Matches("^[a-zA-Z0-9 ]*$").WithMessage("shift name must not contain special characters.")
                    .MaximumLength(100);

            RuleFor(x => x.ShiftMasterAliseName)
                .NotEmpty().WithMessage("ShiftMasterAliseName is required.")
                .MaximumLength(10)
                .Matches("^[a-zA-Z0-9]*$").WithMessage("ShiftMasterAliseName must not contain special characters.");

           
        }

        private async Task<bool> BeUniqueShiftName(string ShiftMasterName, CancellationToken cancellationToken)
        {
            return !await _context.ShiftMasters
                .AnyAsync(c => EF.Functions.Like(c.ShiftMasterName, ShiftMasterName), cancellationToken);
        }
    }
}
   
