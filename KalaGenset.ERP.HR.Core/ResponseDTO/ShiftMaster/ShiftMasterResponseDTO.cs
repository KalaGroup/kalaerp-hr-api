using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.ResponseDTO.ShiftMaster
{
    public class ShiftMasterResponseDTO
    {
        public int ShiftMasterId { get; set; }

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

        public string CompanyName { get; set; } = null!;

        public string EmployeeTypeName { get; set; } = null!;


    }
}
