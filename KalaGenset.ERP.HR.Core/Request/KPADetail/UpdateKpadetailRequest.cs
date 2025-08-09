using KalaGenset.ERP.HR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Request.KPADetail
{
    public class UpdateKpadetailRequest
    {
        public int KpadetailsId { get; set; }

        public int DetailsKpaid { get; set; }

        public int SrNo { get; set; }

        public string KpadetailsDescription { get; set; } = null!;

        public int Marks { get; set; }


    }
}
