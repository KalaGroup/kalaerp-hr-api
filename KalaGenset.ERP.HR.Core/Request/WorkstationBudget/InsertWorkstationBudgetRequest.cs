using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Request.WorkstationBudget
{
    public class InsertWorkstationBudgetRequest
    {
        public int WorkstationBudgetWorkstationId { get; set; }

        public string WorkstationFy { get; set; } = null!;

        public double WorkstationBudgetAmt { get; set; }

        public int WorkstationBudgetHeadId { get; set; }

        public string WorkstationBudgetRemark { get; set; } = null!;

        public string WorkstationBudgetAuthRemark { get; set; } = null!;

        public bool WorkstationBudgetAuth { get; set; }

        public bool WorkstationBudgetIsDiscard { get; set; }

        public bool WorkstationBudgetIsActive { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
