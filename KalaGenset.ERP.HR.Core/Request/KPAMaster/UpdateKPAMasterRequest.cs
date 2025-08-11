using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Request.KPAMaster
{
    public class UpdateKPAMasterRequest
    {
        public int Kpaid { get; set; }

        public int KpagradeId { get; set; }

        public int KpadesignationId { get; set; }

        public string Kparemark { get; set; } = null!;

        public string Kpatype { get; set; } = null!;

        public string KpaauthRemark { get; set; } = null!;

        public bool Kpaauth { get; set; }

        public bool KpaisDiscard { get; set; }

        public bool KpaisActive { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}
