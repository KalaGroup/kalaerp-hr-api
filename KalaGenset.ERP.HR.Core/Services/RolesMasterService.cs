using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.RolesMaster;
using KalaGenset.ERP.HR.Data.DbContexts;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Services
{
    public class RolesMasterService : IRolesMaster
    {
        private readonly KalaDbContext _dbContext;
        public RolesMasterService(KalaDbContext context)
        {
            _dbContext = context;
        }

        /// <summary>
        /// Adds a new role to the RolesMaster table.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task AddRolesAsync(InsertRolesMasterRequest request)
        {
            try
            {
                var roles = new RolesMaster
                {
                    RolesGradeId = request.RolesGradeId,
                    RolesDesignationId = request.RolesDesignationId,
                    RolesDivisionId = request.RolesDivisionId,
                    RolesRemark = request.RolesRemark,
                    RolesAuthRemark = request.RolesAuthRemark,
                    RolesAuth = request.RolesAuth,
                    RolesIsDiscard = request.RolesIsDiscard,
                    RolesIsActive = request.RolesIsActive,
                    CreatedBy = request.CreatedBy,
                    CreatedDate = request.CreatedDate
                };
                await _dbContext.RolesMasters.AddAsync(roles);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the role.", ex);
            }
        }
        /// <summary>
        /// update a new role into the RolesMaster table.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task UpdateRolesAsync(UpdateRolesMasterRequest request)
        {
            try
            {
                var roles = await _dbContext.RolesMasters.FindAsync(request.RolesId);

                roles.RolesGradeId = request.RolesGradeId;
                roles.RolesDesignationId = request.RolesDesignationId;
                roles.RolesDivisionId = request.RolesDivisionId;
                roles.RolesRemark = request.RolesRemark;
                roles.RolesAuthRemark = request.RolesAuthRemark;
                roles.RolesAuth = request.RolesAuth;
                roles.RolesIsDiscard = request.RolesIsDiscard;
                roles.RolesIsActive = request.RolesIsActive;
                roles.CreatedBy = request.CreatedBy;
                roles.CreatedDate = request.CreatedDate;
                _dbContext.Entry(roles).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// get All RolesMaster table.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<RolesMaster>> GetAllRolesAsync()
        {
            return await _dbContext.RolesMasters.ToListAsync();
        }
        /// <summary>
        /// get Role by ID from RolesMaster table.
        /// </summary>
        /// <param name="RolesId"></param>
        /// <returns></returns>


        public async Task<RolesMaster?> GetRoleByID(int RolesId)
        {
            try
            {
                return await _dbContext.RolesMasters.FirstOrDefaultAsync(c => c.RolesId == RolesId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// soft delete a role by setting RolesIsDiscard to true.
        /// </summary>
        /// <param name="RolesId"></param>
        /// <returns></returns>
        public async Task DeleteRoleAsync(int RolesId)
        {
            try
            {
                var roles = await _dbContext.RolesMasters.FirstOrDefaultAsync(c => c.RolesId == RolesId);

                roles.RolesIsActive = false;
                //company.ci = DateTime.Now;
                _dbContext.RolesMasters.Update(roles);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
