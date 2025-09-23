using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.ResponseDTO.ActivityDetails
{
    public class ActivityDetailsResponseDTO
    {
        public int ActivityId { get; set; }
        public int ActivityDetailsId { get; set; }
        public int SrNo { get; set; }

        public string ActivityDetailsDescription { get; set; } = null!;
    }
}
