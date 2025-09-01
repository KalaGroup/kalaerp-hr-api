using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.ResponseDTO.HolidayMaster
{
    public class HolidayMasterResponseDTO
    {
        public int HolidayId { get; set; }

        public string HolidayFy { get; set; } = null!;

        public DateTime HolidayDate { get; set; }

        public string HolidayFor { get; set; } = null!;

        public int HolidayCompanyId { get; set; }

        public string CompanyName { get; set; } = null!;

        public string HolidayRemark { get; set; } = null!;

        public string HolidayAuthRemark { get; set; } = null!;

        public bool HolidayAuth { get; set; }

        public bool HolidayIsDiscard { get; set; }

        public bool HolidayIsActive { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
