using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.ActivityMaster;
using KalaGenset.ERP.HR.Core.ResponseDTO.ActivityMaster;
using KalaGenset.ERP.HR.Data.DbContexts;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace KalaGenset.ERP.HR.Core.Services
{
    public class ActivityMasterServices : IActivityMaster
    {
        private readonly KalaDbContext context;
        public ActivityMasterServices(KalaDbContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// Add Activity Async
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task AddActivityAsync(InsertActivityMasterRequest request)
        {
            try
            {
                var activity = new ActivityMaster
                {
                    ActivityDesignationId = request.ActivityDesignationId,
                    ActivityDivisionId = request.ActivityDivisionId,
                    ActivityGradeId = request.ActivityGradeId,
                    ActivityAuthRemark = request.ActivityAuthRemark,
                    ActivityIsActive = request.ActivityIsActive,
                    ActivityIsDiscard = request.ActivityIsDiscard,
                    ActivityRemark = request.ActivityRemark,
                    CreatedBy = request.CreatedBy,
                    CreatedDate = request.CreatedDate,
                    ActivityAuth = request.ActivityAuth,
                };
                context.ActivityMasters.Add(activity);
                await context.SaveChangesAsync();


            }
            catch (Exception ex)
            {
                throw;
            }
        }


        /// <summary>
        /// Delete Activity Async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteActivityAsync(int id)
        {
            try
            {
                var activity = await context.ActivityMasters.FirstOrDefaultAsync(c => c.ActivityId == id);
                activity.ActivityIsActive = false;
                activity.ActivityIsDiscard = false;
                context.ActivityMasters.Update(activity);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get Activity By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActivityMaster> GetActivityByID(int id)
        {
           return await context.ActivityMasters.FirstOrDefaultAsync(c => c.ActivityId == id);
        }
        /// <summary>
        /// get all ActivityMaster
        /// </summary>
        /// <returns></returns>
       
        public async Task<IEnumerable<InsertActivityMasterDTO>> GetAllActivityMasterAsync()
        {
            return await context.ActivityMasters
         .Where(c => c.ActivityIsActive)
         .Include(c => c.ActivityGrade)
         .Include(c => c.ActivityDesignation)
         .Include(c => c.ActivityDivision)
         .OrderBy(c => c.ActivityId)
                 .Select(c => new InsertActivityMasterDTO  // Project to DTO
                {
                    ActivityId = c.ActivityId,
                    GradeName = c.ActivityGrade.GradeName,
                    DesignationName = c.ActivityDesignation.DesignationName,
                    DivisionName = c.ActivityDivision.DivisionName,
                    ActivityRemark = c.ActivityRemark,
                    ActivityAuthRemark = c.ActivityAuthRemark,
                    ActivityAuth = c.ActivityAuth,
                    ActivityIsDiscard = c.ActivityIsDiscard,
                    ActivityIsActive = c.ActivityIsActive
                })
                .ToListAsync();  // Return as a list of DTOs
        }

        /// <summary>
        /// update code 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        async Task IActivityMaster.updateActivityAsync(UpdateActivityMasterRequest request)
        {
            try
            {
                var activity = await context.ActivityMasters.FirstOrDefaultAsync(c => c.ActivityId == request.ActivityId);
                    activity.ActivityDesignationId = request.ActivityDesignationId;
                    activity.ActivityDivisionId = request.ActivityDivisionId;
                    activity.ActivityGradeId = request.ActivityGradeId;
                    activity.ActivityAuthRemark = request.ActivityAuthRemark;
                    activity.ActivityIsActive = request.ActivityIsActive;
                    activity.ActivityIsDiscard = request.ActivityIsDiscard;
                    activity.ActivityRemark = request.ActivityRemark;
                    activity.CreatedBy = request.CreatedBy;
                    activity.CreatedDate = request.CreatedDate;
                    activity.ActivityAuth = request.ActivityAuth;
                context.ActivityMasters.Update(activity);
                await context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
