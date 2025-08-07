using KalaGenset.ERP.HR.Core.Request.ResposibilitiesDetail;
using KalaGenset.ERP.HR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface IResposibilitiesDetail
    {
        /// <summary>
        /// adds a new responsibility detail to the system.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task AddResposibilitiesDetailAsync(InsertResposibilitiesDetailrequest request);
        /// <summary>
        /// gets all responsibility details from the system.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<ResposibilitiesDetail>> GetResposibilitiesDetailAsync();
        /// <summary>
        /// grets a responsibility detail by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<ResposibilitiesDetail> GetResposibilitiesDetailByIdAsync(int id);
        /// <summary>
        /// updates an existing responsibility detail in the system.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task UpdateResposibilitiesDetailAsync(UpdateResposibilitiesDetailRequest request);
        /// <summary>
        /// deletes a responsibility detail by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task DeleteResposibilitiesDetailAsync(int id); 

    }
}
