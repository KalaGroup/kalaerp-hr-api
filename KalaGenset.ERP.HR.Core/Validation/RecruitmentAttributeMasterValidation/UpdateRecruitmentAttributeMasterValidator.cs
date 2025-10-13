using FluentValidation;
using KalaGenset.ERP.HR.Core.Request.RecruitmentAttributeMaster;
using KalaGenset.ERP.HR.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Validation.RecruitmentAttributeMasterValidation
{
    public class UpdateRecruitmentAttributeMasterValidator : AbstractValidator<UpdateRecruitmentAttributeMasterRequest>
    {
        private readonly KalaDbContext context;
        public UpdateRecruitmentAttributeMasterValidator(KalaDbContext context)
        {
            this.context = context;

            RuleFor(x => x.RecruitmentAttributeName)
                .NotEmpty().WithMessage("Recruitment Attribute name is required.")
                .MaximumLength(100).WithMessage("Recruitment Attribute name cannot exceed 100 characters.")
                .Matches("^[a-zA-Z]*$").WithMessage("Recruitment Attribute name must not contain special characters.");

            RuleFor(x => x.RecruitmentAttributeMarks)
                .NotEmpty().WithMessage("Recruitment Attribute Marks is required.")
                .GreaterThanOrEqualTo(0).WithMessage("Recruitment Attribute Marks must be a non-negative number.");

            RuleFor(x => x.RecruitmentAttributeRemark)
                .MaximumLength(500).WithMessage("Recruitment Attribute Remark cannot exceed 500 characters.")
                .Matches("^[a-zA-Z]*$").WithMessage("Recruitment Attribute Remark must not contain special characters.");

            RuleFor(x => x.RecruitmentAttributeAuthRemark)
                .MaximumLength(500).WithMessage("Recruitment Attribute Auth Remark cannot exceed 500 characters.")
                .Matches("^[a-zA-Z0-9 -]*$").WithMessage("Recruitment Attribute Auth Remark must not contain special characters.");

     
           
        }
    }
}