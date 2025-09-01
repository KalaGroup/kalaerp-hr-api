using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using KalaGenset.ERP.HR.Core.Request.EmployeeTypeMaster;
using KalaGenset.ERP.HR.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace KalaGenset.ERP.HR.Core.Validation.EmployeeTypeMasterValidation
{
    public class InsertEmpTypeMstRequestValidator:AbstractValidator<InsertEmployeeTypeRequest>
    {

        private readonly KalaDbContext _context;
        public InsertEmpTypeMstRequestValidator(KalaDbContext context)
        {
            _context = context;

            RuleFor(x => x.EmployeeTypeCode)
              .NotEmpty().WithMessage("Employee Type code is required.")
              .MaximumLength(10).WithMessage("Employee Type code must be less than 10 characters.")
              .Matches("^[0-9]*$").WithMessage("Employee Type code must be numeric digits (e.g., '001', '002') & must not contain special characters.")
              .MustAsync(BeUniqueEmployeeTypeCode).WithMessage("Grade code already exists.");


            RuleFor(x => x.EmployeeTypeName)
                .ApplyAlphaNumeric("EmployeeType name", 100, allowSpaces: true)
                .MustAsync(BeUniqueEmployeeTypeName).WithMessage("EmployeeType name already exists.");

            //RuleFor(x => x.CreatedBy)
            //   .MustBePresentWhenNew("CreatedBy");

        }
        private async Task<bool> BeUniqueEmployeeTypeCode(string EmployeeTypeCode, CancellationToken cancellationToken)
        {
            return !await _context.EmployeeTypeMasters
                .AnyAsync(c => EF.Functions.Like(c.EmployeeTypeCode, EmployeeTypeCode), cancellationToken);
        }
        private async Task<bool> BeUniqueEmployeeTypeName(string EmployeeTypeName, CancellationToken cancellationToken)
        {
            return !await _context.EmployeeTypeMasters
                .AnyAsync(c => EF.Functions.Like(c.EmployeeTypeName, EmployeeTypeName), cancellationToken);
        }
    }
}
