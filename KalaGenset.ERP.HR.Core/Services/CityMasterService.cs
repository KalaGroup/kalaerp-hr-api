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
        public async Task<IEnumerable<CityMaster>> GetAllCompanyDetailsAsync()
        {
            return await _dbContext.CityMasters.ToListAsync();
        }

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
