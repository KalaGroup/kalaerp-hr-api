using KalaERP.HR.Core.Request.CompanyMaster;
using KalaERP.HR.Core.Request.DesignationMaster;

using KalaGenset.ERP.HR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaERP.HR.Core.Interface
{
    public interface IDesignationMaster
    {
        /// <summary>
        /// Add designation to the system.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task AddDesignationAsync(InsertDesignationMasterRequest request);
        /// <summary>
        /// gets all designations from the system.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<DesignationMaster>> GetDesignationAsync();
        /// <summary>
        /// get designation by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<DesignationMaster> GetDesigationByIdAsync(int id);
        /// <summary>
        /// update an existing designation in the system.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task UpdateDesignationAsync(UpdateDesignationMasterRequest request);
        /// <summary>
        /// deletes a designation by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task DeleteDesignationAsync(int id);
    }
}
