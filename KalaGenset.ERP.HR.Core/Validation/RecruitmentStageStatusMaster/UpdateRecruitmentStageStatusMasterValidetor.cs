using FluentValidation;
using KalaGenset.ERP.HR.Core.Request.RecruitmentStageStatusMaster;
using KalaGenset.ERP.HR.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Validation.RecruitmentStageStatusMaster
{
        public class UpdateRecruitmentStageStatusMasterValidetor : AbstractValidator<UpdateRecruitmentStageStatusMasterRequest>
        {
            private readonly KalaDbContext _context;
            public UpdateRecruitmentStageStatusMasterValidetor(KalaDbContext context)
            {
                _context = context;

            RuleFor(x => x.RecruitmentStageStatusId)
           .GreaterThan(0).WithMessage("Qualification ID must be greater than 0.");


            RuleFor(x => x.RecruitmentStageStatusName)
    .NotEmpty().WithMessage("RecruitmentStage Name is required.")
    .MaximumLength(200).WithMessage("RecruitmentStage Name cannot exceed 200 characters.")
    .Matches("^[A-Za-z ]+$").WithMessage("RecruitmentStage Name must contain only letters and spaces.");
  
   



            RuleFor(x => x.RecruitmentStageStatusAuth)
                   .NotEmpty().WithMessage("RecruitmentStage  is required.");
            }
        }
    
}
