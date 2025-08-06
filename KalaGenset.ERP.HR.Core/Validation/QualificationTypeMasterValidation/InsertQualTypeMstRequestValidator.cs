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
    public class InsertQualTypeMstRequestValidator: AbstractValidator<InsertQualificationTypeMasterRequest>
    {
        private readonly KalaDbContext _context;
        public InsertQualTypeMstRequestValidator(KalaDbContext context)
        {
            _context = context;

            RuleFor(x => x.QualificationTypeCode)
                .ApplyAlphaNumeric("QualificationType code", 10, allowSpaces: false);

            RuleFor(x => x.QualificationTypeName)
                .ApplyAlphaNumeric("QualificationType name", 100, allowSpaces: true)
                .MustAsync(BeUniqueQualificationTypeName).WithMessage("Qualification name already exists.");

            RuleFor(x => x.CreatedBy)
               .MustBePresentWhenNew("CreatedBy");

            
        }

        private async Task<bool> BeUniqueQualificationTypeName(string QualificationTypeName, CancellationToken cancellationToken)
        {
            return !await _context.QualificationTypeMasters
                .AnyAsync(c => EF.Functions.Like(c.QualificationTypeName, QualificationTypeName), cancellationToken);
        }
    }
}
