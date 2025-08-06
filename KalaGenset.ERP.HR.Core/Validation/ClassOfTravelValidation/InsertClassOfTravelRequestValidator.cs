using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using KalaGenset.ERP.HR.Data.DbContexts;
using KalaGenset.ERP.HR.Core.Request.ClassOfTravel;
using KalaGenset.ERP.HR.Core.Request.Grade;
using Microsoft.EntityFrameworkCore;

namespace KalaGenset.ERP.HR.Core.Validation.ClassOfTravelValidation
{
    public class InsertClassOfTravelRequestValidator : AbstractValidator<InsertClassOfTravelRequest>
    {
        private readonly KalaDbContext _context;
        public InsertClassOfTravelRequestValidator(KalaDbContext context)
        {
            _context = context;
            RuleFor(x => x.ClassOfTravelCode)
                .NotEmpty().WithMessage("Class of travel code is required.")
                .MaximumLength(10).WithMessage("Code must not exceed 10 characters.")
                .Matches("^[0-9]*$").WithMessage("Code must be numeric only and must not contain special characters")
                .MustAsync(BeUniqueCode).WithMessage("Code already exists.");
            RuleFor(x => x.ClassOfTravelName)
                .NotEmpty().WithMessage("Class of travel name is required.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.")
                .Matches("^[a-zA-Z0-9 ]*$").WithMessage("Name must not contain special characters.")
                .MustAsync(BeUniqueName).WithMessage("Name already exists.")
                .Must(BeProperCase).WithMessage("Name must be in proper case.");
            RuleFor(x => x.ClassOfTravelGradeId)
                .GreaterThan(0).WithMessage("Grade ID must be valid.")
                .MustAsync(GradeMustExist).WithMessage("Grade ID does not exist.");
            RuleFor(x => x.DafoodAllowancePerday)
                .GreaterThanOrEqualTo(0).WithMessage("Daily food allowance must be non-negative.");
            RuleFor(x => x.ClassOfTravelTierType)
                .GreaterThanOrEqualTo(0).WithMessage("Tier type must be non-negative.");
            RuleFor(x => x.ClassOfTravelRemark)
                .MaximumLength(200).WithMessage("Remark cannot exceed 200 characters.");
            RuleFor(x => x.ClassOfTravelIsActive)
                .NotNull().WithMessage("Active status is required.");
            RuleFor(x => x.CreatedBy)
                .GreaterThan(0).WithMessage("CreatedBy must be greater than 0.");
        }
        private async Task<bool> BeUniqueCode(string code, CancellationToken cancellationToken)
        {
            return !await _context.ClassOfTravelMasters
                .AnyAsync(x => x.ClassOfTravelCode == code, cancellationToken);
        }
        private async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
        {
            return !await _context.ClassOfTravelMasters
                .AnyAsync(x => x.ClassOfTravelName == name, cancellationToken);
        }
        private bool BeProperCase(string name)
        {
            var words = name.Split(new[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
            return words.All(word => !string.IsNullOrEmpty(word) && char.IsUpper(word[0]));
        }
        private async Task<bool> GradeMustExist(int gradeId, CancellationToken cancellationToken)
        {
            return await _context.GradeMasters.AnyAsync(g => g.GradeId == gradeId, cancellationToken);
        }
    }
}
