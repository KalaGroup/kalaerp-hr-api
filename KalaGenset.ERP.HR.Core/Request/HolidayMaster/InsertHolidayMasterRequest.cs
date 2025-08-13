using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Request.HolidayMaster
{
    public class InsertHolidayMasterRequest
    {
        public string HolidayFy { get; set; } = null!;

        public DateTime HolidayDate { get; set; }

        public string HolidayFor { get; set; } = null!;

        public int HolidayCompanyId { get; set; }

        public string HolidayRemark { get; set; } = null!;

        public string HolidayAuthRemark { get; set; } = null!;

        public bool HolidayAuth { get; set; }

        public bool HolidayIsDiscard { get; set; }

        public bool HolidayIsActive { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
