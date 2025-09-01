using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KalaGenset.ERP.HR.Core.Request.HolidayMaster;
using KalaGenset.ERP.HR.Core.ResponseDTO.HolidayMaster;
using KalaGenset.ERP.HR.Data.Models;

namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface IHolidayMaster
    {
        /// <summary>
        /// Insert Holiday Master
        /// </summary>
        /// <param name="insertHolidayMasterRequest"></param>
        /// <returns></returns>
        public Task HolidayMasterAsync(InsertHolidayMasterRequest insertHolidayMasterRequest);
        /// <summary>
        /// Get All Holiday Masters
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<HolidayMasterResponseDTO>> GetHolidayDetailsAsync();
        /// <summary>
        /// Get Holiday Master By Id
        /// </summary>
        /// <param name="holidayId"></param>
        /// <returns></returns>
        public Task<HolidayMaster?> GetHolidayMasterById(int holidayId);
        /// <summary>
        /// Update Holiday Master
        /// </summary>
        /// <param name="updateHolidayMasterRequest"></param>
        /// <returns></returns>
        public Task UpdateHolidayMasterAsync(UpdateHolidayMasterRequest updateHolidayMasterRequest);
        /// <summary>
        /// Delete Holiday Master by Id
        /// </summary>
        /// <param name="HolidayId"></param>
        /// <returns></returns>
        public Task DeleteHolidayById(int HolidayId);

    }

}
