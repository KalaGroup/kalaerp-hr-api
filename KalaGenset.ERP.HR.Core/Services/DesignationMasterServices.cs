using KalaERP.HR.Core.Interface;
using KalaERP.HR.Core.Request.CompanyMaster;
using KalaERP.HR.Core.Request.DesignationMaster;
using KalaGenset.ERP.HR.Data.DbContexts;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaERP.HR.Core.Services
{
    public class DesignationMasterServices : IDesignationMaster
    {
        private readonly KalaDbContext   context;// This is the DbContext for accessing the database
        public DesignationMasterServices(KalaDbContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// Add a new designation to the database.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Task AddDesignationAsync(InsertDesignationMasterRequest request)
        {
            try
            {
                var designation = new DesignationMaster
                {
                    DesignationCode = request.DesignationCode,
                    DesignationName = request.DesignationName,
                    DesignationDescription = request.DesignationDescription,
                    DesignationGradeId = request.DesignationGradeId,
                    DesignationQualificationId = request.DesignationQualificationId,
                    DesignationRemark = request.DesignationRemark,
                    ExperiencedRequired = request.ExperiencedRequired,
                    ExperiencedRemark = request.ExperiencedRemark,
                    GradeQualificationRemark = request.GradeQualificationRemark,
                    RequiredSkills = request.RequiredSkills,

                };
                context.DesignationMasters.Add(designation);
                return context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                // Handle exception (log it, rethrow it, etc.)
                throw new Exception("Error adding designation", ex);
            }
        }
        /// <summary>
        /// delete a designation by its ID.
        /// soft delete is not implemented in this method, it will permanently delete the designation.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Task DeleteDesignationAsync(int id)
        {
            try
            {
                var designation = context.DesignationMasters.FirstOrDefault(d => d.DesignationId == id);
                if (designation != null)
                {
                    context.DesignationMasters.Remove(designation);
                    return context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Designation not found");
                }
            }
            catch (Exception ex)
            {
                // Handle exception (log it, rethrow it, etc.)
                throw new Exception("Error deleting designation", ex);
            }
        }
        /// <summary>
        /// get a designation by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DesignationMaster> GetDesigationByIdAsync(int id)
        {
           return await context.DesignationMasters.FirstOrDefaultAsync(d => d.DesignationId == id);

        }
        /// <summary>
        /// get all designations from the database.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DesignationMaster>> GetDesignationAsync()
        {
           return await context.DesignationMasters.ToListAsync();
        }
        /// <summary>
        /// update an existing designation in the database.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Task UpdateDesignationAsync(UpdateDesignationMasterRequest request)
        {
            try
            {
                var designation = context.DesignationMasters.FirstOrDefault(d => d.DesignationId == request.DesignationId);
                designation.DesignationCode = request.DesignationCode;
                designation.DesignationName = request.DesignationName;
                designation.DesignationDescription = request.DesignationDescription;
                designation.DesignationGradeId = request.DesignationGradeId;
                designation.DesignationQualificationId = request.DesignationQualificationId;
                designation.DesignationRemark = request.DesignationRemark;
                designation.ExperiencedRequired = request.ExperiencedRequired;
                designation.ExperiencedRemark = request.ExperiencedRemark;
                designation.GradeQualificationRemark = request.GradeQualificationRemark;
                designation.RequiredSkills = request.RequiredSkills;

                context.DesignationMasters.Update(designation);
                return context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Handle exception (log it, rethrow it, etc.)
                throw new Exception("Error updating designation", ex);
            }
        }
    }
}
