using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class RecruitmentAttributeMaster
{
    public int RecruitmentAttributeId { get; set; }

    public string RecruitmentAttributeName { get; set; } = null!;

    public int RecruitmentAttributeMarks { get; set; }

    public string RecruitmentAttributeRemark { get; set; } = null!;

    public string RecruitmentAttributeAuthRemark { get; set; } = null!;

    public bool RecruitmentAttributeAuth { get; set; }

    public bool RecruitmentAttributeIsDiscard { get; set; }

    public bool RecruitmentAttributeIsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual ICollection<RecruitmentDetail> RecruitmentDetails { get; set; } = new List<RecruitmentDetail>();
}
