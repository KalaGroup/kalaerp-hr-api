using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Request.RolesMaster
{
    public class InsertRolesMasterRequest
    {
        public int RolesGradeId { get; set; }
        public int RolesDesignationId { get; set; }
        public int RolesDivisionId { get; set; }
        public string RolesRemark { get; set; }
        public string RolesType { get; set; }
        public string RolesAuthRemark { get; set; }
        public bool RolesAuth { get; set; } = false;
        public bool RolesIsDiscard { get; set; }
        public bool RolesIsActive { get; set; } = true;
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
