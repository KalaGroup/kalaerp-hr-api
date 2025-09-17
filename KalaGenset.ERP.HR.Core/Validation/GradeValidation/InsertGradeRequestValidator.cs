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
    //public class InsertGradeRequestValidator : AbstractValidator<InsertGradeRequest>
    //{
    //    private readonly KalaDbContext _context;
    //    public InsertGradeRequestValidator(KalaDbContext context)
    //    {
    //        _context = context;
    //        RuleFor(x => x.GradeCode)
    //           .NotEmpty().WithMessage("Grade code is required.")
    //           .MaximumLength(10).WithMessage("Grade code must be less than 10 characters.")
    //           .Matches("^[0-9]*$").WithMessage("Grade code must be numeric digits (e.g., '001', '002') & must not contain special characters.")
    //           .MustAsync(BeUniqueGradeCode).WithMessage("Grade code already exists.");
    //        RuleFor(x => x.GradeName)
    //            .NotEmpty().WithMessage("Grade name is required.")
    //            .MaximumLength(10).WithMessage("Grade name cannot exceed 10 characters.")
    //            .Matches("^[A-Z0-9]*$").WithMessage("Grade name must be uppercase and must not contain special characters.")
    //            .MustAsync(BeUniqueGradeName).WithMessage("Grade name already exists.");
    //        RuleFor(x => x.GradeLevel)
    //            .NotEmpty().WithMessage("Grade level is required.")
    //            .MaximumLength(10).WithMessage("Grade level cannot exceed 10 characters.");
    //        RuleFor(x => x.MinSalCtc)
    //            .GreaterThanOrEqualTo(0).WithMessage("Minimum CTC must be non-negative.");
    //        RuleFor(x => x.MaxSalCtc)
    //            .GreaterThanOrEqualTo(x => x.MinSalCtc).WithMessage("Maximum CTC must be greater than or equal to Minimum CTC.");
    //        RuleFor(x => x.GradeCurrencyId)
    //            .GreaterThan(0).WithMessage("Currency ID must be valid.")
    //            .MustAsync(CurrencyMustExist).WithMessage("GradeCurrency ID does not exist.");
    //        RuleFor(x => x.GradeDescription)
    //            .MaximumLength(200).WithMessage("Description cannot exceed 200 characters.");
    //        RuleFor(x => x.LeaveEntitlementAnnual)
    //            .GreaterThanOrEqualTo(0).WithMessage("Leave entitlement must be non-negative.");
    //        RuleFor(x => x.ProbationPeriod)
    //            .GreaterThanOrEqualTo(0).WithMessage("Probation period must be non-negative.");
    //        RuleFor(x => x.NoticePeriod)
    //            .GreaterThanOrEqualTo(0).WithMessage("Notice period must be non-negative.");
    //        RuleFor(x => x.GradeRemark)
    //            .MaximumLength(200).WithMessage("Remark cannot exceed 200 characters.");
    //        RuleFor(x => x.GradeIsActive)
    //            .NotNull().WithMessage("Active status is required.");
    //        RuleFor(x => x.CreatedBy)
    //            .GreaterThan(0).WithMessage("CreatedBy must be greater than 0.");
    //        RuleFor(x => x.CreatedDate)
    //            .LessThanOrEqualTo(DateTime.Now).WithMessage("Created date can't be in the future.");
    //    }
    //    private async Task<bool> BeUniqueGradeName(string GradeName, CancellationToken cancellationToken)
    //    {
    //        return !await _context.GradeMasters
    //            .AnyAsync(c => EF.Functions.Like(c.GradeName, GradeName), cancellationToken);
    //    }
    //    private async Task<bool> BeUniqueGradeCode(string GradeCode, CancellationToken cancellationToken)
    //    {
    //        return !await _context.GradeMasters
    //            .AnyAsync(c => EF.Functions.Like(c.GradeCode, GradeCode), cancellationToken);
    //    }
    //    private async Task<bool> CurrencyMustExist(int currencyId, CancellationToken cancellationToken)
    //    {
    //        return await _context.CurrencyMasters.AnyAsync(c => c.CurrencyId == currencyId, cancellationToken);
    //    }
    //}

    public class InsertGradeRequestValidator : AbstractValidator<InsertGradeRequest>
    {
        private readonly KalaDbContext _context;

        public InsertGradeRequestValidator(KalaDbContext context)
        {
            _context = context;

            // Validate gradeData
            RuleFor(x => x.gradeData).NotNull().WithMessage("Grade data is required.");

            When(x => x.gradeData != null, () => {
                // Grade Basic Information
                RuleFor(x => x.gradeData.GradeCode)
                    .NotEmpty().WithMessage("Grade code is required.")
                    .MaximumLength(10).WithMessage("Grade code must be less than 10 characters.")
                    .Matches("^[0-9]*$").WithMessage("Grade code must be numeric digits (e.g., '001', '002') & must not contain special characters.")
                    .MustAsync(BeUniqueGradeCode).WithMessage("Grade code already exists.");

                RuleFor(x => x.gradeData.GradeName)
                    .NotEmpty().WithMessage("Grade name is required.")
                    .MaximumLength(100).WithMessage("Grade name cannot exceed 100 characters.")
                    .Matches("^[A-Z0-9 ]*$").WithMessage("Grade name must be uppercase and must not contain special characters.")
                    .MustAsync(BeUniqueGradeName).WithMessage("Grade name already exists.");

                RuleFor(x => x.gradeData.GradeLevel)
                    .NotEmpty().WithMessage("Grade level is required.")
                    .MaximumLength(100).WithMessage("Grade level cannot exceed 100 characters.");

                RuleFor(x => x.gradeData.GradeDescription)
                    .NotEmpty().WithMessage("Grade description is required.")
                    .MaximumLength(100).WithMessage("Description cannot exceed 100 characters.");

                // Salary Information
                RuleFor(x => x.gradeData.MinSalCTC)
                    .GreaterThanOrEqualTo(0).WithMessage("Minimum CTC must be non-negative.");

                RuleFor(x => x.gradeData.MaxSalCTC)
                    .GreaterThanOrEqualTo(x => x.gradeData.MinSalCTC).WithMessage("Maximum CTC must be greater than or equal to Minimum CTC.");

                RuleFor(x => x.gradeData.GradeCurrencyId)
                    .GreaterThan(0).WithMessage("Currency ID must be valid.")
                    .MustAsync(CurrencyMustExist).WithMessage("GradeCurrency ID does not exist.");

                // Employment Terms
                RuleFor(x => x.gradeData.LeaveEntitlementAnnual)
                    .GreaterThanOrEqualTo(0).WithMessage("Leave entitlement must be non-negative.")
                    .LessThanOrEqualTo(365).WithMessage("Leave entitlement cannot exceed 365 days.");

                RuleFor(x => x.gradeData.ProbationPeriod)
                    .GreaterThanOrEqualTo(0).WithMessage("Probation period must be non-negative.")
                    .LessThanOrEqualTo(24).WithMessage("Probation period cannot exceed 24 months.");

                RuleFor(x => x.gradeData.NoticePeriod)
                    .GreaterThanOrEqualTo(0).WithMessage("Notice period must be non-negative.")
                    .LessThanOrEqualTo(12).WithMessage("Notice period cannot exceed 12 months.");

                RuleFor(x => x.gradeData.ExperiencedRequired)
                    .GreaterThanOrEqualTo(0).WithMessage("Experience required must be non-negative.")
                    .LessThanOrEqualTo(50).WithMessage("Experience required cannot exceed 50 years.");

                RuleFor(x => x.gradeData.ExperiencedRemark)
                    .NotEmpty().WithMessage("Experience remark is required.")
                    .MaximumLength(100).WithMessage("Experience remark cannot exceed 100 characters.");

                RuleFor(x => x.gradeData.GradeRemark)
                    .NotEmpty().WithMessage("Grade remark is required.")
                    .MaximumLength(100).WithMessage("Remark cannot exceed 100 characters.");

                // Status Fields
                RuleFor(x => x.gradeData.GradeIsActive)
                    .NotNull().WithMessage("Active status is required.");
            });

            // Validate designations Collection
            RuleFor(x => x.designations)
                .NotNull().WithMessage("designations are required.")
                .Must(x => x != null && x.Count > 0).WithMessage("At least one designation is required.");

            // Validate Each Designation
            RuleForEach(x => x.designations).ChildRules(designation => {
                designation.RuleFor(d => d.DesignationCode)
                    .NotEmpty().WithMessage("Designation Code is required.")
                    .MaximumLength(10).WithMessage("Designation Code cannot exceed 10 characters.")
                    .MustAsync(BeUniqueDesignationCode).WithMessage("Designation Code must be unique.");

                designation.RuleFor(d => d.DesignationName)
                    .NotEmpty().WithMessage("Designation Name is required.")
                    .MaximumLength(100).WithMessage("Designation Name cannot exceed 100 characters.");

                designation.RuleFor(d => d.DesignationQualificationId)
                    .GreaterThan(0).WithMessage("Qualification ID must be valid.")
                    .MustAsync(QualificationMustExist).WithMessage("Qualification ID does not exist.");

                designation.RuleFor(d => d.DesignationDescription)
                    .NotEmpty().WithMessage("Designation Description is required.")
                    .MaximumLength(100).WithMessage("Designation Description cannot exceed 100 characters.");

                designation.RuleFor(d => d.GradeQualificationRemark)
                    .NotEmpty().WithMessage("Grade Qualification Remark is required.")
                    .MaximumLength(100).WithMessage("Grade Qualification Remark cannot exceed 100 characters.");

                designation.RuleFor(d => d.RequiredSkills)
                    .NotEmpty().WithMessage("Required Skills is required.")
                    .MaximumLength(100).WithMessage("Required Skills cannot exceed 100 characters.");

                designation.RuleFor(d => d.DesignationRemark)
                    .NotEmpty().WithMessage("Designation Remark is required.")
                    .MaximumLength(100).WithMessage("Designation Remark cannot exceed 100 characters.");
            });
        }

        // Grade Validation Methods
        private async Task<bool> BeUniqueGradeName(string gradeName, CancellationToken cancellationToken)
        {
            return !await _context.GradeMasters
                .AnyAsync(c => EF.Functions.Like(c.GradeName, gradeName), cancellationToken);
        }

        private async Task<bool> BeUniqueGradeCode(string gradeCode, CancellationToken cancellationToken)
        {
            return !await _context.GradeMasters
                .AnyAsync(c => EF.Functions.Like(c.GradeCode, gradeCode), cancellationToken);
        }

        private async Task<bool> CurrencyMustExist(int currencyId, CancellationToken cancellationToken)
        {
            return await _context.CurrencyMasters.AnyAsync(c => c.CurrencyId == currencyId, cancellationToken);
        }

        // Designation Validation Methods
        private async Task<bool> BeUniqueDesignationCode(string designationCode, CancellationToken token)
        {
            return !await _context.DesignationMasters
                .AnyAsync(d => d.DesignationCode == designationCode, token);
        }

        private async Task<bool> QualificationMustExist(int qualificationId, CancellationToken cancellationToken)
        {
            return await _context.QualificationMasters.AnyAsync(q => q.QualificationId == qualificationId, cancellationToken);
        }
    }

}
