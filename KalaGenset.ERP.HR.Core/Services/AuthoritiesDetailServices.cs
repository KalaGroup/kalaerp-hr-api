using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.AuthoritiesDetail;
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
    public class AuthoritiesDetailServices : IAuthoritiesDetail
    {
        private readonly KalaDbContext context;    
        public AuthoritiesDetailServices(KalaDbContext context)
        {
            this.context = context ;
        }
        /// <summary>
        /// Adds a new authorities detail to the system based on the provided request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Task AddAuthoritiesDetailAsync(InsertAuthoritiesDetailRequest request)
        {
            try
            {
                var authoritiesDetail = new AuthoritiesDetail
                {
                    DetailsAuthoritiesId = request.DetailsAuthoritiesId,
                    SrNo = request.SrNo,
                    AuthoritiesDetailsDescription = request.AuthoritiesDetailsDescription,
                };
                context.AuthoritiesDetails.Add(authoritiesDetail);
                return context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new Exception("An error occurred while adding authorities detail.", ex);
            }
        }
        /// <summary>
        /// deletes an authorities detail from the system based on its unique identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Task DeleteAuthoritiesDetailAsync(int id)
        {
            try
            {
                var authoritiesDetail = context.AuthoritiesDetails.FirstOrDefault(c => c.AuthoritiesDetailsId == id);
                if (authoritiesDetail == null)
                {
                    throw new Exception("Authorities detail not found.");
                }
                context.AuthoritiesDetails.Remove(authoritiesDetail);
                return context.SaveChangesAsync();  
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new Exception("An error occurred while deleting authorities detail.", ex);
            }
        }
        /// <summary>
        /// gets all authorities details from the system.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<AuthoritiesDetail>> GetAllAuthoritiesDetailsAsync()
        {
            return await context.AuthoritiesDetails.ToListAsync();
        }
        /// <summary>
        /// gets authorities detail by ID from the system.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<AuthoritiesDetail> GetAuthoritiesDetailByID(int id)
        {
           return await context.AuthoritiesDetails.FirstOrDefaultAsync(c => c.AuthoritiesDetailsId == id);
        }
        /// <summary>
        /// updates an existing authorities detail in the system based on the provided request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Task UpdateAuthoritiesDetailAsync(UpdateAuthoritiesaDetailsRequest request)
        {
            try
            {
                var authoritiesDetail = context.AuthoritiesDetails.FirstOrDefault(c => c.AuthoritiesDetailsId == request.AuthoritiesDetailsId);

                if (authoritiesDetail == null)
                {
                    throw new Exception("Authorities detail not found.");
                }
                authoritiesDetail.DetailsAuthoritiesId = request.DetailsAuthoritiesId;
                authoritiesDetail.SrNo = request.SrNo;
                authoritiesDetail.AuthoritiesDetailsDescription = request.AuthoritiesDetailsDescription;
                context.AuthoritiesDetails.Update(authoritiesDetail);
                return context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new Exception("An error occurred while updating authorities detail.", ex);
            }
        }
    }
}
