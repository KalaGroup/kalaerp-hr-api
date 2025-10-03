using FluentValidation;
using KalaGenset.ERP.HR.Core.Request.PositionMaster;
using KalaGenset.ERP.HR.Core.Request.Workstation;
using KalaGenset.ERP.HR.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Validation.PositionMasterValidation
{
    public class InsertPositionMasterValidator : AbstractValidator<InsertPositionRequest>
    {
        private readonly KalaDbContext _context;
        public InsertPositionMasterValidator(KalaDbContext context)
        {
            _context = context;

            RuleFor(x => x.PositionMasterCode)
                     .NotEmpty().WithMessage("Position Master Code is required.")
                     .MaximumLength(10)
                     .Matches("^[a-zA-Z0-9]*$").WithMessage("Position Master Code must not contain special characters.");

            RuleFor(x => x.PositionMasterName)
                    .NotEmpty().WithMessage("Position Master name is required.")
                    .MustAsync(BeUniquePositionName).WithMessage("Position Master name already exists.")
                    .Matches("^[a-zA-Z]*$").WithMessage("Position Master name must not contain special characters.")
                    .MaximumLength(100);

            RuleFor(x => x.PositionMasterCompanyId)
            .NotEmpty().WithMessage("Position Master name is required.");

            RuleFor(x => x.PositionMasterDivisionId)
            .NotEmpty().WithMessage("Position Master name is required.");  

            RuleFor(x => x.PositionMasterProfitcenterId)
            .NotEmpty().WithMessage("Position Master name is required.");  

            RuleFor(x => x.PositionMasterGradeId)
            .NotEmpty().WithMessage("Position Master name is required.");  

            RuleFor(x => x.PositionMasterDesignationId)
            .NotEmpty().WithMessage("Position Master name is required."); 

            RuleFor(x => x.PositionMasterWorkStationId)
            .NotEmpty().WithMessage("Position Master name is required."); 

            RuleFor(x => x.PositionMasterRolesId)
            .NotEmpty().WithMessage("Position Master name is required."); 

            RuleFor(x => x.PositionMasterResponsibilitiesId)
            .NotEmpty().WithMessage("Position Master name is required."); 

            RuleFor(x => x.PositionMasterActivityId)
            .NotEmpty().WithMessage("Position Master name is required.");

            RuleFor(x => x.PositionMasterKpaid)
            .NotEmpty().WithMessage("Position Master name is required."); 

            RuleFor(x => x.PositionMasterEmployeeTypeId)
            .NotEmpty().WithMessage("Position Master name is required."); 

            RuleFor(x => x.CreatedBy)
                    .NotEmpty().WithMessage("CreatedBy is required.");
        }

        private async Task<bool> BeUniquePositionName(string PositionName, CancellationToken cancellationToken)
        {
            return !await _context.PositionMasters
                .AnyAsync(c => EF.Functions.Like(c.PositionMasterName, PositionName), cancellationToken);
        }
    }
}