using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KalaGenset.ERP.HR.Core.Request.RecruitmentMaster.InsertRecruitmentMasterRequest;

namespace KalaGenset.ERP.HR.Core.Request.RecruitmentMaster
{
    public class UpdateRecruitmentMasterRequest
    {
        public int RecruitmentMasterId { get; set; }

        public int RecruitmentMasterPositionId { get; set; }

        public string RecruitmentMasterCode { get; set; } = null!;

        public int RecruitmentMasterReferenceId { get; set; }

        public string RecruitmentMasterReferenceName { get; set; } = null!;

        public string RecruitmentMasterReferenceCode { get; set; } = null!;

        public string RecruitmentMasterNameOfCandidates { get; set; } = null!;

        public int RecruitmentMasterCityId { get; set; }

        public int RecruitmentMasterCompanyId { get; set; }

        public string RecruitmentMasterCandidateEmailId { get; set; } = null!;

        public string RecruitmentMasterCandidateContactNumber { get; set; } = null!;

        public string RecruitmentMasterAppropriateForJobRole { get; set; } = null!;

        public int RecruitmentMasterInterviewerEmployeeId { get; set; }

        public string RecruitmentMasterInterviewerComment { get; set; } = null!;

        public int RecruitmentMasterGradeId { get; set; }

        public int RecruitmentMasterDesignationId { get; set; }

        public double RecruitmentMasterCurrentCtcpa { get; set; }

        public double RecruitmentMasterExpectedCtcpa { get; set; }

        public double RecruitmentMasterRecommendedCtcpa { get; set; }

        public DateTime RecruitmentMasterExpectedJoiningDate { get; set; }

        public string RecruitmentMasterHrcomment { get; set; } = null!;

        public int RecruitmentMasterRecruitmentStageStatusId { get; set; }

        public string RecruitmentMasterOfferLetterStatus { get; set; } = null!;

        public string RecruitmentMasterRemark { get; set; } = null!;

        public string RecruitmentMasterAuthRemark { get; set; } = null!;

        public bool RecruitmentMasterAuth { get; set; }

        public bool RecruitmentMasterIsDiscard { get; set; }

        public bool RecruitmentMasterIsActive { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
        public List<RecruitmentDetailRequest> RecruitmentDetails { get; set; }
      

    }
}
