using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Request.DailyAttendance
{
    public class UpdateDailyAttendanceRequest
    {
        public int AttendanceId { get; set; }

        public int AttendanceEmployeeId { get; set; }

        public int AttendanceCompanyId { get; set; }

        public DateTime AttendanceDate { get; set; }

        public TimeOnly InTime { get; set; }

        public TimeOnly OutTime { get; set; }

        public int AttendanceShiftId { get; set; }

        public bool InTimeAuth { get; set; }

        public bool OutTimeAuth { get; set; }

        public string AttendanceStatus { get; set; } = null!;

        public string AttendanceRemark { get; set; } = null!;

        public string AttendanceInTimeAuthRemark { get; set; } = null!;

        public string AttendanceOutTimeAuthRemark { get; set; } = null!;

        public bool AttendanceIsDiscard { get; set; }

        public bool AttendanceIsActive { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
