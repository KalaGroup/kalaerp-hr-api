using KalaGenset.ERP.HR.Core.Request.EmployeeLeaveBalance;
using KalaGenset.ERP.HR.Core.ResponseDTO.EmployeeLeaveBalance;
using KalaGenset.ERP.HR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface IEmployeeLeaveBalance
    {
        public Task AddEmployeeLeaveBalanceAsync(InsertEmployeeLeaveBalanceRequest request);

        public  Task UpdateEmployeeLeaveBalanceAsync(UpdateEmployeeLeaveBalanceRequest request);

        public  Task DeleteEmployeeLeaveBalanceAsync(int id);

        public  Task<EmployeeLeaveBalance?> GetEmployeeLeaveBalanceByIdAsync(int id);

        public  Task<IEnumerable<EmployeeLeaveBalanceResponseDTO>> GetEmployeeLeaveBalancesAsync();


    }
}
