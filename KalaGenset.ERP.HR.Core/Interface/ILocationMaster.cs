using KalaGenset.ERP.HR.Core.Request.LocationRequest;
using KalaGenset.ERP.HR.Core.Request.QualificationRequest;
using KalaGenset.ERP.HR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface ILocationMaster
    {
        /// <summary>
        /// insert location
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task AddLocationAsync(InsertLocationRequest request);

        /// <summary>
        /// update location
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task UpdateLocationAsync(UpdateLocationRequest request);
        /// <summary>
        /// get location
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<LocationMaster>> GetLocationDetailsAsync();
        /// <summary>
        /// get location
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Task<LocationMaster?> GetLocationByID(int Id);
        /// <summary>
        /// get location by id
        /// </summary>
        /// <param name="lid"></param>
        /// <returns></returns>
        public Task DeleteLocationAsync(int lid);
    }
}
