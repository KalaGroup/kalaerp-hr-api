using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Request.ShiftMaster
{
    public class UpdateShiftMasterRequest
    {
        public int  ShiftMasterId { get; set; }

        public int  ShiftMasterCompanyId { get; set; }

        public int ShiftMasterEmployeeTypeId { get; set; }

        public string ShiftMasterName { get; set; } = null!;

        public string ShiftMasterAliseName { get; set; } = null!;

        public TimeOnly ShiftMasterStartTime { get; set; }

        public TimeOnly ShiftMasterEndTime { get; set; }

        public TimeOnly ShiftMasterLunchStartTime { get; set; }

        public TimeOnly ShiftMasterLunchEndTime { get; set; }

        public string ShiftMasterRemark { get; set; } = null!;

        public string ShiftMasterAuthRemark { get; set; } = null!;

        public bool ShiftMasterAuth { get; set; }

        public bool ShiftMasterIsDiscard { get; set; }

        public bool ShiftMasterIsActive { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}
