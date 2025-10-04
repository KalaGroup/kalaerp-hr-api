using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class EmployeeMasterEmploymentDetail
{
    public int EmployeeMasterEmploymentDetailsId { get; set; }

    public int EmploymentDetailsEmployeeMasterId { get; set; }

    public int EmploymentDetailsDivisionId { get; set; }

    public int EmploymentDetailsPositionId { get; set; }

    public int EmploymentDetailsOfferLetterId { get; set; }

    public int EmploymentDetailsEmployeeTypeId { get; set; }

    public int EmploymentDetailsParentCompanyId { get; set; }

    public int EmploymentDetailsCompanyEntityId { get; set; }

    public int EmploymentDetailsProfitcenterId { get; set; }

    public int EmploymentDetailsDepartmentId { get; set; }

    public int EmploymentDetailsWorkastationId { get; set; }

    public int EmploymentDetailsGradeId { get; set; }

    public int EmploymentDetailsDesignationId { get; set; }

    public int EmploymentDetailsReportToId { get; set; }

    public int EmploymentDetailsReportDepartmentHodid { get; set; }

    public string EmploymentDetailsRemark { get; set; } = null!;

    public string EmploymentDetailsAuth1Remark { get; set; } = null!;

    public string EmploymentDetailsAuth2Remark { get; set; } = null!;

    public string EmploymentDetailsAuth3Remark { get; set; } = null!;

    public bool EmploymentDetailsAuth1 { get; set; }

    public bool EmploymentDetailsAuth2 { get; set; }

    public bool EmploymentDetailsAuth3 { get; set; }

    public DateTime UpdatedDate { get; set; }

    public int UpdatedBy { get; set; }

    public virtual CompanyMaster EmploymentDetailsCompanyEntity { get; set; } = null!;

    public virtual DepartmentMaster EmploymentDetailsDepartment { get; set; } = null!;

    public virtual DesignationMaster EmploymentDetailsDesignation { get; set; } = null!;

    public virtual DivisionMaster EmploymentDetailsDivision { get; set; } = null!;

    public virtual EmployeeMasterPersonalDetail EmploymentDetailsEmployeeMaster { get; set; } = null!;

    public virtual EmployeeTypeMaster EmploymentDetailsEmployeeType { get; set; } = null!;

    public virtual GradeMaster EmploymentDetailsGrade { get; set; } = null!;

    public virtual OfferLetter EmploymentDetailsOfferLetter { get; set; } = null!;

    public virtual CompanyMaster EmploymentDetailsParentCompany { get; set; } = null!;

    public virtual PositionMaster EmploymentDetailsPosition { get; set; } = null!;

    public virtual ProfitcenterMaster EmploymentDetailsProfitcenter { get; set; } = null!;

    public virtual EmployeeMasterPersonalDetail EmploymentDetailsReportDepartmentHod { get; set; } = null!;

    public virtual EmployeeMasterPersonalDetail EmploymentDetailsReportTo { get; set; } = null!;

    public virtual WorkStationMaster EmploymentDetailsWorkastation { get; set; } = null!;

    public virtual UserLogin UpdatedByNavigation { get; set; } = null!;
}
