using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Request.GatePassType
{
    public class UpdateGatePassTypeRequest
    {
        public int GatePassTypeId { get; set; }

        public string GatePassTypesTypeCode { get; set; } = null!;

        public string GatePassTypesTypeName { get; set; } = null!;

        public string GatePassTypesDescription { get; set; } = null!;

        public bool GatePassTypesRequiresApproval { get; set; }

        public bool GatePassTypesIsAuth { get; set; }

        public string GatePassTypesAuthRemark { get; set; } = null!;

        public bool GatePassTypesIsActive { get; set; }

        public bool GatePassTypesIsDiscard { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
