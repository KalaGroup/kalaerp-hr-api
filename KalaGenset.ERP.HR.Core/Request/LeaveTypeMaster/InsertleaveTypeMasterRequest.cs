using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Request.LeaveTypeMaster
{
    public class InsertleaveTypeMasterRequest
    {
        public string LeaveTypeMasterCode { get; set; } = null!;

        public string LeaveTypeMasterName { get; set; } = null!;

        public int LeaveTypeMasterMaxDaysPer { get; set; }

        public int LeaveTypeMasterContinuosDaysPerYear { get; set; }

        public int LeaveTypeMasterCanCarryForward { get; set; }

        public bool LeaveTypeMasterCanEnCash { get; set; }

        public bool LeaveTypeMasterRequiredServiceMonths { get; set; }

        public string LeaveTypeMasterLeaveTypeRemark { get; set; } = null!;

        public string LeaveTypeMasterAuthRemark { get; set; } = null!;

        public string LeaveTypeMasterAuth { get; set; } = null!;

        public bool LeaveTypeMasterIsDiscard { get; set; }

        public bool LeaveTypeMasterIsActive { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
