using FluentValidation;
using KalaGenset.ERP.HR.Core.Request.District;
using KalaGenset.ERP.HR.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Validation.DistrictMasterValidation
{
    public class UpdateDistrictRequestValidator : AbstractValidator<UpdateDistrictRequest>
    {

        private readonly KalaDbContext _context;
        public UpdateDistrictRequestValidator(KalaDbContext context)
        {
            _context = context;


            RuleFor(x => x.DistrictName)
                .NotEmpty().WithMessage("District name is required.")
                .MustAsync(BeUniqueDistrictName).WithMessage("District name already exists.")
                .Matches("^[a-zA-Z ]*$").WithMessage("District name must not contain special characters.")
                .MaximumLength(100);

            RuleFor(x => x.ShortName)
               .NotEmpty().WithMessage("Short Name is required.")
               .MustAsync(BeUniqueDistrictShortName).WithMessage("Short Name already exists.")
               .Matches("^[a-zA-Z]*$").WithMessage("Short Name must not contain special characters.")
               .MaximumLength(10);

                    RuleFor(x => x.DistrictCode)
           .NotEmpty().WithMessage("DistrictCode is required.")
           .MustAsync(BeUniqueDistrictCode).WithMessage("DistrictCode already exists.")
           .Matches("^[A-Z]+$").WithMessage("DistrictCode must contain only uppercase letters without special characters.")
           .MaximumLength(10);


        }

        private async Task<bool> BeUniqueDistrictName(string DistrictName, CancellationToken cancellationToken)
        {
            return !await _context.DistrictMasters
                .AnyAsync(c => EF.Functions.Like(c.DistrictName, DistrictName), cancellationToken);
        }

        private async Task<bool> BeUniqueDistrictShortName(string ShortName, CancellationToken cancellationToken)
        {
            return !await _context.DistrictMasters
                .AnyAsync(c => EF.Functions.Like(c.ShortName, ShortName), cancellationToken);
        }
        private async Task<bool> BeUniqueDistrictCode(string DistrictCode, CancellationToken cancellationToken)
        {
            return !await _context.DistrictMasters
                .AnyAsync(c => EF.Functions.Like(c.DistrictCode, DistrictCode), cancellationToken);
        }
    }
}

