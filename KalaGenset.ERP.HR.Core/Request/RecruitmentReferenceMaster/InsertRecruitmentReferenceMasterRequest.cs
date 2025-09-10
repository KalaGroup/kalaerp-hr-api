using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Request.RecruitmentReferenceMaster
{
    public class InsertRecruitmentReferenceMasterRequest
    {
        public string RecruitmentReferenceName { get; set; } = null!;

        public string RecruitmentReferenceRemark { get; set; } = null!;

        public string RecruitmentReferenceAuthRemark { get; set; } = null!;

        public bool RecruitmentReferenceAuth { get; set; }

        public bool RecruitmentReferenceIsDiscard { get; set; }

        public bool RecruitmentReferenceIsActive { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
