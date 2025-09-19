using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.DepartmentBudget;
using KalaGenset.ERP.HR.Core.Request.WorkstationBudget;
using KalaGenset.ERP.HR.Core.ResponseDTO.DepartmentBudget;
using KalaGenset.ERP.HR.Core.ResponseDTO.WorkstationBudget;
using KalaGenset.ERP.HR.Data.DbContexts;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace KalaGenset.ERP.HR.Core.Services
{
    public class WorkstationBudgetService : IWorkstationBudget
    {
        private readonly KalaDbContext _context;

        public WorkstationBudgetService(KalaDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Add Workstation Budget
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task AddWorkstationBudgetAsync(InsertWorkstationBudgetRequest request)
        {
            try
            {
                var workstationbudget = new WorkstationBudget
                {
                    WorkstationBudgetWorkstationId = request.WorkstationBudgetWorkstationId,
                    WorkstationBudgetHeadId = request.WorkstationBudgetHeadId,
                    WorkstationFy = request.WorkstationFy,
                    WorkstationBudgetAmt = request.WorkstationBudgetAmt,
                    WorkstationBudgetRemark = request.WorkstationBudgetRemark,
                    WorkstationBudgetAuthRemark = request.WorkstationBudgetAuthRemark,
                    WorkstationBudgetAuth = request.WorkstationBudgetAuth,
                    WorkstationBudgetIsDiscard = request.WorkstationBudgetIsDiscard,
                    WorkstationBudgetIsActive = request.WorkstationBudgetIsActive,
                    CreatedBy = request.CreatedBy,
                    CreatedDate = request.CreatedDate,
                    UpdatedBy = request.UpdatedBy,
                    UpdatedDate = request.UpdatedDate,

                };


                _context.WorkstationBudgets.Add(workstationbudget);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Get Workstation Budget Details
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<WorkstationBudgetResponseDTO>> GetWorkstationBudgetDetailsAsync()
        {
            return await _context.WorkstationBudgets
                .Where(c => c.WorkstationBudgetIsActive)
                .Include(c => c.WorkstationBudgetWorkstation)
                .Include(c => c.WorkstationBudgetHead)
                .OrderBy(c => c.WorkstationBudgetId)
                .Select(c => new WorkstationBudgetResponseDTO
                {
                    WorkstationBudgetId = c.WorkstationBudgetId,
                    WorkstationFy = c.WorkstationFy,
                    WorkstationBudgetAmt = c.WorkstationBudgetAmt,
                    WorkstationBudgetRemark = c.WorkstationBudgetRemark,
                    WorkstationBudgetAuthRemark = c.WorkstationBudgetAuthRemark,
                    WorkstationBudgetAuth = c.WorkstationBudgetAuth,
                    WorkstationBudgetIsDiscard = c.WorkstationBudgetIsDiscard,
                    WorkstationBudgetIsActive = c.WorkstationBudgetIsActive,
                    WorkStationName = c.WorkstationBudgetWorkstation.WorkStationName,
                    EmployeeMasterFullName = c.WorkstationBudgetHead.EmployeeMasterFullName,
                })
                .ToListAsync();
        }
        /// <summary>
        /// Get Workstation Budget By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<WorkstationBudgetResponseDTO?> GetWorkstationBudgetByIDAsync(int id)
        {
            return await _context.WorkstationBudgets
                .Where(c => c.WorkstationBudgetId == id)
                .Include(c => c.WorkstationBudgetWorkstation)
                .Include(c => c.WorkstationBudgetHead)
                .Select(c => new WorkstationBudgetResponseDTO
                {
                    WorkstationBudgetId = c.WorkstationBudgetId,
                    WorkstationFy = c.WorkstationFy,
                    WorkstationBudgetAmt = c.WorkstationBudgetAmt,
                    WorkstationBudgetRemark = c.WorkstationBudgetRemark,
                    WorkstationBudgetAuthRemark = c.WorkstationBudgetAuthRemark,
                    WorkstationBudgetAuth = c.WorkstationBudgetAuth,
                    WorkstationBudgetIsDiscard = c.WorkstationBudgetIsDiscard,
                    WorkstationBudgetIsActive = c.WorkstationBudgetIsActive,
                    WorkStationName = c.WorkstationBudgetWorkstation.WorkStationName,
                    EmployeeMasterFullName = c.WorkstationBudgetHead.EmployeeMasterFullName,
                })
                .FirstOrDefaultAsync();
        }
        /// <summary>
        /// Update Workstation Budget
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task UpdateWorkstationBudgetAsync(UpdateWorkstaionBudgetRequest request)
        {
            try
            {
                var workstationbudget = await _context.WorkstationBudgets.FindAsync(request.WorkstationBudgetId);

                if (workstationbudget == null)
                {
                    throw new Exception("Workstation budget not found.");
                }

                // Update fields
                workstationbudget.WorkstationBudgetWorkstationId = request.WorkstationBudgetWorkstationId;
                workstationbudget.WorkstationFy = request.WorkstationFy;
                workstationbudget.WorkstationBudgetAmt = request.WorkstationBudgetAmt;
                workstationbudget.WorkstationBudgetHeadId = request.WorkstationBudgetHeadId;
                workstationbudget.WorkstationBudgetRemark = request.WorkstationBudgetRemark;
                workstationbudget.WorkstationBudgetAuthRemark = request.WorkstationBudgetAuthRemark;
                workstationbudget.WorkstationBudgetAuth = request.WorkstationBudgetAuth;
                workstationbudget.WorkstationBudgetIsDiscard = request.WorkstationBudgetIsDiscard;
                workstationbudget.WorkstationBudgetIsActive = request.WorkstationBudgetIsActive;
                workstationbudget.CreatedBy = request.CreatedBy;
                workstationbudget.CreatedDate = request.CreatedDate;
                workstationbudget.UpdatedBy = request.UpdatedBy;
                workstationbudget.UpdatedDate = request.UpdatedDate;

                _context.WorkstationBudgets.Update(workstationbudget);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// Delete Workstation Budget
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteWorkstationBudgetAsync(int id)
        {
            try
            {
                var workstationbudget = await _context.WorkstationBudgets.FirstOrDefaultAsync(c => c.WorkstationBudgetId == id);

                workstationbudget.WorkstationBudgetIsActive = false;

                _context.WorkstationBudgets.Update(workstationbudget);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
