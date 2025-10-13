using FluentValidation;
using KalaGenset.ERP.HR.Core.Request.EmployeeMasterUpdationForMaster;
using KalaGenset.ERP.HR.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Validation.EmployeeMasterUpdationForMasterValidation
{
    public class InsertEmployeeMasterUpdationForMasterValidator : AbstractValidator<InsertEmployeeMasterUpdationForMasterRequest>
    {
        private readonly KalaDbContext _context;
        public InsertEmployeeMasterUpdationForMasterValidator(KalaDbContext context)
        {
            _context = context;
            RuleFor(x => x.EmployeeMasterUpdationForName)
                .NotEmpty().WithMessage("Employee Master Updation For Name is required.")
                .MaximumLength(100)
                .MustAsync(BeUniqueEmployeeMasterUpdationForName).WithMessage("Employee Master Updation For Name already exists.")
                .Matches("^[a-zA-Z ]*$").WithMessage("Employee Master Updation For Name must not contain special characters.");
            RuleFor(x => x.EmployeeMasterUpdationForRemark)
                .NotEmpty().WithMessage("Employee Master Updation For Remark is required.")
                .MaximumLength(500);
            RuleFor(x => x.EmployeeMasterUpdationForAuthRemark)
                .NotEmpty().WithMessage("Employee Master Updation For Auth Remark is required.")
                .MaximumLength(500);
          
        }

        private async Task<bool> BeUniqueEmployeeMasterUpdationForName(string EmployeeMasterUpdationForName, CancellationToken cancellationToken)
        {
            return !await _context.EmployeeMasterUpdationForMasters
                .AnyAsync(c => EF.Functions.Like(c.EmployeeMasterUpdationForName, EmployeeMasterUpdationForName), cancellationToken);
        }
    }
}
