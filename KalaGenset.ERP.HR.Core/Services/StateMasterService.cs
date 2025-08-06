using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.StateRequest;
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
    public class StateMasterService : IStateMaster
    {
        private readonly KalaDbContext _context;

        public StateMasterService(KalaDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Add State
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>

        public async Task AddStateAsync(InsertStateRequest request)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var state = new StateMaster
                {
                    CountryId = request.CountryId,
                    StateCode = request.StateCode,
                    StateName = request.StateName,
                    ShortName = request.ShortName,
                    IsDiscard = request.IsDiscard,
                    IsActive = request.IsActive,
                    CreatedBy = request.CreatedBy,
                    CreatedDate = request.CreatedDate,
                };

                _context.StateMasters.Add(state);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// Get State details
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<StateMaster>> GetStateDetailsAsync()
        {
            return await _context.StateMasters.ToListAsync();
            // return await _context.Companies.Where(c => c.IsActive == true).ToListAsync();
            //return await _context.StateMsts.OrderByDescending(c => c.StateId).ToListAsync();
        }
        /// <summary>
        /// Update state details
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task UpdateStateAsync(UpdateStateRequest request)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var state = await _context.StateMasters.FindAsync(request.StateId);

                // Update fields
                state.CountryId = request.CountryId;
                state.StateCode = request.StateCode;
                state.StateName = request.StateName;
                state.ShortName = request.ShortName;
                state.IsDiscard = request.IsDiscard;
                state.IsActive = request.IsActive;
                state.CreatedBy = request.CreatedBy;
                state.CreatedDate = request.CreatedDate;
                _context.Entry(state).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Get State By ID
        /// </summary>
        /// <param name="StateId"></param>
        /// <returns></returns>

        public async Task<StateMaster?> GetStateByID(int StateId)
        {
            try
            {
                return await _context.StateMasters.FirstOrDefaultAsync(c => c.StateId == StateId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Delete State By ID
        /// </summary>
        /// <param name="sid"></param>
        /// <returns></returns>

        public async Task DeleteStateAsync(int sid)
        {
            try
            {
                var state = await _context.StateMasters.FirstOrDefaultAsync(c => c.StateId == sid);

                state.IsActive = false;

                _context.StateMasters.Update(state);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
