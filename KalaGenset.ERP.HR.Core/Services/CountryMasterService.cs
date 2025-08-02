using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.Country;
//using KalaGenset.ERP.HR.Core.ResponseDTO;
using KalaGenset.ERP.HR.Data.DbContexts;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.EntityFrameworkCore;
namespace KalaGenset.ERP.HR.Core.Services
{
    public class CountryMasterService : ICountryMaster
    {
        private readonly KalaDbContext _context;
        public CountryMasterService(KalaDbContext context)
        {
            _context = context;
        }
        // Insert Code
        /// <summary>
        /// Adds a new country to the database.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task AddCountryAsync(InsertCountryRequest request)
        {
            try
            {
                var country = new CountryMaster
                {
                    CountryCode = request.CountryCode,
                    CountryName = request.CountryName,
                    CountryShortName = request.CountryShortName,
                    CountryCurrencyId = request.CountryCurrencyId,
                    IsActive = request.IsActive,
                    CreatedBy = request.CreatedBy,
                    CreatedDate = request.CreatedDate
                };
                _context.CountryMasters.Add(country);
                await _context.SaveChangesAsync();
            }
            catch 
            {
                throw; 
            }
        }
        // Update Code
        /// <summary>
        /// Updates an existing country in the database.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task UpdateCountryAsync(UpdateCountryRequest request)
        {
            try
            {
                var country = await _context.CountryMasters.FirstOrDefaultAsync(c => c.CountryId == request.CountryId);
                if (country == null)
                { 
                       throw new Exception("Country not found.");
                }
                // Update fields
                country.CountryCode = request.CountryCode;
                country.CountryName = request.CountryName;
                country.CountryShortName = request.CountryShortName;
                country.CountryCurrencyId = request.CountryCurrencyId;
                country.IsActive = request.IsActive;
                country.CreatedBy = request.CreatedBy;
                country.CreatedDate = request.CreatedDate;

                _context.CountryMasters.Update(country);
                await _context.SaveChangesAsync();
            }
            catch 
            {
                throw; 
            }
        }

        //Get Code
        /// <summary>
        /// Retrieves all active countries from the database.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CountryMaster>> GetCountryDetailsAsync()
        {
            return await _context.CountryMasters.OrderBy(c => c.CountryId).ToListAsync();
        }

        // Get By ID Code
        /// <summary>
        /// Retrieves a country by its ID from the database.
        /// </summary>
        /// <param name="CountryId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<CountryMaster?> GetCountryById(int CountryId)
        {
            if (await _context.CountryMasters.FirstOrDefaultAsync(c => c.CountryId == CountryId) == null)
            {
                throw new Exception("ID Not available");
            }
            return await _context.CountryMasters.FirstOrDefaultAsync(c => c.CountryId == CountryId);
        }
        // Soft-Delete Code
        /// <summary>
        /// Soft-deletes a country by setting its IsActive property to false.
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public async Task DeleteCountryAsync(int cid)
        {
            try
            {
                var country = await _context.CountryMasters.FirstOrDefaultAsync(c => c.CountryId == cid);
                if (country == null)
                {
                    throw new Exception("Country not found.");
                }
                if (!country.IsActive)
                {
                    throw new Exception("Country is already soft-deleted");
                }
                country.IsActive = false;
                _context.CountryMasters.Update(country);
                await _context.SaveChangesAsync();
            }
            catch 
            {
                throw; 
            }
        }
    }
}
