using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class RolesMaster
{
    public int RolesId { get; set; }

    public int RolesGradeId { get; set; }

    public int RolesDesignationId { get; set; }

    public string RolesRemark { get; set; } = null!;

    public string RolesType { get; set; } = null!;

    public string RolesAuthRemark { get; set; } = null!;

    public bool RolesAuth { get; set; }

    public bool RolesIsDiscard { get; set; }

    public bool RolesIsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual DesignationMaster RolesDesignation { get; set; } = null!;

    public virtual ICollection<RolesDetail> RolesDetails { get; set; } = new List<RolesDetail>();

    public virtual GradeMaster RolesGrade { get; set; } = null!;
}
