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

    public class InsertHolidayMasterRequestValidator : AbstractValidator<InsertHolidayMasterRequest>
    {
        private readonly KalaDbContext _context;
        public InsertHolidayMasterRequestValidator(KalaDbContext context)
        {
            _context = context;

            //RuleFor(x => x.HolidayFy)
            //    .NotEmpty().WithMessage("HolidayFy is required.");

            //RuleFor(x => x.HolidayDate)
            //   .NotEmpty().WithMessage("Holiday Date is required.");

            //RuleFor(x => x.HolidayFor)
            //    .NotEmpty().WithMessage("HolidayFy is required.")
            //    .ApplyAlphaNumeric("Holiday For", 100, allowSpaces: true);

            //RuleFor(x => x.HolidayRemark)
            //    .ApplyAlphaNumeric("Holiday Remark", 500, allowSpaces: true);

            //RuleFor(x => x.CreatedBy)
            //   .MustBePresentWhenNew("CreatedBy");
        }
    }
}
