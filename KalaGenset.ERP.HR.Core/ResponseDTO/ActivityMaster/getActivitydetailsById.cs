using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.ResponseDTO.ActivityMaster
{
    public class getActivitydetailsById
    {
        public int ActivityDetailsId { get; set; }

        public int DetailsActivityId { get; set; }

        public int SrNo { get; set; }

        public string ActivityDetailsDescription { get; set; } = null!;
    }
}
