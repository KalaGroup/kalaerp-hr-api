using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.ResponseDTO.QualificationMaster
{
    public class QualifiactionIdAndNameResponseDTO
    {
        public int QualificationId { get; set; }

        public string QualificationName { get; set; } = null!;
    }
}
