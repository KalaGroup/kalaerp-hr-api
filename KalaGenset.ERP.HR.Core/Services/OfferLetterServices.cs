using FluentValidation.AspNetCore;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.OfferLetter;
using KalaGenset.ERP.HR.Core.ResponseDTO.ActivityMaster;
using KalaGenset.ERP.HR.Core.ResponseDTO.OfferLetter;
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
    public class OfferLetterServices : IOfferLetter
    {
        private readonly KalaDbContext context;
        public OfferLetterServices(KalaDbContext context)
        {
            this.context = context;
        }

        public async Task AddOfferLetterAsync(InsertOfferLetterRequest request)
        {
            try
            {
                // 1️⃣ Insert OfferLetter master
                var offerLetter = new OfferLetter
                {
                    OfferLetterPositionId = request.OfferLetterPositionId,
                    OfferLetterRecruitmentId = request.OfferLetterRecruitmentId,
                    OfferLetterJoinindate = request.OfferLetterJoinindate, // consider changing to DateTime
                    OfferLetterRemark = request.OfferLetterRemark,
                    OfferLetterAuth1 = request.OfferLetterAuth1,
                    OfferLetterAuth1Remark = request.OfferLetterAuth1Remark,
                    OfferLetterAuth2 = request.OfferLetterAuth2,
                    OfferLetterAuth2Remark = request.OfferLetterAuth2Remark,
                    OfferLetterAuth3 = request.OfferLetterAuth3,
                    OfferLetterAuth3Remark = request.OfferLetterAuth3Remark,
                    OfferLetterIsActive = request.OfferLetterIsActive,
                    OfferLetterIsDiscard = request.OfferLetterIsDiscard,
                    CreatedBy =1,
                    CreatedDate = request.CreatedDate,
                    UpdatedBy =1,
                    UpdatedDate = request.UpdatedDate
                };

                context.OfferLetters.Add(offerLetter);
                await context.SaveChangesAsync();

                // 2️⃣ Retrieve auto-generated ID
                int offerLetterId = offerLetter.OfferLetterId;

     
                if (request.offerLetterCtcs != null && request.offerLetterCtcs.Any())
                {
                    var ctcs = request.offerLetterCtcs.Select(ctc => new OfferLetterCtc
                    {
                        OfferLetterCtcofferLetterId = offerLetterId, // FK to master
                        OfferLetterBasic = ctc.OfferLetterBasic,
                        OfferLetterDa = ctc.OfferLetterDa,
                        OfferLetterHra = ctc.OfferLetterHra,
                        OfferLetterConvAllowance = ctc.OfferLetterConvAllowance,
                        OfferLetterCityCompensatoryAlowance = ctc.OfferLetterCityCompensatoryAlowance,
                        OfferLetterLeaveTravelAllowance = ctc.OfferLetterLeaveTravelAllowance,
                        OfferLetterCarAllowance = ctc.OfferLetterCarAllowance,
                        OfferLetterFuelAllowance = ctc.OfferLetterFuelAllowance,
                        OfferLetterDriverAllowance = ctc.OfferLetterDriverAllowance,
                        OfferLetterMiscAllowance = ctc.OfferLetterMiscAllowance,
                        OfferLetterGross = ctc.OfferLetterGross,
                        OfferLetterPt = ctc.OfferLetterPt,
                        OfferLetterEsic = ctc.OfferLetterEsic,
                        OfferLetterPfemployer = ctc.OfferLetterPfemployer,
                        OfferLetterPfemployee = ctc.OfferLetterPfemployee,
                        OfferLetterMedicalInsurance = ctc.OfferLetterMedicalInsurance,
                        OfferLetterPerformanceKpa = ctc.OfferLetterPerformanceKpa,
                        OfferLetterGraduity = ctc.OfferLetterGraduity,
                        OfferLetterBonus = ctc.OfferLetterBonus,
                        OfferLetterMlwf = ctc.OfferLetterMlwf
                    }).ToList();

                    context.OfferLetterCtcs.AddRange(ctcs);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw; // optionally log the exception here
            }
        }
        public async Task DeleteOfferLetterAsync(int offerLetterId)
        {
            try
            {
                var offerLetter = await context.OfferLetters
                    .Include(o => o.OfferLetterCtcs)
                    .FirstOrDefaultAsync(o => o.OfferLetterId == offerLetterId);

                if (offerLetter == null)
                    throw new Exception("Offer letter not found");

                // Soft delete: mark inactive instead of removing master
                offerLetter.OfferLetterIsActive = false;

                // Remove child records if any
                if (offerLetter.OfferLetterCtcs != null && offerLetter.OfferLetterCtcs.Any())
                {
                    context.OfferLetterCtcs.RemoveRange(offerLetter.OfferLetterCtcs);
                }

                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting offer letter", ex);
            }
        }

        public async Task<IEnumerable<OfferLetterWithDto>> GetAllOfferLetterAsync()
        {
            var result = await (from ol in context.OfferLetters
                                join pos in context.PositionMasters
                                    on ol.OfferLetterPositionId equals pos.PositionMasterId
                                join rec in context.RecruitmentMasters
                                    on ol.OfferLetterRecruitmentId equals rec.RecruitmentMasterId
                                select new OfferLetterWithDto
                                {
                                    OfferLetterId = ol.OfferLetterId,
                                    PositionMasterName = pos.PositionMasterName,
                                    RecruitmentMasterNameOfCandidates = rec.RecruitmentMasterNameOfCandidates,
                                    OfferLetterJoinindate = ol.OfferLetterJoinindate,
                                    OfferLetterRemark = ol.OfferLetterRemark,
                                    OfferLetterAuth1 = ol.OfferLetterAuth1,
                                    OfferLetterAuth1Remark = ol.OfferLetterAuth1Remark,
                                    OfferLetterAuth2 = ol.OfferLetterAuth2,
                                    OfferLetterAuth2Remark = ol.OfferLetterAuth2Remark,
                                    OfferLetterAuth3 = ol.OfferLetterAuth3,
                                    OfferLetterAuth3Remark = ol.OfferLetterAuth3Remark,
                                    OfferLetterIsActive = ol.OfferLetterIsActive,
                                    OfferLetterIsDiscard = ol.OfferLetterIsDiscard,
                                    CreatedBy = ol.CreatedBy,
                                    CreatedDate = ol.CreatedDate,
                                    UpdatedBy = ol.UpdatedBy,
                                    UpdatedDate = ol.UpdatedDate,
                                    OfferLetterCtcs = ol.OfferLetterCtcs.Select(ctc => new OfferLetterCtcDto
                                    {
                                        OfferLetterCtcid = ctc.OfferLetterCtcid,
                                        OfferLetterCtcofferLetterId = ctc.OfferLetterCtcofferLetterId,
                                        OfferLetterBasic = ctc.OfferLetterBasic,
                                        OfferLetterDa = ctc.OfferLetterDa,
                                        OfferLetterHra = ctc.OfferLetterHra,
                                        OfferLetterConvAllowance = ctc.OfferLetterConvAllowance,
                                        OfferLetterCityCompensatoryAlowance = ctc.OfferLetterCityCompensatoryAlowance,
                                        OfferLetterLeaveTravelAllowance = ctc.OfferLetterLeaveTravelAllowance,
                                        OfferLetterCarAllowance = ctc.OfferLetterCarAllowance,
                                        OfferLetterFuelAllowance = ctc.OfferLetterFuelAllowance,
                                        OfferLetterDriverAllowance = ctc.OfferLetterDriverAllowance,
                                        OfferLetterMiscAllowance = ctc.OfferLetterMiscAllowance,
                                        OfferLetterGross = ctc.OfferLetterGross,
                                        OfferLetterPt = ctc.OfferLetterPt,
                                        OfferLetterEsic = ctc.OfferLetterEsic,
                                        OfferLetterPfemployer = ctc.OfferLetterPfemployer,
                                        OfferLetterPfemployee = ctc.OfferLetterPfemployee,
                                        OfferLetterMedicalInsurance = ctc.OfferLetterMedicalInsurance,
                                        OfferLetterPerformanceKpa = ctc.OfferLetterPerformanceKpa,
                                        OfferLetterGraduity = ctc.OfferLetterGraduity,
                                        OfferLetterBonus = ctc.OfferLetterBonus,
                                        OfferLetterMlwf = ctc.OfferLetterMlwf
                                    }).ToList()
                                }).ToListAsync();

            return result;
        }

       

        public async Task<OfferLetter?> GetOfferLetterById(int OfferLetterId)
        {
            return await context.OfferLetters.FirstOrDefaultAsync(c => c.OfferLetterId == OfferLetterId);
        }

        public async Task UpdateOfferLetterAsync(UpdateOfferLetterRequest request)
        {
       try
         {
        // 1️⃣ Retrieve existing master record
           var offerLetter = await context.OfferLetters
            .FirstOrDefaultAsync(x => x.OfferLetterId == request.OfferLetterId);

           if (offerLetter == null)
            throw new Exception("Offer Letter not found");

                // 2️⃣ Update master
                offerLetter.OfferLetterPositionId = request.OfferLetterPositionId;
                offerLetter.OfferLetterRecruitmentId = request.OfferLetterRecruitmentId;
                offerLetter.OfferLetterJoinindate = request.OfferLetterJoinindate; // consider DateTime
                offerLetter.OfferLetterRemark = request.OfferLetterRemark;
                offerLetter.OfferLetterAuth1 = request.OfferLetterAuth1;
                offerLetter.OfferLetterAuth1Remark = request.OfferLetterAuth1Remark;
                offerLetter.OfferLetterAuth2 = request.OfferLetterAuth2;
                offerLetter.OfferLetterAuth2Remark = request.OfferLetterAuth2Remark;
                offerLetter.OfferLetterAuth3 = request.OfferLetterAuth3;
                offerLetter.OfferLetterAuth3Remark = request.OfferLetterAuth3Remark;
                offerLetter.OfferLetterIsActive = request.OfferLetterIsActive;
                offerLetter.OfferLetterIsDiscard = request.OfferLetterIsDiscard;
                offerLetter.CreatedBy = 1;
                offerLetter.CreatedDate = request.CreatedDate;
                offerLetter.UpdatedBy = 1;
                offerLetter.UpdatedDate = request.UpdatedDate;
                
                // 3️⃣ Remove old child CTC records
                var existingCtcs = await context.OfferLetterCtcs
                    .Where(c => c.OfferLetterCtcofferLetterId == request.OfferLetterId)
                    .ToListAsync();
                
                if (existingCtcs.Any())
                    context.OfferLetterCtcs.RemoveRange(existingCtcs);
                
                // 4️⃣ Add new child CTCs
                if (request.offerLetterCtcs != null && request.offerLetterCtcs.Any())
                {
                    var newCtcs = request.offerLetterCtcs.Select(ctc => new OfferLetterCtc
                    {
                        OfferLetterCtcofferLetterId = request.OfferLetterId,
                        OfferLetterBasic = ctc.OfferLetterBasic,
                        OfferLetterDa = ctc.OfferLetterDa,
                        OfferLetterHra = ctc.OfferLetterHra,
                        OfferLetterConvAllowance = ctc.OfferLetterConvAllowance,
                        OfferLetterCityCompensatoryAlowance = ctc.OfferLetterCityCompensatoryAlowance,
                        OfferLetterLeaveTravelAllowance = ctc.OfferLetterLeaveTravelAllowance,
                        OfferLetterCarAllowance = ctc.OfferLetterCarAllowance,
                        OfferLetterFuelAllowance = ctc.OfferLetterFuelAllowance,
                        OfferLetterDriverAllowance = ctc.OfferLetterDriverAllowance,
                        OfferLetterMiscAllowance = ctc.OfferLetterMiscAllowance,
                        OfferLetterGross = ctc.OfferLetterGross,
                        OfferLetterPt = ctc.OfferLetterPt,
                        OfferLetterEsic = ctc.OfferLetterEsic,
                        OfferLetterPfemployer = ctc.OfferLetterPfemployer,
                        OfferLetterPfemployee = ctc.OfferLetterPfemployee,
                        OfferLetterMedicalInsurance = ctc.OfferLetterMedicalInsurance,
                        OfferLetterPerformanceKpa = ctc.OfferLetterPerformanceKpa,
                        OfferLetterGraduity = ctc.OfferLetterGraduity,
                        OfferLetterBonus = ctc.OfferLetterBonus,
                        OfferLetterMlwf = ctc.OfferLetterMlwf
            });

            await context.OfferLetterCtcs.AddRangeAsync(newCtcs);
        }

        // 5️⃣ Save all changes at once
        await context.SaveChangesAsync();
    }
    catch (Exception ex)
    {
        throw new Exception("Error updating Offer Letter", ex);
    }
}


    }
}
