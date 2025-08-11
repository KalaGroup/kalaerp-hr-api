using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class GradeMaster
{
    public int GradeId { get; set; }

    public string GradeCode { get; set; } = null!;

    public string GradeName { get; set; } = null!;

    public string GradeLevel { get; set; } = null!;

    public int MinSalCtc { get; set; }

    public int MaxSalCtc { get; set; }

    public int GradeCurrencyId { get; set; }

    public string GradeDescription { get; set; } = null!;

    public int LeaveEntitlementAnnual { get; set; }

    public int ProbationPeriod { get; set; }

    public int NoticePeriod { get; set; }

    public string GradeRemark { get; set; } = null!;

    public bool GradeAuth { get; set; }

    public bool GradeIsDiscard { get; set; }

    public bool GradeIsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual ICollection<ActivityMaster> ActivityMasters { get; set; } = new List<ActivityMaster>();

    public virtual ICollection<AuthoritiesMaster> AuthoritiesMasters { get; set; } = new List<AuthoritiesMaster>();

    public virtual ICollection<ClassOfTravelMaster> ClassOfTravelMasters { get; set; } = new List<ClassOfTravelMaster>();

    public virtual ICollection<CtcstructureMaster> CtcstructureMasters { get; set; } = new List<CtcstructureMaster>();

    public virtual ICollection<DesignationMaster> DesignationMasters { get; set; } = new List<DesignationMaster>();

    public virtual CurrencyMaster GradeCurrency { get; set; } = null!;

    public virtual ICollection<GradeFacilityAssignment> GradeFacilityAssignments { get; set; } = new List<GradeFacilityAssignment>();

    public virtual ICollection<Kpamaster> Kpamasters { get; set; } = new List<Kpamaster>();

    public virtual ICollection<ResponsibilitiesMaster> ResponsibilitiesMasters { get; set; } = new List<ResponsibilitiesMaster>();

    public virtual ICollection<RolesMaster> RolesMasters { get; set; } = new List<RolesMaster>();
}
