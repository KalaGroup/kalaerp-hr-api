using FluentValidation;
using KalaGenset.ERP.HR.Core.Request;
using KalaGenset.ERP.HR.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Validation
{
    public class CompanyEntityTypeRequestValidator: AbstractValidator<CompanyEntityTypeMasterRequest>
    {
        private readonly KalaDbContext _context;

        public CompanyEntityTypeRequestValidator(KalaDbContext context)
        {
            _context = context;

            RuleFor(x => x.CompanyEntityTypeName)
               .ApplyAlphaNumeric("Company Entity Type Name", 100, allowSpaces: true)
               .MustAsync(BeUniqueCompanyEnityType).WithMessage("Company Entity Type already exists.");
            RuleFor(x => x.CompanyEntityTypeShortName)
               .ApplyAlphaNumeric("Company Entity Type Short Name", 50, allowSpaces: true);

            RuleFor(x => x.CreatedBy)
                .MustBePresentWhenNew("CreatedBy");
        }

        private async Task<bool> BeUniqueCompanyEnityType(string CompanyEnityType, CancellationToken cancellationToken)
        {
            return !await _context.CompanyEntityTypeMasters
                .AnyAsync(c => EF.Functions.Like(c.CompanyEntityTypeName, CompanyEnityType), cancellationToken);
        }
    }
}
