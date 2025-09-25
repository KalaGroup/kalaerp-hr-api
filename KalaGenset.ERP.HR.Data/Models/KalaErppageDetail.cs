using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class KalaErppageDetail
{
    public int KalaErppageDetailsId { get; set; }

    public int KalaErppageDetailsDivisionId { get; set; }

    public string PageTittle { get; set; } = null!;

    public string PageUrl { get; set; } = null!;

    public int PageType { get; set; }

    public string PageIsonumber { get; set; } = null!;

    public string KalaErppageDetailsRemark { get; set; } = null!;

    public string KalaErppageDetailsAuthRemark { get; set; } = null!;

    public bool KalaErppageDetailsAuth { get; set; }

    public bool KalaErppageDetailsIsDiscard { get; set; }

    public bool KalaErppageDetailsIsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int UpdatedBy { get; set; }

    public DateTime UpdatedDate { get; set; }

    public virtual UserLogin CreatedByNavigation { get; set; } = null!;

    public virtual DivisionMaster KalaErppageDetailsDivision { get; set; } = null!;

    public virtual UserLogin UpdatedByNavigation { get; set; } = null!;
}
