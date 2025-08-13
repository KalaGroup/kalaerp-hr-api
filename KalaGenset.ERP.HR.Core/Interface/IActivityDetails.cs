using KalaGenset.ERP.HR.Core.Request.ActivityDetails;
using KalaGenset.ERP.HR.Core.Request.ActivityMaster;
using KalaGenset.ERP.HR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface IActivityDetails
    {
        /// <summary>
        /// Add Activity Detail Async
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task AddActivityDetailAsync(InsertActivityDetailsRequest request);
        /// <summary>
        /// update Activity DetailA sync
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task updateActivityDetailAsync(UpdateActivityDetailsRequest request);
        /// <summary>
        /// delete 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task DeleteActivityDetailAsync(int id);
        /// <summary>
        /// Get All Activity Detail Async
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<ActivityDetail>> GetAllActivityDetailAsync();
        /// <summary>
        /// Get Activity Detail By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<ActivityDetail> GetActivityDetailByID(int id);
    }
}
