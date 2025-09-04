using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.ResponseDTO.ResponsibilitiesMaster
{
    public class GetResponsibilityDetailsById
    {
        public int ResponsibilitiesDetailsId { get; set; }

        public int DetailsResposibilitiesId { get; set; }

        public int SrNo { get; set; }

        public string ResponsibilitiesDetailsDescription { get; set; } = null!;
    }
}
