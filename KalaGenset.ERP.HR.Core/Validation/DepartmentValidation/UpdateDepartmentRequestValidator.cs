using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using KalaGenset.ERP.HR.Core.Request.Department;
using KalaGenset.ERP.HR.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace KalaGenset.ERP.HR.Core.Validation.DepartmentValidation
{
    public class UpdateDepartmentRequestValidator : AbstractValidator<UpdateDepartmentRequest>
    {
        private readonly KalaDbContext _context;
        public UpdateDepartmentRequestValidator(KalaDbContext context)
        {
            _context = context;
            RuleFor(x => x.DepartmentId)
                .GreaterThan(0).WithMessage("Department ID must be greater than 0.")
                .MustAsync(DepartmentExists).WithMessage("Department with this ID does not exist.");
            RuleFor(x => x.DepartmentCode)
                .NotEmpty().WithMessage("Department code is required.")
                .MaximumLength(10).WithMessage("Department code must not exceed 10 characters.")
                .Matches("^[0-9]*$").WithMessage("Department code must be numeric digits (e.g., '001', '002') & must not contain special characters.")
                .MustAsync(BeUniqueCode).WithMessage("Department code already exists.");
            RuleFor(x => x.DepartmentName)
                .NotEmpty().WithMessage("Department name is required.")
                .MaximumLength(100).WithMessage("Department name cannot exceed 100 characters.")
                .Matches("^[a-zA-Z0-9 ]*$").WithMessage("Department name must not contain special characters.")
                .MustAsync(BeUniqueName).WithMessage("Department name already exists.")
                .Must(BeProperCase).WithMessage("Department name must be in proper case.");
            RuleFor(x => x.DepartmentShortName)
                .NotEmpty().WithMessage("Short name is required.")
                .MaximumLength(50).WithMessage("Short name cannot exceed 50 characters.")
                .Matches("^[A-Z0-9 ]*$").WithMessage("Department short name must be uppercase and must not contain special characters.");
            RuleFor(x => x.ParentDepartmentId)
                .GreaterThan(0).WithMessage("ParentDepartment ID must be valid.");
            RuleFor(x => x.DepartmentProfitcenterId)
                .GreaterThan(0).WithMessage("Profit center ID must be valid.");
            RuleFor(x => x.DepartmentRemark)
                .MaximumLength(200).WithMessage("Remark cannot exceed 200 characters.");
            RuleFor(x => x.DepartmentType)
                .NotEmpty().WithMessage("Department type is required.")
                .MaximumLength(50).WithMessage("Department type cannot exceed 50 characters.");
            RuleFor(x => x.DepartmentAuthRemark)
                .MaximumLength(200).WithMessage("Auth remark cannot exceed 200 characters.");
            RuleFor(x => x.DepartmentIsActive)
                .NotNull().WithMessage("Active status is required.");
            RuleFor(x => x.CreatedBy)
                .GreaterThan(0).WithMessage("CreatedBy must be greater than 0.");
        }

        private async Task<bool> DepartmentExists(int id, CancellationToken cancellationToken)
        {
            return await _context.DepartmentMasters
                .AnyAsync(x => x.DepartmentId == id, cancellationToken);
        }

        private async Task<bool> BeUniqueCode(UpdateDepartmentRequest model, string code, CancellationToken cancellationToken)
        {
            return !await _context.DepartmentMasters
                .AnyAsync(x => x.DepartmentCode == code && x.DepartmentId != model.DepartmentId, cancellationToken);
        }

        private async Task<bool> BeUniqueName(UpdateDepartmentRequest model, string name, CancellationToken cancellationToken)
        {
            return !await _context.DepartmentMasters
                .AnyAsync(x => x.DepartmentName == name && x.DepartmentId != model.DepartmentId, cancellationToken);
        }

        private bool BeProperCase(string name)
        {
            var words = name.Split(new[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
            return words.All(word => char.IsUpper(word[0]));
        }
    }
}
