using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class PositionMaster
{
    public int PositionMasterId { get; set; }

    public string PositionMasterCode { get; set; } = null!;

    public string PositionMasterName { get; set; } = null!;

    public int PositionMasterEmployeeTypeId { get; set; }

    public int PositionMasterCompanyId { get; set; }

    public int PositionMasterDivisionId { get; set; }

    public int PositionMasterDepartmentId { get; set; }

    public int PositionMasterProfitcenterId { get; set; }

    public int PositionMasterGradeId { get; set; }

    public int PositionMasterDesignationId { get; set; }

    public int PositionMasterWorkStationId { get; set; }

    public int PositionMasterPositionCount { get; set; }

    public int PositionMasterRolesId { get; set; }

    public int PositionMasterResponsibilitiesId { get; set; }

    public int PositionMasterActivityId { get; set; }

    public int PositionMasterAuthoritiesId { get; set; }

    public int PositionMasterKpaid { get; set; }

    public string PositionMasterRemark { get; set; } = null!;

    public string PositionMasterAuthRemark { get; set; } = null!;

    public bool PositionMasterAuth { get; set; }

    public bool PositionMasterIsDiscard { get; set; }

    public bool PositionMasterIsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int UpdatedBy { get; set; }

    public DateTime UpdatedDate { get; set; }

    public virtual ICollection<EmployeeMasterEmploymentDetail> EmployeeMasterEmploymentDetails { get; set; } = new List<EmployeeMasterEmploymentDetail>();

    public virtual ICollection<ErppageAssignmentRelationshipDetail> ErppageAssignmentRelationshipDetailErppageAssignmentRelationshipDetailschecker1Positionts { get; set; } = new List<ErppageAssignmentRelationshipDetail>();

    public virtual ICollection<ErppageAssignmentRelationshipDetail> ErppageAssignmentRelationshipDetailErppageAssignmentRelationshipDetailschecker2Positionts { get; set; } = new List<ErppageAssignmentRelationshipDetail>();

    public virtual ICollection<ErppageAssignmentRelationshipDetail> ErppageAssignmentRelationshipDetailErppageAssignmentRelationshipDetailschecker3Positionts { get; set; } = new List<ErppageAssignmentRelationshipDetail>();

    public virtual ICollection<ErppageAssignmentRelationshipDetail> ErppageAssignmentRelationshipDetailErppageAssignmentRelationshipDetailschecker4Positionts { get; set; } = new List<ErppageAssignmentRelationshipDetail>();

    public virtual ICollection<ErppageAssignmentRelationshipDetail> ErppageAssignmentRelationshipDetailErppageAssignmentRelationshipDetailschecker5Positionts { get; set; } = new List<ErppageAssignmentRelationshipDetail>();

    public virtual ICollection<OfferLetter> OfferLetters { get; set; } = new List<OfferLetter>();

    public virtual ActivityMaster PositionMasterActivity { get; set; } = null!;

    public virtual AuthoritiesMaster PositionMasterAuthorities { get; set; } = null!;

    public virtual CompanyMaster PositionMasterCompany { get; set; } = null!;

    public virtual DepartmentMaster PositionMasterDepartment { get; set; } = null!;

    public virtual DesignationMaster PositionMasterDesignation { get; set; } = null!;

    public virtual DivisionMaster PositionMasterDivision { get; set; } = null!;

    public virtual EmployeeTypeMaster PositionMasterEmployeeType { get; set; } = null!;

    public virtual GradeMaster PositionMasterGrade { get; set; } = null!;

    public virtual Kpamaster PositionMasterKpa { get; set; } = null!;

    public virtual ProfitcenterMaster PositionMasterProfitcenter { get; set; } = null!;

    public virtual ICollection<PositionMasterQualificationDetail> PositionMasterQualificationDetails { get; set; } = new List<PositionMasterQualificationDetail>();

    public virtual ResponsibilitiesMaster PositionMasterResponsibilities { get; set; } = null!;

    public virtual RolesMaster PositionMasterRoles { get; set; } = null!;

    public virtual WorkStationMaster PositionMasterWorkStation { get; set; } = null!;

    public virtual ICollection<RecruitmentMaster> RecruitmentMasters { get; set; } = new List<RecruitmentMaster>();
}
