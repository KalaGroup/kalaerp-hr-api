using FluentValidation;
using KalaGenset.ERP.HR.Core.Request.OfferLetter;
using KalaGenset.ERP.HR.Core.Request.RecruitmentMaster;
using KalaGenset.ERP.HR.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Validation.OfferLetter
{
    public class UpdateOffereLetterValidator : AbstractValidator<UpdateOfferLetterRequest>
    {
        private readonly KalaDbContext _context;
        public UpdateOffereLetterValidator(KalaDbContext context)
        {
            _context = context;


            RuleFor(x => x.OfferLetterRecruitmentId)
              .NotEmpty().WithMessage("RecruitmentId is required.")
              .GreaterThan(0).WithMessage("RecruitmentId must be a positive integer.");

            RuleFor(x => x.OfferLetterJoinindate)
                .NotEmpty().WithMessage("Joining date is required.");

            RuleFor(x => x.OfferLetterRemark)
                .MaximumLength(500).WithMessage("Remark cannot exceed 500 characters.");

            RuleFor(x => x.OfferLetterAuth1Remark)
                .MaximumLength(250).WithMessage("Auth1 remark cannot exceed 250 characters.");

            RuleFor(x => x.OfferLetterAuth2Remark)
                .MaximumLength(250).WithMessage("Auth2 remark cannot exceed 250 characters.");

            RuleFor(x => x.OfferLetterAuth3Remark)
                .MaximumLength(250).WithMessage("Auth3 remark cannot exceed 250 characters.");
        }
    }
}
