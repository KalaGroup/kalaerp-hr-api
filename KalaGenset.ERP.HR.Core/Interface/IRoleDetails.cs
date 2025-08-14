using KalaGenset.ERP.HR.Core.Request.RoleDetails;
using KalaGenset.ERP.HR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface IRoleDetails
    {
        /// <summary>
        /// Inserts a new role into the RolesDetails table.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task AddRoleDetailsAsync(InsertRoleDetailsRequest request);
        /// <summary>
        /// Update a new role into the RolesDetails table.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task UpdateRoleDetailsAsync(UpdateRoleDetailsRequest request);
        /// <summary>
        /// Get All Role Details
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<RolesDetail>> GetAllRoleDetailsAsync();
        /// <summary>
        /// Get Role Details by ID from RolesDetails table.
        /// </summary>
        /// <param name="RolesDetailsId"></param>
        /// <returns></returns>
        public Task<RolesDetail> GetRoleDetailsByID(int RolesDetailsId);
        /// <summary>
        /// Delete a role by setting RolesIsDiscard to true.
        /// </summary>
        /// <param name="RolesDetailsId"></param>
        /// <returns></returns>
        public Task DeleteRoleDetailsAsync(int RolesDetailsId);
    }
}
