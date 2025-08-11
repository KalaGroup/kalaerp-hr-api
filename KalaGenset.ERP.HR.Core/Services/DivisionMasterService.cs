using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.DivisionMaster;
using KalaGenset.ERP.HR.Core.Request.Workstation;
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
    public class DivisionMasterService : IDivisionMaster
    {
        private readonly KalaDbContext _context;

        public DivisionMasterService(KalaDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// This is Add Code
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task AddDivisionAsync(InsertDivisionMasterRequest request)
        {
            try
            {
                var Division = new DivisionMaster
                {
                    DivisionCode = request.DivisionCode,
                    DivisionName = request.DivisionName,
                    DivisionShortName = request.DivisionShortName,
                    DivisionMailId = request.DivisionMailId,
                    DivisionRemark = request.DivisionRemark,
                    DivisionAuthRemark = request.DivisionAuthRemark,
                    DivisionAuth = request.DivisionAuth,
                    DivisionIsDiscard = request.DivisionIsDiscard,
                    DivisionIsActive = request.DivisionIsActive,
                    CreatedBy = request.CreatedBy,
                    CreatedDate = request.CreatedDate,
                };

                _context.DivisionMasters.Add(Division);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }

        }


        /// <summary>
        /// This is Delete Code
        /// </summary>
        /// <param name="wid"></param>
        /// <returns></returns>
        public async Task DeleteDivisionAsync(int did)
        {
            try
            {
                var Division = await _context.DivisionMasters.FirstOrDefaultAsync(c => c.DivisionId == did);

                Division.DivisionIsActive = false;

                _context.DivisionMasters.Update(Division);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        /// <summary>
        /// This is Get Code By ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<DivisionMaster?> GetDivisionByID(int Id)
        {
            return await _context.DivisionMasters.FirstOrDefaultAsync(c => c.DivisionId == Id);

        }

        /// <summary>
        /// This is Get Code for All Workstation Details
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DivisionMaster>> GetDivisionDetailsAsync()
        {
            return await _context.DivisionMasters.ToListAsync();
        }


        /// <summary>
        /// This is Update Code
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task UpdateDivisionAsync(UpdateDivisionMasterRequest request)
        {
            try
            {
                var Division = await _context.DivisionMasters.FindAsync(request.DivisionId);

                // Update fields
                Division.DivisionCode = request.DivisionCode;
                Division.DivisionName = request.DivisionName;
                Division.DivisionShortName = request.DivisionShortName;
                Division.DivisionMailId = request.DivisionMailId;
                Division.DivisionRemark = request.DivisionRemark;
                Division.DivisionAuthRemark = request.DivisionAuthRemark;
                Division.DivisionAuth = request.DivisionAuth;
                Division.DivisionIsDiscard = request.DivisionIsDiscard;
                Division.DivisionIsActive = request.DivisionIsActive;
                Division.CreatedBy = request.CreatedBy;
                Division.CreatedDate = request.CreatedDate;
                _context.DivisionMasters.Update(Division);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
