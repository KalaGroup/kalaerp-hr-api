using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.ResponseDTO.RoleDetails
{
    public class RolesDetailsResponseDTO
    {
        public int RolesId { get; set; }   // comes from Roles table
        public int RolesDetailsId { get; set; }   // comes from RolesDetail
        public int SrNo { get; set; }
        public string RolesDetailsDescription { get; set; }
    }
}
