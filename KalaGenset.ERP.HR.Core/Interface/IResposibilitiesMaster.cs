using KalaGenset.ERP.HR.Core.Request.ResposibilitiesMaster;
using KalaGenset.ERP.HR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface IResposibilitiesMaster
    {
        /// <summary>
        /// add a new responsibility to the system.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task AddResposibilitiesAsync(InsertResposibilitiesMasterRequest request);
        /// <summary>
        /// gets all responsibilities from the system.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<ResposibilitiesMaster>> GetResposibilitiesAsync();
        /// <summary>
        /// get responsibility by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<ResposibilitiesMaster> GetResposibilitiesByIdAsync(int id);
        /// <summary>
        /// update an existing responsibility in the system.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task UpdateResposibilitiesAsync(UpdateResposibilitiesMasterRequest request);
        /// <summary>
        /// deletes a responsibility by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task DeleteResposibilitiesAsync(int id);
    }
}
