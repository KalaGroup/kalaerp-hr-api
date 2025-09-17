using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.ResponseDTO.RecruitmentMaster
{
    public class getrecruitmenDetailsById
    {
        public int RecruitmentDetailsId { get; set; }

        public int DetailsRecruitmentMasterId { get; set; }

        public int RecruitmentDetailsInterviewRoundNumber { get; set; }

        public int RecruitmentDetailsMarksObtained { get; set; }

        public int RecruitmentDetailsAttributeId { get; set; }
    }
}
