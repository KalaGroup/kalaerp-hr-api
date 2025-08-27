using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.ResponseDTO.QualificationMaster
{
    public class QualificationMasterResponseDTO
    {
        public int QualificationId { get; set; }
        public string QualificationCode { get; set; } = null!;
        public string QualificationName { get; set; } = null!;
        public string QualificationRemark { get; set; } = null!;
        public bool QualificationAuth { get; set; } 
        public bool QualificationIsDiscard { get; set; } 
        public string QualificationTypeName { get; set; } = null!;
        public bool QualificationIsActive { get; set; }
    }
}
