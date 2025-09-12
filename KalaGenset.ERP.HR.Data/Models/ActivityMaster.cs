using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class ActivityMaster
{
    public int ActivityId { get; set; }

    public int ActivityGradeId { get; set; }

    public int ActivityDesignationId { get; set; }

    public int ActivityDivisionId { get; set; }

    public string ActivityRemark { get; set; } = null!;

    public string ActivityAuthRemark { get; set; } = null!;

    public bool ActivityAuth { get; set; }

    public bool ActivityIsDiscard { get; set; }

    public bool ActivityIsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual DesignationMaster ActivityDesignation { get; set; } = null!;

    public virtual ICollection<ActivityDetail> ActivityDetails { get; set; } = new List<ActivityDetail>();

    public virtual DivisionMaster ActivityDivision { get; set; } = null!;

    public virtual GradeMaster ActivityGrade { get; set; } = null!;

    public virtual ICollection<PositionMaster> PositionMasters { get; set; } = new List<PositionMaster>();
}
