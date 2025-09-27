using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.ResponseDTO.DailyAttendance
{
    public class EmployeeNameAndCompanyNameDTO
    {
        public int CompanyId { get; set; }
     
         public string CompanyName { get; set; } = null!;
    }
}
