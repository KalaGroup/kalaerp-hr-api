using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.RecruitmentStageStatusMaster;
using KalaGenset.ERP.HR.Data.DbContexts;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Services
{
    public class RecruitmentStageStatusMasterServices : IRecruitmentStageStatusMaster
    {
        private readonly KalaDbContext context;
        public RecruitmentStageStatusMasterServices(KalaDbContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// This method Add new RecruitmentStage
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task AddRecruitmentStageAsync(InsertRecruitmentStageStatusMasterRequest request)
        {
            try
            {
                var RecruitmentStage = new RecruitmentStageStatusMaster
                {
                    RecruitmentStageStatusName = request.RecruitmentStageStatusName,
                    RecruitmentStageStatusAuth = request.RecruitmentStageStatusAuth,
                    RecruitmentStageStatusAuthRemark = request.RecruitmentStageStatusAuthRemark,
                    RecruitmentStageStatusIsActive = request.RecruitmentStageStatusIsActive,
                    RecruitmentStageStatusIsDiscard = request.RecruitmentStageStatusIsDiscard,
                    RecruitmentStageStatusRemark = request.RecruitmentStageStatusRemark,
                    CreatedBy = request.CreatedBy,
                    CreatedDate = request.CreatedDate,

                };
                context.RecruitmentStageStatusMasters.Add(RecruitmentStage);
                await context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// This Method Delete RecruitmentStage
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteRecruitmentStageAsync(int id)
        {
            try
            {
                var RecruitmentStage = await context.RecruitmentStageStatusMasters.FirstOrDefaultAsync(c => c.RecruitmentStageStatusId == id);

                RecruitmentStage.RecruitmentStageStatusIsActive = false;
                RecruitmentStage.RecruitmentStageStatusIsDiscard= false;
                context.RecruitmentStageStatusMasters.Update(RecruitmentStage);
                await context.SaveChangesAsync();
            }
            catch (Exception )
            {
                throw;
            }
        }
        /// <summary>
        /// This Method Get all RecruitmentStage
        /// </summary>
        /// <returns></returns>      
        public async Task<IEnumerable<RecruitmentStageStatusMaster>> GetAllRecruitmentStageAsync()
        {
            return await context.RecruitmentStageStatusMasters.ToListAsync();
        }
        /// <summary>
        /// Get By Id RecruitmentStage
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<RecruitmentStageStatusMaster> GetRecruitmentStageByID(int id)
        {
           return await context.RecruitmentStageStatusMasters.FirstOrDefaultAsync(c=>c.RecruitmentStageStatusId==id);
        }
        /// <summary>
        /// This method Update record RecruitmentStage
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task updateRecruitmentStageAsync(UpdateRecruitmentStageStatusMasterRequest request)
        {
            try
            {
                var RecruitmentStage = await context.RecruitmentStageStatusMasters.FindAsync(request.RecruitmentStageStatusId);

              RecruitmentStage.RecruitmentStageStatusName = request.RecruitmentStageStatusName;
              RecruitmentStage.RecruitmentStageStatusAuth = request.RecruitmentStageStatusAuth;
              RecruitmentStage.RecruitmentStageStatusAuthRemark = request.RecruitmentStageStatusAuthRemark;
              RecruitmentStage.RecruitmentStageStatusIsActive = request.RecruitmentStageStatusIsActive;
              RecruitmentStage.RecruitmentStageStatusIsDiscard = request.RecruitmentStageStatusIsDiscard;
              RecruitmentStage.RecruitmentStageStatusRemark = request.RecruitmentStageStatusRemark;
              RecruitmentStage.CreatedBy = request.CreatedBy;
                RecruitmentStage.CreatedDate = request.CreatedDate;
                context.RecruitmentStageStatusMasters.Update(RecruitmentStage);
                await context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
