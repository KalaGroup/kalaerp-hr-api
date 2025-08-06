using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using KalaGenset.ERP.HR.Core.Request;
using KalaGenset.ERP.HR.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace KalaGenset.ERP.HR.Core.Validation.QualificationTypeMaster
{
    public class UpdateQualTypeMstRequestValidator : AbstractValidator<UpdateQualificationTypeMasterRequest>
    {
        private readonly KalaDbContext _context;
        public UpdateQualTypeMstRequestValidator(KalaDbContext context)
        {
            _context = context;

            RuleFor(x => x.QualificationTypeId)
                .GreaterThan(0).WithMessage("Qualification ID must be greater than 0.");

            RuleFor(x => x.QualificationTypeCode)
                .NotEmpty().WithMessage("QualificationType code is required.")
                .Length(3).WithMessage("QualificationTypeCode must be exactly 3 characters long.");

            RuleFor(x => x.QualificationTypeName)
                .NotEmpty().WithMessage("QualificationTypeName name is required.")
                .Matches("^[a-zA-Z0-9 -]*$").WithMessage("QualificationTypeName  must not contain special characters.")
                .MaximumLength(100).WithMessage("QualificationTypeName  cannot exceed 100 characters.");

            RuleFor(x => x.CreatedBy)
                .NotEmpty().WithMessage("CreatedBy is required.");
        }


        private async Task<bool> BeUniqueCountryName(string QualificationTypeName, CancellationToken cancellationToken)
        {
            return !await _context.QualificationTypeMasters
                .AnyAsync(c => EF.Functions.Like(c.QualificationTypeName, QualificationTypeName), cancellationToken);


        }
    }
}
