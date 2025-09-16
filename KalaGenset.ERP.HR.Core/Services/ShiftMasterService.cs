using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.LocationRequest;
using KalaGenset.ERP.HR.Core.Request.QualificationRequest;
using KalaGenset.ERP.HR.Core.Request.ShiftMaster;
using KalaGenset.ERP.HR.Core.ResponseDTO.QualificationMaster;
using KalaGenset.ERP.HR.Core.ResponseDTO.ShiftMaster;
using KalaGenset.ERP.HR.Data.DbContexts;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace KalaGenset.ERP.HR.Core.Services
{
    public class ShiftMasterService : IShiftMaster
    {
        private readonly KalaDbContext _context;

        public ShiftMasterService(KalaDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Insert Shift Master
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task AddShiftAsync(InsertShiftMasterRequest request)
        {
            try
            {
                var shift = new ShiftMaster
                {
                    ShiftMasterCompanyId = request.ShiftMasterCompanyId,
                    ShiftMasterEmployeeTypeId = request.ShiftMasterEmployeeTypeId,
                    ShiftMasterName = request.ShiftMasterName,
                    ShiftMasterAliseName = request.ShiftMasterAliseName,
                    ShiftMasterStartTime = request.ShiftMasterStartTime,
                    ShiftMasterEndTime = request.ShiftMasterEndTime,
                    ShiftMasterLunchStartTime = request.ShiftMasterLunchStartTime,
                    ShiftMasterLunchEndTime = request.ShiftMasterLunchEndTime,
                    ShiftMasterRemark = request.ShiftMasterRemark,
                    ShiftMasterAuthRemark = request.ShiftMasterAuthRemark,
                    ShiftMasterAuth = request.ShiftMasterAuth,
                    ShiftMasterIsDiscard = request.ShiftMasterIsDiscard,
                    ShiftMasterIsActive = request.ShiftMasterIsActive,
                    CreatedBy = request.CreatedBy,
                    CreatedDate = request.CreatedDate,
                };

                _context.ShiftMasters.Add(shift);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        /// <summary>
        /// Get Shift By ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<ShiftMaster?> GetShiftByID(int Id)
        {
            return await _context.ShiftMasters.FirstOrDefaultAsync(c => c.ShiftMasterId == Id);

        }
        /// <summary>
        /// Get All Shift Details
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ShiftMasterResponseDTO>> GetShiftDetailsAsync()
        {


            return await _context.ShiftMasters
                .Where(c => c.ShiftMasterIsActive)
                .Include(c => c.ShiftMasterCompany)
                .Include(c => c.ShiftMasterEmployeeType)
                .OrderBy(c => c.ShiftMasterId)
                .Select(c => new ShiftMasterResponseDTO
                {
                    ShiftMasterId = c.ShiftMasterId,
                    ShiftMasterName = c.ShiftMasterName,
                    ShiftMasterAliseName = c.ShiftMasterAliseName,
                    ShiftMasterStartTime = c.ShiftMasterStartTime,
                    ShiftMasterEndTime = c.ShiftMasterEndTime,
                    ShiftMasterLunchStartTime = c.ShiftMasterLunchStartTime,
                    ShiftMasterLunchEndTime = c.ShiftMasterLunchEndTime,
                    ShiftMasterRemark = c.ShiftMasterRemark,
                    ShiftMasterAuthRemark = c.ShiftMasterAuthRemark,
                    ShiftMasterAuth = c.ShiftMasterAuth,
                    ShiftMasterIsDiscard = c.ShiftMasterIsDiscard,
                    ShiftMasterIsActive = c.ShiftMasterIsActive,
                    CompanyName = c.ShiftMasterCompany.CompanyName,
                    EmployeeTypeName = c.ShiftMasterEmployeeType.EmployeeTypeName,
                })
                .ToListAsync();

        }
        /// <summary>
        /// Update Shift Master
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task UpdateShiftAsync(UpdateShiftMasterRequest request)
        {
            try
            {
                var shift = await _context.ShiftMasters.FindAsync(request.ShiftMasterId);

                // Update fields
                //shift.ShiftMasterId = request.ShiftMasterId;
                shift.ShiftMasterCompanyId = request.ShiftMasterCompanyId;
                shift.ShiftMasterEmployeeTypeId = request.ShiftMasterEmployeeTypeId;
                shift.ShiftMasterName = request.ShiftMasterName;
                shift.ShiftMasterAliseName = request.ShiftMasterAliseName;
                shift.ShiftMasterStartTime = request.ShiftMasterStartTime;
                shift.ShiftMasterEndTime = request.ShiftMasterEndTime;
                shift.ShiftMasterLunchStartTime = request.ShiftMasterLunchStartTime;
                shift.ShiftMasterLunchEndTime = request.ShiftMasterLunchEndTime;
                shift.ShiftMasterRemark = request.ShiftMasterRemark;
                shift.ShiftMasterAuthRemark = request.ShiftMasterAuthRemark;
                shift.ShiftMasterAuth = request.ShiftMasterAuth;
                shift.ShiftMasterIsDiscard = request.ShiftMasterIsDiscard;
                shift.ShiftMasterIsActive = request.ShiftMasterIsActive;
                shift.CreatedBy = request.CreatedBy;
                shift.CreatedDate = request.CreatedDate;
                _context.ShiftMasters.Update(shift);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// Delete Shift Master
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteshiftAsync(int id)
        {
            try
            {
                var shift = await _context.ShiftMasters.FirstOrDefaultAsync(c => c.ShiftMasterId == id);

                shift.ShiftMasterIsActive = false;

                _context.ShiftMasters.Update(shift);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}