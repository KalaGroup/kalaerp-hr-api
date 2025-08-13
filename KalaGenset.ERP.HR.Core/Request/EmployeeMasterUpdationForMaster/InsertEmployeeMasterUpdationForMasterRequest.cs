using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Request.EmployeeMasterUpdationForMaster
{
    public class InsertEmployeeMasterUpdationForMasterRequest
    {
        public string EmployeeMasterUpdationForName { get; set; } = null!;

        public string EmployeeMasterUpdationForRemark { get; set; } = null!;

        public string EmployeeMasterUpdationForAuthRemark { get; set; } = null!;

        public bool EmployeeMasterUpdationForAuth { get; set; }

        public bool EmployeeMasterUpdationForIsDiscard { get; set; }

        public bool EmployeeMasterUpdationForIsActive { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
