using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.ResponseDTO.RoleMaster
{
    public class RoleMasterResponseDTO
    {
        public int RolesId { get; set; }

        public int RolesGradeId { get; set; }

        public string GradeName { get; set; }

        public int RolesDesignationId { get; set; }

        public string DesignationName { get; set; }

        public int RolesDivisionId { get; set; }
        public string DivisionName { get; set; }

        public string RolesRemark { get; set; } = null!;

        public string RolesAuthRemark { get; set; } = null!;

        public bool RolesAuth { get; set; }

        public bool RolesIsDiscard { get; set; }

        public bool RolesIsActive { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}
