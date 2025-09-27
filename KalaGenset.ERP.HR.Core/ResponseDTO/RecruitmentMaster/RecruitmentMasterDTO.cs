using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.ResponseDTO.RecruitmentMaster
{
    public class RecruitmentMasterDTO
    {
        public int RecruitmentMasterId { get; set; }

        public string RecruitmentMasterPositionName { get; set; } = null!;   // string

        public string RecruitmentMasterCode { get; set; } = null!;

        public string RecruitmentReferenceName { get; set; } = null!; // string

        public string RecruitmentMasterReferenceName { get; set; } = null!;

        public string RecruitmentMasterReferenceCode { get; set; } = null!;

        public string RecruitmentMasterNameOfCandidates { get; set; } = null!;

        public string CityName { get; set; } = null!;             // string

        public string CompanyName { get; set; } = null!;          // string

        public string RecruitmentMasterCandidateEmailId { get; set; } = null!;

        public string RecruitmentMasterCandidateContactNumber { get; set; } = null!;

        public string RecruitmentMasterAppropriateForJobRole { get; set; } = null!;

        public string RecruiterFullName { get; set; } = null!; // string

        public string RecruitmentMasterInterviewerComment { get; set; } = null!;

        public string GradeName { get; set; } = null!;            // string

        public string DesignationName { get; set; } = null!;      // string

        public double RecruitmentMasterCurrentCTCPA { get; set; }

        public double RecruitmentMasterExpectedCTCPA { get; set; }

        public double RecruitmentMasterRecommendedCTCPA { get; set; }

        public DateTime RecruitmentMasterExpectedJoiningDate { get; set; }

        public string RecruitmentMasterHrcomment { get; set; } = null!;

        public string RecruitmentStageStatusName { get; set; } = null!; // string

        public string RecruitmentMasterOfferLetterStatus { get; set; } = null!;

        public string RecruitmentMasterRemark { get; set; } = null!;

        public string RecruitmentMasterAuthRemark { get; set; } = null!;

        public bool RecruitmentMasterAuth { get; set; }

        public bool RecruitmentMasterIsDiscard { get; set; }

        public bool RecruitmentMasterIsActive { get; set; }
    }

}
