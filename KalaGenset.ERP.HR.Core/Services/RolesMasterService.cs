using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.RolesMaster;
using KalaGenset.ERP.HR.Core.ResponseDTO.AuthoritiesMaster;
using KalaGenset.ERP.HR.Core.ResponseDTO.RoleMaster;
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
                // ✅ Insert into master table
                var role = new RolesMaster
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

                await _dbContext.RolesMasters.AddAsync(role);
                await _dbContext.SaveChangesAsync();

                // ✅ Retrieve auto-generated master ID
                int roleMstId = role.RolesId;

                // ✅ Insert child details (if any)
                if (request.descriptions != null && request.descriptions.Any())
                {
                    var details = request.descriptions.Select(item => new RolesDetail
                    {
                        DetailsRolesId = roleMstId, // FK to master
                        SrNo = item.srno,
                        RolesDetailsDescription = item.desc
                    }).ToList();

                    await _dbContext.RolesDetails.AddRangeAsync(details);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding role", ex);
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
                var role = await _dbContext.RolesMasters
                    .FirstOrDefaultAsync(r => r.RolesId == request.RolesId);

                if (role == null)
                    throw new Exception("Role not found");

                // ✅ Update master
                role.RolesGradeId = request.RolesGradeId;
                role.RolesDesignationId = request.RolesDesignationId;
                role.RolesDivisionId = request.RolesDivisionId;
                role.RolesRemark = request.RolesRemark;
                role.RolesAuthRemark = request.RolesAuthRemark;
                role.RolesAuth = request.RolesAuth;
                role.RolesIsDiscard = request.RolesIsDiscard;
                role.RolesIsActive = request.RolesIsActive;
                role.CreatedBy = request.CreatedBy;
                role.CreatedDate = request.CreatedDate;

                _dbContext.RolesMasters.Update(role);

                // ✅ Delete old details
                var existingDetails = await _dbContext.RolesDetails
                    .Where(d => d.DetailsRolesId == request.RolesId)
                    .ToListAsync();

                if (existingDetails.Any())
                {
                    _dbContext.RolesDetails.RemoveRange(existingDetails);
                }

                // ✅ Insert new details
                if (request.descriptions != null && request.descriptions.Any())
                {
                    var newDetails = request.descriptions.Select(item => new RolesDetail
                    {
                        DetailsRolesId = request.RolesId,
                        SrNo = item.srno,
                        RolesDetailsDescription = item.desc
                    });

                    await _dbContext.RolesDetails.AddRangeAsync(newDetails);
                }

                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating role", ex);
            }
        }

        /// <summary>
        /// get All RolesMaster table.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<RoleMasterResponseDTO>> GetAllRolesAsync()
        {
            var result = await (from r in _dbContext.RolesMasters
                                join g in _dbContext.GradeMasters
                                    on r.RolesGradeId equals g.GradeId
                                join d in _dbContext.DesignationMasters
                                    on r.RolesDesignationId equals d.DesignationId
                                join div in _dbContext.DivisionMasters
                                    on r.RolesDivisionId equals div.DivisionId
                                where r.RolesIsActive == true   // ✅ Only active records
                                select new RoleMasterResponseDTO
                                {
                                    RolesId = r.RolesId,
                                    RolesGradeId = r.RolesGradeId,
                                    GradeName = g.GradeName,
                                    RolesDesignationId = r.RolesDesignationId,
                                    DesignationName = d.DesignationName,
                                    RolesDivisionId = r.RolesDivisionId,
                                    DivisionName = div.DivisionName,
                                    RolesRemark = r.RolesRemark,
                                    RolesAuthRemark = r.RolesAuthRemark,
                                    RolesAuth = r.RolesAuth,
                                    RolesIsDiscard = r.RolesIsDiscard,
                                    RolesIsActive = r.RolesIsActive,
                                    CreatedBy = r.CreatedBy,
                                    CreatedDate = r.CreatedDate
                                }).ToListAsync();

            return result;
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
        public async Task DeleteRoleAsync(int id)
        {
            try
            {
                var role = await _dbContext.RolesMasters
                    .FirstOrDefaultAsync(c => c.RolesId == id);

                if (role == null)
                    throw new Exception("Role not found");

                // ✅ Get child details
                var details = await _dbContext.RolesDetails
                    .Where(d => d.DetailsRolesId == id)
                    .ToListAsync();

                // ✅ Remove child details
                if (details.Any())
                {
                    _dbContext.RolesDetails.RemoveRange(details);
                }

                // ✅ Soft delete master
                role.RolesIsActive = false;
                role.RolesIsDiscard = false; // keep consistent with Authorities

                _dbContext.RolesMasters.Update(role);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting role", ex);
            }
        }


        public async Task<IEnumerable<GetRoleDetailsById>> GetroleDetailsByMsaterId(int masterId)
        {
            return await _dbContext.RolesDetails
                .Where(r => r.DetailsRolesId == masterId)   // filter by ID
                .Select(r => new GetRoleDetailsById
                {
                    RolesDetailsId = r.RolesDetailsId,
                    DetailsRolesId = r.DetailsRolesId,
                    SrNo = r.SrNo,
                    RolesDetailsDescription = r.RolesDetailsDescription
                })
                .ToListAsync();
        }

    }
}
