using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KalaGenset.ERP.HR.Core.Request.EmployeeTypeMaster;
using KalaGenset.ERP.HR.Data.Models;

namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface IEmployeeTypeMaster
    {
        /// <summary>
        /// This method is used to add a new employee type to the database.
        /// </summary>
        /// <param name="insertEmployeeTypeRequest"></param>
        /// <returns></returns>
        public Task AddEmployeetype(InsertEmployeeTypeRequest insertEmployeeTypeRequest);

        /// <summary>
        /// This method retrieves all employee types from the database.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<EmployeeTypeMaster>> GetAllEmployeeType();

        /// <summary>
        /// This method retrieves an employee type by its ID.
        /// </summary>
        /// <param name="EmployeeTypeId"></param>
        /// <returns></returns>
        public Task<EmployeeTypeMaster?> EmployeeTypeById(int EmployeeTypeId);
        /// <summary>
        /// This method updates an existing employee type in the database.
        /// </summary>
        /// <param name="UpdateEmployeeTypeRequest"></param>
        /// <returns></returns>
        public Task UpdateEmployeeTypeMasterAsync(UpdateEmployeeTypeRequest UpdateEmployeeTypeRequest);
        /// <summary>
        /// This method deletes an employee type by its ID.
        /// </summary>
        /// <param name="EmployeeTypeId"></param>
        /// <returns></returns>
        public Task DeleteEmployeeTypeById(int EmployeeTypeId);
    }

}
