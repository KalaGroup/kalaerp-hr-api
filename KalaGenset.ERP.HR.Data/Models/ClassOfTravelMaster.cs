using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class ClassOfTravelMaster
{
    public int ClassOfTravelId { get; set; }

    public string ClassOfTravelCode { get; set; } = null!;

    public string ClassOfTravelName { get; set; } = null!;

    public int ClassOfTravelGradeId { get; set; }

    public int DafoodAllowancePerday { get; set; }

    public int ClassOfTravelTierType { get; set; }

    public string ClassOfTravelRemark { get; set; } = null!;

    public bool ClassOfTravelIsAuth { get; set; }

    public bool ClassOfTravelIsDiscard { get; set; }

    public bool ClassOfTravelIsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual GradeMaster ClassOfTravelGrade { get; set; } = null!;
}
