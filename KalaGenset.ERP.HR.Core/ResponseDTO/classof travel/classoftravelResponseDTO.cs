using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.ResponseDTO.classof_travel
{
    public class classoftravelResponseDTO
    {
        public int ClassOfTravelId { get; set; }

        public string ClassOfTravelCode { get; set; } = null!;

        public string ClassOfTravelName { get; set; } = null!;

        public string GradeName { get; set; } = null!;

        public int DafoodAllowancePerday { get; set; }

        public int ClassOfTravelTierType { get; set; }

        public string ClassOfTravelRemark { get; set; } = null!;

        public bool ClassOfTravelIsAuth { get; set; }

        public bool ClassOfTravelIsDiscard { get; set; }

        public bool ClassOfTravelIsActive { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
