using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Request
{
    public class InsertQualificationTypeMasterRequest
    {
        public string QualificationTypeCode { get; set; } 

        public string QualificationTypeName { get; set; } 

        public string QualificationTypeRemark { get; set; } 

        public bool QualificationTypeAuth { get; set; }

        public bool QualificationTypeIsDiscard { get; set; }

        public bool QualificationTypeIsActive { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
    }


}
