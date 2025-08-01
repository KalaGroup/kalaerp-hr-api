using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Request.District
{
    public class InsertDistrictRequest
    {

        public int CountryId { get; set; }

        public int StateId { get; set; }

        public string? DistrictCode { get; set; }

        public string? DistrictName { get; set; }

        public string? ShortName { get; set; }

        public bool IsDiscard { get; set; }

        public bool IsActive { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
