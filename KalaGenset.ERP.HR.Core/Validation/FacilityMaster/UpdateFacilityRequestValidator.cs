using FluentValidation;
using KalaGenset.ERP.HR.Core.Request.Facility;
using KalaGenset.ERP.HR.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Validation.FacilityMaster
{
    public class UpdateFacilityRequestValidator : AbstractValidator<UpdateFacilityRequest>
    {
        private readonly KalaDbContext _context;

        public UpdateFacilityRequestValidator(KalaDbContext context)
        {
            _context = context;
            RuleFor(x => x.FacilityName)
               .ApplyAlphaNumeric("Facility Name required", 100, allowSpaces: true);
            RuleFor(x => x.FacilityId)
                .MustBePresentWhenNew("FacilityId");
            RuleFor(x => x.FacilityRemark)
               .ApplyAlphaNumeric("Remark should not be blank. Remark", 100, allowSpaces: true);

        }

    }
}
