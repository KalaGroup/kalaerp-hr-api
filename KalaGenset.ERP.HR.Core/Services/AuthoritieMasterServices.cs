using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.AuthoritieMaster;
using KalaGenset.ERP.HR.Core.ResponseDTO.AuthoritiesMaster;
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
    public class AuthoritieMasterServices : IAuthoritieMaster
    {
        /// <summary>
        /// service for managing authorities in the system.
        /// </summary>
        private readonly KalaDbContext _context;
        /// <summary>
        /// constructor for initializing the AuthoritieMasterServices with the database context.
        /// </summary>
        /// <param name="context"></param>
        public AuthoritieMasterServices(KalaDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// adds a new authoritie to the system based on the provided request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task AddAuthoritieAsync(InsertAuthoritieMasterRequest request)
        {
            try
            {
                // Insert into master table
                var authoritie = new AuthoritiesMaster
                {
                    AuthoritiesGradeId = request.AuthoritiesGradeId,
                    AuthoritiesDesignationId = request.AuthoritiesDesignationId,
                    AuthoritiesRemark = request.AuthoritiesRemark,
                    AuthoritiesDivisionId = request.AuthoritiesDivisionId,
                    AuthoritiesAuthRemark = request.AuthoritiesAuthRemark,
                    AuthoritiesAuth = request.AuthoritiesAuth,
                    AuthoritiesIsDiscard = request.AuthoritiesIsDiscard,
                    AuthoritiesIsActive = request.AuthoritiesIsActive,
                    CreatedBy = request.CreatedBy,
                    CreatedDate = request.CreatedDate,
                    UpdatedBy = request.UpdatedBy,
                    UpdatedDate = request.UpdatedDate,
                };

                _context.AuthoritiesMasters.Add(authoritie);
                await _context.SaveChangesAsync();

                // ✅ Retrieve auto-generated master ID
                int authoritieMstId = authoritie.AuthoritiesId;

                // Insert child details (if any)
                if (request.descriptions != null && request.descriptions.Any())
                {
                    var details = request.descriptions.Select(item => new AuthoritiesDetail
                    {
                        DetailsAuthoritiesId = authoritieMstId, // FK to master
                        SrNo = item.srno,
                        AuthoritiesDetailsDescription = item.desc
                    }).ToList();

                    _context.AuthoritiesDetails.AddRange(details);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding authority", ex);
            }
        }

        /// <summary>
        /// deletes an authoritie from the system based on its unique identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task DeleteAuthoritieAsync(int id)
        {
            try
            {
                var authoritie = await _context.AuthoritiesMasters
                    .FirstOrDefaultAsync(c => c.AuthoritiesId == id);

                if (authoritie == null)
                    throw new Exception("Authoritie not found");

                // ✅ Get child details
                var details = await _context.AuthoritiesDetails
                    .Where(d => d.DetailsAuthoritiesId == id)
                    .ToListAsync();

                // ✅ Remove child details
                if (details.Any())
                {
                    _context.AuthoritiesDetails.RemoveRange(details);
                }

                // ✅ Soft delete master
                authoritie.AuthoritiesIsActive = false;
                authoritie.AuthoritiesIsDiscard = false;

                _context.AuthoritiesMasters.Update(authoritie);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting authoritie", ex);
            }
        }

        /// <summary>
        /// gets all authoritie details from the system.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<AuthoritiesMasterResponseDTO>> GetAllAuthoritieDetailsAsync()
        {
            var result = await (from a in _context.AuthoritiesMasters
                                join g in _context.GradeMasters
                                    on a.AuthoritiesGradeId equals g.GradeId
                                join d in _context.DesignationMasters
                                    on a.AuthoritiesDesignationId equals d.DesignationId
                                join div in _context.DivisionMasters
                                    on a.AuthoritiesDivisionId equals div.DivisionId
                                where a.AuthoritiesIsActive == true   // ✅ Only active records
                                select new AuthoritiesMasterResponseDTO
                                {
                                    AuthoritiesId = a.AuthoritiesId,
                                    AuthoritiesGradeId = a.AuthoritiesGradeId,
                                    GradeName = g.GradeName,
                                    AuthoritiesDesignationId = a.AuthoritiesDesignationId,
                                    DesignationName = d.DesignationName,
                                    AuthoritiesDivisionId = a.AuthoritiesDivisionId,
                                    DivisionName = div.DivisionName,
                                    AuthoritiesRemark = a.AuthoritiesRemark,
                                    AuthoritiesAuthRemark = a.AuthoritiesAuthRemark,
                                    AuthoritiesAuth = a.AuthoritiesAuth,
                                    AuthoritiesIsDiscard = a.AuthoritiesIsDiscard,
                                    AuthoritiesIsActive = a.AuthoritiesIsActive,
                                    CreatedBy = a.CreatedBy,
                                    CreatedDate = a.CreatedDate
                                }).ToListAsync();
            return result;
        }

        /// <summary>
        /// gets an authoritie by its unique identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<AuthoritiesMaster> GetAuthoritieByID(int id)
        {
            return await _context.AuthoritiesMasters.FirstOrDefaultAsync(c => c.AuthoritiesId == id);
               
        }
        /// <summary>
        /// updates an existing authoritie in the system based on the provided request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task UpdateAuthoritieAsync(UpdateAuthoritieMasterRequest request)
        {
            try
            {
                var authoritie = await _context.AuthoritiesMasters
                    .FirstOrDefaultAsync(c => c.AuthoritiesId == request.AuthoritiesId);

                if (authoritie == null)
                    throw new Exception("Authoritie not found");

                // ✅ Update master
                authoritie.AuthoritiesGradeId = request.AuthoritiesGradeId;
                authoritie.AuthoritiesDesignationId = request.AuthoritiesDesignationId;
                authoritie.AuthoritiesRemark = request.AuthoritiesRemark;
                authoritie.AuthoritiesAuthRemark = request.AuthoritiesAuthRemark;
                authoritie.AuthoritiesDivisionId = request.AuthoritiesDivisionId;
                authoritie.AuthoritiesAuth = request.AuthoritiesAuth;
                authoritie.AuthoritiesIsDiscard = request.AuthoritiesIsDiscard;
                authoritie.AuthoritiesIsActive = request.AuthoritiesIsActive;
                authoritie.CreatedBy = request.CreatedBy;
                authoritie.CreatedDate = request.CreatedDate;
                authoritie.UpdatedBy = request.UpdatedBy;
                authoritie.UpdatedDate = request.UpdatedDate;

                _context.AuthoritiesMasters.Update(authoritie);

                // ✅ Delete old details
                var existingDetails = await _context.AuthoritiesDetails
                    .Where(d => d.DetailsAuthoritiesId == request.AuthoritiesId)
                    .ToListAsync();

                if (existingDetails.Any())
                {
                    _context.AuthoritiesDetails.RemoveRange(existingDetails);
                }

                // ✅ Insert new details
                if (request.descriptions != null && request.descriptions.Any())
                {
                    var newDetails = request.descriptions.Select(item => new AuthoritiesDetail
                    {
                        DetailsAuthoritiesId = request.AuthoritiesId,
                        SrNo = item.srno,
                        AuthoritiesDetailsDescription = item.desc
                    });

                    await _context.AuthoritiesDetails.AddRangeAsync(newDetails);
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating authoritie", ex);
            }
        }


        public async Task<IEnumerable<GetAuthoritiesDetailsById>> GetAuthoritiesDetailsByMsaterId(int masterId)
        {
            return await _context.AuthoritiesDetails
                .Where(r => r.DetailsAuthoritiesId == masterId)   // filter by ID
                .Select(r => new GetAuthoritiesDetailsById
                {
                    AuthoritiesDetailsId = r.AuthoritiesDetailsId,
                    DetailsAuthoritiesId = r.DetailsAuthoritiesId,
                    SrNo = r.SrNo,
                    AuthoritiesDetailsDescription = r.AuthoritiesDetailsDescription
                })
                .ToListAsync();
        }
    }
}
