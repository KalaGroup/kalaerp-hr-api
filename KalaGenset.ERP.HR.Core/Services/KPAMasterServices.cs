using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.KPAMaster;
using KalaGenset.ERP.HR.Core.ResponseDTO.KPA;
using KalaGenset.ERP.HR.Core.ResponseDTO.Location;
using KalaGenset.ERP.HR.Core.ResponseDTO.ResponsibilitiesMaster;
using KalaGenset.ERP.HR.Data.DbContexts;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KalaGenset.ERP.HR.Core.Request.KPAMaster.InsertKPAMasterRequest;

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
        public async Task InsertKPAMasterAsync(InsertKPAMasterRequest request)
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
                CreatedBy = 1,
                CreatedDate = DateTime.Now
            };

             dbContext.Kpamasters.AddAsync(kpaMaster);
            await dbContext.SaveChangesAsync();

            // ✅ Retrieve auto-generated ID
            int kpaMstId = kpaMaster.Kpaid;

              // Insert child descriptions (if any)
                if (request.descriptions != null && request.descriptions.Any())
                {
                    var details = request.descriptions.Select(item => new Kpadetail
                    {
                        DetailsKpaid = kpaMstId, // FK to master
                        SrNo = item.srno,
                        KpadetailsDescription = item.desc
                    }).ToList();

                    dbContext.Kpadetails.AddRange(details);
                    await dbContext.SaveChangesAsync();
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
                .OrderBy(c => c.Kpaid)
                .Select(c => new KPAmasterResponseDTO
                {
                    Kpaid = c.Kpaid,
                    Kpaauth = c.Kpaauth,
                    KpaisActive = c.KpaisActive,
                    KpaauthRemark = c.KpaauthRemark,
                    KpaisDiscard = c.KpaisDiscard,
                    Kparemark = c.Kparemark,

                    // Navigation properties (safe-checked)
                    GradeName = c.Kpagrade != null ? c.Kpagrade.GradeName : string.Empty,
                    DesignationName = c.Kpadesignation != null ? c.Kpadesignation.DesignationName : string.Empty,
                    DivisionName = c.Kpadivision != null ? c.Kpadivision.DivisionName : string.Empty
                })
                .ToListAsync();
        }

        /// <summary>
        /// update KPA master recode 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task UpdateKPAMasterAsync(UpdateKPAMasterRequest request)
        {
           

            try
            {
                var kpa = await dbContext.Kpamasters
                    .FirstOrDefaultAsync(d => d.Kpaid == request.Kpaid);

                if (kpa == null)
                    throw new Exception("kpa not found");

                // ✅ Update master
               kpa.Kpaid = request.Kpaid;
                kpa.Kpaauth = request.Kpaauth;
                kpa.KpaisActive = request.KpaisActive;
                kpa.KpaauthRemark = request.KpaauthRemark;
                kpa.KpaisDiscard = request.KpaisDiscard;
                kpa.KpagradeId = request.KpagradeId;
                kpa.KpadesignationId = request.KpadesignationId;
                kpa.KpadivisionId = request.KpadivisionId;  
                kpa.Kparemark= request.Kparemark;
                kpa.CreatedBy = request.CreatedBy;
                kpa.CreatedDate = DateTime.Now;


                // ✅ Replace old details
                var existingDetails = await dbContext.Kpadetails
                    .Where(d => d.DetailsKpaid == request.Kpaid)
                    .ToListAsync();

                if (existingDetails.Any())
                    dbContext.Kpadetails.RemoveRange(existingDetails);

                if (request.descriptions != null && request.descriptions.Any())
                {
                    var newDetails = request.descriptions.Select(item => new Kpadetail
                    {
                        DetailsKpaid = request.Kpaid,
                        SrNo = item.srno,
                        KpadetailsDescription = item.desc
                    });

                    await dbContext.Kpadetails.AddRangeAsync(newDetails);
                }

                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating KPA", ex);
            }

        }
       

        public async Task DeleteKPAMasterAsync(int id)
        {
            try
            {
                var kpa = await dbContext.Kpamasters
                    .FirstOrDefaultAsync(c => c.Kpaid == id);

                if (kpa == null)
                    throw new Exception("KPA not found");

                var details = await dbContext.Kpadetails
                    .Where(d => d.DetailsKpaid == id)
                    .ToListAsync();
                // ✅ Remove child details
                if (details.Any())
                {
                    dbContext.Kpadetails.RemoveRange(details);
                }

                // ✅ Soft delete master
                kpa.KpaisActive = false;
                dbContext.Kpamasters.Update(kpa);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


       

        public async Task<IEnumerable<GetKPADeatilsById>> GetKpaDetailsByMsaterId(int kpaMstId)
        {
            return await dbContext.Kpadetails
               .Where(r => r.DetailsKpaid == kpaMstId)   // filter by ID
               .Select(r => new GetKPADeatilsById
               {
                   DetailsKpaid = r.DetailsKpaid,
                   KpadetailsId = r.KpadetailsId,
                   SrNo = r.SrNo,
                   KpadetailsDescription = r.KpadetailsDescription,
               })
               .ToListAsync();
        }
    }
}
