using KalaGenset.ERP.HR.Core.Request.AuthoritiesDetail;
using KalaGenset.ERP.HR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface IAuthoritiesDetail
    {
        /// <summary>
        /// adds a new authorities detail to the system based on the provided request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task AddAuthoritiesDetailAsync(InsertAuthoritiesDetailRequest request);
        /// <summary>
        /// updates an existing authorities detail in the system based on the provided request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task UpdateAuthoritiesDetailAsync(UpdateAuthoritiesaDetailsRequest request);
        /// <summary>
        /// gets all authorities details from the system.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<AuthoritiesDetail>> GetAllAuthoritiesDetailsAsync();
        /// <summary>
        /// gets authorities detail by ID from the system.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<AuthoritiesDetail> GetAuthoritiesDetailByID(int id);
        /// <summary>
        /// deletes an authorities detail from the system based on its unique identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task DeleteAuthoritiesDetailAsync(int id);

    }
}
