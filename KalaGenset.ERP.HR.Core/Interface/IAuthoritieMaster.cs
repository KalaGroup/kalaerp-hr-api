using KalaGenset.ERP.HR.Core.Request.AuthoritieMaster;
using KalaGenset.ERP.HR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Interface
{
    /// <summary>
    /// interface for managing authorities in the system.
    /// </summary>
    public interface IAuthoritieMaster
    {
        /// <summary>
        /// Adds a new authoritie to the system based on the provided request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task AddAuthoritieAsync(InsertAuthoritieMasterRequest request);
        /// <summary>
        /// updates an existing authoritie in the system based on the provided request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task UpdateAuthoritieAsync(UpdateAuthoritieMasterRequest request);
        /// <summary>
        /// gets all authoritie details from the system.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<AuthoritiesMaster>> GetAllAuthoritieDetailsAsync();
        /// <summary>
        /// gets an authoritie by its unique identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<AuthoritiesMaster> GetAuthoritieByID(int id);
        /// <summary>
        /// deletes an authoritie from the system based on its unique identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task DeleteAuthoritieAsync(int id);
    }
}
