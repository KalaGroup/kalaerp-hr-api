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
    public class UpdateClassOfTravelRequestValidator : AbstractValidator<UpdateClassOfTravelRequest>
    {
        private readonly KalaDbContext _context;
        public UpdateClassOfTravelRequestValidator(KalaDbContext context)
        {
            _context = context;
            RuleFor(x => x.ClassOfTravelId)
                .GreaterThan(0).WithMessage("ID must be greater than 0.")
                .MustAsync(ClassOfTravelMustExist).WithMessage("Record with this ID does not exist.");
            RuleFor(x => x.ClassOfTravelCode)
                .NotEmpty().WithMessage("Code is required.")
                .MaximumLength(10).WithMessage("Code must not exceed 10 characters.")
                .Matches("^[a-zA-Z0-9]*$").WithMessage("Code must be alphanumeric only.")
                .MustAsync(BeUniqueCode).WithMessage("Code already exists.");
            RuleFor(x => x.ClassOfTravelName)
                .NotEmpty().WithMessage("Name is required.")
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
        }
        private async Task<bool> ClassOfTravelMustExist(int id, CancellationToken cancellationToken)
        {
            return await _context.ClassOfTravelMasters
                .AnyAsync(x => x.ClassOfTravelId == id, cancellationToken);
        }
        private async Task<bool> BeUniqueCode(UpdateClassOfTravelRequest model, string code, CancellationToken cancellationToken)
        {
            return !await _context.ClassOfTravelMasters
                .AnyAsync(x => x.ClassOfTravelCode == code && x.ClassOfTravelId != model.ClassOfTravelId, cancellationToken);
        }
        private async Task<bool> BeUniqueName(UpdateClassOfTravelRequest model, string name, CancellationToken cancellationToken)
        {
            return !await _context.ClassOfTravelMasters
                .AnyAsync(x => x.ClassOfTravelName == name && x.ClassOfTravelId != model.ClassOfTravelId, cancellationToken);
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
