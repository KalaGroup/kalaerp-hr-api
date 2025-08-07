using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.ResposibilitiesMaster;
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
    public class ResposibilitiesMasterServices : IResposibilitiesMaster
    {
        private readonly KalaDbContext context; // This is the DbContext for accessing the database

        public ResposibilitiesMasterServices(KalaDbContext context)
        {
            this.context = context; // Initialize the context
        }
        public async Task AddResposibilitiesAsync(InsertResposibilitiesMasterRequest request)
        {
            try
            {
                var resposibility = new ResposibilitiesMaster
                {
                    ResposibilitiesGradeId = request.ResposibilitiesGradeId,
         
                    ResposibilitiesRemark = request.ResposibilitiesRemark,
                    ResposibilitiesType = request.ResposibilitiesType,
                    ResposibilitiesDesignationId = request.ResposibilitiesDesignationId,
                    ResposibilitiesAuthRemark = request.ResposibilitiesAuthRemark,
                    ResposibilitiesAuth = request.ResposibilitiesAuth,
                    ResposibilitiesIsDiscard = request.ResposibilitiesIsDiscard,
                    ResposibilitiesIsActive = request.ResposibilitiesIsActive,
                    CreatedBy = request.CreatedBy,
                    CreatedDate = DateTime.Now,
                    

                };
                context.ResposibilitiesMasters.Add(resposibility);
                await context.SaveChangesAsync();
               
            }
            catch (Exception ex)
            {
                // Handle exception (log it, rethrow it, etc.)
                throw new Exception("Error adding responsibility", ex);
            }
        }

        public async Task DeleteResposibilitiesAsync(int id)
        {
            try
            {
                var resposibilitie = await context.ResposibilitiesMasters.FirstOrDefaultAsync(c => c.ResposibilitiesId == id);
                resposibilitie.ResposibilitiesIsActive = false;
                context.ResposibilitiesMasters.Update(resposibilitie);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Handle exception (log it, rethrow it, etc.)
                throw new Exception("Error deleting responsibility", ex);
            }
        }

        public async Task<IEnumerable<ResposibilitiesMaster>> GetResposibilitiesAsync()
        {
            return await context.ResposibilitiesMasters.ToListAsync();
        }

        public async Task<ResposibilitiesMaster> GetResposibilitiesByIdAsync(int id)
        {
            return await context.ResposibilitiesMasters.FirstOrDefaultAsync(d => d.ResposibilitiesId == id);

        }

        public Task UpdateResposibilitiesAsync(UpdateResposibilitiesMasterRequest request)
        {
            try
            {
                var resposibility = context.ResposibilitiesMasters.FirstOrDefault(d => d.ResposibilitiesId == request.ResposibilitiesId);

               resposibility.ResposibilitiesGradeId = request.ResposibilitiesGradeId;
                resposibility.ResposibilitiesDesignationId = request.ResposibilitiesDesignationId;
                resposibility.ResposibilitiesRemark = request.ResposibilitiesRemark;
                resposibility.ResposibilitiesType = request.ResposibilitiesType;
                resposibility.ResposibilitiesAuthRemark = request.ResposibilitiesAuthRemark;
                resposibility.ResposibilitiesAuth = request.ResposibilitiesAuth;
                resposibility.ResposibilitiesIsDiscard = request.ResposibilitiesIsDiscard;
                resposibility.ResposibilitiesIsActive = request.ResposibilitiesIsActive;
                resposibility.CreatedBy = request.CreatedBy;
                resposibility.CreatedDate = request.CreatedDate;
                context.ResposibilitiesMasters.Update(resposibility);
                return context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Handle exception (log it, rethrow it, etc.)
                throw new Exception("Error updating responsibility", ex);
            }
        }
    }
}
