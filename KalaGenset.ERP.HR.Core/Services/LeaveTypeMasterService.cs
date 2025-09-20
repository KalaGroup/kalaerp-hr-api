using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.DepartmentBudget;
using KalaGenset.ERP.HR.Core.Request.EmployeeTypeMaster;
using KalaGenset.ERP.HR.Core.Request.LeaveTypeMaster;
using KalaGenset.ERP.HR.Core.Request.WorkstationBudget;
using KalaGenset.ERP.HR.Core.ResponseDTO.DepartmentBudget;
using KalaGenset.ERP.HR.Core.ResponseDTO.LeaveTypeMaster;
using KalaGenset.ERP.HR.Data.DbContexts;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace KalaGenset.ERP.HR.Core.Services
{
    public class LeaveTypeMasterService : ILeaveTypeMaster
    {
        private readonly KalaDbContext _context;
        public LeaveTypeMasterService(KalaDbContext Context)
        {
            _context = Context;
        }
        public async Task AddLeaveTypeAsync(InsertleaveTypeMasterRequest request)
        {
            try
            {
                var leavetype = new LeaveTypeMaster
                {
                    LeaveTypeMasterName = request.LeaveTypeMasterName,
                    LeaveTypeMasterCode = request.LeaveTypeMasterCode,
                    LeaveTypeMasterMaxDaysPer = request.LeaveTypeMasterMaxDaysPer,
                    LeaveTypeMasterContinuosDaysPerYear = request.LeaveTypeMasterContinuosDaysPerYear,
                    LeaveTypeMasterCanCarryForward = request.LeaveTypeMasterCanCarryForward,
                    LeaveTypeMasterCanEnCash = request.LeaveTypeMasterCanEnCash,
                    LeaveTypeMasterRequiredServiceMonths = request.LeaveTypeMasterRequiredServiceMonths,
                    LeaveTypeMasterLeaveTypeRemark = request.LeaveTypeMasterLeaveTypeRemark,
                    LeaveTypeMasterAuthRemark = request.LeaveTypeMasterAuthRemark,
                    LeaveTypeMasterAuth = request.LeaveTypeMasterAuth,
                    LeaveTypeMasterIsDiscard = request.LeaveTypeMasterIsDiscard,
                    LeaveTypeMasterIsActive = request.LeaveTypeMasterIsActive,
                    CreatedBy = request.CreatedBy,
                    CreatedDate = request.CreatedDate,
                    UpdatedBy = request.UpdatedBy,
                    UpdatedDate = request.UpdatedDate,
                };

                _context.LeaveTypeMasters.Add(leavetype);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IEnumerable<LeaveTypeMasterResponseDTO>> GetLeaveTypeDetailsAsync()
        {
            return await _context.LeaveTypeMasters
                .Where(c => c.LeaveTypeMasterIsActive)
                .OrderBy(c => c.LeaveTypeMasterId)
                .Select(c => new LeaveTypeMasterResponseDTO
                {
                    LeaveTypeMasterId = c.LeaveTypeMasterId,
                    LeaveTypeMasterName = c.LeaveTypeMasterName,
                    LeaveTypeMasterCode = c.LeaveTypeMasterCode,
                    LeaveTypeMasterMaxDaysPer = c.LeaveTypeMasterMaxDaysPer,
                    LeaveTypeMasterContinuosDaysPerYear = c.LeaveTypeMasterContinuosDaysPerYear,
                    LeaveTypeMasterCanCarryForward = c.LeaveTypeMasterCanCarryForward,
                    LeaveTypeMasterCanEnCash = c.LeaveTypeMasterCanEnCash,
                    LeaveTypeMasterRequiredServiceMonths = c.LeaveTypeMasterRequiredServiceMonths,
                    LeaveTypeMasterLeaveTypeRemark = c.LeaveTypeMasterLeaveTypeRemark,
                    LeaveTypeMasterAuthRemark = c.LeaveTypeMasterAuthRemark,
                    LeaveTypeMasterAuth = c.LeaveTypeMasterAuth,
                    LeaveTypeMasterIsDiscard = c.LeaveTypeMasterIsDiscard,
                    LeaveTypeMasterIsActive = c.LeaveTypeMasterIsActive,

                })
                .ToListAsync();

        }

        public async Task<LeaveTypeMaster?> GetLeaveTypeById(int LeaveTypeMasterId)
        {
            return await _context.LeaveTypeMasters.FirstOrDefaultAsync(c => c.LeaveTypeMasterId == LeaveTypeMasterId);
        }

        public async Task UpdateLeaveTypeAsync(UpdateLeaveTypeMasterRequest request)
        {
            try
            {
                var leavetype = await _context.LeaveTypeMasters.FindAsync(request.LeaveTypeMasterId);

                if (leavetype == null)
                {
                    throw new Exception("Leave Type not found.");
                }

                // Update fields
                leavetype.LeaveTypeMasterId = request.LeaveTypeMasterId;
                leavetype.LeaveTypeMasterCode = request.LeaveTypeMasterCode;
                leavetype.LeaveTypeMasterName = request.LeaveTypeMasterName;
                leavetype.LeaveTypeMasterMaxDaysPer = request.LeaveTypeMasterMaxDaysPer;
                leavetype.LeaveTypeMasterContinuosDaysPerYear = request.LeaveTypeMasterContinuosDaysPerYear;
                leavetype.LeaveTypeMasterCanCarryForward = request.LeaveTypeMasterCanCarryForward;
                leavetype.LeaveTypeMasterCanEnCash = request.LeaveTypeMasterCanEnCash;
                leavetype.LeaveTypeMasterRequiredServiceMonths = request.LeaveTypeMasterRequiredServiceMonths;
                leavetype.LeaveTypeMasterLeaveTypeRemark = request.LeaveTypeMasterLeaveTypeRemark;
                leavetype.LeaveTypeMasterAuthRemark = request.LeaveTypeMasterAuthRemark;
                leavetype.LeaveTypeMasterAuth = request.LeaveTypeMasterAuth;
                leavetype.LeaveTypeMasterIsDiscard = request.LeaveTypeMasterIsDiscard;
                leavetype.LeaveTypeMasterIsActive = request.LeaveTypeMasterIsActive;
                leavetype.CreatedBy = request.CreatedBy;
                leavetype.CreatedDate = request.CreatedDate;
                leavetype.UpdatedBy = request.UpdatedBy;
                leavetype.UpdatedDate = request.UpdatedDate;

                _context.LeaveTypeMasters.Update(leavetype);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task DeleteLeaveTypeAsync(int id)
        {
            try
            {
                var leavetype = await _context.LeaveTypeMasters.FirstOrDefaultAsync(c => c.LeaveTypeMasterId == id);

                leavetype.LeaveTypeMasterIsActive = false;

                _context.LeaveTypeMasters.Update(leavetype);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }


}
