using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KalaGenset.ERP.HR.Core.Request.Country;
//using KalaGenset.ERP.HR.Core.ResponseDTO;
using KalaGenset.ERP.HR.Data.Models;

namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface ICountryMaster
    {
        /// <summary>
        /// Adds a new country to the database.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task AddCountryAsync(InsertCountryRequest request);
        /// <summary>
        /// Updates an existing country in the database.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task UpdateCountryAsync(UpdateCountryRequest request);
        /// <summary>
        /// Retrieves all countries from the database.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<CountryMaster>> GetCountryDetailsAsync();
        /// <summary>
        /// Retrieves a country by its ID from the database.
        /// </summary>
        /// <param name="CountryId"></param>
        /// <returns></returns>
        public Task<CountryMaster?> GetCountryById(int CountryId);
        /// <summary>
        /// Deletes a country by its ID from the database.
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public Task DeleteCountryAsync(int cid);
    }
}
