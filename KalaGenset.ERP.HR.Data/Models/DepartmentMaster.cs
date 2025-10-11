using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class DepartmentMaster
{
    public int DepartmentId { get; set; }

    public string DepartmentCode { get; set; } = null!;

    public string DepartmentName { get; set; } = null!;

    public string DepartmentShortName { get; set; } = null!;

    public int? DepartmentDivisionId { get; set; }

    public int? ParentDepartmentId { get; set; }

    public int DepartmentProfitcenterId { get; set; }

    public string DepartmentRemark { get; set; } = null!;

    public string DepartmentType { get; set; } = null!;

    public string DepartmentAuthRemark { get; set; } = null!;

    public bool DepartmentAuth { get; set; }

    public bool DepartmentIsDiscard { get; set; }

    public bool DepartmentIsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int UpdatedBy { get; set; }

    public DateTime UpdatedDate { get; set; }

    public virtual ICollection<DepartmentBudget> DepartmentBudgets { get; set; } = new List<DepartmentBudget>();

    public virtual DivisionMaster? DepartmentDivision { get; set; }

    public virtual ProfitcenterMaster DepartmentProfitcenter { get; set; } = null!;

    public virtual ICollection<EmployeeMasterEmploymentDetail> EmployeeMasterEmploymentDetails { get; set; } = new List<EmployeeMasterEmploymentDetail>();

    public virtual ICollection<ErppageAssignmentRelationship> ErppageAssignmentRelationships { get; set; } = new List<ErppageAssignmentRelationship>();

    public virtual ICollection<DepartmentMaster> InverseParentDepartment { get; set; } = new List<DepartmentMaster>();

    public virtual DepartmentMaster? ParentDepartment { get; set; }

    public virtual ICollection<PositionMaster> PositionMasters { get; set; } = new List<PositionMaster>();
}
