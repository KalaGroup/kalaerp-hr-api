using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class RecruitmentReferenceMaster
{
    public int RecruitmentReferenceId { get; set; }

    public string RecruitmentReferenceName { get; set; } = null!;

    public string RecruitmentReferenceRemark { get; set; } = null!;

    public string RecruitmentReferenceAuthRemark { get; set; } = null!;

    public bool RecruitmentReferenceAuth { get; set; }

    public bool RecruitmentReferenceIsDiscard { get; set; }

    public bool RecruitmentReferenceIsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual ICollection<RecruitmentMaster> RecruitmentMasters { get; set; } = new List<RecruitmentMaster>();
}
