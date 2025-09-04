using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.ResponseDTO.KPA
{
    public class KPAmasterResponseDTO
    {
        public int Kpaid { get; set; }        
        public string GradeName { get; set; } = null!;
        public string DesignationName { get; set; } = null!;
        public string DivisionName { get; set; } = null!;
        public string Kparemark { get; set; } = null!;

        public string KpaauthRemark { get; set; } = null!;

        public bool Kpaauth { get; set; }

        public bool KpaisDiscard { get; set; }

        public bool KpaisActive { get; set; }

    

    }
}
