using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using KalaGenset.ERP.HR.Core.Request;
using KalaGenset.ERP.HR.Data.DbContexts;

namespace KalaGenset.ERP.HR.Core.Validation.PetrolAllowanceMaster
{
    public class UpdatePetrolAllowanceRequestValidator : AbstractValidator<UpdatePetrolAllowanceMasterRequest>
    {
        private readonly KalaDbContext _context;
        public UpdatePetrolAllowanceRequestValidator(KalaDbContext context)
        {
            _context = context;

            RuleFor(x => x.TwoWheelerPerKm)
                 .NotEmpty().WithMessage("Two Wheeler per km is required.")
                 .Matches("^[0-9]+$").WithMessage("Two Wheeler per km must contain only numbers."); ;

            RuleFor(x => x.FourWheelerPerKm)
                    .NotEmpty().WithMessage("QualificationType code is required.")
                    .Matches("^[0-9]+$").WithMessage("Two Wheeler per km must contain only numbers."); ;
                    
            RuleFor(x => x.CreatedBy)
                   .NotEmpty().WithMessage("CreatedBy is required.");
        
        }
    }
}
