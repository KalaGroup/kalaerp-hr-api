using KalaGenset.ERP.HR.Core.Request.ActivityMaster;
using KalaGenset.ERP.HR.Core.Request.AuthoritieMaster;
using KalaGenset.ERP.HR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface IActivityMaster
    {
        /// <summary>
        /// Add Activity Async
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task AddActivityAsync(InsertActivityMasterRequest request);
        /// <summary>
        /// update Activity Async
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task updateActivityAsync(UpdateActivityMasterRequest request);
        /// <summary>
        /// Delete Activity Async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task DeleteActivityAsync(int id);
        /// <summary>
        /// Get by id Activity Async
        /// </summary>
        /// <returns></returns>
        public Task<ActivityMaster> GetActivityByID(int id);
        /// <summary>
        /// Get All Activity Master Async
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<ActivityMaster>> GetAllActivityMasterAsync();
    }
}
