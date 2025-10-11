using FluentValidation;
using KalaGenset.ERP.HR.Core.Request;
using KalaGenset.ERP.HR.Core.Request.ERPPageDetails;
using KalaGenset.ERP.HR.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace KalaGenset.ERP.HR.Core.Validation.ERPPageDetailsValidation
{
    public class InsertERPPageDetailsValidator : AbstractValidator<InsertERPPageDetailsRequest>
    {
        private readonly KalaDbContext _context;

        public InsertERPPageDetailsValidator(KalaDbContext context)
        {
            _context = context;

            RuleFor(x => x.KalaErppageDetailsDivisionId)
                .NotEmpty().WithMessage("Division Id is required.");

            RuleFor(x => x.PageTittle)
                .NotEmpty().WithMessage("Page Title is required.")
                .MaximumLength(200).WithMessage("Page Title must not exceed 200 characters.")
                .Matches("^[a-zA-Z0-9 ]*$").WithMessage("Page Title must not contain special characters.");


            RuleFor(x => x.PageUrl)
                .NotEmpty().WithMessage("Page URL is required.")
                .MaximumLength(500).WithMessage("Page URL must not exceed 500 characters.")
                .MustAsync(BeUniquePageUrl).WithMessage("Page URL already exists.");

            RuleFor(x => x.PageType)
                .NotEmpty().WithMessage("Page Type is required.");

            RuleFor(x => x.PageIsonumber)
                .NotEmpty().WithMessage("Page ISO Number is required.")
                .MaximumLength(50).WithMessage("ISO Number must not exceed 50 characters.");

            RuleFor(x => x.KalaErppageDetailsRemark)
                .MaximumLength(500).WithMessage("Remark must not exceed 500 characters.");

            RuleFor(x => x.KalaErppageDetailsAuthRemark)
                .MaximumLength(500).WithMessage("Auth Remark must not exceed 500 characters.");

        
        }

      

        private async Task<bool> BeUniquePageUrl(string pageUrl, CancellationToken cancellationToken)
        {
            return !await _context.KalaErppageDetails
                .AnyAsync(p => EF.Functions.Like(p.PageUrl, pageUrl), cancellationToken);
        }
    }
}
