using FluentValidation;
using KalaGenset.ERP.HR.Core.Request.QualificationRequest;
using KalaGenset.ERP.HR.Core.Request.StateRequest;
using KalaGenset.ERP.HR.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Validation.QualificationValidator
{
    public class UpdateQualificationValidator : AbstractValidator<UpdateQualificationRequest>
    {
        private readonly KalaDbContext _context;

        public UpdateQualificationValidator(KalaDbContext context)
        {
            _context = context;

            // Primary key check for update
            RuleFor(x => x.QualificationId)
                .GreaterThan(0).WithMessage("Qualification Id is required for update.");

            // Foreign key checks
            RuleFor(x => x.MasterQualificationTypeId)
                .GreaterThan(0).WithMessage("Master Qualification ID must be greater than 0.");

            RuleFor(x => x.QualificationCode)
                .NotEmpty().WithMessage("Qualification code is required.")
                .Matches("^[A-Z0-9]*$").WithMessage("Qualification code must be uppercase alphanumeric only.")
                .MustAsync(BeUniqueQualificationCodeForUpdate).WithMessage("Qualification code already exists for another Country.");

            RuleFor(x => x.QualificationName)
                .NotEmpty().WithMessage("Qualification name is required.")
                .MaximumLength(100).WithMessage("Qualification name cannot exceed 100 characters.")
                .Matches("^[a-zA-Z0-9 -]*$").WithMessage("Qualification name must not contain special characters.");

            RuleFor(x => x.CreatedBy)
                .NotEmpty().WithMessage("CreatedBy is required.");

            RuleFor(x => x.CreatedDate)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Created date can't be in the future.");
        }


        private async Task<bool> BeUniqueQualificationCodeForUpdate(UpdateQualificationRequest model, string qualificationCode, CancellationToken cancellationToken)
        {
            return !await _context.QualificationMasters
                .AnyAsync(c => c.QualificationCode == qualificationCode && c.QualificationId != model.QualificationId, cancellationToken);
        }
    }
}

