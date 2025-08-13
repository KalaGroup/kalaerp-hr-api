using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Request.RecruitmentStageStatusMaster
{
    public class UpdateRecruitmentStageStatusMasterRequest
    {
        public int RecruitmentStageStatusId { get; set; }

        public string RecruitmentStageStatusName { get; set; } = null!;

        public string RecruitmentStageStatusRemark { get; set; } = null!;

        public string RecruitmentStageStatusAuthRemark { get; set; } = null!;

        public bool RecruitmentStageStatusAuth { get; set; }

        public bool RecruitmentStageStatusIsDiscard { get; set; }

        public bool RecruitmentStageStatusIsActive { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
