using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Request.LeaveApplication
{
    public class InsertLeaveApplicationRequest
    {
        public int LeaveApplicationsEmployeeId { get; set; }

        public int LeaveApplicationsLeaveTypeId { get; set; }

        public DateOnly LeaveApplicationsFromDate { get; set; }

        public DateOnly LeaveApplicationsToDate { get; set; }

        public int LeaveApplicationsLeaveCount { get; set; }

        public string LeaveApplicationsRemark { get; set; } = null!;

        public string LeaveApplicationsAuthRemark { get; set; } = null!;

        public bool LeaveApplicationsAuth { get; set; }

        public bool LeaveApplicationsIsDiscard { get; set; }

        public bool LeaveApplicationsIsActive { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
