using KalaGenset.ERP.HR.Core.Request.AuthoritieMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Request.RolesMaster
{
    public class UpdateRolesMasterRequest
    {
        public int RolesId { get; set; }
        public int RolesGradeId { get; set; }
        public int RolesDesignationId { get; set; }
        public int RolesDivisionId { get; set; }
        public string RolesRemark { get; set; }
  
        public string RolesAuthRemark { get; set; }
        public bool RolesAuth { get; set; } = false;
        public bool RolesIsDiscard { get; set; }
        public bool RolesIsActive { get; set; } = true;
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<Roles> descriptions { get; set; }


    }
}
