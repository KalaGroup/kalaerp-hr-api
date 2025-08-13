using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request;
using KalaGenset.ERP.HR.Core.Request.HolidayMaster;
using KalaGenset.ERP.HR.Data.DbContexts;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace KalaGenset.ERP.HR.Core.Services
{
    public class HolidayMasterService : IHolidayMaster
    {
        private readonly KalaDbContext _context;
        public HolidayMasterService(KalaDbContext context)
        {
            _context = context ;
        }
        /// <summary>
        /// Insert Holiday Master
        /// </summary>
        /// <param name="insertHolidayMasterRequest"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task HolidayMasterAsync(InsertHolidayMasterRequest insertHolidayMasterRequest)
        {
            try
            {
                var holidayMaster = new HolidayMaster
                {
                    HolidayFy = insertHolidayMasterRequest.HolidayFy,
                    HolidayDate = insertHolidayMasterRequest.HolidayDate,
                    HolidayFor = insertHolidayMasterRequest.HolidayFor,
                    HolidayCompanyId = insertHolidayMasterRequest.HolidayCompanyId,
                    HolidayRemark = insertHolidayMasterRequest.HolidayRemark,
                    HolidayAuthRemark = insertHolidayMasterRequest.HolidayAuthRemark,
                    HolidayAuth = insertHolidayMasterRequest.HolidayAuth,
                    HolidayIsDiscard = insertHolidayMasterRequest.HolidayIsDiscard,
                    HolidayIsActive = insertHolidayMasterRequest.HolidayIsActive,
                    CreatedBy = insertHolidayMasterRequest.CreatedBy,
                    CreatedDate = DateTime.Now
                };
                await _context.HolidayMasters.AddAsync(holidayMaster);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Handle exception (log it, rethrow it, etc.)
                throw new Exception("An error occurred while inserting holiday master.", ex);
            }
        }
        /// <summary>
        /// Get All Holiday Masters
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<HolidayMaster>> GetAllHolidayMasters()
        {
            return await _context.HolidayMasters.ToListAsync();
        }
        /// <summary>
        /// Get Holiday Master By Id
        /// </summary>
        /// <param name="holidayId"></param>
        /// <returns></returns>
        public async Task<HolidayMaster?> GetHolidayMasterById(int holidayId)
        {
            return await _context.HolidayMasters
                .FirstOrDefaultAsync(h => h.HolidayId == holidayId);
        }
        /// <summary>
        /// Update Holiday Master
        /// </summary>
        /// <param name="updateHolidayMasterRequest"></param>
        /// <returns></returns>
        public async Task UpdateHolidayMasterAsync(UpdateHolidayMasterRequest updateHolidayMasterRequest)
        {
            try
            {
                var holidayMaster = await _context.HolidayMasters.FirstOrDefaultAsync(c => c.HolidayId == updateHolidayMasterRequest.HolidayId);

                holidayMaster.HolidayId = updateHolidayMasterRequest.HolidayId;
                holidayMaster.HolidayFy = updateHolidayMasterRequest.HolidayFy;
                holidayMaster.HolidayDate = updateHolidayMasterRequest.HolidayDate;
                holidayMaster.HolidayFor = updateHolidayMasterRequest.HolidayFor;
                holidayMaster.HolidayCompanyId = updateHolidayMasterRequest.HolidayCompanyId;
                holidayMaster.HolidayRemark = updateHolidayMasterRequest.HolidayRemark;
                holidayMaster.HolidayAuthRemark = updateHolidayMasterRequest.HolidayAuthRemark;
                holidayMaster.HolidayAuth = updateHolidayMasterRequest.HolidayAuth;
                holidayMaster.HolidayIsDiscard = updateHolidayMasterRequest.HolidayIsDiscard;
                holidayMaster.HolidayIsActive = updateHolidayMasterRequest.HolidayIsActive;
                holidayMaster.CreatedBy = updateHolidayMasterRequest.CreatedBy;
                holidayMaster.CreatedDate = updateHolidayMasterRequest.CreatedDate;

                _context.HolidayMasters.Update(holidayMaster);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }  
        }
        /// <summary>
        /// Delete Holiday By Id (Soft Delete)
        /// </summary>
        /// <param name="HolidayId"></param>
        /// <returns></returns>
        public async Task DeleteHolidayById(int HolidayId)
        {
            try
            {
                var holiday = await _context.HolidayMasters.FirstOrDefaultAsync(c => c.HolidayId == HolidayId);
                if (holiday == null)
                {
                    throw new Exception("Holiday Type not found");
                }
                if (!holiday.HolidayIsActive)
                {
                    throw new Exception("Holiday type is alredy Soft Deleted");
                }
                holiday.HolidayIsActive = false;
                _context.HolidayMasters.Update(holiday);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
    }   }
}
