using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.ResponseDTO.AuthoritiesMaster
{
    public class GetAuthoritiesDetailsById
    {
        public int AuthoritiesDetailsId { get; set; }

        public int DetailsAuthoritiesId { get; set; }

        public int SrNo { get; set; }

        public string AuthoritiesDetailsDescription { get; set; } = null!;
    }
}
