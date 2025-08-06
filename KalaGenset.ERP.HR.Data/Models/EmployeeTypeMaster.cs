using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class EmployeeTypeMaster
{
    public int EmployeeTypeId { get; set; }

    public string EmployeeTypeCode { get; set; } = null!;

    public string EmployeeTypeName { get; set; } = null!;

    public string EmployeeTypeDescription { get; set; } = null!;

    public string EmployeeTypeRemark { get; set; } = null!;

    public string EmployeeTypeAuthRemark { get; set; } = null!;

    public bool EmployeeTypeAuth { get; set; }

    public bool EmployeeTypeIsDiscard { get; set; }

    public bool EmployeeTypeIsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }
}
