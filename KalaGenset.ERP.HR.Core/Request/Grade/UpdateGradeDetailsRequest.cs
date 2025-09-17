using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KalaGenset.ERP.HR.Data.Models;

namespace KalaGenset.ERP.HR.Core.Request.Grade
{
    //public class UpdateGradeRequest
    //{
    //    public int GradeId { get; set; }
    //    public string GradeCode { get; set; }
    //    public string GradeName { get; set; }
    //    public string GradeLevel { get; set; }
    //    public int MinSalCtc { get; set; }
    //    public int MaxSalCtc { get; set; }
    //    public int GradeCurrencyId { get; set; }
    //    public string GradeDescription { get; set; }
    //    public int LeaveEntitlementAnnual { get; set; }
    //    public int ProbationPeriod { get; set; }
    //    public int NoticePeriod { get; set; }
    //    public string GradeRemark { get; set; }
    //    public bool GradeAuth { get; set; }
    //    public bool GradeIsDiscard { get; set; }
    //    public bool GradeIsActive { get; set; }
    //    public int CreatedBy { get; set; }
    //}

    public class UpdateGradeDetailsRequest
    {
        public GradeData gradeData { get; set; }
        public List<DesignationData> designations { get; set; }
        public List<FacilityAssignmentData> facilityAssignments { get; set; }
        public CTCStructureData ctcStructure { get; set; }
    }

    //public class GradeData
    //{
    //    public string GradeCode { get; set; }
    //    public string GradeName { get; set; }
    //    public string GradeLevel { get; set; }
    //    public int MinSalCTC { get; set; }
    //    public int MaxSalCTC { get; set; }
    //    public int GradeCurrencyId { get; set; }
    //    public string GradeDescription { get; set; }
    //    public int LeaveEntitlementAnnual { get; set; }
    //    public int ProbationPeriod { get; set; }
    //    public int NoticePeriod { get; set; }
    //    public string GradeRemark { get; set; }
    //    public bool GradeAuth { get; set; }
    //    public bool GradeIsDiscard { get; set; }
    //    public bool GradeIsActive { get; set; }
    //    public double ExperiencedRequired { get; set; }
    //    public string ExperiencedRemark { get; set; }
    //    //public int CreatedBy { get; set; }
    //    //public DateTime CreatedDate { get; set; }
    //}

    //public class DesignationData
    //{
    //    public string DesignationCode { get; set; }
    //    public string DesignationName { get; set; }

    //    public int DesignationQualificationId { get; set; }
    //    public string DesignationDescription { get; set; }
    //    public string GradeQualificationRemark { get; set; }
    //    public string RequiredSkills { get; set; }
    //    public string DesignationRemark { get; set; }
    //}

    //public class FacilityAssignmentData
    //{
    //    public int AssignmentFacilityId { get; set; }

    //}

    //public class CTCStructureData
    //{
    //    public int CTCMasterBasic { get; set; }
    //    public int CTCMasterBonus { get; set; }
    //    public int CTCMasterCarAllowance { get; set; }
    //    public int CTCMasterCityCompensatoryAlowance { get; set; }
    //    public int CTCMasterConvAllowance { get; set; }
    //    public int CTCMasterDA { get; set; }
    //    public int CTCMasterDriverAllowance { get; set; }
    //    public int CTCMasterEsic { get; set; }
    //    public int CTCMasterFuelAllowance { get; set; }
    //    public int CTCMasterGraduity { get; set; }
    //    public int CTCMasterGross { get; set; }
    //    public int CTCMasterHRA { get; set; }
    //    public int CTCMasterLeaveTravelAllowance { get; set; }
    //    public int CTCMasterMLWF { get; set; }
    //    public int CTCMasterMedicalInsurance { get; set; }
    //    public int CTCMasterMiscAllowance { get; set; }
    //    public int CTCMasterPFEmployee { get; set; }
    //    public int CTCMasterPFEmployer { get; set; }
    //    public int CTCMasterPT { get; set; }
    //    public int CTCMasterPerformanceKPA { get; set; }
    //}
}
