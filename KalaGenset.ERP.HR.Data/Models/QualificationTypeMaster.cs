using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class QualificationTypeMaster
{
    public int QualificationTypeId { get; set; }

    public string QualificationTypeCode { get; set; } = null!;

    public string QualificationTypeName { get; set; } = null!;

    public string QualificationTypeRemark { get; set; } = null!;

    public bool QualificationTypeAuth { get; set; }

    public bool QualificationTypeIsDiscard { get; set; }

    public bool QualificationTypeIsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual ICollection<QualificationMaster> QualificationMasters { get; set; } = new List<QualificationMaster>();
}
