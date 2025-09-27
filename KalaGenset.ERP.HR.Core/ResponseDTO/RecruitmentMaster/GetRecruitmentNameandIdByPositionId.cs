using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.ResponseDTO.RecruitmentMaster
{
    public class GetRecruitmentNameandIdByPositionId
    {
        public int RecruitmentMasterId { get; set; }
        public string RecruitmentMasterNameOfCandidates { get;set; }
    }
}
