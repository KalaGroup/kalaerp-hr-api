using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.ResposibilitiesMaster;
using KalaGenset.ERP.HR.Core.ResponseDTO.ResponsibilitiesMaster;
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
        /// <summary>
        /// adds a new responsibility to the system.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task AddResposibilitiesAsync(InsertResposibilitiesMasterRequest request)
        {
            try
            {
                //var resposibility = new ResponsibilitiesMaster
                //{
                //    ResponsibilitiesGradeId = request.ResposibilitiesGradeId,

                //    ResponsibilitiesRemark = request.ResposibilitiesRemark,
                //    ResponsibilitiesDesignationId = request.ResposibilitiesDesignationId,
                //    ResponsibilitiesAuthRemark = request.ResposibilitiesAuthRemark,
                //    ResponsibilitiesDivisionId = request.ResponsibilitiesDivisionId,
                //    ResponsibilitiesAuth = request.ResposibilitiesAuth,
                //    ResponsibilitiesIsDiscard = request.ResposibilitiesIsDiscard,
                //    ResponsibilitiesIsActive = request.ResposibilitiesIsActive,
                //    CreatedBy = 1,
                //    CreatedDate = DateTime.Now,
                //};
                //context.ResponsibilitiesMasters.Add(resposibility);
                //await context.SaveChangesAsync();

                var responsibility = new ResponsibilitiesMaster
                {
                    ResponsibilitiesGradeId = request.ResposibilitiesGradeId,
                    ResponsibilitiesRemark = request.ResposibilitiesRemark,
                    ResponsibilitiesDesignationId = request.ResposibilitiesDesignationId,
                    ResponsibilitiesAuthRemark = request.ResposibilitiesAuthRemark,
                    ResponsibilitiesDivisionId = request.ResponsibilitiesDivisionId,
                    ResponsibilitiesAuth = request.ResposibilitiesAuth,
                    ResponsibilitiesIsDiscard = request.ResposibilitiesIsDiscard,
                    ResponsibilitiesIsActive = request.ResposibilitiesIsActive,
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now
                };

                // Insert into DB
                context.ResponsibilitiesMasters.Add(responsibility);
                await context.SaveChangesAsync();

                // ✅ Retrieve auto-generated ID
                int resonsibilityMstId = responsibility.ResponsibilitiesId;

                // Insert child descriptions (if any)
                if (request.descriptions != null && request.descriptions.Any())
                {
                    var details = request.descriptions.Select(item => new ResponsibilitiesDetail
                    {
                        DetailsResposibilitiesId = resonsibilityMstId, // FK to master
                        SrNo = item.srno,
                        ResponsibilitiesDetailsDescription = item.desc
                    }).ToList();

                    context.ResponsibilitiesDetails.AddRange(details);
                    await context.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                // Handle exception (log it, rethrow it, etc.)
                throw new Exception("Error adding responsibility", ex);
            }
        }
        /// <summary>
        /// deletes a responsibility by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        //public async Task DeleteResposibilitiesAsync(int id)
        //{
        //    try
        //    {
        //        var resposibilitie = await context.ResponsibilitiesMasters.FirstOrDefaultAsync(c => c.ResponsibilitiesId == id);
        //        resposibilitie.ResponsibilitiesIsActive = false;
        //        context.ResponsibilitiesMasters.Update(resposibilitie);
        //        await context.SaveChangesAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle exception (log it, rethrow it, etc.)
        //        throw new Exception("Error deleting responsibility", ex);
        //    }
        //}


        public async Task DeleteResposibilitiesAsync(int id)
        {
            try
            {
                var responsibility = await context.ResponsibilitiesMasters
                    .FirstOrDefaultAsync(c => c.ResponsibilitiesId == id);

                if (responsibility == null)
                    throw new Exception("Responsibility not found");

                var details = await context.ResponsibilitiesDetails
                    .Where(d => d.DetailsResposibilitiesId == id)
                    .ToListAsync();
                // ✅ Remove child details
                if (details.Any())
                {
                    context.ResponsibilitiesDetails.RemoveRange(details);
                }

                // ✅ Soft delete master
                responsibility.ResponsibilitiesIsActive = false;
                context.ResponsibilitiesMasters.Update(responsibility);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting responsibility", ex);
            }
        }

        /// <summary>
        /// gets a list of all responsibilities in the system.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ResponsibilitiesMaster>> GetResposibilitiesAsync()
        {
            return await context.ResponsibilitiesMasters.ToListAsync();
        }

        public async Task<List<ResponsibilitiesResponseDTO>> GetResponsibilitiesDetails()
        {
            var responsibilities = await (from r in context.ResponsibilitiesMasters
                                          join g in context.GradeMasters on r.ResponsibilitiesGradeId equals g.GradeId
                                          join d in context.DesignationMasters on r.ResponsibilitiesDesignationId equals d.DesignationId
                                          join div in context.DivisionMasters on r.ResponsibilitiesDivisionId equals div.DivisionId
                                          select new ResponsibilitiesResponseDTO
                                          {
                                              ResponsibilitiesId = r.ResponsibilitiesId,
                                              ResponsibilitiesGradeName = g.GradeName,
                                              ResponsibilitiesDesignationName = d.DesignationName,
                                              ResponsibilitiesDivisionName = div.DivisionName,
                                              ResponsibilitiesRemark = r.ResponsibilitiesRemark,
                                              ResponsibilitiesAuthRemark = r.ResponsibilitiesAuthRemark,
                                              ResponsibilitiesAuth = r.ResponsibilitiesAuth,
                                              ResponsibilitiesIsDiscard = r.ResponsibilitiesIsDiscard,
                                              ResponsibilitiesIsActive = r.ResponsibilitiesIsActive
                                          }).ToListAsync();
            return responsibilities;
        }

        /// <summary>
        /// gets a responsibility by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponsibilitiesMaster> GetResposibilitiesByIdAsync(int id)
        {
            return await context.ResponsibilitiesMasters.FirstOrDefaultAsync(d => d.ResponsibilitiesId == id);

        }
        /// <summary>
        /// updates an existing responsibility in the system.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        //public async Task UpdateResposibilitiesAsync(UpdateResposibilitiesMasterRequest request)
        //{
        //    try
        //    {
        //        //var resposibility = context.ResponsibilitiesMasters.FirstOrDefault(d => d.ResponsibilitiesId == request.ResposibilitiesId);

        //        //resposibility.ResponsibilitiesGradeId = request.ResposibilitiesGradeId;
        //        //resposibility.ResponsibilitiesDesignationId = request.ResposibilitiesDesignationId;
        //        //resposibility.ResponsibilitiesRemark = request.ResposibilitiesRemark;
        //        //resposibility.ResponsibilitiesAuthRemark = request.ResposibilitiesAuthRemark;
        //        //resposibility.ResponsibilitiesDivisionId = request.ResponsibilitiesDivisionId;
        //        //resposibility.ResponsibilitiesAuth = request.ResposibilitiesAuth;
        //        //resposibility.ResponsibilitiesIsDiscard = request.ResposibilitiesIsDiscard;
        //        //resposibility.ResponsibilitiesIsActive = request.ResposibilitiesIsActive;
        //        //resposibility.CreatedBy = 1;
        //        //resposibility.CreatedDate = DateTime.Now;
        //        //context.ResponsibilitiesMasters.Update(resposibility);
        //        //return context.SaveChangesAsync();
        //        var responsibility = await context.ResponsibilitiesMasters
        //                            .FirstOrDefaultAsync(d => d.ResponsibilitiesId == request.ResposibilitiesId);

        //        if (responsibility == null)
        //            throw new Exception("Responsibility not found");

        //        // ✅ Update master
        //        responsibility.ResponsibilitiesGradeId = request.ResposibilitiesGradeId;
        //        responsibility.ResponsibilitiesDesignationId = request.ResposibilitiesDesignationId;
        //        responsibility.ResponsibilitiesRemark = request.ResposibilitiesRemark;
        //        responsibility.ResponsibilitiesAuthRemark = request.ResposibilitiesAuthRemark;
        //        responsibility.ResponsibilitiesDivisionId = request.ResponsibilitiesDivisionId;
        //        responsibility.ResponsibilitiesAuth = request.ResposibilitiesAuth;
        //        responsibility.ResponsibilitiesIsDiscard = request.ResposibilitiesIsDiscard;
        //        responsibility.ResponsibilitiesIsActive = request.ResposibilitiesIsActive;
        //        responsibility.CreatedBy = 1;
        //        responsibility.CreatedDate = DateTime.Now;

        //        context.ResponsibilitiesMasters.Update(responsibility);

        //        // ✅ Update child descriptions
        //        if (request.descriptions != null && request.descriptions.Any())
        //        {
        //            // Remove existing children for this master
        //            var existingDetails = await context.ResponsibilitiesDetails
        //                .Where(d => d.DetailsResposibilitiesId == request.ResposibilitiesId)
        //                .ToListAsync();   // <-- FIX

        //            context.ResponsibilitiesDetails.RemoveRange(existingDetails);

        //            // Insert new descriptions
        //            var details = request.descriptions.Select(item => new ResponsibilitiesDetail
        //            {
        //                DetailsResposibilitiesId = request.ResposibilitiesId,
        //                SrNo = item.srno,
        //                ResponsibilitiesDetailsDescription = item.desc
        //            }).ToList();

        //            await context.ResponsibilitiesDetails.AddRangeAsync(details);
        //        }

        //        await context.SaveChangesAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle exception (log it, rethrow it, etc.)
        //        throw new Exception("Error updating responsibility", ex);
        //    }
        //}


        public async Task UpdateResposibilitiesAsync(UpdateResposibilitiesMasterRequest request)
        {
            try
            {
                var responsibility = await context.ResponsibilitiesMasters
                    .FirstOrDefaultAsync(d => d.ResponsibilitiesId == request.ResposibilitiesId);

                if (responsibility == null)
                    throw new Exception("Responsibility not found");

                // ✅ Update master
                responsibility.ResponsibilitiesGradeId = request.ResposibilitiesGradeId;
                responsibility.ResponsibilitiesDesignationId = request.ResposibilitiesDesignationId;
                responsibility.ResponsibilitiesRemark = request.ResposibilitiesRemark;
                responsibility.ResponsibilitiesAuthRemark = request.ResposibilitiesAuthRemark;
                responsibility.ResponsibilitiesDivisionId = request.ResponsibilitiesDivisionId;
                responsibility.ResponsibilitiesAuth = request.ResposibilitiesAuth;
                responsibility.ResponsibilitiesIsDiscard = request.ResposibilitiesIsDiscard;
                responsibility.ResponsibilitiesIsActive = request.ResposibilitiesIsActive;
                responsibility.CreatedBy = 1;
                responsibility.CreatedDate = DateTime.Now;

                context.ResponsibilitiesMasters.Update(responsibility);

                // ✅ Delete old details and insert new ones
                var existingDetails = await context.ResponsibilitiesDetails
                    .Where(d => d.DetailsResposibilitiesId == request.ResposibilitiesId)
                    .ToListAsync();

                if (existingDetails.Any())
                {
                    context.ResponsibilitiesDetails.RemoveRange(existingDetails);
                }

                if (request.descriptions != null && request.descriptions.Any())
                {
                    var newDetails = request.descriptions.Select(item => new ResponsibilitiesDetail
                    {
                        DetailsResposibilitiesId = request.ResposibilitiesId,
                        SrNo = item.srno,
                        ResponsibilitiesDetailsDescription = item.desc
                    });

                    await context.ResponsibilitiesDetails.AddRangeAsync(newDetails);
                }

                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating responsibility", ex);
            }
        }


        public async Task<IEnumerable<GetResponsibilityDetailsById>> GetResponsibilityDetailsByMsaterId(int masterId)
        {
            return await context.ResponsibilitiesDetails
                .Where(r => r.DetailsResposibilitiesId == masterId)   // filter by ID
                .Select(r => new GetResponsibilityDetailsById
                {
                    ResponsibilitiesDetailsId = r.ResponsibilitiesDetailsId,
                    DetailsResposibilitiesId = r.DetailsResposibilitiesId,
                    SrNo = r.SrNo,
                    ResponsibilitiesDetailsDescription = r.ResponsibilitiesDetailsDescription
                })
                .ToListAsync();
        }

    }
}
