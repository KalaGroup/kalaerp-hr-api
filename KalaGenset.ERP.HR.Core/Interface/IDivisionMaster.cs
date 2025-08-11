using KalaGenset.ERP.HR.Core.Request.DivisionMaster;
using KalaGenset.ERP.HR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface IDivisionMaster
    {
        /// <summary>
        /// Add a new Division to the system.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task AddDivisionAsync(InsertDivisionMasterRequest request);

        /// <summary>
        /// Get the details of all Divisions in the system.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<DivisionMaster>> GetDivisionDetailsAsync();

        /// <summary>
        /// Update the details of an existing Division.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task UpdateDivisionAsync(UpdateDivisionMasterRequest request);

        /// <summary>
        /// Get the details of a Division by its ID.
        /// </summary>
        /// <param name="StateId"></param>
        /// <returns></returns>
        public Task<DivisionMaster?> GetDivisionByID(int DivisionId);

        /// <summary>
        /// Delete a Division by its ID. This marks the Division as inactive instead of removing it from the database.
        /// </summary>
        /// <param name="wid"></param>
        /// <returns></returns>
        public Task DeleteDivisionAsync(int did);
    }
}

