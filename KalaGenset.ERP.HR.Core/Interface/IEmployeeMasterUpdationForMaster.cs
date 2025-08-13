using KalaGenset.ERP.HR.Core.Request.EmployeeMasterUpdationForMaster;
using KalaGenset.ERP.HR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface IEmployeeMasterUpdationForMaster
    {
        /// <summary>  
        /// This is Add Code  
        /// </summary>  
        /// <param name="request"></param>  
        /// <returns></returns>  
        public Task AddEmployeeMasterUpdationForAsync(InsertEmployeeMasterUpdationForMasterRequest request);

        /// <summary>  
        /// This is Update Code By ID  
        /// </summary>  
        /// <param name="request"></param>  
        /// <returns></returns>  
        public Task UpdateEmployeeMasterUpdationForAsync(UpdateEmployeeMasterUpdationForMasterRequest request);

        /// <summary>  
        /// This is Get Code By ID  
        /// </summary>  
        /// <returns></returns>  
        public Task<IEnumerable<EmployeeMasterUpdationForMaster>> GetEmployeeMasterUpdationForAsync();

        public Task<EmployeeMasterUpdationForMaster> GetEmployeeMasterUpdationForById(int id);

        public Task DeleteEmployeeMasterUpdationForAsync(int sid);
    }
}
