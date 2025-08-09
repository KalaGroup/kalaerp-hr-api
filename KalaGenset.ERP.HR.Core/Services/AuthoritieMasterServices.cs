using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.AuthoritieMaster;
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
        public Task AddAuthoritieAsync(InsertAuthoritieMasterRequest request)
        {
            try
            {
                var authoritie = new AuthoritiesMaster
                {
                    AuthoritiesGradeId = request.AuthoritiesGradeId,
                    AuthoritiesDesignationId = request.AuthoritiesDesignationId,
                    AuthoritiesRemark = request.AuthoritiesRemark,
                    AuthoritiesType = request.AuthoritiesType,
                    AuthoritiesAuthRemark = request.AuthoritiesAuthRemark,
                    AuthoritiesAuth = request.AuthoritiesAuth,
                    AuthoritiesIsDiscard = request.AuthoritiesIsDiscard,
                    AuthoritiesIsActive = request.AuthoritiesIsActive,
                    CreatedBy = request.CreatedBy,
                    CreatedDate = request.CreatedDate
                };
                _context.AuthoritiesMasters.Add(authoritie);
                return _context.SaveChangesAsync();
            }
            catch
            {
                throw;// rethrow the exception to be handled by the caller
            }
        }
        /// <summary>
        /// deletes an authoritie from the system based on its unique identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Task DeleteAuthoritieAsync(int id)
        {
            var authoritie = _context.AuthoritiesMasters.FirstOrDefault(c => c.AuthoritiesId == id);
            if (authoritie != null)
            {
                authoritie.AuthoritiesIsActive = false;
                authoritie.AuthoritiesIsDiscard = false;
                _context.AuthoritiesMasters.Update(authoritie);
                return _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Authoritie not found");
            }
        }
        /// <summary>
        /// gets all authoritie details from the system.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<AuthoritiesMaster>> GetAllAuthoritieDetailsAsync()
        {
            return await _context.AuthoritiesMasters.ToListAsync();
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
                var authoritie =await _context.AuthoritiesMasters.FirstOrDefaultAsync(c => c.AuthoritiesId == request.AuthoritiesId);

                authoritie.AuthoritiesAuth = request.AuthoritiesAuth;
                authoritie.AuthoritiesAuthRemark = request.AuthoritiesAuthRemark;
                authoritie.AuthoritiesDesignationId = request.AuthoritiesDesignationId;
                authoritie.AuthoritiesGradeId = request.AuthoritiesGradeId;
                authoritie.AuthoritiesIsActive = request.AuthoritiesIsActive;
                authoritie.AuthoritiesIsDiscard = request.AuthoritiesIsDiscard;
                authoritie.AuthoritiesRemark = request.AuthoritiesRemark;
                authoritie.AuthoritiesType = request.AuthoritiesType;
                authoritie.CreatedBy = request.CreatedBy;
                authoritie.CreatedDate = request.CreatedDate;
                _context.AuthoritiesMasters.Update(authoritie);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)// Catching the exception to provide a more specific error message
            {
                throw new Exception("Error updating authoritie: " + ex.Message);// Rethrow the exception with a custom message
            }
        }
    }
}
