using KalaGenset.ERP.HR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Request.QualificationRequest
{
    public class InsertQualificationRequest
    {
        public int MasterQualificationTypeId { get; set; }

        public string QualificationCode { get; set; } = null!;

        public string QualificationName { get; set; } = null!;

        public string QualificationRemark { get; set; } = null!;

        public bool QualificationAuth { get; set; }

        public bool QualificationIsDiscard { get; set; }

        public bool QualificationIsActive { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
       // public virtual QualificationTypeMaster MasterQualificationType { get; set; } = null!;


    }
}
