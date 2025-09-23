namespace KalaGenset.ERP.HR.Core.ResponseDTO.PositionMaster
{
    public class PositionResponseDTO
    {
        public int PositionMasterId { get; set; }
        public string PositionMasterName { get; set; }
        public string PositionMasterCode { get; set; }
        public int PositionMasterCompanyId { get; set; }
        public int CompanyName { get; set; }
        public int PositionMasterDivisionId { get; set; }
        public string DivisionName { get; set; }
        public int PositionMasterProfitcenterId { get; set; }
        public string ProfitCenterName { get; set; }
        public int PositionMasterGradeId { get; set; }
        public int PositionMasterDepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int PositionMasterPositionCount { get; set; }
        public string GradeName { get; set; }
        public int PositionMasterDesignationId { get; set; }
        public string DesignationName { get; set; }
        public int PositionMasterWorkStationId { get; set; }
        public string WorkStationName { get; set; }
        public int PositionMasterRolesId { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public int PositionMasterResponsibilitiesId { get; set; }
        public string ResponsibilityName { get; set; }
        public int PositionMasterActivityId { get; set; }
        public string ActivityName { get; set; }
        public int PositionMasterAuthoritiesId { get; set; }
        public string AuthorityName { get; set; }
        public int PositionMasterKpaid { get; set; }
        public string KpaName { get; set; }
        public int PositionMasterEmployeeTypeId { get; set; }
        public string EmployeeTypeName { get; set; }
        public string PositionMasterRemark { get; set; }
        public string PositionMasterAuthRemark { get; set; }
        public bool PositionMasterAuth { get; set; }
        public bool PositionMasterIsDiscard { get; set; }
        public bool PositionMasterIsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
