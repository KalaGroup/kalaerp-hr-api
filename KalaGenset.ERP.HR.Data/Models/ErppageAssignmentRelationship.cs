using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class ErppageAssignmentRelationship
{
    public int ErppageAssignmentRelationshipId { get; set; }

    public int ErppageAssignmentRelationshipDivisionId { get; set; }

    public int ErppageAssignmentRelationshipDepartmentId { get; set; }

    public int ErppageAssignmentRelationshipProfitcenterId { get; set; }

    public string ErppageAssignmentRelationshipRemark { get; set; } = null!;

    public string ErppageAssignmentRelationshipAuth1Remark { get; set; } = null!;

    public string ErppageAssignmentRelationshipAuth2Remark { get; set; } = null!;

    public bool ErppageAssignmentRelationshipAuth1 { get; set; }

    public bool ErppageAssignmentRelationshipAuth2 { get; set; }

    public bool ErppageAssignmentRelationshipIsDiscard { get; set; }

    public bool ErppageAssignmentRelationshipIsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int UpdatedBy { get; set; }

    public DateTime UpdatedDate { get; set; }

    public virtual DepartmentMaster ErppageAssignmentRelationshipDepartment { get; set; } = null!;

    public virtual ICollection<ErppageAssignmentRelationshipDetail> ErppageAssignmentRelationshipDetails { get; set; } = new List<ErppageAssignmentRelationshipDetail>();

    public virtual DivisionMaster ErppageAssignmentRelationshipDivision { get; set; } = null!;

    public virtual ProfitcenterMaster ErppageAssignmentRelationshipProfitcenter { get; set; } = null!;
}
