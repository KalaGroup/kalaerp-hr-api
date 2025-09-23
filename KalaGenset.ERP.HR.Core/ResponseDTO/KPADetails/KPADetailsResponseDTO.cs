using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.ResponseDTO.KPADetails
{
    public class KPADetailsResponseDTO
    {
        public int Kpaid { get; set; }
        public int KpadetailsId { get; set; }
 
        public int SrNo { get; set; }

        public string KpadetailsDescription { get; set; } = null!;

        public int Marks { get; set; }
    }
}
