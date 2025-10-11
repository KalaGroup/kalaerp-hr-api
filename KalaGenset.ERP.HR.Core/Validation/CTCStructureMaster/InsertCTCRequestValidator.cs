using FluentValidation;
using KalaGenset.ERP.HR.Core.Request.ActivityDetails;
using KalaGenset.ERP.HR.Core.Request.Currency;
using KalaGenset.ERP.HR.Core.Validation.AuthoritieMaster;
using KalaGenset.ERP.HR.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Validation.CTCStructureMaster
{
    public class InsertCTCRequestValidator : AbstractValidator<InsertCTCStructureMasterRequest>
    {
        private readonly KalaDbContext _context;

        public InsertCTCRequestValidator(KalaDbContext context)
        {
            _context = context;

            RuleFor(x => x.CtcmasterBasic)
                .GreaterThan(0).WithMessage("Basic pay must be a number greater than 0.");

            RuleFor(x => x.CtcmasterDa)
                .GreaterThan(0).WithMessage("Dearness Allowance (DA) must be a number greater than 0.");



            RuleFor(x => x.CtcmasterConvAllowance)
                .GreaterThan(0).WithMessage("Conveyance Allowance must be a number greater than 0.");

            RuleFor(x => x.CtcmasterCityCompensatoryAlowance)
                .GreaterThan(0).WithMessage("City Compensatory Allowance must be a number greater than 0.");

            RuleFor(x => x.CtcmasterLeaveTravelAllowance)
                .GreaterThan(0).WithMessage("Leave Travel Allowance must be a number greater than 0.");

            RuleFor(x => x.CtcmasterCarAllowance)
                .GreaterThan(0).WithMessage("Car Allowance must be a number greater than 0.");

            RuleFor(x => x.CtcmasterFuelAllowance)
                .GreaterThan(0).WithMessage("Fuel Allowance must be a number greater than 0.");

            RuleFor(x => x.CtcmasterDriverAllowance)
                .GreaterThan(0).WithMessage("Driver Allowance must be a number greater than 0.");

            RuleFor(x => x.CtcmasterMiscAllowance)
                .GreaterThan(0).WithMessage("Miscellaneous Allowance must be a number greater than 0.");
        }
    }
}
