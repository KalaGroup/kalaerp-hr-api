using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class PositionMasterQualificationDetail
{
    public int PositionQualificationDetailsId { get; set; }

    public int DetailsPositionMasterId { get; set; }

    public int PositionQualificationId { get; set; }

    public int SrNo { get; set; }

    public string PositionMasterQualificationDetailsDescription { get; set; } = null!;

    public virtual PositionMaster DetailsPositionMaster { get; set; } = null!;

    public virtual QualificationMaster PositionQualification { get; set; } = null!;
}
