using KalaGenset.ERP.HR.Core.Request.StateRequest;
using KalaGenset.ERP.HR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface IStateMaster
    {
        /// <summary>
        /// Insert State Request
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task AddStateAsync(InsertStateRequest request);

        /// <summary>
        /// Get State Details
        /// </summary>
        /// <returns></returns>
       public Task<IEnumerable<StateMaster>> GetStateDetailsAsync();

        /// <summary>
        /// Update State Request
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task UpdateStateAsync(UpdateStateRequest request);

        /// <summary>
        /// Get State By ID
        /// </summary>
        /// <param name="StateId"></param>
        /// <returns></returns>
        public Task<StateMaster?> GetStateByID(int StateId);


        /// <summary>
        /// Delete State
        /// </summary>
        /// <param name="sid"></param>
        /// <returns></returns>
        public Task DeleteStateAsync(int sid);
    }
}
