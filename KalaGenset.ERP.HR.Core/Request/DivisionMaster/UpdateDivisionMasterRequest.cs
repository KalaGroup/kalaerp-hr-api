using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Request.DivisionMaster
{
    public class UpdateDivisionMasterRequest
    {
        public int DivisionId { get; set; }

        public string DivisionCode { get; set; } = null!;

        public string DivisionName { get; set; } = null!;

        public string DivisionShortName { get; set; } = null!;

        public string DivisionMailId { get; set; } = null!;

        public string DivisionRemark { get; set; } = null!;

        public string DivisionAuthRemark { get; set; } = null!;

        public bool DivisionAuth { get; set; }

        public bool DivisionIsDiscard { get; set; }

        public bool DivisionIsActive { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
