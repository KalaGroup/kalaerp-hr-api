using FluentValidation;
using KalaGenset.ERP.HR.Core.Request.ActivityDetails;
using KalaGenset.ERP.HR.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Validation.CTCStructureMaster
{
    public class UpdateCTCRequestValidator: AbstractValidator<UpdateCTCStructureMasterRequest>
    {
        private readonly KalaDbContext _context;
        /// <summary>
        /// validation Applay
        /// </summary>
        /// <param name="context"></param>
        public UpdateCTCRequestValidator(KalaDbContext context)
        {
            _context = context;

            RuleFor(x => x.CtcstructureId)
               .NotEmpty().WithMessage(" ID is required.");


            RuleFor(x => x.CtcmasterBasic)
                 .GreaterThan(0).WithMessage("Basic must be greater than 0.");

            RuleFor(x => x.CtcmasterDa)
                .GreaterThan(0).WithMessage("DA must be greater than 0.");


            RuleFor(x => x.CtcmasterHra)
                .GreaterThan(0).WithMessage("DA must be greater than 0.");

            RuleFor(x => x.CtcmasterConvAllowance)
                .GreaterThan(0).WithMessage("DA must be greater than 0.");

            RuleFor(x => x.CtcmasterCityCompensatoryAlowance)
               .GreaterThan(0).WithMessage("DA must be greater than 0.");

            RuleFor(x => x.CtcmasterLeaveTravelAllowance)
                .GreaterThan(0).WithMessage("DA must be greater than 0.");

            RuleFor(x => x.CtcmasterCarAllowance)
                .GreaterThan(0).WithMessage("DA must be greater than 0.");

            RuleFor(x => x.CtcmasterFuelAllowance)
               .GreaterThan(0).WithMessage("DA must be greater than 0.");

            RuleFor(x => x.CtcmasterDriverAllowance)
              .GreaterThan(0).WithMessage("DA must be greater than 0.");
            RuleFor(x => x.CtcmasterMiscAllowance)
                .GreaterThan(0).WithMessage("DA must be greater than 0.");
        }
    }
}
