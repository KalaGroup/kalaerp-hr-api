using KalaGenset.ERP.HR.Core.Request.KPAMaster;
using KalaGenset.ERP.HR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface IKPAMaster
    {
        /// <summary>
        /// Adds a new KPA master to the system based on the provided request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task InsertKPAMasterAsync(InsertKPAMasterRequest request);
        /// <summary>
        /// updates an existing KPA master in the system based on the provided request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task UpdateKPAMasterAsync(UpdateKPAMasterRequest request);
        /// <summary>
        /// deletes a KPA master from the system based on its unique identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task DeleteKPAMasterAsync(int id);
        /// <summary>
        /// gets all KPA masters from the system.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Kpamaster>> GetAllKPAMasterAsync();
        /// <summary>
        /// gets a KPA master by its unique identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Kpamaster> GetKPAMasterByID(int id);


    }
}
