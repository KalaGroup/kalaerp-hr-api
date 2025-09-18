using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KalaGenset.ERP.HR.Core.Request.DepartmentBudget;
using KalaGenset.ERP.HR.Core.ResponseDTO.DepartmentBudget;

namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface IDepartmentBudget
    {
        /// <summary>
        /// Insert Department Budget
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task AddDepartmentBudgetAsync(InsertDepartmentBudgetRequest request);
        /// <summary>
        /// Get All Department Budget Details
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<DepartmentBudgetResponseDTO>> GetDepartmentBudgetDetailsAsync();
        /// <summary>
        /// Get Department Budget By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<DepartmentBudgetResponseDTO?> GetDepartmentBudgetByIDAsync(int id);
        /// <summary>
        /// Update Department Budget
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task UpdatedepartmentBudgetAsync(UpdateDepartmentBudgetRequest request);
        /// <summary>
        /// Delete Department Budget
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task DeleteDepartmentBudgetAsync(int id);
        /// <summary>
        /// Get Year End
        /// </summary>
        /// <returns></returns>
        public Task<List<YearEndResult>> GetYearEndAsync();
    }
}
