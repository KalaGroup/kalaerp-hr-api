using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class RecruitmentStageStatusMaster
{
    public int RecruitmentStageStatusId { get; set; }

    public string RecruitmentStageStatusName { get; set; } = null!;

    public string RecruitmentStageStatusRemark { get; set; } = null!;

    public string RecruitmentStageStatusAuthRemark { get; set; } = null!;

    public bool RecruitmentStageStatusAuth { get; set; }

    public bool RecruitmentStageStatusIsDiscard { get; set; }

    public bool RecruitmentStageStatusIsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int UpdatedBy { get; set; }

    public DateTime UpdatedDate { get; set; }

    public virtual ICollection<RecruitmentMaster> RecruitmentMasters { get; set; } = new List<RecruitmentMaster>();
}
