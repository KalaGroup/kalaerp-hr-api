using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.StateRequest;
using KalaGenset.ERP.HR.Core.ResponseDTO.StateMaster;
using KalaGenset.ERP.HR.Data.DbContexts;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.EntityFrameworkCore;

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
                    CreatedBy = "1", // Hardcoded as string
                    CreatedDate = DateTime.Now,
                };

                _context.StateMasters.Add(state);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Get State details
        /// </summary>
        /// <returns></returns>
        /// 

        public async Task<IEnumerable<StateMasterResponseDTO>> GetStateDetailsAsync()
        {
            var result = await (from state in _context.StateMasters
                                join country in _context.CountryMasters
                                on state.CountryId equals country.CountryId
                                select new StateMasterResponseDTO
                                {
                                    StateId = state.StateId,
                                    StateCode = state.StateCode,
                                    StateName = state.StateName,
                                    ShortName = state.ShortName,
                                    CountryName = country.CountryName,
                                    CountryId = state.CountryId,
                                    IsActive = state.IsActive,
                                    IsDiscard = state.IsDiscard,
                                    CreatedBy = state.CreatedBy,
                                    CreatedDate = state.CreatedDate
                                }).ToListAsync();

            return result;
        }

        /// <summary>
        /// Update state details
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task UpdateStateAsync(UpdateStateRequest request)
        {
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

        /// <summary>
        /// Get State Details By Country ID
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<StateDetailsByCountryIdDTO>> GetStateDetailsByCountryId(int countryId)
        {
            try
            {
                var states = await _context.StateMasters
                    .Where(s => s.CountryId == countryId && s.IsActive)
                    .Select(s => new StateDetailsByCountryIdDTO
                    {
                        StateId = s.StateId,
                        StateName = s.StateName,                        
                    })
                    .ToListAsync();

                return states;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
