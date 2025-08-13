using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Request.ActivityDetails
{
    public class InsertActivityDetailsRequest
    {
        public int DetailsActivityId { get; set; }
        public int SrNo { get; set; }
        public string ActivityDetailsDescription { get; set; } = null!;
    }
}
