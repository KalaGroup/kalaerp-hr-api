using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using KalaGenset.ERP.HR.Core.Request;
using KalaGenset.ERP.HR.Core.Request.EmployeeTypeMaster;
using KalaGenset.ERP.HR.Data.DbContexts;

namespace KalaGenset.ERP.HR.Core.Validation.EmployeeTypeMasterValidation
{
    public class UpdateEmpTypeMstRequestValidator : AbstractValidator<UpdateEmployeeTypeRequest>
    {
        private readonly KalaDbContext _context;
        public UpdateEmpTypeMstRequestValidator(KalaDbContext context)
        {
            _context = context;

            RuleFor(x => x.EmployeeTypeId)
                .GreaterThan(0).WithMessage("Employee ID must be greater than 0.");

            RuleFor(x => x.EmployeeTypeCode)
                .NotEmpty().WithMessage("EmployeeType code is required.");

            RuleFor(x => x.EmployeeTypeName)
                .NotEmpty().WithMessage("EmployeeTypeName name is required.")
                .Matches("^[a-zA-Z0-9 -]*$").WithMessage("EmployeeTypeName  must not contain special characters.")
                .MaximumLength(100).WithMessage("EmployeeTypeName  cannot exceed 100 characters.");

            RuleFor(x => x.CreatedBy)
                .NotEmpty().WithMessage("CreatedBy is required.");
        }
    }
}
