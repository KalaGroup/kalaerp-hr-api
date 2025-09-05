using FluentValidation;
using KalaERP.HR.Core.Request.CompanyMaster;
using KalaGenset.ERP.HR.Core.Request.RecruitmentStageStatusMaster;
using KalaGenset.ERP.HR.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Validation.RecruitmentStageStatusMaster
{
    public class InsertRecruitmentStageStatusMasterValidetor : AbstractValidator<InsertRecruitmentStageStatusMasterRequest>
    {
        private readonly KalaDbContext _context;

        public InsertRecruitmentStageStatusMasterValidetor(KalaDbContext context)
        {
            _context = context;
            RuleFor(x => x.RecruitmentStageStatusName)
                .NotEmpty().WithMessage("RecruitmentStage Name is required.")
                .MaximumLength(200).WithMessage("RecruitmentStage Name cannot exceed 200 characters.")
                .Must((model, name) => !context.RecruitmentStageStatusMasters
            .Any(r => r.RecruitmentStageStatusName == name))
        .WithMessage("RecruitmentStage Name already exists.");

            RuleFor(x => x.RecruitmentStageStatusAuth)
               .NotEmpty().WithMessage("RecruitmentStage  is required.");
        }
    }
}
