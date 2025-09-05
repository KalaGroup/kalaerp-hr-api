using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.ResponseDTO.AuthoritiesMaster
{
    public class AuthoritiesMasterResponseDTO
    {
        public int AuthoritiesId { get; set; }

        public int AuthoritiesGradeId { get; set; }

        public string GradeName { get; set; }

        public int AuthoritiesDesignationId { get; set; }

        public string DesignationName { get; set; }

        public int AuthoritiesDivisionId { get; set; }
        public string DivisionName { get; set; }

        public string AuthoritiesRemark { get; set; } = null!;

        public string AuthoritiesAuthRemark { get; set; } = null!;

        public bool AuthoritiesAuth { get; set; }

        public bool AuthoritiesIsDiscard { get; set; }

        public bool AuthoritiesIsActive { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
