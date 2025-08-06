using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class PetrolAllowanceMaster
{
    public int PetrolAllowanceId { get; set; }

    public string TwoWheelerPerKm { get; set; } = null!;

    public string FourWheelerPerKm { get; set; } = null!;

    public string PetrolAllowanceRemark { get; set; } = null!;

    public string PetrolAllowanceAuthRemark { get; set; } = null!;

    public bool PetrolAllowanceIsAuth { get; set; }

    public bool PetrolAllowanceIsDiscard { get; set; }

    public bool PetrolAllowanceIsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }
}
