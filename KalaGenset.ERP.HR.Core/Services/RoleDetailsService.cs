using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.RoleDetails;
using KalaGenset.ERP.HR.Data.DbContexts;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Services
{
    public class RoleDetailsService : IRoleDetails
    {
        private readonly KalaDbContext _dbContext;
        public RoleDetailsService(KalaDbContext context)
        {
            _dbContext = context;
        }

        /// <summary>
        /// adds a new role to the RolesDetails table.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task AddRoleDetailsAsync(InsertRoleDetailsRequest request)
        {
            try
            {
                var roleDetails = new RolesDetail
                {
                    DetailsRolesId = request.DetailsRolesId,
                    SrNo = request.SrNo,
                    RolesDetailsDescription = request.RolesDetailsDescription
                };
                _dbContext.RolesDetails.Add(roleDetails);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the role details.", ex);
            }
        }

        /// <summary>
        /// soft delete a role by setting RolesIsDiscard to true.
        /// </summary>
        /// <param name="RolesDetailsId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Task DeleteRoleDetailsAsync(int RolesDetailsId)
        {
            try
            {
                var roleDetails = _dbContext.RolesDetails.FirstOrDefaultAsync(c => c.RolesDetailsId == RolesDetailsId);
                if (roleDetails != null)
                {
                    _dbContext.RolesDetails.Remove(roleDetails.Result);
                    return _dbContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Role details not found.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the role details.", ex);
            }
        }

        /// <summary>
        /// get All Role Details
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<RolesDetail>> GetAllRoleDetailsAsync()
        {
            return await _dbContext.RolesDetails.ToListAsync();
        }

        /// <summary>
        /// get Role Details by ID from RolesDetails table.
        /// </summary>
        /// <param name="RolesDetailsId"></param>
        /// <returns></returns>
        public async Task<RolesDetail> GetRoleDetailsByID(int RolesDetailsId)
        {
            return await _dbContext.RolesDetails.FirstOrDefaultAsync(c => c.RolesDetailsId == RolesDetailsId);
        }
        /// <summary>
        /// update a new role into the RolesDetails table.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Task UpdateRoleDetailsAsync(UpdateRoleDetailsRequest request)
        {
            try
            {
                var roleDetails = _dbContext.RolesDetails.FindAsync(request.RolesDetailsId);
                if (roleDetails != null)
                {
                    roleDetails.Result.DetailsRolesId = request.DetailsRolesId;
                    roleDetails.Result.SrNo = request.SrNo;
                    roleDetails.Result.RolesDetailsDescription = request.RolesDetailsDescription;
                    return _dbContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Role details not found.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the role details.", ex);
            }
        }
    }
}
