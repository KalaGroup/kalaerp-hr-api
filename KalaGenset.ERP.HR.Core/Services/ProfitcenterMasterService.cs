using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.Facility;
using KalaGenset.ERP.HR.Core.Request.ProfitcenterMaster;
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
    public class ProfitcenterMasterService:IProfitcenterMaster
    {
        private readonly KalaDbContext _context;

        public ProfitcenterMasterService(KalaDbContext dbContext)
        {
          _context= dbContext;
        }

        public Task AddProfitCenter(InsertProfitcenterRequest profitCenterMaster)
        {
            throw new NotImplementedException();
        }

        public async Task AddProfitCenterAsync(InsertProfitcenterRequest insertprofitCenter)
        {
            var profitCenter = new ProfitcenterMaster
            {
                ProfitCenterCode = insertprofitCenter.ProfitCenterCode,
                ProfitCenterName = insertprofitCenter.ProfitCenterName,
                ProfitCenterCompanyId = insertprofitCenter.ProfitCenterCompanyId,
                ParentProfitCenterId = insertprofitCenter.ParentProfitCenterId,
                ProfitCenterRemark = insertprofitCenter.ProfitCenterRemark,
                ProfitCenterAuthRemark = insertprofitCenter.ProfitCenterAuthRemark,
                ProfitCenterAuth = insertprofitCenter.ProfitCenterAuth,
                ProfitCenterIsDiscard = insertprofitCenter.ProfitCenterIsDiscard,
                ProfitCenterIsActive = insertprofitCenter.ProfitCenterIsActive,
                CreatedBy = insertprofitCenter.CreatedBy,
                CreatedDate = insertprofitCenter.CreatedDate

            };
            _context.ProfitcenterMasters.Add(profitCenter);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProfitCenterAsync(UpdateProfitcenterRequest updateProfitcenterRequest)
        {
            try
            {
                var profitCenter = await _context.ProfitcenterMasters.FindAsync(updateProfitcenterRequest.ProfitCenterId);
                if (profitCenter == null)
                {
                    throw new Exception("Profit Center not found.");
                }
                profitCenter.ProfitCenterName=updateProfitcenterRequest.ProfitCenterName;
                profitCenter.ProfitCenterRemark=updateProfitcenterRequest.ProfitCenterRemark;
                profitCenter.ProfitCenterAuthRemark=updateProfitcenterRequest.ProfitCenterAuthRemark;
                profitCenter.ProfitCenterAuth = updateProfitcenterRequest.ProfitCenterAuth;
                profitCenter.ProfitCenterIsDiscard=updateProfitcenterRequest.ProfitCenterIsDiscard;
                profitCenter.ProfitCenterIsActive=updateProfitcenterRequest.ProfitCenterIsActive;
                
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw; // Let the controller handle the error
            }
        }

        public async Task<IEnumerable<ProfitcenterMaster>> GetAllProfitCenterAsync()
        {
            return await _context.ProfitcenterMasters.ToListAsync();
        }

        public async Task<ProfitcenterMaster?> GetProfitCenterByIdAsync(int profitCenterId)
        {
            if (await _context.ProfitcenterMasters.FirstOrDefaultAsync(c => c.ProfitCenterId == profitCenterId) == null)
            {
                throw new Exception("Profit Center Id Not available");
            }
            return await _context.ProfitcenterMasters.FirstOrDefaultAsync(f => f.ProfitCenterId == profitCenterId);
        }
        
        public async Task DeleteProfitCenterAsync(int profitCenterId)
        {
            try
            {
                var profitcenter = await _context.ProfitcenterMasters.FirstOrDefaultAsync(f => f.ProfitCenterId == profitCenterId);

                if (profitcenter == null)
                {
                    throw new Exception("Profit Center Id not found.");
                }

                profitcenter.ProfitCenterIsActive = false;
                _context.ProfitcenterMasters.Update(profitcenter);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

      
    }
}
