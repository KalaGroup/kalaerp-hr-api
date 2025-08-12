using FluentValidation;
using KalaGenset.ERP.HR.Core.Request.RecruitmentAttributeMaster;
using KalaGenset.ERP.HR.Core.Request.Workstation;
using KalaGenset.ERP.HR.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Validation.RecruitmentAttributeMasterValidation
{
    public class InsertRecruitmentAttributeMasterValidator : AbstractValidator<InsertRecruitmentAttributeMasterRequest>
    {
        private readonly KalaDbContext _context;
        public InsertRecruitmentAttributeMasterValidator(KalaDbContext context)
        {
            _context = context;
            RuleFor(x => x.RecruitmentAttributeName)
                .NotEmpty().WithMessage("RecruitmentAttributeName is required.")
                .MustAsync(BeUniqueRecruitmentAttributeName).WithMessage("RecruitmentAttributeName already exists.")
                .Matches("^[a-zA-Z0-9 ]*$").WithMessage("RecruitmentAttributeName must not contain special characters.")
                .MaximumLength(100);
            RuleFor(x => x.RecruitmentAttributeMarks)
                .NotEmpty().WithMessage("RecruitmentAttributeMarks is required.")
                .GreaterThanOrEqualTo(0).WithMessage("RecruitmentAttributeMarks must be greater than or equal to 0.");
            RuleFor(x => x.RecruitmentAttributeRemark)
                .NotEmpty().WithMessage("RecruitmentAttributeRemark is required.")
                .MaximumLength(500);
            RuleFor(x => x.RecruitmentAttributeAuthRemark)
                .NotEmpty().WithMessage("RecruitmentAttributeAuthRemark is required.")
                .MaximumLength(500);
            RuleFor(x => x.RecruitmentAttributeAuth)
                .NotNull().WithMessage("RecruitmentAttributeAuth is required.");
            RuleFor(x => x.RecruitmentAttributeIsDiscard)
                .NotNull().WithMessage("RecruitmentAttributeIsDiscard is required.");
            RuleFor(x => x.RecruitmentAttributeIsActive)
                .NotNull().WithMessage("RecruitmentAttributeIsActive is required.");
            RuleFor(x => x.CreatedBy)
                .NotEmpty().WithMessage("CreatedBy is required.")
                .GreaterThan(0).WithMessage("CreatedBy must be a positive integer.");
            RuleFor(x => x.CreatedDate)
                .NotEmpty().WithMessage("CreatedDate is required.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("CreatedDate cannot be in the future.");
        }

        private async Task<bool> BeUniqueRecruitmentAttributeName(string RecruitmentAttributeName, CancellationToken cancellationToken)
        {
            return !await _context.RecruitmentAttributeMasters
                .AnyAsync(c => EF.Functions.Like(c.RecruitmentAttributeName, RecruitmentAttributeName), cancellationToken);
        }
    }
}
