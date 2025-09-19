using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.ProfitcenterBudget;
using KalaGenset.ERP.HR.Core.ResponseDTO.ProfitcenterBudget;
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
    public class ProfitcenterBudgetService : IProfitcenterBudget
    {
        private readonly KalaDbContext context;
        public ProfitcenterBudgetService(KalaDbContext context)
        {
            this.context = context;
        }

        public async Task AddProfitCenterBudgetAsync(InsertProfitcenterBudgetRequest request)
        {
            try
            {
                // 🔹 First check if the same FinancialYear + ProfitCenter already exists
                bool exists = await context.ProfitcenterBudgets
                    .AnyAsync(x => x.ProfitcenterFy == request.ProfitcenterFy &&
                                   x.ProfitcenterBudgetProfitcenterId == request.ProfitcenterBudgetProfitcenterId);

                if (exists)
                {
                    throw new InvalidOperationException();
                }

                // 🔹 If not exists, create new entry
                var budget = new ProfitcenterBudget
                {
                    ProfitcenterBudgetProfitcenterId = request.ProfitcenterBudgetProfitcenterId,
                    ProfitcenterFy = request.ProfitcenterFy,
                    ProfitcenterBudgetBudgetAmt = request.ProfitcenterBudgetBudgetAmt,
                    ProfitCenterBudgetHeadId = request.ProfitCenterBudgetHeadId,
                    ProfitCenterBudgetRemark = request.ProfitCenterBudgetRemark,
                    ProfitCenterBudgetAuthRemark = request.ProfitCenterBudgetAuthRemark,
                    ProfitCenterBudgetAuth = request.ProfitCenterBudgetAuth,
                    ProfitCenterBudgetIsDiscard = request.ProfitCenterBudgetIsDiscard,
                    ProfitCenterBudgetIsActive = request.ProfitCenterBudgetIsActive,
                    CreatedBy = request.CreatedBy,
                    CreatedDate = request.CreatedDate,
                    UpdatedBy = request.UpdatedBy,
                    UpdatedDate = request.UpdatedDate
                };

                context.ProfitcenterBudgets.Add(budget);
                await context.SaveChangesAsync();
            }
            catch (InvalidOperationException)
            {
                // rethrow so controller can send 409 Conflict
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }


        public async Task DeleteProfitCenterBudgetAsync(int profitcenterBudgetId)
        {
            try
            {
                var budget = await context.ProfitcenterBudgets
                    .FirstOrDefaultAsync(b => b.ProfitcenterBudgetId == profitcenterBudgetId);

                if (budget == null)
                {
                    throw new KeyNotFoundException($"ProfitcenterBudget with ID {profitcenterBudgetId} not found.");
                }

                budget.ProfitCenterBudgetIsActive = false;
                context.ProfitcenterBudgets.Update(budget);
                await context.SaveChangesAsync();
               
            }
            catch (Exception ex)
            {
                // Log exception here if needed
                throw new Exception("Error deleting profit center budget", ex);
            }
        }


        public async Task<IEnumerable<ProfitcenterBudgetDTO>> GetAllProfitCenterBudgetAsync()
        {
            return await context.ProfitcenterBudgets
                .Where(b => b.ProfitCenterBudgetIsActive)
                .Include(b => b.ProfitcenterBudgetProfitcenter)
                .Include(b => b.ProfitCenterBudgetHead)
                .OrderBy(b => b.ProfitcenterBudgetId)
                .Select(b => new ProfitcenterBudgetDTO
                {
                    ProfitcenterBudgetId = b.ProfitcenterBudgetId,
                    ProfitCenterName = b.ProfitcenterBudgetProfitcenter.ProfitCenterName,  
                    ProfitcenterFy = b.ProfitcenterFy,
                    ProfitcenterBudgetBudgetAmt = b.ProfitcenterBudgetBudgetAmt,
                    EmployeeMasterFullName = b.ProfitCenterBudgetHead.EmployeeMasterFullName,
                    ProfitCenterBudgetRemark = b.ProfitCenterBudgetRemark,
                    ProfitCenterBudgetAuthRemark = b.ProfitCenterBudgetAuthRemark,
                    ProfitCenterBudgetAuth = b.ProfitCenterBudgetAuth,
                    ProfitCenterBudgetIsDiscard = b.ProfitCenterBudgetIsDiscard,
                    ProfitCenterBudgetIsActive = b.ProfitCenterBudgetIsActive,
                    CreatedBy = b.CreatedBy,
                    CreatedDate = b.CreatedDate,
                    UpdatedBy = b.UpdatedBy,
                    UpdatedDate = b.UpdatedDate
                })
                .ToListAsync();
        }

        public async Task<ProfitcenterBudget?> GetProfitCenterBudgetByIdAsync(int ProfitcenterBudgetId)
        {
            return await context.ProfitcenterBudgets.FirstOrDefaultAsync(c => c.ProfitcenterBudgetId == ProfitcenterBudgetId);
        }

        public async Task UpdateProfitCenterBudgetAsync(UpdateProfitcenterBudgetRequest request)
        {
            try
            {
                var budget = await context.ProfitcenterBudgets
                    .FirstOrDefaultAsync(b => b.ProfitcenterBudgetId == request.ProfitcenterBudgetId);

                if (budget == null)
                {
                    throw new KeyNotFoundException($"ProfitcenterBudget with ID {request.ProfitcenterBudgetId} not found.");
                }

                // 🔹 Check for duplicate (exclude current record)
                bool exists = await context.ProfitcenterBudgets
                    .AnyAsync(x => x.ProfitcenterFy == request.ProfitcenterFy &&
                                   x.ProfitcenterBudgetProfitcenterId == request.ProfitcenterBudgetProfitcenterId &&
                                   x.ProfitcenterBudgetId != request.ProfitcenterBudgetId);

                if (exists)
                {
                     throw new InvalidOperationException("A budget for this Financial Year and Profit Center already exists.");
                }

                // 🔹 Update fields
                budget.ProfitcenterBudgetProfitcenterId = request.ProfitcenterBudgetProfitcenterId;
                budget.ProfitcenterFy = request.ProfitcenterFy;
                budget.ProfitcenterBudgetBudgetAmt = request.ProfitcenterBudgetBudgetAmt;
                budget.ProfitCenterBudgetHeadId = request.ProfitCenterBudgetHeadId;
                budget.ProfitCenterBudgetRemark = request.ProfitCenterBudgetRemark;
                budget.ProfitCenterBudgetAuthRemark = request.ProfitCenterBudgetAuthRemark;
                budget.ProfitCenterBudgetAuth = request.ProfitCenterBudgetAuth;
                budget.ProfitCenterBudgetIsDiscard = request.ProfitCenterBudgetIsDiscard;
                budget.ProfitCenterBudgetIsActive = request.ProfitCenterBudgetIsActive;

                budget.UpdatedBy = request.UpdatedBy;
                budget.UpdatedDate = request.UpdatedDate;

                context.ProfitcenterBudgets.Update(budget);
                await context.SaveChangesAsync();
            }
            catch (InvalidOperationException)
            {
                // 🔹 Let controller translate into 409 Conflict
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating profit center budget", ex);
            }
        }

        public async Task<List<YearEndResult>> GetYearEndAsync()
        {
            var results = await context.Database
                .SqlQueryRaw<YearEndResult>("EXEC year_end")
                .ToListAsync();

            return results;
        }


    }
}
