using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KalaGenset.ERP.HR.Core.Request.QualificationRequest;
using KalaGenset.ERP.HR.Core.Request.ShiftMaster;
using KalaGenset.ERP.HR.Core.ResponseDTO.ShiftMaster;
using KalaGenset.ERP.HR.Data.Models;

namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface IShiftMaster
    {
        /// <summary>
        /// Insert Shift Master
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task AddShiftAsync(InsertShiftMasterRequest request);
        /// <summary>
        /// Get Shift By ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Task<ShiftMaster?> GetShiftByID(int Id);
        /// <summary>
        /// Get All Shift Details
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<ShiftMasterResponseDTO>> GetShiftDetailsAsync();
        /// <summary>
        /// Update Shift Master
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task UpdateShiftAsync(UpdateShiftMasterRequest request);
        /// <summary>
        /// Delete Shift Master
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task DeleteshiftAsync(int id);
    }
}
