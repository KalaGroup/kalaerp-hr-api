using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.EmployeeLeaveBalance;
using KalaGenset.ERP.HR.Core.Request.Workstation;
using KalaGenset.ERP.HR.Core.ResponseDTO.EmployeeLeaveBalance;
using KalaGenset.ERP.HR.Core.ResponseDTO.WorkstationMaster;
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
    public class EmployeeLeaveBalanceService : IEmployeeLeaveBalance
    {
        private readonly KalaDbContext _context;

        public EmployeeLeaveBalanceService(KalaDbContext context)
        {
            _context = context;
        }

        public async Task AddEmployeeLeaveBalanceAsync(InsertEmployeeLeaveBalanceRequest request)
        {
            try
            {
                var employeeLeaveBalance = new EmployeeLeaveBalance
                {
                    LeaveBalancesEmployeeId = request.LeaveBalancesEmployeeId,
                    LeaveBalancesTypeId = request.LeaveBalancesTypeId,
                    LeaveBalancesYear = request.LeaveBalancesYear,
                    LeaveBalancesOpening = request.LeaveBalancesOpening,
                    LeaveBalancesCredited = request.LeaveBalancesCredited,
                    LeaveBalancesUtilized = request.LeaveBalancesUtilized,
                    LeaveBalancesEncashed = request.LeaveBalancesEncashed,
                    LeaveBalancesClosing = request.LeaveBalancesClosing,
                    LeaveBalancesRemark = request.LeaveBalancesRemark,
                    LeaveBalancesAuthRemark = request.LeaveBalancesAuthRemark,
                    LeaveBalancesAuth = request.LeaveBalancesAuth,
                    LeaveBalancesIsDiscard = request.LeaveBalancesIsDiscard,
                    LeaveBalancesIsActive = request.LeaveBalancesIsActive,
                    CreatedBy = 3,
                    CreatedDate = DateTime.Now,
                    UpdatedBy = 3,
                    UpdatedDate = DateTime.Now
                };

                _context.EmployeeLeaveBalances.Add(employeeLeaveBalance);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        /// <summary>
        /// Update Employee Leave Balance
        /// </summary>
        public async Task UpdateEmployeeLeaveBalanceAsync(UpdateEmployeeLeaveBalanceRequest request)
        {
            try
            {
                var leaveBalance = await _context.EmployeeLeaveBalances.FindAsync(request.LeaveBalancesId);

                // Update fields
                leaveBalance.LeaveBalancesEmployeeId = request.LeaveBalancesEmployeeId;
                leaveBalance.LeaveBalancesTypeId = request.LeaveBalancesTypeId;
                leaveBalance.LeaveBalancesYear = request.LeaveBalancesYear;
                leaveBalance.LeaveBalancesOpening = request.LeaveBalancesOpening;
                leaveBalance.LeaveBalancesCredited = request.LeaveBalancesCredited;
                leaveBalance.LeaveBalancesUtilized = request.LeaveBalancesUtilized;
                leaveBalance.LeaveBalancesEncashed = request.LeaveBalancesEncashed;
                leaveBalance.LeaveBalancesClosing = request.LeaveBalancesClosing;
                leaveBalance.LeaveBalancesRemark = request.LeaveBalancesRemark;
                leaveBalance.LeaveBalancesAuthRemark = request.LeaveBalancesAuthRemark;
                leaveBalance.LeaveBalancesAuth = request.LeaveBalancesAuth;
                leaveBalance.LeaveBalancesIsDiscard = request.LeaveBalancesIsDiscard;
                leaveBalance.LeaveBalancesIsActive = request.LeaveBalancesIsActive;
                leaveBalance.UpdatedBy = request.UpdatedBy;
                leaveBalance.UpdatedDate = DateTime.Now;

                _context.EmployeeLeaveBalances.Update(leaveBalance);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Soft Delete (set IsActive = false)
        /// </summary>
        public async Task DeleteEmployeeLeaveBalanceAsync(int id)
        {
            try
            {
                var leaveBalance = await _context.EmployeeLeaveBalances.FirstOrDefaultAsync(c => c.LeaveBalancesId == id);

                if (leaveBalance == null)
                    throw new Exception("Employee Leave Balance not found.");

                leaveBalance.LeaveBalancesIsActive = false;

                _context.EmployeeLeaveBalances.Update(leaveBalance);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get By ID
        /// </summary>
        public async Task<EmployeeLeaveBalance?> GetEmployeeLeaveBalanceByIdAsync(int id)
        {
            return await _context.EmployeeLeaveBalances
                                 .Include(e => e.LeaveBalancesEmployee)
                                 .Include(e => e.LeaveBalancesType)
                                 .FirstOrDefaultAsync(c => c.LeaveBalancesId == id);
        }

        /// <summary>
        /// Get All (Active only)
        /// </summary>
        public async Task<IEnumerable<EmployeeLeaveBalanceResponseDTO>> GetEmployeeLeaveBalancesAsync()
        {
            var result = await (
                from lb in _context.EmployeeLeaveBalances
                join emp in _context.EmployeeMasterPersonalDetails
                    on lb.LeaveBalancesEmployeeId equals emp.EmployeeMasterId
                join lt in _context.LeaveTypeMasters
                    on lb.LeaveBalancesTypeId equals lt.LeaveTypeMasterId
                where lb.LeaveBalancesIsActive == true   // ✅ Only active
                select new EmployeeLeaveBalanceResponseDTO
                {
                    LeaveBalancesId = lb.LeaveBalancesId,
                    LeaveBalancesEmployeeId = lb.LeaveBalancesEmployeeId,
                    EmployeeMasterFullName = emp.EmployeeMasterFullName,   // From Employee

                    LeaveBalancesTypeId = lb.LeaveBalancesTypeId,
                    LeaveTypeMasterName = lt.LeaveTypeMasterName,  // From LeaveType

                    LeaveBalancesYear = lb.LeaveBalancesYear,
                    LeaveBalancesOpening = lb.LeaveBalancesOpening,
                    LeaveBalancesCredited = lb.LeaveBalancesCredited,
                    LeaveBalancesUtilized = lb.LeaveBalancesUtilized,
                    LeaveBalancesEncashed = lb.LeaveBalancesEncashed,
                    LeaveBalancesClosing = lb.LeaveBalancesClosing,

                    LeaveBalancesRemark = lb.LeaveBalancesRemark,
                    LeaveBalancesAuthRemark = lb.LeaveBalancesAuthRemark,
                    LeaveBalancesAuth = lb.LeaveBalancesAuth,
                    LeaveBalancesIsDiscard = lb.LeaveBalancesIsDiscard,
                    LeaveBalancesIsActive = lb.LeaveBalancesIsActive,

                    CreatedBy = lb.CreatedBy,
                    CreatedDate = lb.CreatedDate,
                    UpdatedBy = lb.UpdatedBy,
                    UpdatedDate = lb.UpdatedDate
                }).ToListAsync();

            return result;
        }

    }
}

