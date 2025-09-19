using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.ResponseDTO.WorkstationBudget
{
    public class WorkstationBudgetResponseDTO
    {
        public int WorkstationBudgetId { get; set; }

        public string WorkstationFy { get; set; } = null!;

        public double WorkstationBudgetAmt { get; set; }

        public string WorkstationBudgetRemark { get; set; } = null!;

        public string WorkstationBudgetAuthRemark { get; set; } = null!;

        public bool WorkstationBudgetAuth { get; set; }

        public bool WorkstationBudgetIsDiscard { get; set; }

        public bool WorkstationBudgetIsActive { get; set; }

        public string WorkStationName { get; set; } = null!;

        public string EmployeeMasterFullName { get; set; } = null!;
    }
}
