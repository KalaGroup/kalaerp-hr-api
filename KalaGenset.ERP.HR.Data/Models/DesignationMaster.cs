using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class DesignationMaster
{
    public int DesignationId { get; set; }

    public int DesignationGradeId { get; set; }

    public string DesignationCode { get; set; } = null!;

    public string DesignationName { get; set; } = null!;

    public int DesignationQualificationId { get; set; }

    public string DesignationDescription { get; set; } = null!;

    public string GradeQualificationRemark { get; set; } = null!;

    public string RequiredSkills { get; set; } = null!;

    public string DesignationRemark { get; set; } = null!;

    public virtual ICollection<ActivityMaster> ActivityMasters { get; set; } = new List<ActivityMaster>();

    public virtual ICollection<AuthoritiesMaster> AuthoritiesMasters { get; set; } = new List<AuthoritiesMaster>();

    public virtual GradeMaster DesignationGrade { get; set; } = null!;

    public virtual QualificationMaster DesignationQualification { get; set; } = null!;

    public virtual ICollection<Kpamaster> Kpamasters { get; set; } = new List<Kpamaster>();

    public virtual ICollection<PositionMaster> PositionMasters { get; set; } = new List<PositionMaster>();

    public virtual ICollection<RecruitmentMaster> RecruitmentMasters { get; set; } = new List<RecruitmentMaster>();

    public virtual ICollection<ResponsibilitiesMaster> ResponsibilitiesMasters { get; set; } = new List<ResponsibilitiesMaster>();

    public virtual ICollection<RolesMaster> RolesMasters { get; set; } = new List<RolesMaster>();
}
