using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.KPAMaster;
using KalaGenset.ERP.HR.Core.ResponseDTO.KPA;
using KalaGenset.ERP.HR.Core.ResponseDTO.Location;
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
    public class KPAMasterServices : IKPAMaster
    {
        /// <summary>
        /// method call
        /// </summary>
        private readonly KalaDbContext dbContext;
        public KPAMasterServices(KalaDbContext context)
        {
            dbContext = context;
        }
        /// <summary>
        /// insert KPA Master  new entity
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Task InsertKPAMasterAsync(InsertKPAMasterRequest request)
        {
            try
            {
                var kpaMaster = new Kpamaster
                {
                    KpagradeId = request.KpagradeId,
                    KpadesignationId = request.KpadesignationId,
                    Kparemark = request.Kparemark,
                    KpaauthRemark = request.KpaauthRemark,
                    KpadivisionId = request.KpadivisionId,
                    Kpaauth = request.Kpaauth,
                    KpaisDiscard = request.KpaisDiscard,
                    KpaisActive = request.KpaisActive,
                    CreatedBy = request.CreatedBy,
                    CreatedDate = request.CreatedDate
                };
                dbContext.Kpamasters.Add(kpaMaster);
                return dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new Exception("An error occurred while inserting KPA Master data.", ex);
            }
        }
        /// <summary>
        /// GetKPAMasterByID BY Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Kpamaster> GetKPAMasterByID(int id)
        {
            return await dbContext.Kpamasters.FirstOrDefaultAsync(k => k.Kpaid == id);
               
        }
        /// <summary>
        /// get  GetAllKPAMaster 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<KPAmasterResponseDTO>> GetAllKPAMasterAsync()
        {
            return await dbContext.Kpamasters
               .Where(c => c.KpaisActive)
               .Include(c => c.Kpadesignation)
               .Include(c => c.Kpagrade)
               .Include(c => c.Kpadivision)
               .OrderBy(c => c.Kpaid)
               .Select(c => new KPAmasterResponseDTO
               {
                  Kpaid = c.Kpaid,
                  KpaauthRemark = c.KpaauthRemark,
                  KpaisActive = c.KpaisActive,
                  Kpaauth=c.Kpaauth,
                  KpaisDiscard = c.KpaisDiscard,
                  Kparemark = c.Kparemark,
                  DesignationName= c.Kpadesignation.DesignationName,
                  GradeName=c.Kpagrade.GradeName,
                  DivisionName=c.Kpadivision.DivisionName,
                  
                  
               })
               .ToListAsync();
        }
        /// <summary>
        /// update KPA master recode 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Task UpdateKPAMasterAsync(UpdateKPAMasterRequest request)
        {
            try
            {
                var kpaMaster = dbContext.Kpamasters.FirstOrDefault(k => k.Kpaid == request.Kpaid);
                if (kpaMaster != null)
                {
                    kpaMaster.KpagradeId = request.KpagradeId;
                    kpaMaster.KpadesignationId = request.KpadesignationId;
                    kpaMaster.Kparemark = request.Kparemark;
                    kpaMaster.KpaauthRemark = request.KpaauthRemark;
                    kpaMaster.KpadivisionId = request.KpadivisionId;
                    kpaMaster.Kpaauth = request.Kpaauth;
                    kpaMaster.KpaisDiscard = request.KpaisDiscard;
                    kpaMaster.KpaisActive = request.KpaisActive;
                    kpaMaster.CreatedBy = request.CreatedBy;
                    kpaMaster.CreatedDate = request.CreatedDate;
                    dbContext.Kpamasters.Update(kpaMaster);
                    return dbContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("KPA Master not found.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new Exception("An error occurred while updating KPA Master data.", ex);
            }
        }
        /// <summary>
        /// delete soft 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Task DeleteKPAMasterAsync(int id)
        {
            try
            {
                var kpaMaster = dbContext.Kpamasters.FirstOrDefault(k => k.Kpaid == id);
                if (kpaMaster != null)
                {
                    kpaMaster.KpaisActive = false; // Set active status to false instead of deleting
                    kpaMaster.KpaisDiscard = false; // Mark as discarded instead of deleting
                    return dbContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("KPA Master not found.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new Exception("An error occurred while deleting KPA Master data.", ex);
            }
        }
    }
}
