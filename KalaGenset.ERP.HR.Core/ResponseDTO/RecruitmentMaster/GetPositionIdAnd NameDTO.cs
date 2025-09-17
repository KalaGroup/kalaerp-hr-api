using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.ResponseDTO.RecruitmentMaster
{
    public class GetPositionIdAnd_NameDTO
    {
        public int PositionMasterId { get; set; }
        public string PositionMasterName { get; set; } = null!;
    }
}
