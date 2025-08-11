using KalaGenset.ERP.HR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Request.AuthoritieMaster
{
    public class UpdateAuthoritieMasterRequest
    {
        public int AuthoritiesId { get; set; }

        public int AuthoritiesGradeId { get; set; }

        public int AuthoritiesDesignationId { get; set; }

        public string AuthoritiesRemark { get; set; } = null!;

        public string AuthoritiesType { get; set; } = null!;

        public string AuthoritiesAuthRemark { get; set; } = null!;

        public bool AuthoritiesAuth { get; set; }

        public bool AuthoritiesIsDiscard { get; set; }

        public bool AuthoritiesIsActive { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        
    }
}
