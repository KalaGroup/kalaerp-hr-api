using KalaGenset.ERP.HR.Core.Request.ResposibilitiesMaster;
using KalaGenset.ERP.HR.Core.ResponseDTO.ResponsibilitiesMaster;
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
        public Task<IEnumerable<ResponsibilitiesMaster>> GetResposibilitiesAsync();
        /// <summary>
        /// get responsibility by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<ResponsibilitiesMaster> GetResposibilitiesByIdAsync(int id);
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

        //Get Responsibilities Details
        public Task<List<ResponsibilitiesResponseDTO>> GetResponsibilitiesDetails();

        public Task<IEnumerable<GetResponsibilityDetailsById>> GetResponsibilityDetailsByMsaterId(int masterId);
    }
}
