using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.DepartmentBudget;
using KalaGenset.ERP.HR.Core.Request.ShiftMaster;
using KalaGenset.ERP.HR.Core.ResponseDTO.DepartmentBudget;
using KalaGenset.ERP.HR.Core.ResponseDTO.ShiftMaster;
using KalaGenset.ERP.HR.Data.DbContexts;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace KalaGenset.ERP.HR.Core.Services
{
    public class DepartmentBudgetService : IDepartmentBudget
    {
        private readonly KalaDbContext _context;

        public DepartmentBudgetService(KalaDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Insert Department Budget
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task AddDepartmentBudgetAsync(InsertDepartmentBudgetRequest request)
        {
            try
            {
                var departmentbudget = new DepartmentBudget
                {
                    DepartmentBudgetDepartmentId = request.DepartmentBudgetDepartmentId,
                    DepartmentBudgetHeadId = request.DepartmentBudgetHeadId,
                    DepartmentFy = request.DepartmentFy,
                    DepartmentBudgetAmt = request.DepartmentBudgetAmt,
                    DepartmentBudgetRemark = request.DepartmentBudgetRemark,
                    DepartmentBudgetAuthRemark = request.DepartmentBudgetAuthRemark,
                    DepartmentBudgetAuth = request.DepartmentBudgetAuth,
                    DepartmentBudgetIsDiscard = request.DepartmentBudgetIsDiscard,
                    DepartmentBudgetIsActive = request.DepartmentBudgetIsActive,
                    CreatedBy = request.CreatedBy,
                    CreatedDate = request.CreatedDate,
                    UpdatedBy = request.UpdatedBy,
                    UpdatedDate = request.UpdatedDate,

                };


                _context.DepartmentBudgets.Add(departmentbudget);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// Get All Department Budget Details
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DepartmentBudgetResponseDTO>> GetDepartmentBudgetDetailsAsync()
        {


            return await _context.DepartmentBudgets
                .Where(c => c.DepartmentBudgetIsActive)
                .Include(c => c.DepartmentBudgetDepartment)
                .Include(c => c.DepartmentBudgetHead)
                .OrderBy(c => c.DepartmentBudgetId)
                .Select(c => new DepartmentBudgetResponseDTO
                {
                    DepartmentBudgetId = c.DepartmentBudgetId,
                    DepartmentFy = c.DepartmentFy,
                    DepartmentBudgetAmt = c.DepartmentBudgetAmt,
                    DepartmentBudgetRemark = c.DepartmentBudgetRemark,
                    DepartmentBudgetAuthRemark = c.DepartmentBudgetAuthRemark,
                    DepartmentBudgetAuth = c.DepartmentBudgetAuth,
                    DepartmentBudgetIsDiscard = c.DepartmentBudgetIsDiscard,
                    DepartmentBudgetIsActive = c.DepartmentBudgetIsActive,
                    DepartmentName = c.DepartmentBudgetDepartment.DepartmentName,
                    EmployeeMasterFullName = c.DepartmentBudgetHead.EmployeeMasterFullName,
                })
                .ToListAsync();

        }
        /// <summary>
        /// Get Department Budget By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DepartmentBudgetResponseDTO?> GetDepartmentBudgetByIDAsync(int id)
        {
            return await _context.DepartmentBudgets
                .Where(c => c.DepartmentBudgetId == id)
                .Include(c => c.DepartmentBudgetDepartment)
                .Include(c => c.DepartmentBudgetHead)
                .Select(c => new DepartmentBudgetResponseDTO
                {
                    DepartmentBudgetId = c.DepartmentBudgetId,
                    DepartmentFy = c.DepartmentFy,
                    DepartmentBudgetAmt = c.DepartmentBudgetAmt,
                    DepartmentBudgetRemark = c.DepartmentBudgetRemark,
                    DepartmentBudgetAuthRemark = c.DepartmentBudgetAuthRemark,
                    DepartmentBudgetAuth = c.DepartmentBudgetAuth,
                    DepartmentBudgetIsDiscard = c.DepartmentBudgetIsDiscard,
                    DepartmentBudgetIsActive = c.DepartmentBudgetIsActive,
                    DepartmentName = c.DepartmentBudgetDepartment.DepartmentName,
                    EmployeeMasterFullName = c.DepartmentBudgetHead.EmployeeMasterFullName,
                })
                .FirstOrDefaultAsync();
        }
        /// <summary>
        /// Update Department Budget
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task UpdatedepartmentBudgetAsync(UpdateDepartmentBudgetRequest request)
        {
            try
            {
                var departmentbudget = await _context.DepartmentBudgets.FindAsync(request.DepartmentBudgetId);

                if (departmentbudget == null)
                {
                    throw new Exception("Department budget not found.");
                }

                // Update fields
                departmentbudget.DepartmentBudgetDepartmentId = request.DepartmentBudgetDepartmentId;
                departmentbudget.DepartmentFy = request.DepartmentFy;
                departmentbudget.DepartmentBudgetAmt = request.DepartmentBudgetAmt;
                departmentbudget.DepartmentBudgetHeadId = request.DepartmentBudgetHeadId;
                departmentbudget.DepartmentBudgetRemark = request.DepartmentBudgetRemark;
                departmentbudget.DepartmentBudgetAuthRemark = request.DepartmentBudgetAuthRemark;
                departmentbudget.DepartmentBudgetAuth = request.DepartmentBudgetAuth;
                departmentbudget.DepartmentBudgetIsDiscard = request.DepartmentBudgetIsDiscard;
                departmentbudget.DepartmentBudgetIsActive = request.DepartmentBudgetIsActive;
                departmentbudget.CreatedBy = request.CreatedBy;
                departmentbudget.CreatedDate = request.CreatedDate;
                departmentbudget.UpdatedBy = request.UpdatedBy;
                departmentbudget.UpdatedDate = request.UpdatedDate;

                _context.DepartmentBudgets.Update(departmentbudget);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// Get Year End
        /// </summary>
        /// <returns></returns>
        public async Task<List<YearEndResult>> GetYearEndAsync()
        {
            var results = await _context.Database
                .SqlQueryRaw<YearEndResult>("EXEC year_end")
                .ToListAsync();

            return results;
        }
        /// <summary>
        /// Delete Department Budget
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public async Task DeleteDepartmentBudgetAsync(int id)
        {
            try
            {
                var departmentbudget = await _context.DepartmentBudgets.FirstOrDefaultAsync(c => c.DepartmentBudgetId == id);

                departmentbudget.DepartmentBudgetIsActive = false;

                _context.DepartmentBudgets.Update(departmentbudget);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
    
}
