using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class CurrencyMaster
{
    public int CurrencyId { get; set; }

    public string CurrencyName { get; set; } = null!;

    public string CurrencySymbol { get; set; } = null!;

    public string CurrencyRemark { get; set; } = null!;

    public bool CurrencyAuth { get; set; }

    public bool CurrencyIsDiscard { get; set; }

    public bool CurrencyIsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }
}
