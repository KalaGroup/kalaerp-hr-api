using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.ResponseDTO.AuthoritiesDetails
{
    public class AuthoritiesDetailsResponseDTO
    {
        public int AuthoritiesId { get; set; }

        public int AuthoritiesDetailsId { get; set; }

        public int SrNo { get; set; }

        public string AuthoritiesDetailsDescription { get; set; } = null!;
    }
}
