using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.ResponseDTO.PositionDetails
{
    public class PositionDetailsResponseDTO
    {
        public int PositionMasterId { get; set; }
        public int PositionQualificationDetailsId { get; set; }

        public int PositionQualificationId { get; set; }

        public int SrNo { get; set; }

        public string PositionMasterQualificationDetailsDescription { get; set; } = null!;
    }
}
