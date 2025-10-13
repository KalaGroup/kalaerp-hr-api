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
                .Matches("^[a-zA-Z ]*$").WithMessage("RecruitmentAttributeName must not contain special characters.")
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
           
        }

        private async Task<bool> BeUniqueRecruitmentAttributeName(string RecruitmentAttributeName, CancellationToken cancellationToken)
        {
            return !await _context.RecruitmentAttributeMasters
                .AnyAsync(c => EF.Functions.Like(c.RecruitmentAttributeName, RecruitmentAttributeName), cancellationToken);
        }
    }
}
