using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Request
{
    public class CompanyEntityTypeMasterRequest
    {     
        public int? CompEntityTypeId {  get; set; }
        public string CompanyEntityTypeName { get; set; } = null!;

        public string CompanyEntityTypeShortName { get; set; } = null!;

        public string CompanyEntityTypeRemark { get; set; } = null!;

        public bool CompanyEntityTypeAuth { get; set; }

        public bool CompanyEntityTypeIsDiscard { get; set; }

        public bool CompanyEntityTypeIsActive { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
