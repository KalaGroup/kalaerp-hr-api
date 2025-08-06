using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class WorkStationMaster
{
    public int WorkStationId { get; set; }

    public string WorkStationCode { get; set; } = null!;

    public string WorkStationName { get; set; } = null!;

    public string WorkStationShortName { get; set; } = null!;

    public int WorkStationProfitcenterId { get; set; }

    public string WorkStationRemark { get; set; } = null!;

    public string WorkStationType { get; set; } = null!;

    public string WorkStationAuthRemark { get; set; } = null!;

    public bool WorkStationAuth { get; set; }

    public bool WorkStationIsDiscard { get; set; }

    public bool WorkStationIsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual ProfitcenterMaster WorkStationProfitcenter { get; set; } = null!;
}
