using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class HolidayMaster
{
    public int HolidayId { get; set; }

    public string HolidayFy { get; set; } = null!;

    public DateTime HolidayDate { get; set; }

    public string HolidayFor { get; set; } = null!;

    public int HolidayCompanyId { get; set; }

    public string HolidayRemark { get; set; } = null!;

    public string HolidayAuthRemark { get; set; } = null!;

    public bool HolidayAuth { get; set; }

    public bool HolidayIsDiscard { get; set; }

    public bool HolidayIsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int UpdatedBy { get; set; }

    public DateTime UpdatedDate { get; set; }

    public virtual CompanyMaster HolidayCompany { get; set; } = null!;
}
