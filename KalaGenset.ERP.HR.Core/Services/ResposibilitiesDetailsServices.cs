using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.ResposibilitiesDetail;
using KalaGenset.ERP.HR.Core.ResponseDTO.ResponsibiltiesDetails;
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
    public class ResposibilitiesDetailsServices : IResposibilitiesDetail
    {
        private readonly KalaDbContext context; // This is the DbContext for accessing the database
        public ResposibilitiesDetailsServices(KalaDbContext context)
        {
            this.context = context; // Initialize the context
        }
        /// <summary>
        /// Add new responsibility detail to the system.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task AddResposibilitiesDetailAsync(InsertResposibilitiesDetailrequest request)
        {
            try
            {
                var resposibilitiesDetail = new ResponsibilitiesDetail
                {
                   DetailsResposibilitiesId=request.DetailsResposibilitiesId,
                    SrNo = request.SrNo,
                    ResponsibilitiesDetailsDescription = request.ResposibilitiesDetailsDescription,

                };
                context.ResponsibilitiesDetails.Add(resposibilitiesDetail); // Add the new responsibility detail to the context
                return context.SaveChangesAsync(); // Save changes to the database asynchronously
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// deletes a responsibility detail by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task DeleteResposibilitiesDetailAsync(int id)
        {
            try
            {
                var resposibilitiesDetail = context.ResponsibilitiesDetails.FirstOrDefault(d => d.ResponsibilitiesDetailsId == id);
                if (resposibilitiesDetail != null)
                {
                    context.ResponsibilitiesDetails.Remove(resposibilitiesDetail); // Remove the responsibility detail from the context
                    return context.SaveChangesAsync(); // Save changes to the database asynchronously
                }
                else
                {
                    throw new Exception("Responsibility detail not found");
                }
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// gets all responsibility details from the system.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ResponsibilitiesDetail>> GetResposibilitiesDetailAsync()
        {
            return await context.ResponsibilitiesDetails.ToListAsync(); // Retrieve all responsibility details from the database asynchronously
        }
        /// <summary>
        /// gets a responsibility detail by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponsibilitiesDetail> GetResposibilitiesDetailByIdAsync(int id)
        {
           return await context.ResponsibilitiesDetails.FirstOrDefaultAsync(d => d.ResponsibilitiesDetailsId == id); // Retrieve a specific responsibility detail by its ID asynchronously
        }
        /// <summary>
        /// updates an existing responsibility detail in the system.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task UpdateResposibilitiesDetailAsync(UpdateResposibilitiesDetailRequest request)
        {
            try
            {
                var resposibilitiesDetail = context.ResponsibilitiesDetails.FirstOrDefault(d => d.ResponsibilitiesDetailsId == request.ResposibilitiesDetailsId);
                if (resposibilitiesDetail != null)
                {
                    resposibilitiesDetail.DetailsResposibilitiesId = request.DetailsResposibilitiesId;
                    resposibilitiesDetail.SrNo = request.SrNo;
                    resposibilitiesDetail.ResponsibilitiesDetailsDescription = request.ResposibilitiesDetailsDescription;
                    context.ResponsibilitiesDetails.Update(resposibilitiesDetail); // Update the existing responsibility detail
                    return context.SaveChangesAsync(); // Save changes to the database asynchronously
                }
                else
                {
                    throw new Exception("Responsibility detail not found");
                }
            }
            catch(Exception)
            {
                throw;  
            }
        }

        public async Task<IEnumerable<ResponsilitiesDetailsResponseDTO>> GetResponsibiltiesDetailsByCombination(int gradeId, int designationId, int divisionId)
        {
            var result = await (from r in context.ResponsibilitiesMasters
                                join rd in context.ResponsibilitiesDetails
                                on r.ResponsibilitiesId equals rd.DetailsResposibilitiesId
                                where r.ResponsibilitiesGradeId == gradeId
                                      && r.ResponsibilitiesDesignationId == designationId
                                      && r.ResponsibilitiesDivisionId == divisionId
                                      && r.ResponsibilitiesIsActive
                                select new ResponsilitiesDetailsResponseDTO
                                {
                                    ResponsibilitiesId = r.ResponsibilitiesId,
                                    ResponsibilitiesDetailsId = rd.ResponsibilitiesDetailsId,
                                    SrNo = rd.SrNo,
                                    ResponsibilitiesDetailsDescription = rd.ResponsibilitiesDetailsDescription
                                }).ToListAsync();

            return result;
        }
    }
}
