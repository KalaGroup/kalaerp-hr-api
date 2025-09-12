using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class RecruitmentMaster
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

    public virtual ICollection<RecruitmentDetail> RecruitmentDetails { get; set; } = new List<RecruitmentDetail>();

    public virtual CityMaster RecruitmentMasterCity { get; set; } = null!;

    public virtual CompanyMaster RecruitmentMasterCompany { get; set; } = null!;

    public virtual DesignationMaster RecruitmentMasterDesignation { get; set; } = null!;

    public virtual RecruitmentStageStatusMaster RecruitmentMasterDesignationNavigation { get; set; } = null!;

    public virtual GradeMaster RecruitmentMasterGrade { get; set; } = null!;

    public virtual PositionMaster RecruitmentMasterPosition { get; set; } = null!;

    public virtual RecruitmentReferenceMaster RecruitmentMasterReference { get; set; } = null!;
}
