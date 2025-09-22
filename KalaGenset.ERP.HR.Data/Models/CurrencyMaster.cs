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

    public int UpdatedBy { get; set; }

    public DateTime UpdatedDate { get; set; }

    public virtual ICollection<CompanyMaster> CompanyMasters { get; set; } = new List<CompanyMaster>();

    public virtual ICollection<CountryMaster> CountryMasters { get; set; } = new List<CountryMaster>();

    public virtual ICollection<GradeMaster> GradeMasters { get; set; } = new List<GradeMaster>();
}
