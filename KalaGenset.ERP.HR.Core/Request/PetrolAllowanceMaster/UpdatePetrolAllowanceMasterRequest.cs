using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Request
{
    public class UpdatePetrolAllowanceMasterRequest
    {
        public int PetrolAllowanceId { get; set; }

        public string TwoWheelerPerKm { get; set; } 

        public string FourWheelerPerKm { get; set; } 

        public string PetrolAllowanceRemark { get; set; } = null!;

        public string PetrolAllowanceAuthRemark { get; set; } = null!;

        public bool PetrolAllowanceIsAuth { get; set; }

        public bool PetrolAllowanceIsDiscard { get; set; }

        public bool PetrolAllowanceIsActive { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
