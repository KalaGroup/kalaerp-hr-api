using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Request.ActivityMaster
{
    public class InsertActivityMasterRequest
    {
        public int ActivityGradeId { get; set; }

        public int ActivityDesignationId { get; set; }

        public int ActivityDivisionId { get; set; }

        public string ActivityRemark { get; set; } = null!;

        public string ActivityType { get; set; } = null!;

        public string ActivityAuthRemark { get; set; } = null!;

        public bool ActivityAuth { get; set; }

        public bool ActivityIsDiscard { get; set; }

        public bool ActivityIsActive { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        //public int ActivityDetailsId { get; set; }

        public int DetailsActivityId { get; set; }

        public int SrNo { get; set; }

        public string ActivityDetailsDescription { get; set; } = null!;


    }
}
