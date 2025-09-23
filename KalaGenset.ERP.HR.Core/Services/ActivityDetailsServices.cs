using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.ActivityDetails;
using KalaGenset.ERP.HR.Core.ResponseDTO.ActivityDetails;
using KalaGenset.ERP.HR.Core.ResponseDTO.RoleDetails;
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
    public class ActivityDetailsServices : IActivityDetails
    {
        /// <summary>
        /// Inalization string
        /// </summary>
        private readonly KalaDbContext context;
        public ActivityDetailsServices(KalaDbContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// Add Activity Detail Async
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task AddActivityDetailAsync(InsertActivityDetailsRequest request)
        {
            try
            {
                var details = new ActivityDetail
                {
                    ActivityDetailsDescription = request.ActivityDetailsDescription,
                    SrNo = request.SrNo,
                    DetailsActivityId = request.DetailsActivityId,
                };
                context.ActivityDetails.Add(details);
                return context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Delete Activit y Detail Async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteActivityDetailAsync(int id)
        {
            try
            {
                var activity = await context.ActivityDetails.FirstOrDefaultAsync(c => c.ActivityDetailsId == id);
              
                context.ActivityDetails.Update(activity);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get Activity Detai l ByID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActivityDetail> GetActivityDetailByID(int id)
        {
            return await context.ActivityDetails.FirstOrDefaultAsync(c => c.ActivityDetailsId == id);
        }
        /// <summary>
        /// Get All Activity Detail Async
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ActivityDetail>> GetAllActivityDetailAsync()
        {
           return await context.ActivityDetails.ToListAsync();
        }
        /// <summary>
        /// update Activity Detail Async
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task updateActivityDetailAsync(UpdateActivityDetailsRequest request)
        {
            try
            {
                var details= await context.ActivityDetails.FirstOrDefaultAsync(c => c.ActivityDetailsId == request.ActivityDetailsId);
                details.ActivityDetailsDescription = request.ActivityDetailsDescription;
                details.SrNo = request.SrNo;
                details.DetailsActivityId = request.DetailsActivityId;
                context.ActivityDetails.Update(details);
                await context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<ActivityDetailsResponseDTO>> GetActivityDetailsByCombination(int gradeId, int designationId, int divisionId)
        {
            var result = await (from r in context.ActivityMasters
                                join rd in context.ActivityDetails
                                on r.ActivityId equals rd.DetailsActivityId
                                where r.ActivityGradeId == gradeId
                                      && r.ActivityDesignationId == designationId
                                      && r.ActivityDivisionId == divisionId
                                      && r.ActivityIsActive
                                select new ActivityDetailsResponseDTO
                                {
                                    ActivityId = r.ActivityId,
                                    ActivityDetailsId = rd.ActivityDetailsId,
                                    SrNo = rd.SrNo,
                                    ActivityDetailsDescription = rd.ActivityDetailsDescription
                                }).ToListAsync();

            return result;
        }
    }
}
