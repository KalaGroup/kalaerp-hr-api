using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class QualificationMaster
{
    public int QualificationId { get; set; }

    public int MasterQualificationTypeId { get; set; }

    public string QualificationCode { get; set; } = null!;

    public string QualificationName { get; set; } = null!;

    public string QualificationRemark { get; set; } = null!;

    public bool QualificationAuth { get; set; }

    public bool QualificationIsDiscard { get; set; }

    public bool QualificationIsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual ICollection<DesignationMaster> DesignationMasters { get; set; } = new List<DesignationMaster>();

    public virtual QualificationTypeMaster MasterQualificationType { get; set; } = null!;
}
