using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Request.Facility
{
    public class UpdateFacilityRequest
    {
        public int FacilityId { get; set; }
        public string FaciltyCode { get; set; }
        public string FacilityName { get; set; }
        public string FacilityRemark { get; set; }
        public bool FacilityIsDiscard { get; set; }
        public bool FacilityIsActive { get; set; }

    }
}
