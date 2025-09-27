using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.ERPPageDetails;
using KalaGenset.ERP.HR.Core.Request.Workstation;
using KalaGenset.ERP.HR.Core.ResponseDTO.ERPPageDetails;
using KalaGenset.ERP.HR.Core.ResponseDTO.WorkstationMaster;
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
    public class ERPPageDetailsService : IERPPageDetails
    {
        private readonly KalaDbContext _context;

        public ERPPageDetailsService(KalaDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// This is Add Code
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task AddERPPageDetailsAsync(InsertERPPageDetailsRequest request)
        {
            try
            {
                var ERPPageDetails = new KalaErppageDetail
                {
                    KalaErppageDetailsDivisionId = request.KalaErppageDetailsDivisionId,
                    PageTittle = request.PageTittle,
                    PageUrl = request.PageUrl,
                    PageType = request.PageType,
                    PageIsonumber = request.PageIsonumber,
                    KalaErppageDetailsRemark = request.KalaErppageDetailsRemark,
                    KalaErppageDetailsAuthRemark = request.KalaErppageDetailsAuthRemark,
                    KalaErppageDetailsAuth = request.KalaErppageDetailsAuth,
                    KalaErppageDetailsIsDiscard = request.KalaErppageDetailsIsDiscard,
                    KalaErppageDetailsIsActive = request.KalaErppageDetailsIsActive,
                    CreatedBy = 3,
                    CreatedDate = DateTime.Now,
                    UpdatedBy = 3,
                    UpdatedDate = DateTime.Now
                };

                _context.KalaErppageDetails.Add(ERPPageDetails);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }

        }


        /// <summary>
        /// This is Delete Code
        /// </summary>
        /// <param name="wid"></param>
        /// <returns></returns>
        public async Task DeleteERPPageDetailsAsync(int Eid)
        {
            try
            {
                var ERPPageDetails = await _context.KalaErppageDetails.FirstOrDefaultAsync(c => c.KalaErppageDetailsId == Eid);

                ERPPageDetails.KalaErppageDetailsIsActive = false;

                _context.KalaErppageDetails.Update(ERPPageDetails);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        /// <summary>
        /// This is Get Code By ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<KalaErppageDetail?> GetERPPageDetailsByID(int Eid)
        {
            return await _context.KalaErppageDetails.FirstOrDefaultAsync(c => c.KalaErppageDetailsId == Eid);

        }

        /// <summary>
        /// This is Get Code for All Workstation Details
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ERPPageDetailsResponseDTO>> GetERPPageDetailsAsync()
        {
            var result = await (
                from ep in _context.KalaErppageDetails
                join div in _context.DivisionMasters
                    on ep.KalaErppageDetailsDivisionId equals div.DivisionId
                where ep.KalaErppageDetailsIsActive == true   // ✅ Only active records
                select new ERPPageDetailsResponseDTO
                {
                    KalaErppageDetailsId = ep.KalaErppageDetailsId,
                    KalaErppageDetailsDivisionId = ep.KalaErppageDetailsDivisionId,
                    DivisionName = div.DivisionName,

                    PageTittle = ep.PageTittle,
                    PageUrl = ep.PageUrl,
                    PageType = ep.PageType,
                    PageIsonumber = ep.PageIsonumber,

                    KalaErppageDetailsRemark = ep.KalaErppageDetailsRemark,
                    KalaErppageDetailsAuthRemark = ep.KalaErppageDetailsAuthRemark,
                    KalaErppageDetailsAuth = ep.KalaErppageDetailsAuth,
                    KalaErppageDetailsIsDiscard = ep.KalaErppageDetailsIsDiscard,
                    KalaErppageDetailsIsActive = ep.KalaErppageDetailsIsActive,

                    CreatedBy = ep.CreatedBy,
                    CreatedDate = ep.CreatedDate,
                    UpdatedBy = ep.UpdatedBy,
                    UpdatedDate = ep.UpdatedDate
                }
            ).ToListAsync();

            return result;
        }





        /// <summary>
        /// This is Update Code
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task UpdateERPPageDetailsAsync(UpdateERPPageDetailsRequest request)
        {
            try
            {
                var erpPageDetails = await _context.KalaErppageDetails.FindAsync(request.KalaErppageDetailsId);

                if (erpPageDetails == null)
                    throw new Exception("ERP Page Details not found.");

                // ✅ Update fields
                erpPageDetails.KalaErppageDetailsDivisionId = request.KalaErppageDetailsDivisionId;
                erpPageDetails.PageTittle = request.PageTittle;
                erpPageDetails.PageUrl = request.PageUrl;
                erpPageDetails.PageType = request.PageType;
                erpPageDetails.PageIsonumber = request.PageIsonumber;

                erpPageDetails.KalaErppageDetailsRemark = request.KalaErppageDetailsRemark;
                erpPageDetails.KalaErppageDetailsAuthRemark = request.KalaErppageDetailsAuthRemark;
                erpPageDetails.KalaErppageDetailsAuth = request.KalaErppageDetailsAuth;
                erpPageDetails.KalaErppageDetailsIsDiscard = request.KalaErppageDetailsIsDiscard;
                erpPageDetails.KalaErppageDetailsIsActive = request.KalaErppageDetailsIsActive;

                // Audit fields
                erpPageDetails.UpdatedBy = request.UpdatedBy;
                erpPageDetails.UpdatedDate = request.UpdatedDate;

                _context.KalaErppageDetails.Update(erpPageDetails);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Optional: log ex here
                throw;
            }
        }

    }
}
