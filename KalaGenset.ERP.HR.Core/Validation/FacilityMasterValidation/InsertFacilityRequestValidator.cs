using FluentValidation;
using KalaGenset.ERP.HR.Core.Request.Facility;
using KalaGenset.ERP.HR.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Validation.FacilityMaster
{
    public class InsertFacilityRequestValidator : AbstractValidator<InsertFacilityRequest>
    {
        private readonly KalaDbContext _context;
        public InsertFacilityRequestValidator(KalaDbContext context)
        {
            _context = context;

            RuleFor(x => x.FaciltyCode)
            .ApplyAlphaNumeric("Facility Code", 10, allowSpaces: false)
            .MustAsync(BeUniqueFacilityCode).WithMessage("Facility Code already exists");

            RuleFor(x => x.FacilityName)
                .ApplyAlphaNumeric("Facility Name", 100, allowSpaces: true)
               .MustAsync(BeUniqueFacilityName).WithMessage("Facility Name already exists.");

            RuleFor(x => x.FacilityRemark)
               .ApplyAlphaNumeric("Remark should not be blank. Remark", 100, allowSpaces: true);

            RuleFor(x => x.CreatedBy)
               .MustBePresentWhenNew("CreatedBy");

            RuleFor(x => x.CreatedDate)
                .MustBePastOrNowWhenNew("Created date");
        }

        private async Task<bool> BeUniqueFacilityName(string facilityName, CancellationToken cancellationToken)
        {
            return !await _context.FacilityMasters
                .AnyAsync(c => EF.Functions.Like(c.FacilityName, facilityName), cancellationToken);
        }
        private async Task<bool> BeUniqueFacilityCode(string facilityCode, CancellationToken cancellationToken)
        {
            return !await _context.FacilityMasters
                .AnyAsync(c => EF.Functions.Like(c.FaciltyCode, facilityCode), cancellationToken);
        }
    }
}
