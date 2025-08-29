using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.ResponseDTO.WorkstationMaster
{
    public class WorkstationMasterResponseDTO
    {
        public int WorkStationId { get; set; }
        public string WorkStationCode { get; set; }
        public string WorkStationName { get; set; }
        public string WorkStationShortName { get; set; }
        public int WorkStationProfitcenterId { get; set; }
        public string ProfitCenterName { get; set; }
        public bool WorkStationIsDiscard { get; set; }
        public string WorkStationRemark { get; set; }
        public string WorkStationAuthRemark { get; set; }
        public bool WorkStationIsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
