using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.ResposibilitiesDetail;
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
        // This method adds a new responsibility detail to the database
        public Task AddResposibilitiesDetailAsync(InsertResposibilitiesDetailrequest request)
        {
            try
            {
                var resposibilitiesDetail = new ResposibilitiesDetail
                {
                   DetailsResposibilitiesId=request.DetailsResposibilitiesId,
                    SrNo = request.SrNo,
                    ResposibilitiesDetailsDescription = request.ResposibilitiesDetailsDescription,

                };
                context.ResposibilitiesDetails.Add(resposibilitiesDetail); // Add the new responsibility detail to the context
                return context.SaveChangesAsync(); // Save changes to the database asynchronously
            }
            catch
            {
                throw;
            }
        }
        // This method deletes a responsibility detail by its ID
        public Task DeleteResposibilitiesDetailAsync(int id)
        {
            try
            {
                var resposibilitiesDetail = context.ResposibilitiesDetails.FirstOrDefault(d => d.ResposibilitiesDetailsId == id);
                if (resposibilitiesDetail != null)
                {
                    context.ResposibilitiesDetails.Remove(resposibilitiesDetail); // Remove the responsibility detail from the context
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
        // This method retrieves all responsibility details from the database
        public async Task<IEnumerable<ResposibilitiesDetail>> GetResposibilitiesDetailAsync()
        {
            return await context.ResposibilitiesDetails.ToListAsync(); // Retrieve all responsibility details from the database asynchronously
        }
        // This method retrieves a specific responsibility detail by its ID
        public async Task<ResposibilitiesDetail> GetResposibilitiesDetailByIdAsync(int id)
        {
           return await context.ResposibilitiesDetails.FirstOrDefaultAsync(d => d.ResposibilitiesDetailsId == id); // Retrieve a specific responsibility detail by its ID asynchronously
        }
        // This method updates an existing responsibility detail
        public Task UpdateResposibilitiesDetailAsync(UpdateResposibilitiesDetailRequest request)
        {
            try
            {
                var resposibilitiesDetail = context.ResposibilitiesDetails.FirstOrDefault(d => d.ResposibilitiesDetailsId == request.ResposibilitiesDetailsId);
                if (resposibilitiesDetail != null)
                {
                    resposibilitiesDetail.DetailsResposibilitiesId = request.DetailsResposibilitiesId;
                    resposibilitiesDetail.SrNo = request.SrNo;
                    resposibilitiesDetail.ResposibilitiesDetailsDescription = request.ResposibilitiesDetailsDescription;
                    context.ResposibilitiesDetails.Update(resposibilitiesDetail); // Update the existing responsibility detail
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
    }
}
