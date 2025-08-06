using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using KalaGenset.ERP.HR.Core.Request;
using KalaGenset.ERP.HR.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace KalaGenset.ERP.HR.Core.Validation.PetrolAllowanceMaster
{
    public class InsertPetrolAllowanceRequestValidator:AbstractValidator<InsertPetrolAllowanceMasterRequest>
    {
        private readonly KalaDbContext _context;
        public InsertPetrolAllowanceRequestValidator(KalaDbContext context)
        {
            _context = context;

            RuleFor(x => x.TwoWheelerPerKm)
                  .NotEmpty().WithMessage("Two Wheeler per km is required.");

            RuleFor(x => x.FourWheelerPerKm)
                     .NotEmpty().WithMessage("Two Wheeler per km is required.");
            // .MustAsync(BeUniqueQualificationTypeName).WithMessage("Qualification name already exists."); 

            RuleFor(x => x.CreatedBy)
                   .MustBePresentWhenNew("CreatedBy");


        }

        //private async Task<bool> BeUniqueQualificationTypeName(string QualificationTypeName, CancellationToken cancellationToken)
        //{
        //    return !await _context.QualificationTypeMasters
        //        .AnyAsync(c => EF.Functions.Like(c.QualificationTypeName, QualificationTypeName), cancellationToken);
        //}
        
       
    }
}
