using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class GatePassType
{
    public int GatePassTypeId { get; set; }

    public string GatePassTypesTypeCode { get; set; } = null!;

    public string GatePassTypesTypeName { get; set; } = null!;

    public string GatePassTypesDescription { get; set; } = null!;

    public bool GatePassTypesRequiresApproval { get; set; }

    public bool GatePassTypesIsAuth { get; set; }

    public string GatePassTypesAuthRemark { get; set; } = null!;

    public bool GatePassTypesIsActive { get; set; }

    public bool GatePassTypesIsDiscard { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int UpdatedBy { get; set; }

    public DateTime UpdatedDate { get; set; }

    public virtual UserLogin CreatedByNavigation { get; set; } = null!;

    public virtual UserLogin UpdatedByNavigation { get; set; } = null!;
}
