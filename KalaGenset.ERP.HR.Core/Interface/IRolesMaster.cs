using KalaGenset.ERP.HR.Core.Request.RolesMaster;
using KalaGenset.ERP.HR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface IRolesMaster
    {
        /// <summary>
        ///  Inserts a new role into the RolesMaster table.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task AddRolesAsync(InsertRolesMasterRequest request);

        /// <summary>
        /// Update a new role into the RolesMaster table.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task UpdateRolesAsync(UpdateRolesMasterRequest request);

        /// <summary>
        /// Get All RolesMaster table.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<RolesMaster>> GetAllRolesAsync();
        /// <summary>
        /// Get Role by ID from RolesMaster table.
        /// </summary>
        /// <param name="RolesId"></param>
        /// <returns></returns>

        public Task<RolesMaster?> GetRoleByID(int RolesId);
        /// <summary>
        /// Soft delete a role by setting RolesIsDiscard to true.
        /// </summary>
        /// <param name="RolesId"></param>
        /// <returns></returns>
        public Task DeleteRoleAsync(int RolesId);
    }
}
