using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.ActivityDetails;
using KalaGenset.ERP.HR.Core.ResponseDTO.CTC;
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
    public class CTCStructureMasterServices : ICTCStructureMaster
    {
        private readonly KalaDbContext context;
        public CTCStructureMasterServices(KalaDbContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// Add CTC 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task AddCTCStructureAsync(InsertCTCStructureMasterRequest request)
        {
            try
            {
                var ctc = new CtcstructureMaster
                {
                    CtcmasterBasic = request.CtcmasterBasic,
                    CtcmasterBonus = request.CtcmasterBonus,
                    CtcmasterCarAllowance = request.CtcmasterCarAllowance,
                    CtcmasterCityCompensatoryAlowance = request.CtcmasterCityCompensatoryAlowance,
                    CtcmasterConvAllowance = request.CtcmasterConvAllowance,
                    CtcmasterDa = request.CtcmasterDa,
                    CtcmasterDriverAllowance = request.CtcmasterDriverAllowance,
                    CtcmasterEsic = request.CtcmasterEsic,
                    CtcmasterFuelAllowance = request.CtcmasterFuelAllowance,
                    CtcmasterGradeId = request.CtcmasterGradeId,
                    CtcmasterGraduity = request.CtcmasterGraduity,
                    CtcmasterGross = request.CtcmasterGross,
                    CtcmasterHra = request.CtcmasterHra,
                    CtcmasterPt = request.CtcmasterPt,
                    CtcmasterLeaveTravelAllowance = request.CtcmasterLeaveTravelAllowance,
                    CtcmasterMedicalInsurance = request.CtcmasterMedicalInsurance,
                    CtcmasterMiscAllowance = request.CtcmasterMiscAllowance,
                    CtcmasterMlwf = request.CtcmasterMlwf,
                    CtcmasterPerformanceKpa = request.CtcmasterPerformanceKpa,
                    CtcmasterPfemployee = request.CtcmasterPfemployee,
                    CtcmasterPfemployer = request.CtcmasterPfemployer,
                };

                context.CtcstructureMasters.Add(ctc);
                await context.SaveChangesAsync();
            }
            catch
            {
                throw; // Or log exception before throwing
            }
        }
        /// <summary>
        /// delete ctc
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteCTCStructureAsync(int id)
        {
            try
            {
                var ctc = await context.CtcstructureMasters.FirstOrDefaultAsync(c => c.CtcstructureId == id);
                context.CtcstructureMasters.Update(ctc);
                await context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// get all ctc
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CTCStructureMasterResponseDTO>> GetCTCStructureAsync()
        {
            var result = await (from ctc in context.CtcstructureMasters
                                join grade in context.GradeMasters
                                    on ctc.CtcmasterGradeId equals grade.GradeId into gradeJoin
                                from grade in gradeJoin.DefaultIfEmpty()   // left join, in case no grade
                                select new CTCStructureMasterResponseDTO
                                {
                                    CtcstructureId = ctc.CtcstructureId,
                                    CtcmasterGradeId = ctc.CtcmasterGradeId,
                                    GradeName = grade != null ? grade.GradeName : null,   // 👈 fetch name
                                    CtcmasterBasic = ctc.CtcmasterBasic,
                                    CtcmasterDa = ctc.CtcmasterDa,
                                    CtcmasterHra = ctc.CtcmasterHra,
                                    CtcmasterConvAllowance = ctc.CtcmasterConvAllowance,
                                    CtcmasterCityCompensatoryAlowance = ctc.CtcmasterCityCompensatoryAlowance,
                                    CtcmasterLeaveTravelAllowance = ctc.CtcmasterLeaveTravelAllowance,
                                    CtcmasterCarAllowance = ctc.CtcmasterCarAllowance,
                                    CtcmasterFuelAllowance = ctc.CtcmasterFuelAllowance,
                                    CtcmasterDriverAllowance = ctc.CtcmasterDriverAllowance,
                                    CtcmasterMiscAllowance = ctc.CtcmasterMiscAllowance,
                                    CtcmasterGross = ctc.CtcmasterGross,
                                    CtcmasterPfemployee = ctc.CtcmasterPfemployee,
                                    CtcmasterPt = ctc.CtcmasterPt,
                                    CtcmasterEsic = ctc.CtcmasterEsic,
                                    CtcmasterPfemployer = ctc.CtcmasterPfemployer,
                                    CtcmasterMedicalInsurance = ctc.CtcmasterMedicalInsurance,
                                    CtcmasterPerformanceKpa = ctc.CtcmasterPerformanceKpa,
                                    CtcmasterGraduity = ctc.CtcmasterGraduity,
                                    CtcmasterBonus = ctc.CtcmasterBonus,
                                    CtcmasterMlwf = ctc.CtcmasterMlwf
                                }).ToListAsync();

            return result;

        }
        /// <summary>
        /// get by id ctc
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CtcstructureMaster> GetCTCStructureByIdAsync(int id)
        {
            return await context.CtcstructureMasters.FirstOrDefaultAsync(c => c.CtcstructureId == id);
        }
        /// <summary>
        /// update ctc 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task UpdateCTCStructureAsync(UpdateCTCStructureMasterRequest request)
        {
            try
            {
                var ctc = await context.CtcstructureMasters.FindAsync(request.CtcstructureId);
                ctc.CtcmasterBasic = request.CtcmasterBasic;
                 ctc.CtcmasterBonus = request.CtcmasterBonus;
                 ctc.CtcmasterCarAllowance = request.CtcmasterCarAllowance;
                 ctc.CtcmasterCityCompensatoryAlowance = request.CtcmasterCityCompensatoryAlowance;
                 ctc.CtcmasterConvAllowance = request.CtcmasterConvAllowance;
                 ctc.CtcmasterDa = request.CtcmasterDa;
                 ctc.CtcmasterDriverAllowance = request.CtcmasterDriverAllowance;
                 ctc.CtcmasterEsic = request.CtcmasterEsic;
                 ctc.CtcmasterFuelAllowance = request.CtcmasterFuelAllowance;
                 ctc.CtcmasterGradeId = request.CtcmasterGradeId;
                 ctc.CtcmasterGraduity = request.CtcmasterGraduity;
                 ctc.CtcmasterGross = request.CtcmasterGross;
                 ctc.CtcmasterHra = request.CtcmasterHra;
                 ctc.CtcmasterPt = request.CtcmasterPt;
                 ctc.CtcmasterLeaveTravelAllowance = request.CtcmasterLeaveTravelAllowance;
                 ctc.CtcmasterMedicalInsurance = request.CtcmasterMedicalInsurance;
                 ctc.CtcmasterMiscAllowance = request.CtcmasterMiscAllowance;
                 ctc.CtcmasterMlwf = request.CtcmasterMlwf;
                 ctc.CtcmasterPerformanceKpa = request.CtcmasterPerformanceKpa;
                 ctc.CtcmasterPfemployee = request.CtcmasterPfemployee;
                ctc.CtcmasterPfemployer = request.CtcmasterPfemployer;
                context.CtcstructureMasters.Update(ctc);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
