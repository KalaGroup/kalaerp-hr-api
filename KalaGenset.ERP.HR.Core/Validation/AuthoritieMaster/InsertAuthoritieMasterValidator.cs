using FluentValidation;
using KalaGenset.ERP.HR.Core.Request.AuthoritieMaster;
using KalaGenset.ERP.HR.Core.Request.City;
using KalaGenset.ERP.HR.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace KalaGenset.ERP.HR.Core.Validation.AuthoritieMaster
{
    public class InsertAuthoritieMasterValidator: AbstractValidator<InsertAuthoritieMasterRequest>
    {
        /// <summary>
        /// service for managing authorities in the system.
        /// </summary>
        private readonly KalaDbContext context;
        /// <summary>
        /// constructor for initializing the InsertAuthoritieMasterValidator with the database context.
        /// </summary>
        /// <param name="context"></param>
        public InsertAuthoritieMasterValidator(KalaDbContext context)
        {
            ///validation rules for the InsertAuthoritieMasterRequest
            ///
            this.context = context;
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
