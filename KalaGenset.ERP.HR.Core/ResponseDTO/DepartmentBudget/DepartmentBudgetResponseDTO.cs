using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.ResponseDTO.DepartmentBudget
{
    public class DepartmentBudgetResponseDTO
    {
        public int DepartmentBudgetId { get; set; }

        public string DepartmentFy { get; set; } = null!;

        public double DepartmentBudgetAmt { get; set; }

        public string DepartmentBudgetRemark { get; set; } = null!;

        public string DepartmentBudgetAuthRemark { get; set; } = null!;

        public bool DepartmentBudgetAuth { get; set; }

        public bool DepartmentBudgetIsDiscard { get; set; }

        public bool DepartmentBudgetIsActive { get; set; }

        public string DepartmentName { get; set; } = null!;

        public string EmployeeMasterFullName { get; set; } = null!;



    }
}
