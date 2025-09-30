using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.GatePassType;
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
    public class GatePassTypeService : IGatePassType
    {
        private readonly KalaDbContext _context;

        public GatePassTypeService(KalaDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Add a new GatePassType
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task AddGatePassTypeAsync(InsertGatePassTypeRequest request)
        {
            try
            {
                var gatePassType = new GatePassType
                {
                    GatePassTypesTypeCode = request.GatePassTypesTypeCode,
                    GatePassTypesTypeName = request.GatePassTypesTypeName,
                    GatePassTypesDescription = request.GatePassTypesDescription,
                    GatePassTypesRequiresApproval = request.GatePassTypesRequiresApproval,
                    GatePassTypesIsAuth = request.GatePassTypesIsAuth,
                    GatePassTypesAuthRemark = request.GatePassTypesAuthRemark,
                    GatePassTypesIsActive = request.GatePassTypesIsActive,
                    GatePassTypesIsDiscard = request.GatePassTypesIsDiscard,
                    CreatedBy = request.CreatedBy,
                    CreatedDate = DateTime.Now,
                    UpdatedBy = request.CreatedBy,
                    UpdatedDate = DateTime.Now
                };

                _context.GatePassTypes.Add(gatePassType);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Update an existing GatePassType
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task UpdateGatePassTypeAsync(UpdateGatePassTypeRequest request)
        {
            try
            {
                var gatePassType = await _context.GatePassTypes.FindAsync(request.GatePassTypeId);

                if (gatePassType == null)
                    throw new Exception("GatePassType not found");

                gatePassType.GatePassTypesTypeCode = request.GatePassTypesTypeCode;
                gatePassType.GatePassTypesTypeName = request.GatePassTypesTypeName;
                gatePassType.GatePassTypesDescription = request.GatePassTypesDescription;
                gatePassType.GatePassTypesRequiresApproval = request.GatePassTypesRequiresApproval;
                gatePassType.GatePassTypesIsAuth = request.GatePassTypesIsAuth;
                gatePassType.GatePassTypesAuthRemark = request.GatePassTypesAuthRemark;
                gatePassType.GatePassTypesIsActive = request.GatePassTypesIsActive;
                gatePassType.GatePassTypesIsDiscard = request.GatePassTypesIsDiscard;
                gatePassType.UpdatedBy = request.UpdatedBy;
                gatePassType.UpdatedDate = DateTime.Now;

                _context.GatePassTypes.Update(gatePassType);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Soft delete a GatePassType (set IsActive = false)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteGatePassTypeAsync(int id)
        {
            try
            {
                var gatePassType = await _context.GatePassTypes.FirstOrDefaultAsync(c => c.GatePassTypeId == id);

                if (gatePassType == null)
                    throw new Exception("GatePassType not found");

                gatePassType.GatePassTypesIsActive = false;
                gatePassType.UpdatedDate = DateTime.Now;

                _context.GatePassTypes.Update(gatePassType);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Get GatePassType by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GatePassType?> GetGatePassTypeByIdAsync(int id)
        {
            return await _context.GatePassTypes.FirstOrDefaultAsync(c => c.GatePassTypeId == id);
        }

        /// <summary>
        /// Get all active GatePassTypes
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<GatePassType>> GetGatePassTypeDetailsAsync()
        {
            var result = await (from gp in _context.GatePassTypes
                                where gp.GatePassTypesIsActive == true   // ✅ Only active records
                                select new GatePassType
                                {
                                    GatePassTypeId = gp.GatePassTypeId,
                                    GatePassTypesTypeCode = gp.GatePassTypesTypeCode,
                                    GatePassTypesTypeName = gp.GatePassTypesTypeName,
                                    GatePassTypesDescription = gp.GatePassTypesDescription,
                                    GatePassTypesRequiresApproval = gp.GatePassTypesRequiresApproval,
                                    GatePassTypesIsAuth = gp.GatePassTypesIsAuth,
                                    GatePassTypesAuthRemark = gp.GatePassTypesAuthRemark,
                                    GatePassTypesIsActive = gp.GatePassTypesIsActive,
                                    GatePassTypesIsDiscard = gp.GatePassTypesIsDiscard,
                                    CreatedBy = gp.CreatedBy,
                                    CreatedDate = gp.CreatedDate,
                                    UpdatedBy = gp.UpdatedBy,
                                    UpdatedDate = gp.UpdatedDate
                                }).ToListAsync();

            return result;
        }
    }
}
