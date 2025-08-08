using KalaGenset.ERP.HR.Core.Request.LocationRequest;
using KalaGenset.ERP.HR.Core.Request.Workstation;
using KalaGenset.ERP.HR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface IWorkstationMaster
    {
        /// <summary>
        /// Add a new workstation to the system.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task AddWorkStationAsync(InsertWorkstationRequest request);

        /// <summary>
        /// Get the details of all workstations in the system.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<WorkStationMaster>> GetWorkStationDetailsAsync();

        /// <summary>
        /// Update the details of an existing workstation.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task UpdateWorkStationAsync(UpdateWorkstationRequest request);

        /// <summary>
        /// Get the details of a workstation by its ID.
        /// </summary>
        /// <param name="StateId"></param>
        /// <returns></returns>
        public Task<WorkStationMaster?> GetWorkStationByID(int StateId);

        /// <summary>
        /// Delete a workstation by its ID. This marks the workstation as inactive instead of removing it from the database.
        /// </summary>
        /// <param name="wid"></param>
        /// <returns></returns>
        public Task DeleteWorkStationAsync(int wid);
    }
}
