using FluentValidation;
using KalaGenset.ERP.HR.Core.Request.AuthoritieMaster;
using KalaGenset.ERP.HR.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace KalaGenset.ERP.HR.Core.Validation.AuthoritieMaster
{
    public class UpdateAuthoritieMasterValidator: AbstractValidator<UpdateAuthoritieMasterRequest>
    {
        private readonly KalaDbContext   context;
        public UpdateAuthoritieMasterValidator(KalaDbContext context)
        {
            this.context = context;
            RuleFor(x => x.AuthoritiesId)
                .GreaterThan(0).WithMessage("Authorities ID must be greater than 0.");
            RuleFor(x => x.AuthoritiesGradeId)
                .GreaterThan(0).WithMessage("Authorities Grade ID must be greater than 0.");
            RuleFor(x => x.AuthoritiesDesignationId)
                .GreaterThan(0).WithMessage("Authorities Designation ID must be greater than 0.");
            RuleFor(x => x.AuthoritiesType)
                .NotEmpty().WithMessage("Authorities Type is required.")
                .MaximumLength(50).WithMessage("Authorities Type cannot exceed 50 characters.");
        }
    }
}
