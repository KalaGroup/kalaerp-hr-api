using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class DivisionMaster
{
    public int DivisionId { get; set; }

    public string DivisionCode { get; set; } = null!;

    public string DivisionName { get; set; } = null!;

    public string DivisionShortName { get; set; } = null!;

    public string DivisionMailId { get; set; } = null!;

    public string DivisionRemark { get; set; } = null!;

    public string DivisionAuthRemark { get; set; } = null!;

    public bool DivisionAuth { get; set; }

    public bool DivisionIsDiscard { get; set; }

    public bool DivisionIsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int UpdatedBy { get; set; }

    public DateTime UpdatedDate { get; set; }

    public virtual ICollection<ActivityMaster> ActivityMasters { get; set; } = new List<ActivityMaster>();

    public virtual ICollection<AuthoritiesMaster> AuthoritiesMasters { get; set; } = new List<AuthoritiesMaster>();

    public virtual ICollection<DepartmentMaster> DepartmentMasters { get; set; } = new List<DepartmentMaster>();

    public virtual ICollection<KalaErppageDetail> KalaErppageDetails { get; set; } = new List<KalaErppageDetail>();

    public virtual ICollection<Kpamaster> Kpamasters { get; set; } = new List<Kpamaster>();

    public virtual ICollection<PositionMaster> PositionMasters { get; set; } = new List<PositionMaster>();

    public virtual ICollection<ResponsibilitiesMaster> ResponsibilitiesMasters { get; set; } = new List<ResponsibilitiesMaster>();

    public virtual ICollection<RolesMaster> RolesMasters { get; set; } = new List<RolesMaster>();
}
