using KalaGenset.ERP.HR.Core.Request.PositionMaster;
using KalaGenset.ERP.HR.Core.Request.Workstation;
using KalaGenset.ERP.HR.Core.ResponseDTO.PositionMaster;
using KalaGenset.ERP.HR.Core.ResponseDTO.WorkstationMaster;
using KalaGenset.ERP.HR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface IPositionMaster
    {
        /// <summary>
        /// Add a new workstation to the system.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task AddPositionAsync(InsertPositionRequest request);

        /// <summary>
        /// Get the details of all workstations in the system.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<PositionResponseDTO>> GetPositionDetailsAsync();

        /// <summary>
        /// Update the details of an existing workstation.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task UpdatePositionAsync(UpdatePositionRequest request);

        /// <summary>
        /// Get the details of a workstation by its ID.
        /// </summary>
        /// <param name="StateId"></param>
        /// <returns></returns>
        public Task<PositionMaster?> GetPositionByID(int StateId);

        /// <summary>
        /// Delete a workstation by its ID. This marks the workstation as inactive instead of removing it from the database.
        /// </summary>
        /// <param name="wid"></param>
        /// <returns></returns>
        public Task DeletePositionAsync(int wid);

        public Task<IEnumerable<getpositionDetailsById>> GetpositionDetailsByMasterId(int PositionMasterId);

    }
}
