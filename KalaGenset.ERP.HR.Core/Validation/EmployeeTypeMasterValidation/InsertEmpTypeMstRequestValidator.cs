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



            RuleFor(x => x.EmployeeTypeName)
                .ApplyAlphaNumeric("EmployeeType name", 100, allowSpaces: true)
                .MustAsync(BeUniqueEmployeeTypeName).WithMessage("EmployeeType name already exists.")
                .Matches("^[A-Za-z ]+$").WithMessage("EmployeeTypeName  must not contain special characters.");
            RuleFor(x => x.EmployeeTypeDescription)
                .Matches("^[A-Za-z ]+$").WithMessage("EmployeeTypeDescription   must not contain special characters.");


          
        }
      
        private async Task<bool> BeUniqueEmployeeTypeName(string EmployeeTypeName, CancellationToken cancellationToken)
        {
            return !await _context.EmployeeTypeMasters
                .AnyAsync(c => EF.Functions.Like(c.EmployeeTypeName, EmployeeTypeName), cancellationToken);
        }
    }
}
