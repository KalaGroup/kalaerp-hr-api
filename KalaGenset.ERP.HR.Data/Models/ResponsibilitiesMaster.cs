using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class ResponsibilitiesMaster
{
    public int ResponsibilitiesId { get; set; }

    public int ResponsibilitiesGradeId { get; set; }

    public int ResponsibilitiesDesignationId { get; set; }

    public int ResponsibilitiesDivisionId { get; set; }

    public string ResponsibilitiesRemark { get; set; } = null!;

    public string ResponsibilitiesType { get; set; } = null!;

    public string ResponsibilitiesAuthRemark { get; set; } = null!;

    public bool ResponsibilitiesAuth { get; set; }

    public bool ResponsibilitiesIsDiscard { get; set; }

    public bool ResponsibilitiesIsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual DesignationMaster ResponsibilitiesDesignation { get; set; } = null!;

    public virtual DivisionMaster ResponsibilitiesDivision { get; set; } = null!;

    public virtual GradeMaster ResponsibilitiesGrade { get; set; } = null!;
}
