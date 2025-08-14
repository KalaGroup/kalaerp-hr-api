using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Request.RoleDetails
{
    public class InsertRoleDetailsRequest
    {
       // public int RolesDetailsId { get; set; }
        public int DetailsRolesId { get; set; }
        public int SrNo { get; set; }
        public string RolesDetailsDescription { get; set; } = null!;

    }
}
