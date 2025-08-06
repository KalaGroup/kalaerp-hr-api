using KalaGenset.ERP.HR.Core.Request.City;
using KalaGenset.ERP.HR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface ICityMaster
    {
        /// <summary>
        /// Asynchronously adds a new city to the system based on the provided request.
        /// </summary>
        /// <param name="request">The request containing the details of the city to be added. This must include all required fields such as
        /// the city name and any other necessary information.</param>
        /// <returns>A task that represents the asynchronous operation. The task completes when the city has been successfully
        /// added to the system.</returns>
        public Task AddCityAsync(InsertCityRequest request);

        /// <summary>
        /// Updates the details of an existing city asynchronously.
        /// </summary>
        /// <remarks>Use this method to modify the details of a city, such as its name, population, or
        /// other attributes.  Ensure that the <paramref name="request"/> object contains valid data, including the
        /// unique identifier of the city to be updated.</remarks>
        /// <param name="request">The request object containing the updated city details. This must include the city's identifier and the new
        /// values for the properties to be updated.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public Task UpdateCityAsync(UpdateCityRequest request);

        /// <summary>
        /// Retrieves a collection of all company details asynchronously.
        /// </summary>
        /// <remarks>This method returns a collection of <see cref="CityMaster"/> objects representing the
        /// details of all companies. The returned collection may be empty if no company details are
        /// available.</remarks>
        /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="IEnumerable{T}"/>
        /// of <see cref="CityMaster"/> objects.</returns>
        public Task<IEnumerable<CityMaster>> GetAllCompanyDetailsAsync();

        /// <summary>
        /// Retrieves the details of a city based on its unique identifier.
        /// </summary>
        /// <param name="CityId">The unique identifier of the city to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="CityMaster"/>
        /// object  representing the city details if found; otherwise, <see langword="null"/>.</returns>
        public Task<CityMaster?> GetCityByID(int CityId);

        /// <summary>
        /// Deletes the company associated with the specified city identifier.
        /// </summary>
        /// <remarks>This method performs an asynchronous operation to delete the company associated with
        /// the given city identifier. Ensure that the specified <paramref name="CityId"/> corresponds to an existing
        /// city with an associated company.</remarks>
        /// <param name="CityId">The unique identifier of the city whose associated company is to be deleted. Must be a valid, non-negative
        /// integer.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public Task DeleteCompanyAsync(int CityId);

    }
}
