using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.ResponseDTO.Company
{
    public class profitcenterResponseDTO
    {
        public int ProfitCenterId { get; set; }

        public string ProfitCenterCode { get; set; } = null!;

        public string ProfitCenterName { get; set; } = null!;

        //  public int ProfitCenterCompanyId { get; set; }
        public string CompanyName { get; set; } = null!;


        public int ParentProfitCenterId { get; set; }

        public string ProfitCenterRemark { get; set; } = null!;

        public string ProfitCenterAuthRemark { get; set; } = null!;

        public bool ProfitCenterAuth { get; set; }

        public bool ProfitCenterIsDiscard { get; set; }

        public bool ProfitCenterIsActive { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
