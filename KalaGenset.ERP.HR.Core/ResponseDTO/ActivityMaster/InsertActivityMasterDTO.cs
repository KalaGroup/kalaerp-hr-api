using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.ResponseDTO.ActivityMaster
{
    public class InsertActivityMasterDTO
    {
        public int ActivityId { get; set; }
        public string GradeName { get; set; } = null!;
        // public int ActivityGradeId { get; set; }


        // public int ActivityDesignationId { get; set; }
        public string DesignationName { get; set; } = null!;

        //public int ActivityDivisionId { get; set; }
        public string DivisionName { get; set; } = null!;

        public string ActivityRemark { get; set; } = null!;

        public string ActivityType { get; set; } = null!;

        public string ActivityAuthRemark { get; set; } = null!;

        public bool ActivityAuth { get; set; }

        public bool ActivityIsDiscard { get; set; }

        public bool ActivityIsActive { get; set; }
    }
}
