using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.ResponseDTO.ResponsibiltiesDetails
{
    public class ResponsilitiesDetailsResponseDTO
    {
        public int ResponsibilitiesDetailsId { get; set; }

        public int ResponsibilitiesId { get; set; }

        public int SrNo { get; set; }

        public string ResponsibilitiesDetailsDescription { get; set; } = null!;
    }
}
