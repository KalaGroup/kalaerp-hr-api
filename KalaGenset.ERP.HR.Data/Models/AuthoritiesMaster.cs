using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class AuthoritiesMaster
{
    public int AuthoritiesId { get; set; }

    public int AuthoritiesGradeId { get; set; }

    public int AuthoritiesDesignationId { get; set; }

    public string AuthoritiesRemark { get; set; } = null!;

    public string AuthoritiesType { get; set; } = null!;

    public string AuthoritiesAuthRemark { get; set; } = null!;

    public bool AuthoritiesAuth { get; set; }

    public bool AuthoritiesIsDiscard { get; set; }

    public bool AuthoritiesIsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual DesignationMaster AuthoritiesDesignation { get; set; } = null!;

    public virtual ICollection<AuthoritiesDetail> AuthoritiesDetails { get; set; } = new List<AuthoritiesDetail>();

    public virtual GradeMaster AuthoritiesGrade { get; set; } = null!;
}
