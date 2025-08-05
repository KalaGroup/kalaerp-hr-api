using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class GradeFacilityAssignment
{
    public int GradeFacilityAssignmentId { get; set; }

    public int AssignmentGradeId { get; set; }

    public int AssignmentFacilityId { get; set; }

    public virtual FacilityMaster AssignmentFacility { get; set; } = null!;
}
