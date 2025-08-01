using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.District;
using KalaGenset.ERP.HR.Data.DbContexts;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KalaGenset.ERP.HR.Core.Services
{
    public class DistrictMasterService:IDistrictMaster
    {
        private readonly KalaDbContext _context;

        public DistrictMasterService(KalaDbContext context  )
        {
            _context = context;
        }


        /// <summary>
        /// AddDistrictMasterAsync
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task AddDistrictMasterAsync(InsertDistrictRequest request)
        {
            try
            {
                var district = new DistrictMaster
                {
                    CountryId = request.CountryId,
                    StateId = request.StateId,
                    DistrictCode = request.DistrictCode,
                    DistrictName = request.DistrictName,
                    ShortName = request.ShortName,
                    CreatedBy = request.CreatedBy,                  
                    IsDiscard = request.IsDiscard,
                    IsActive = request.IsActive,
                    CreatedDate = request.CreatedDate,
                };

                _context.DistrictMasters.Add(district);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw; 
            }
        }
        /// <summary>
        /// GetDistrictMasterDetailsAsync
        /// </summary>
        /// <returns></returns>

        public async Task<IEnumerable<DistrictMaster>> GetDistrictMasterDetailsAsync()
        {          
           return await _context.DistrictMasters.Where(c => c.IsActive == true && c.IsDiscard == true).ToListAsync();       
        }

        /// <summary>
        /// GetDistrictMasterById
        /// </summary>
        /// <param name="DistrictId"></param>
        /// <returns></returns>
        public async Task<DistrictMaster?> GetDistrictMasterById(int DistrictId)
        {
            return await _context.DistrictMasters.FirstOrDefaultAsync(c => c.DistrictId == DistrictId);
        }
        /// <summary>
        /// UpdateDistrictMasterAsync
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>

        public async Task UpdateDistrictMasterAsync(UpdateDistrictRequest request)
        {
            try
            {
                var district = await _context.DistrictMasters.FirstOrDefaultAsync(c => c.DistrictId == request.DistrictId);
                if (district == null)
                {
                    throw new Exception("District not found.");
                }
                // Update fields
                district.CountryId = request.CountryId;
                district.StateId = request.StateId;
                district.DistrictCode = request.DistrictCode;
                district.DistrictName = request.DistrictName;
                district.ShortName = request.ShortName;
                district.CreatedBy = request.CreatedBy;
                district.IsDiscard = request.IsDiscard;
                district.IsActive = request.IsActive;
                district.CreatedDate = request.CreatedDate;
                _context.DistrictMasters.Update(district);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw; 
            }
        }
        /// <summary>
        /// DeleteDistrictMasterAsync
        /// </summary>
        /// <param name="DistrictId"></param>
        /// <returns></returns>
        public async Task DeleteDistrictMasterAsync(int DistrictId)
        {
            try
            {
                var district = await _context.DistrictMasters.FirstOrDefaultAsync(c => c.DistrictId == DistrictId);

                if (district == null)
                {
                    throw new Exception("District not found.");
                }
                district.IsActive = false;
                district.IsDiscard = false;
                _context.DistrictMasters.Update(district);
                await _context.SaveChangesAsync();
      
            }
            catch
            {
                throw; // Let the controller handle the error
            }
        }
    }
}
