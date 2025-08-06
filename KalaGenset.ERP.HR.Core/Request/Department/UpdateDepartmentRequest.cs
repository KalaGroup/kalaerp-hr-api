using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Request.Department
{
    public class UpdateDepartmentRequest
    {
        public int DepartmentId { get; set; }
        public string DepartmentCode { get; set; } 
        public string DepartmentName { get; set; } 
        public string DepartmentShortName { get; set; }
        public int? ParentDepartmentId { get; set; }
        public int DepartmentProfitcenterId { get; set; }
        public string DepartmentRemark { get; set; } 
        public string DepartmentType { get; set; } 
        public string DepartmentAuthRemark { get; set; }
        public bool DepartmentAuth { get; set; }
        public bool DepartmentIsDiscard { get; set; }
        public bool DepartmentIsActive { get; set; }
        public int CreatedBy { get; set; }
    }
}
