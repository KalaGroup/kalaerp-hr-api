using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KalaGenset.ERP.HR.Core.Request.Country;
using KalaGenset.ERP.HR.Core.Request.Department;
using KalaGenset.ERP.HR.Data.Models;

namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface IDepartmentMaster
    {
        /// <summary>
        /// Adds a new Department to the database.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task AddDepartmentAsync(InsertDepartmentRequest request);
        /// <summary>
        /// Updates an existing Department in the database.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task UpdateDepartmentAsync(UpdateDepartmentRequest request);
        /// <summary>
        /// Retrieves all Departments from the database.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<DepartmentMaster>> GetDepartmentDetailsAsync();
        /// <summary>
        /// Retrieves a Department by its ID from the database.
        /// </summary>
        /// <param name="DepartmentId"></param>
        /// <returns></returns>
        public Task<DepartmentMaster?> GetDepartmentById(int DepartmentId);
        /// <summary>
        /// Deletes a Department by its ID from the database.
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public Task DeleteDepartmentAsync(int did);
    }
}
