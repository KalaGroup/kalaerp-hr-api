using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.ResponseDTO.LeaveApplication
{
    public class LeaveApplicationDTO
    {
        public int LeaveApplicationId { get; set; }

        //public int LeaveApplicationsEmployeeId { get; set; }

        // public int LeaveApplicationsLeaveTypeId { get; set; }
        public string EmployeeMasterFullName { get; set; } = null!;
        public string LeaveTypeMasterName { get; set; } = null!;
        public DateOnly LeaveApplicationsFromDate { get; set; }

        public DateOnly LeaveApplicationsToDate { get; set; }

        public int LeaveApplicationsLeaveCount { get; set; }

        public string LeaveApplicationsRemark { get; set; } = null!;

        public string LeaveApplicationsAuthRemark { get; set; } = null!;

        public bool LeaveApplicationsAuth { get; set; }

        public bool LeaveApplicationsIsDiscard { get; set; }

        public bool LeaveApplicationsIsActive { get; set; }
    }
}
