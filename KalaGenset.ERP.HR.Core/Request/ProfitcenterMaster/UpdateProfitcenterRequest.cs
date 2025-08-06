using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Request.ProfitcenterMaster
{
    public class UpdateProfitcenterRequest
    {
        public int ProfitCenterId { get; set; }

       // public string ProfitCenterCode { get; set; }

        public string ProfitCenterName { get; set; }

      //  public int ProfitCenterCompanyId { get; set; }

      //  public int ParentProfitCenterId { get; set; }

        public string ProfitCenterRemark { get; set; }

        public string ProfitCenterAuthRemark { get; set; }

        public bool ProfitCenterAuth { get; set; }

        public bool ProfitCenterIsDiscard { get; set; }

        public bool ProfitCenterIsActive { get; set; }

      //  public int CreatedBy { get; set; }

      //  public DateTime CreatedDate { get; set; }
    }
}
