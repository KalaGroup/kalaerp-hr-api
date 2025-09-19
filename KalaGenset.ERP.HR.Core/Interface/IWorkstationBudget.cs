using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KalaGenset.ERP.HR.Core.Request.WorkstationBudget;
using KalaGenset.ERP.HR.Core.ResponseDTO.WorkstationBudget;

namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface IWorkstationBudget
    {
        /// <summary>
        /// Add Workstation Budget
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task AddWorkstationBudgetAsync(InsertWorkstationBudgetRequest request);
        /// <summary>
        /// Get All Workstation Budget Details
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<WorkstationBudgetResponseDTO>> GetWorkstationBudgetDetailsAsync();
        /// <summary>
        /// Get Workstation Budget By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<WorkstationBudgetResponseDTO?> GetWorkstationBudgetByIDAsync(int id);
        /// <summary>
        /// Update Workstation Budget
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task UpdateWorkstationBudgetAsync(UpdateWorkstaionBudgetRequest request);
        /// <summary>
        /// Delete Workstation Budget
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task DeleteWorkstationBudgetAsync(int id);
        
    }
}
