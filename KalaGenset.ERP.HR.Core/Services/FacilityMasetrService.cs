using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.Facility;
using KalaGenset.ERP.HR.Data.DbContexts;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace KalaGenset.ERP.HR.Core.Services
{
    public class FacilityMasetrService : IFacilityMaster
    {
        private readonly KalaDbContext _context;

        public FacilityMasetrService(KalaDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// To Add or Insert New Facility in Facility Master
        /// </summary>
        /// <param name="insertfacilityrequest"></param>
        /// <returns></returns>
        public async Task AddFacilityAsync(InsertFacilityRequest insertfacilityrequest)
        {
            try
            {
                var facility = new FacilityMaster
                {
                    FaciltyCode = insertfacilityrequest.FaciltyCode,
                    FacilityName = insertfacilityrequest.FacilityName,
                    FacilityRemark = insertfacilityrequest.FacilityRemark,
                    FacilityAuth = insertfacilityrequest.FacilityAuth,
                    FacilityIsDiscard = insertfacilityrequest.FacilityIsDiscard,
                    FacilityIsActive = insertfacilityrequest.FacilityIsActive,
                    CreatedBy = insertfacilityrequest.CreatedBy,
                    CreatedDate = insertfacilityrequest.CreatedDate
                };

                _context.FacilityMasters.Add(facility);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        ///  To Update Facility Against Facility Id
        /// </summary>
        /// <param name="updatefacilityrequest"></param>
        /// <returns></returns>
        public async Task UpdateFacilityAsync(UpdateFacilityRequest updatefacilityrequest)
        {
            try
            {
                var facility = await _context.FacilityMasters.FindAsync(updatefacilityrequest.FacilityId);
                if (facility == null)
                {
                    throw new Exception("Facility not found.");
                }
                facility.FacilityId = updatefacilityrequest.FacilityId;
                facility.FaciltyCode = updatefacilityrequest.FaciltyCode;
                facility.FacilityName = updatefacilityrequest.FacilityName;
                facility.FacilityRemark = updatefacilityrequest.FacilityRemark;
                facility.FacilityIsActive = updatefacilityrequest.FacilityIsActive;
                facility.FacilityIsDiscard = updatefacilityrequest.FacilityIsDiscard;

                await _context.SaveChangesAsync();
            }
            catch
            {
                throw; // Let the controller handle the error
            }
        }

        /// <summary>
        ///To Get All Facility from Facility Master
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<FacilityMaster>> GetFacilityAsync()
        {
            return await _context.FacilityMasters.ToListAsync();
        }

        /// <summary>
        /// To get Facility by Facility Id
        /// </summary>
        /// <param name="facilityId"></param>
        /// <returns></returns>
        public async Task<FacilityMaster?> GetFacilityByIdAsync(int facilityId)
        {
            if (await _context.FacilityMasters.FirstOrDefaultAsync(c => c.FacilityId == facilityId) == null)
            {
                throw new Exception("Grade Facility Assignment Id Not available");
            }
            return await _context.FacilityMasters.FirstOrDefaultAsync(f => f.FacilityId == facilityId);

        }

        /// <summary>
        /// To Delete Facility by Facility Id
        /// </summary>
        /// <param name="facilityId"></param>
        /// <returns></returns>
        public async Task DeleteFacilityAsync(int facilityId)
        {
            try
            {
                if (await _context.FacilityMasters.FirstOrDefaultAsync(c => c.FacilityId == facilityId) == null)
                {
                    throw new Exception("Grade Facility Assignment Id Not available");
                }

                var facility = await _context.FacilityMasters.FirstOrDefaultAsync(f => f.FacilityId == facilityId);
                facility.FacilityIsActive = false;
                _context.FacilityMasters.Update(facility);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
