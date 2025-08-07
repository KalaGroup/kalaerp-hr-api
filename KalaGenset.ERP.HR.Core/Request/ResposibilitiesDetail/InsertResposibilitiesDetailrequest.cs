using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Request.ResposibilitiesDetail
{
    public class InsertResposibilitiesDetailrequest
    {
        public int DetailsResposibilitiesId { get; set; }

        public int SrNo { get; set; }

        public string ResposibilitiesDetailsDescription { get; set; } = null!;
    }
}
