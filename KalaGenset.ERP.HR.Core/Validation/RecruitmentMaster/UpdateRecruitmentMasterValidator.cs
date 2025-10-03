using FluentValidation;
using KalaGenset.ERP.HR.Core.Request.RecruitmentAttributeMaster;
using KalaGenset.ERP.HR.Core.Request.RecruitmentMaster;
using KalaGenset.ERP.HR.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Validation.RecruitmentMaster
{
    public class UpdateRecruitmentMasterValidator : AbstractValidator<UpdateRecruitmentMasterRequest>
    {
        private readonly KalaDbContext context;
        public UpdateRecruitmentMasterValidator(KalaDbContext context)
        {
            this.context = context;

            RuleFor(x => x.RecruitmentMasterPositionId)
         .NotEmpty().WithMessage("PositionId is required.")
         .GreaterThan(0).WithMessage("PositionId must be a positive integer.");

            RuleFor(x => x.RecruitmentMasterCode)
                .NotEmpty().WithMessage("Code is required.")
                .MaximumLength(50).WithMessage("Code cannot exceed 50 characters.");

            RuleFor(x => x.RecruitmentMasterReferenceId)
                .NotEmpty().WithMessage("ReferenceId is required.")
                .GreaterThan(0).WithMessage("ReferenceId must be a positive integer.");

            RuleFor(x => x.RecruitmentMasterReferenceName)
                .NotEmpty().WithMessage("ReferenceName is required.")
                .Matches("^[A-Za-z ]+$")
            .WithMessage("Recruitment Reference Name must contain only letters.")
                .MaximumLength(100);

            RuleFor(x => x.RecruitmentMasterReferenceCode)
                .NotEmpty().WithMessage("ReferenceCode is required.")
                .MaximumLength(10);

            RuleFor(x => x.RecruitmentMasterNameOfCandidates)
                .NotEmpty().WithMessage("Candidate name is required.")
                .MaximumLength(150);

            RuleFor(x => x.RecruitmentMasterCityId)
                .NotEmpty().WithMessage("CityId is required.")
                .GreaterThan(0);

            RuleFor(x => x.RecruitmentMasterCompanyId)
                .NotEmpty().WithMessage("CompanyId is required.")
                .GreaterThan(0);

            RuleFor(x => x.RecruitmentMasterCandidateEmailId)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.RecruitmentMasterCandidateContactNumber)
                .NotEmpty().WithMessage("Contact number is required.")
                .Matches(@"^[0-9]{7,15}$").WithMessage("Contact number must be between 7 and 15 digits.");

            RuleFor(x => x.RecruitmentMasterAppropriateForJobRole)
                .NotEmpty().WithMessage("AppropriateForJobRole is required.")
                .MaximumLength(200);

            RuleFor(x => x.RecruitmentMasterInterviewerEmployeeId)
                .NotEmpty().WithMessage("InterviewerEmployeeId is required.")
                .GreaterThan(0);

            RuleFor(x => x.RecruitmentMasterInterviewerComment)
                .MaximumLength(500);

            RuleFor(x => x.RecruitmentMasterGradeId)
                .NotEmpty().WithMessage("GradeId is required.")
                .GreaterThan(0);

            RuleFor(x => x.RecruitmentMasterDesignationId)
                .NotEmpty().WithMessage("DesignationId is required.")
                .GreaterThan(0);

            RuleFor(x => x.RecruitmentMasterCurrentCtcpa)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.RecruitmentMasterExpectedCtcpa)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.RecruitmentMasterRecommendedCtcpa)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.RecruitmentMasterExpectedJoiningDate)
                .NotEmpty().WithMessage("ExpectedJoiningDate is required.")
                .GreaterThanOrEqualTo(DateTime.Today).WithMessage("Joining date cannot be in the past.");

            RuleFor(x => x.RecruitmentMasterHrcomment)
                .MaximumLength(500);

            RuleFor(x => x.RecruitmentMasterRecruitmentStageStatusId)
                .NotEmpty().WithMessage("RecruitmentStageStatusId is required.")
                .GreaterThan(0);

            RuleFor(x => x.RecruitmentMasterOfferLetterStatus)
                .NotEmpty().WithMessage("OfferLetterStatus is required.")
                .MaximumLength(50);
        }
    }
}
