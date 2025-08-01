using FluentValidation;
using KalaGenset.ERP.HR.Core.Request.District;
using KalaGenset.ERP.HR.Data.DbContexts;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KalaGenset.ERP.HR.Core.Validator
{
    public class InsertDistrictRequestValidator : AbstractValidator<InsertDistrictRequest>
    {
        private readonly KalaDbContext _context;
        public InsertDistrictRequestValidator(KalaDbContext context)
        {
            _context = context;





                   RuleFor(x => x.DistrictCode)
           .NotEmpty().WithMessage("DistrictCode is required.")
           .MustAsync(BeUniqueDistrictCode).WithMessage("DistrictCode already exists.")
           .Matches("^[A-Z]+$").WithMessage("DistrictCode must contain only uppercase letters without special characters.")
           .MaximumLength(10);


            RuleFor(x => x.DistrictName)
                .NotEmpty().WithMessage("District name is required.")
                .MustAsync(BeUniqueDistrictName).WithMessage("District name already exists.")
                .Matches("^[a-zA-Z ]*$").WithMessage("District name must not contain special characters.")
                .MaximumLength(100);

            RuleFor(x => x.ShortName)
                .NotEmpty().WithMessage("District short name is required.")
                .MustAsync(BeUniqueDistrictShortName).WithMessage("District name already exists.")
                .Matches("^[a-zA-Z]*$").WithMessage("District short name must not contain special characters.")
                .MaximumLength(10);

            RuleFor(x => x.CountryId)
                .GreaterThan(0).WithMessage("Country ID must be greater than 0.");
            RuleFor(x => x.StateId)
               .GreaterThan(0).WithMessage("State ID must be greater than 0.");

            RuleFor(x => x.CreatedBy)
                .NotEmpty().WithMessage("CreatedBy is required.");

            RuleFor(x => x.CreatedDate)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Created date can't be in the future.");
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
