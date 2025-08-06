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
   public  class InsertQualificationRequestValidator : AbstractValidator<InsertQualificationRequest>
    {
        private readonly KalaDbContext _context;
        public InsertQualificationRequestValidator(KalaDbContext context)
        {
            _context = context;

            RuleFor(x => x.QualificationCode)
                    .NotEmpty().WithMessage("Qualification Code is required.")
                    .MaximumLength(10)
                    .Matches("^[a-zA-Z0-9]*$").WithMessage("Qualification Code must not contain special characters.");

            RuleFor(x => x.QualificationName)
                    .NotEmpty().WithMessage("Qualification name is required.")
                    .MustAsync(BeUniqueStateName).WithMessage("Qualification name already exists.")
                    .Matches("^[a-zA-Z0-9 ]*$").WithMessage("Qualification name must not contain special characters.")
                    .MaximumLength(100);

            RuleFor(x => x.CreatedBy)
                    .NotEmpty().WithMessage("CreatedBy is required.");

            
        }

        private async Task<bool> BeUniqueStateName(string qualificationName, CancellationToken cancellationToken)
        {
            return !await _context.QualificationMasters
                .AnyAsync(c => EF.Functions.Like(c.QualificationName, qualificationName), cancellationToken);
        }
    }
}
