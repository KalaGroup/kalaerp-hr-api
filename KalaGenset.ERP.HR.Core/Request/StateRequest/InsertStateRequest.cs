using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Request.StateRequest
{
    public class InsertStateRequest
    {
        public int StateId { get; set; }
        public int CountryId { get; set; }

        public string StateCode { get; set; }

        public string StateName { get; set; }

        public string ShortName { get; set; }
        public bool IsDiscard { get; set; }

        public bool IsActive { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
