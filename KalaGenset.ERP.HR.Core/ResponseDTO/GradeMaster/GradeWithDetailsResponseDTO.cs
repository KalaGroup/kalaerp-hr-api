using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.ResponseDTO.GradeMaster
{
    public class GradeWithDetailsResponseDTO
    {
        public int GradeId { get; set; }
        public string GradeCode { get; set; }
        public string GradeName { get; set; }
        public string GradeLevel { get; set; }
        public int MinSalCTC { get; set; }
        public int MaxSalCTC { get; set; }
        public int GradeCurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public string GradeDescription { get; set; }
        public int LeaveEntitlementAnnual { get; set; }
        public int ProbationPeriod { get; set; }
        public int NoticePeriod { get; set; }
        public string GradeRemark { get; set; }
        public bool GradeAuth { get; set; }
        public bool GradeIsDiscard { get; set; }
        public bool GradeIsActive { get; set; }
        public double ExperiencedRequired { get; set; }
        public string ExperiencedRemark { get; set; }
        public List<DesignationResponse> Designations { get; set; } = new List<DesignationResponse>();
        public List<FacilityResponse> FacilityAssignments { get; set; } = new List<FacilityResponse>();

    }

    public class DesignationResponse
    {
        public int DesignationId { get; set; }
        public string DesignationCode { get; set; }
        public string DesignationName { get; set; }
        public int DesignationQualificationId { get; set; }
        public string QualificationName { get; set; }
        public string DesignationDescription { get; set; }
        public string GradeQualificationRemark { get; set; }
        public string RequiredSkills { get; set; }
        public string DesignationRemark { get; set; }
    }

    public class FacilityResponse
    {
        public int GradeFacilityAssignmentId { get; set; }
        public int AssignmentFacilityId { get; set; }
        public string FacilityName { get; set; } // Assuming you have a Facilities table with FacilityName
    }
}
