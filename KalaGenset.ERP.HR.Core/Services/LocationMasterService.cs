using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.LocationRequest;
using KalaGenset.ERP.HR.Data.DbContexts;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Services
{
    public class LocationMasterService : ILocationMaster
    {
        private readonly KalaDbContext _context;

        public LocationMasterService(KalaDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// add location
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task AddLocationAsync(InsertLocationRequest request)
        {
            try
            {
                var location = new LocationMaster
                {
                    LocationCode = request.LocationCode,
                    LocationName = request.LocationName,
                    ProfitcenterLocationId = request.ProfitcenterLocationId,
                    LocationRemark = request.LocationRemark,
                    LocationType = request.LocationType,
                    LocationAuthRemark = request.LocationAuthRemark,
                    LocationAuth = request.LocationAuth,
                    LocationIsDiscard = request.LocationIsDiscard,
                    LocationIsActive = request.LocationIsActive,
                    CreatedBy = request.CreatedBy,
                    CreatedDate = request.CreatedDate,
                };

                _context.LocationMasters.Add(location);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        /// <summary>
        /// delete location
        /// </summary>
        /// <param name="lid"></param>
        /// <returns></returns>
        public async Task DeleteLocationAsync(int lid)
        {
            try
            {
                var location = await _context.LocationMasters.FirstOrDefaultAsync(c => c.LocationId == lid);

                location.LocationIsActive = false;

                _context.LocationMasters.Update(location);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// get location by id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<LocationMaster?> GetLocationByID(int Id)
        {
            return await _context.LocationMasters.FirstOrDefaultAsync(c => c.LocationId == Id);

        }

        /// <summary>
        /// get location
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<LocationMaster>> GetLocationDetailsAsync()
        {
            return await _context.LocationMasters.ToListAsync();
        }

        /// <summary>
        /// update location
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task UpdateLocationAsync (UpdateLocationRequest request)
        {
            try
            {
                var location = await _context.LocationMasters.FindAsync(request.LocationId);

                // Update fields
                location.LocationCode = request.LocationCode;
                location.LocationName = request.LocationName;
                location.ProfitcenterLocationId = request.ProfitcenterLocationId;
                location.LocationRemark = request.LocationRemark;
                location.LocationType = request.LocationType;
                location.LocationAuthRemark = request.LocationAuthRemark;
                location.LocationAuth = request.LocationAuth;
                location.LocationIsDiscard = request.LocationIsDiscard;
                location.LocationIsActive = request.LocationIsActive;
                location.CreatedBy = request.CreatedBy;
                location.CreatedDate = request.CreatedDate;
                _context.LocationMasters.Update(location);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
