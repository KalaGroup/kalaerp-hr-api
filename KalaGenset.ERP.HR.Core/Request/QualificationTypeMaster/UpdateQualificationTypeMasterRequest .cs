using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Request
{
    public class UpdateQualificationTypeMasterRequest
    {
        public int QualificationTypeId { get; set; }

        public string QualificationTypeCode { get; set; } = null!;

        public string QualificationTypeName { get; set; } = null!;

        public string QualificationTypeRemark { get; set; } = null!;

        public bool QualificationTypeAuth { get; set; }

        public bool QualificationTypeIsDiscard { get; set; }

        public bool QualificationTypeIsActive { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
