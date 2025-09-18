using KalaGenset.ERP.HR.Core.Request.ProfitcenterBudget;
using KalaGenset.ERP.HR.Core.Request.ProfitcenterMaster;
using KalaGenset.ERP.HR.Core.ResponseDTO.Company;
using KalaGenset.ERP.HR.Core.ResponseDTO.ProfitcenterBudget;
using KalaGenset.ERP.HR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface IProfitcenterBudget
    {
        public Task AddProfitCenterBudgetAsync(InsertProfitcenterBudgetRequest request);

        public Task UpdateProfitCenterBudgetAsync(UpdateProfitcenterBudgetRequest request);

        public Task<IEnumerable<ProfitcenterBudgetDTO>> GetAllProfitCenterBudgetAsync();

        public Task<ProfitcenterBudget?> GetProfitCenterBudgetByIdAsync(int ProfitcenterBudgetId);

        public Task DeleteProfitCenterBudgetAsync(int ProfitcenterBudgetId);
        public Task<List<YearEndResult>> GetYearEndAsync();
    }
}
