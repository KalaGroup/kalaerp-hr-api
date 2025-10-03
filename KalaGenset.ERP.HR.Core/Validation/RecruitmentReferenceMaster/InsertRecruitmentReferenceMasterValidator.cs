using FluentValidation;
using KalaGenset.ERP.HR.Core.Request.RecruitmentAttributeMaster;
using KalaGenset.ERP.HR.Core.Request.RecruitmentReferenceMaster;
using KalaGenset.ERP.HR.Core.Request.RolesMaster;
using KalaGenset.ERP.HR.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Validation.RecruitmentReferenceMaster
{
    public class InsertRecruitmentReferenceMasterValidator : AbstractValidator<InsertRecruitmentReferenceMasterRequest>
    {
        private readonly KalaDbContext _context;
        public InsertRecruitmentReferenceMasterValidator(KalaDbContext context)
        {
            _context = context;

            RuleFor(x => x.RecruitmentReferenceName)
                     .NotEmpty().WithMessage("RecruitmentReferenceName is required.") 
            .Matches("^[A-Za-z ]+$")
            .WithMessage("Recruitment Reference Name must contain only letters.");

            RuleFor(x => x.RecruitmentReferenceAuthRemark)
             .NotEmpty().WithMessage("RecruitmentReferenceAuthRemark is required.");
        }

      
    }
}
