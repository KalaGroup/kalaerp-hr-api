using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Request.PositionMaster
{
    public class InsertPositionRequest
    {
        public string PositionMasterCode { get; set; } = null!;

        public string PositionMasterName { get; set; } = null!;

        public int PositionMasterCompanyId { get; set; }

        public int PositionMasterDivisionId { get; set; }

        public int PositionMasterProfitcenterId { get; set; }

        public int PositionMasterGradeId { get; set; }

        public int PositionMasterDesignationId { get; set; }

        public int PositionMasterWorkStationId { get; set; }

        public int PositionMasterDepartmentId { get; set; }
        public int PositionMasterPositionCount { get; set; }

        public int PositionMasterRolesId { get; set; }

        public int PositionMasterResponsibilitiesId { get; set; }

        public int PositionMasterActivityId { get; set; }

        public int PositionMasterAuthoritiesId { get; set; }

        public int PositionMasterKpaid { get; set; }

        public int PositionMasterEmployeeTypeId { get; set; }

        public string PositionMasterRemark { get; set; } = null!;

        public string PositionMasterAuthRemark { get; set; } = null!;

        public bool PositionMasterAuth { get; set; }

        public bool PositionMasterIsDiscard { get; set; }

        public bool PositionMasterIsActive { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public List<QualificationDetails> PositionMasterQualificationDetails { get; set; }

    }

    public class QualificationDetails
    {
        public int qual { get; set; }   // was newQualification
        public int srno { get; set; }              // was newSrNo
        public string desc { get; set; }    // was newDescription
    }

}

