using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.City;
using KalaGenset.ERP.HR.Data.DbContexts;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace KalaGenset.ERP.HR.Core.Services
{
    public class CityMasterService : ICityMaster
    {
        private readonly KalaDbContext _dbContext;
        public CityMasterService(KalaDbContext context)
        {
            _dbContext = context;
        }

        /// <summary>
        /// Asynchronously adds a new city to the database.
        /// </summary>
        /// <remarks>This method creates a new city record in the database using the information provided
        /// in the <paramref name="request"/> parameter. The operation is performed asynchronously, and the changes are
        /// saved to the database upon successful execution.</remarks>
        /// <param name="request">An <see cref="InsertCityRequest"/> object containing the details of the city to be added, including its
        /// country, state, district, code, name, coordinates, tier type, and other metadata.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
        public async Task AddCityAsync(InsertCityRequest request)
        {
            try
            {

                //  CityID CityCountryID   CityStateID CityDistrictID  CityCode CityName    CityShortName CityLatitude    

                //   CityLongitude CityTierTypeID  CityRemark CityAuth    CityIsDiscard CityIsActive    CreatedBy CreatedDate

                var City = new CityMaster
                {
                    CityCountryId = request.CityCountryId,
                    CityStateId = request.CityStateId,
                    CityDistrictId = request.CityDistrictId,
                    CityCode = request.CityCode,
                    CityName = request.CityName,
                    CityShortName = request.CityShortName,
                    CityLatitude = request.CityLatitude,
                    CityLongitude = request.CityLongitude,
                    CityTierTypeId = request.CityTierTypeId,
                    CityRemark = request.CityRemark,
                    CreatedBy = request.CreatedBy,
                    CreatedDate = request.CreatedDate


                };

                _dbContext.CityMasters.Add(City);
                await _dbContext.SaveChangesAsync();

               
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Updates the details of an existing city in the database.
        /// </summary>
        /// <remarks>The method retrieves the city record corresponding to the <see
        /// cref="UpdateCityRequest.CityId"/> from the database, updates its properties with the values provided in the
        /// request, and saves the changes. Ensure that the <paramref name="request"/> parameter contains valid data, as
        /// no validation is performed within this method.</remarks>
        /// <param name="request">An <see cref="UpdateCityRequest"/> object containing the updated city details, including the city ID and
        /// other properties such as name, code, location, and metadata.</param>
        /// <returns>A task that represents the asynchronous operation. The task completes when the city details have been
        /// successfully updated in the database.</returns>
        public async Task UpdateCityAsync(UpdateCityRequest request)
        {
            try
            {
                var city = await _dbContext.CityMasters.FindAsync(request.CityId);
               
                city.CityCountryId = request.CityCountryId;
                city.CityStateId = request.CityStateId;
                city.CityDistrictId = request.CityDistrictId;
                city.CityCode = request.CityCode;
                city.CityName = request.CityName;
                city.CityShortName = request.CityShortName;
                city.CityLatitude = request.CityLatitude;
                city.CityLongitude = request.CityLongitude;
                city.CityTierTypeId = request.CityTierTypeId;
                city.CityRemark = request.CityRemark;
                city.CreatedBy = request.CreatedBy;
                city.CreatedDate = request.CreatedDate;
                _dbContext.Entry(city).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Asynchronously retrieves all company details from the database.
        /// </summary>
        /// <remarks>This method queries the database for all records in the CityMaster table and returns
        /// them as a collection.</remarks>
        /// <returns>A task that represents the asynchronous operation. The task result contains an  IEnumerable{T} of CityMaster
        /// objects representing the company details.</returns>
        public async Task<IEnumerable<CityMaster>> GetAllCompanyDetailsAsync()
        {
            return await _dbContext.CityMasters.ToListAsync();
        }

        /// <summary>
        /// Retrieves a city record by its unique identifier.
        /// </summary>
        /// <param name="CityId">The unique identifier of the city to retrieve. Must be a valid, non-negative integer.</param>
        /// <returns>A <see cref="CityMaster"/> object representing the city with the specified identifier,  or <see
        /// langword="null"/> if no matching city is found.</returns>
        public async Task<CityMaster?> GetCityByID(int CityId)
        {
            try
            {
                return await _dbContext.CityMasters.FirstOrDefaultAsync(c => c.CityId == CityId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Marks a company as inactive based on the specified city identifier.
        /// </summary>
        /// <remarks>This method updates the company's status to inactive by setting the
        /// <c>CityIsActive</c> property to <see langword="false"/>. The changes are persisted to the database
        /// asynchronously.</remarks>
        /// <param name="CityId">The unique identifier of the city associated with the company to be marked as inactive.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task DeleteCompanyAsync(int CityId)
        {
            try
            {
                var company = await _dbContext.CityMasters.FirstOrDefaultAsync(c => c.CityId == CityId);

                company.CityIsActive = false;
                //company.ci = DateTime.Now;
                _dbContext.CityMasters.Update(company);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
