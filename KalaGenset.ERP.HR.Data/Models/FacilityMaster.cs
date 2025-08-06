using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class FacilityMaster
{
    public int FacilityId { get; set; }

    public string FaciltyCode { get; set; } = null!;

    public string FacilityName { get; set; } = null!;

    public string FacilityRemark { get; set; } = null!;

    public bool FacilityAuth { get; set; }

    public bool FacilityIsDiscard { get; set; }

    public bool FacilityIsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual ICollection<GradeFacilityAssignment> GradeFacilityAssignments { get; set; } = new List<GradeFacilityAssignment>();
}
