using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using KalaGenset.ERP.HR.Core.Request;
using KalaGenset.ERP.HR.Core.Request.HolidayMaster;
using KalaGenset.ERP.HR.Data.DbContexts;

namespace KalaGenset.ERP.HR.Core.Validation.HolidayMaster
{
    public class UpdateHolidayMasterRequestValidator : AbstractValidator<UpdateHolidayMasterRequest>
    {
        private readonly KalaDbContext _context;
        public UpdateHolidayMasterRequestValidator(KalaDbContext context)
            {
                _context = context;

                RuleFor(x => x.HolidayId)
                    .GreaterThan(0).WithMessage("Holiday ID must be greater than 0.");

                RuleFor(x => x.HolidayFor)
                    .NotEmpty().WithMessage("Holiday For is required.")
                    .Matches("^[a-zA-Z0-9 -]*$").WithMessage("Holiday  must not contain special characters.")
                    .MaximumLength(100).WithMessage("Holiday  cannot exceed 100 characters.");

                RuleFor(x => x.CreatedBy)
                    .NotEmpty().WithMessage("CreatedBy is required.");
            }

        }
    }
