using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.ResponseDTO.RecruitmentMaster
{
    public class GetEmployeeIdAndNameResponseDTO
    {
        public int EmployeeMasterId { get; set; }
        public string EmployeeMasterFullName { get; set; } = null!;
        public string EmployeeMasterCode { get; set; } = null!;
        public int LeaveBalancesClosing { get; set; }
    }
}
