using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Request.DepartmentBudget
{
    public class InsertDepartmentBudgetRequest
    {
        public int DepartmentBudgetDepartmentId { get; set; }

        public string DepartmentFy { get; set; } = null!;

        public double DepartmentBudgetAmt { get; set; }

        public int DepartmentBudgetHeadId { get; set; }

        public string DepartmentBudgetRemark { get; set; } = null!;

        public string DepartmentBudgetAuthRemark { get; set; } = null!;

        public bool DepartmentBudgetAuth { get; set; }

        public bool DepartmentBudgetIsDiscard { get; set; }

        public bool DepartmentBudgetIsActive { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
