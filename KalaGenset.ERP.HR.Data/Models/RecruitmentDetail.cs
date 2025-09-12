using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class RecruitmentDetail
{
    public int RecruitmentDetailsId { get; set; }

    public int DetailsRecruitmentMasterId { get; set; }

    public int RecruitmentDetailsInterviewRoundNumber { get; set; }

    public int RecruitmentDetailsMarksObtained { get; set; }

    public int RecruitmentDetailsAttributeId { get; set; }

    public virtual RecruitmentMaster DetailsRecruitmentMaster { get; set; } = null!;

    public virtual RecruitmentAttributeMaster RecruitmentDetailsAttribute { get; set; } = null!;
}
