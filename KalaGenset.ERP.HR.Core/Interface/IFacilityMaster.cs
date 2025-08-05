using KalaGenset.ERP.HR.Core.Request.Facility;
using KalaGenset.ERP.HR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface IFacilityMaster
    {
        /// <summary>
        /// Insert Facility in Facility Master
        /// </summary>
        /// <param name="insertfacilityrequest"></param>
        /// <returns></returns>
        public Task AddFacilityAsync(InsertFacilityRequest insertfacilityrequest);

        /// <summary>
        /// Update facility
        /// </summary>
        /// <param name="updatefacilityrequest"></param>
        /// <returns></returns>
        public Task UpdateFacilityAsync(UpdateFacilityRequest updatefacilityrequest);

        /// <summary>
        /// Get All Facility
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<FacilityMaster>> GetFacilityAsync();

        /// <summary>
        /// Get Facility By Facility Id
        /// </summary>
        /// <param name="facilityId"></param>
        /// <returns></returns>
        public Task<FacilityMaster?> GetFacilityByIdAsync(int facilityId);

        /// <summary>
        /// Delete Facility by FacilityId
        /// </summary>
        /// <param name="facilityId"></param>
        /// <returns></returns>
        public Task DeleteFacilityAsync(int facilityId);


    }
}
