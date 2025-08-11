using FluentValidation;
using KalaGenset.ERP.HR.Core.Request.Workstation;
using KalaGenset.ERP.HR.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Validation.WorkstationMasterValidation
{
    public class InsertWorkstationRequestValidator : AbstractValidator<InsertWorkstationRequest>
    {
        private readonly KalaDbContext _context;
        public InsertWorkstationRequestValidator(KalaDbContext context)
        {
            _context = context;

            RuleFor(x => x.WorkStationCode)
                    .NotEmpty().WithMessage("WorkStationName Code is required.")
                    .MaximumLength(10)
                    .Matches("^[a-zA-Z0-9]*$").WithMessage("WorkStationName Code must not contain special characters.");

            RuleFor(x => x.WorkStationName)
                    .NotEmpty().WithMessage("WorkStationName name is required.")
                    .MustAsync(BeUniqueWorkStationNameName).WithMessage("WorkStationName name already exists.")
                    .Matches("^[a-zA-Z0-9 ]*$").WithMessage("WorkStationName name must not contain special characters.")
                    .MaximumLength(100);

            RuleFor(x => x.WorkStationShortName)
                .NotEmpty().WithMessage("WorkStationName name is required.")
                .MustAsync(BeUniqueWorkStationNameName).WithMessage("WorkStationName name already exists.")
                .Matches("^[a-zA-Z0-9 ]*$").WithMessage("WorkStationName name must not contain special characters.")
                .MaximumLength(100);

            RuleFor(x => x.WorkStationProfitcenterId)
            .NotEmpty().WithMessage("WorkStationName name is required.");

            RuleFor(x => x.WorkStationType)
                .NotEmpty().WithMessage("WorkStationName name is required.")
                 .MustAsync(BeUniqueWorkStationNameName).WithMessage("WorkStationName name already exists.")
                .Matches("^[a-zA-Z0-9 ]*$").WithMessage("WorkStationName name must not contain special characters.")
                .MaximumLength(100);

            RuleFor(x => x.CreatedBy)
                    .NotEmpty().WithMessage("CreatedBy is required.");


        }

        private async Task<bool> BeUniqueWorkStationNameName(string WorkStationName, CancellationToken cancellationToken)
        {
            return !await _context.WorkStationMasters
                .AnyAsync(c => EF.Functions.Like(c.WorkStationName, WorkStationName), cancellationToken);
        }
    }
}
