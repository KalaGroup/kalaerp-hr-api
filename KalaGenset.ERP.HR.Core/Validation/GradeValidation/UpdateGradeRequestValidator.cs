using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using KalaGenset.ERP.HR.Data.DbContexts;
using KalaGenset.ERP.HR.Core.Request.Grade;
using Microsoft.EntityFrameworkCore;

namespace KalaGenset.ERP.HR.Core.Validation.GradeValidation
{
    public class UpdateGradeRequestValidator : AbstractValidator<UpdateGradeRequest>
    {
        private readonly KalaDbContext _context;
        public UpdateGradeRequestValidator(KalaDbContext context)
        {
            _context = context;
            RuleFor(x => x.GradeId)
                .GreaterThan(0).WithMessage("Grade ID must be greater than 0.")
                .MustAsync(GradeMustExist).WithMessage("Grade with this ID does not exist.");
            RuleFor(x => x.GradeCode)
                .NotEmpty().WithMessage("Grade code is required.")
                .MaximumLength(10).WithMessage("Grade code must be less than 10 characters.")
                .Matches("^[0-9]*$").WithMessage("Grade code must be numeric digits only.")
                .MustAsync(BeUniqueGradeCode).WithMessage("Grade code already exists.");
            RuleFor(x => x.GradeName)
                .NotEmpty().WithMessage("Grade name is required.")
                .MaximumLength(10).WithMessage("Grade name cannot exceed 10 characters.")
                .Matches("^[A-Z0-9]*$").WithMessage("Country short name must be uppercase and must not contain special characters.")
                .MustAsync(BeUniqueGradeName).WithMessage("Grade name already exists.");
            RuleFor(x => x.GradeLevel)
                .NotEmpty().WithMessage("Grade level is required.")
                .MaximumLength(10).WithMessage("Grade level cannot exceed 10 characters.");
            RuleFor(x => x.MinSalCtc)
                .GreaterThanOrEqualTo(0).WithMessage("Minimum CTC must be non-negative.");
            RuleFor(x => x.MaxSalCtc)
                .GreaterThanOrEqualTo(x => x.MinSalCtc).WithMessage("Maximum CTC must be greater than or equal to Minimum CTC.");
            RuleFor(x => x.GradeCurrencyId)
                .GreaterThan(0).WithMessage("Currency ID must be valid.")
                .MustAsync(CurrencyMustExist).WithMessage("Currency ID does not exist.");
            RuleFor(x => x.GradeDescription)
                .MaximumLength(200).WithMessage("Description cannot exceed 200 characters.");
            RuleFor(x => x.LeaveEntitlementAnnual)
                .GreaterThanOrEqualTo(0).WithMessage("Leave entitlement must be non-negative.");
            RuleFor(x => x.ProbationPeriod)
                .GreaterThanOrEqualTo(0).WithMessage("Probation period must be non-negative.");
            RuleFor(x => x.NoticePeriod)
                .GreaterThanOrEqualTo(0).WithMessage("Notice period must be non-negative.");
            RuleFor(x => x.GradeRemark)
                .MaximumLength(200).WithMessage("Remark cannot exceed 200 characters.");
            RuleFor(x => x.GradeIsActive)
                .NotNull().WithMessage("Active status is required.");
        }
        private async Task<bool> GradeMustExist(int GradeId, CancellationToken cancellationToken)
        {
            return await _context.GradeMasters
                .AnyAsync(c => c.GradeId == GradeId, cancellationToken);
        }
        private async Task<bool> BeUniqueGradeName(UpdateGradeRequest model, string gradeName, CancellationToken cancellationToken)
        {
            return !await _context.GradeMasters
                .AnyAsync(x => x.GradeName == gradeName && x.GradeId != model.GradeId, cancellationToken);
        }
        private async Task<bool> BeUniqueGradeCode(UpdateGradeRequest model, string gradeCode, CancellationToken cancellationToken)
        {
            return !await _context.GradeMasters
                .AnyAsync(x => x.GradeCode == gradeCode && x.GradeId != model.GradeId, cancellationToken);
        }
        private bool BeProperCase(string gradeName)
        {
            var words = gradeName.Split(new[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
            return words.All(word => !string.IsNullOrEmpty(word) && char.IsUpper(word[0]));
        }
        private async Task<bool> CurrencyMustExist(int currencyId, CancellationToken cancellationToken)
        {
            return await _context.CurrencyMasters
                .AnyAsync(c => c.CurrencyId == currencyId, cancellationToken);
        }
    }
}
