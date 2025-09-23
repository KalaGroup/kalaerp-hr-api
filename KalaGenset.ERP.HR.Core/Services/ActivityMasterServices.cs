using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.ActivityMaster;
using KalaGenset.ERP.HR.Core.ResponseDTO.ActivityMaster;
using KalaGenset.ERP.HR.Core.ResponseDTO.ResponsibilitiesMaster;
using KalaGenset.ERP.HR.Data.DbContexts;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using static KalaGenset.ERP.HR.Core.Request.KPAMaster.InsertKPAMasterRequest;

namespace KalaGenset.ERP.HR.Core.Services
{
    public class ActivityMasterServices : IActivityMaster
    {
        private readonly KalaDbContext context;
        public ActivityMasterServices(KalaDbContext context)
        {
            this.context = context;
        }

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
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now,
                    ActivityAuth = request.ActivityAuth,
                    UpdatedBy = 1,
                    UpdatedDate = DateTime.Now,
                };
                context.ActivityMasters.Add(activity);
                await context.SaveChangesAsync();


                // ✅ Retrieve auto-generated ID
                int activityMstId = activity.ActivityId;

                // Insert child descriptions (if any)
                if (request.descriptions != null && request.descriptions.Any())
                {
                    var details = request.descriptions.Select(item => new ActivityDetail
                    {
                        DetailsActivityId = activityMstId, // FK to master
                        SrNo = item.srno,
                        ActivityDetailsDescription = item.desc
                    }).ToList();

                    context.ActivityDetails.AddRange(details);
                    await context.SaveChangesAsync();
                }


            }
            catch (Exception ex)
            {
                throw;
            }
        }




        public async Task DeleteActivityAsync(int id)
        {
            try
            {
                var activity = await context.ActivityMasters
                    .Include(a => a.ActivityDetails)
                    .FirstOrDefaultAsync(c => c.ActivityId == id);

                if (activity == null)
                    throw new Exception("Activity not found");

                // Remove details first
                if (activity.ActivityDetails.Any())
                    activity.ActivityIsActive = false;
                context.ActivityDetails.RemoveRange(activity.ActivityDetails);

                // Remove master
                //context.ActivityMasters.Remove(activity);

                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting activity", ex);
            }
        }


        public async Task<IEnumerable<ActivityMaster>> GetActivityAsync()
        {
            return await context.ActivityMasters.Where(e => e.ActivityIsActive == true).ToListAsync();
        }

        public async Task<ActivityMaster> GetActivityByIdAsync(int id)
        {
            return await context.ActivityMasters.FirstOrDefaultAsync(c => c.ActivityId == id);
        }

        public async Task<List<InsertActivityMasterDTO>> GetActivityDetails()
        {
            var activity = await (from r in context.ActivityMasters
                                  join g in context.GradeMasters on r.ActivityGradeId equals g.GradeId
                                  join d in context.DesignationMasters on r.ActivityDesignationId equals d.DesignationId
                                  join div in context.DivisionMasters on r.ActivityDivisionId equals div.DivisionId
                                  where r.ActivityIsActive == true
                                  select new InsertActivityMasterDTO
                                  {
                                      ActivityId = r.ActivityId,
                                      ActivityAuth = r.ActivityAuth,
                                      ActivityAuthRemark = r.ActivityAuthRemark,
                                      ActivityIsActive = r.ActivityIsActive,
                                      ActivityIsDiscard = r.ActivityIsDiscard,
                                      ActivityRemark = r.ActivityRemark,
                                      DesignationName = d.DesignationName,
                                      DivisionName = div.DivisionName,
                                      GradeName = g.GradeName,
                                  }).ToListAsync();
            return activity;
        }

        public async Task<IEnumerable<getActivitydetailsById>> GetActivityDetailsByMsaterId(int activityMstId)
        {
            return await context.ActivityDetails
                .Where(r => r.DetailsActivityId == activityMstId)   // filter by ID
                .Select(r => new getActivitydetailsById
                {
                    DetailsActivityId = r.DetailsActivityId,
                    ActivityDetailsId = r.ActivityDetailsId,
                    SrNo = r.SrNo,
                    ActivityDetailsDescription = r.ActivityDetailsDescription
                })
                .ToListAsync();
        }


    
        public async Task UpdateActivityAsync(UpdateActivityMasterRequest request)
        {
            try
            {
                var activity = await context.ActivityMasters
                    .FirstOrDefaultAsync(d => d.ActivityId == request.ActivityId);

                if (activity == null)
                    throw new Exception("Activity not found");

                // ✅ Update master
                activity.ActivityGradeId = request.ActivityGradeId;
                activity.ActivityDivisionId = request.ActivityDivisionId;
                activity.ActivityDesignationId = request.ActivityDesignationId;
                activity.ActivityAuth = request.ActivityAuth;
                activity.ActivityRemark = request.ActivityRemark;
                activity.ActivityAuthRemark = request.ActivityAuthRemark;
                activity.ActivityIsDiscard = request.ActivityIsDiscard;
                activity.ActivityIsActive = request.ActivityIsActive;
                activity.CreatedBy = request.CreatedBy;
                activity.CreatedDate = DateTime.Now;
                activity.UpdatedBy = request.UpdatedBy;
                activity.UpdatedDate = DateTime.Now;



                // ✅ Replace old details
                var existingDetails = await context.ActivityDetails
                    .Where(d => d.DetailsActivityId == request.ActivityId)
                    .ToListAsync();

                if (existingDetails.Any())
                    context.ActivityDetails.RemoveRange(existingDetails);

                if (request.descriptions != null && request.descriptions.Any())
                {
                    var newDetails = request.descriptions.Select(item => new ActivityDetail
                    {
                        DetailsActivityId = request.ActivityId,
                        SrNo = item.srno,
                        ActivityDetailsDescription = item.desc
                    });

                    await context.ActivityDetails.AddRangeAsync(newDetails);
                }

                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating activity", ex);
            }
        }





    }
}
