using KalaGenset.ERP.HR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Request.AuthoritiesDetail
{
    public class UpdateAuthoritiesaDetailsRequest
    {
        public int AuthoritiesDetailsId { get; set; }

        public int DetailsAuthoritiesId { get; set; }

        public int SrNo { get; set; }

        public string AuthoritiesDetailsDescription { get; set; } = null!;

        
    }
}
