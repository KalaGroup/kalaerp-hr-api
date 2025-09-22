using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KalaGenset.ERP.HR.Core.Request.ActivityMaster.InsertActivityMasterRequest;
using static KalaGenset.ERP.HR.Core.Request.KPAMaster.InsertKPAMasterRequest;

namespace KalaGenset.ERP.HR.Core.Request.ActivityMaster
{
    public class UpdateActivityMasterRequest
    {
        public int ActivityId { get; set; }

        public int ActivityGradeId { get; set; }

        public int ActivityDesignationId { get; set; }

        public int ActivityDivisionId { get; set; }

        public string ActivityRemark { get; set; } = null!;


        public string ActivityAuthRemark { get; set; } = null!;

        public bool ActivityAuth { get; set; }

        public bool ActivityIsDiscard { get; set; }

        public bool ActivityIsActive { get; set; }

        public int CreatedBy { get; set; }

        //public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public List<activity> descriptions { get; set; }

    }
}
