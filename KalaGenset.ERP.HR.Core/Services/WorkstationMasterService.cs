using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.LocationRequest;
using KalaGenset.ERP.HR.Core.Request.Workstation;
using KalaGenset.ERP.HR.Core.ResponseDTO.WorkstationMaster;
using KalaGenset.ERP.HR.Data.DbContexts;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Services
{
    public class WorkstationMasterService : IWorkstationMaster
    {
        private readonly KalaDbContext _context;

        public WorkstationMasterService(KalaDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// This is Add Code
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task AddWorkStationAsync(InsertWorkstationRequest request)
        {
            try
            {
                var WorkStation = new WorkStationMaster
                {
                    WorkStationCode = request.WorkStationCode,
                    WorkStationName = request.WorkStationName,
                    WorkStationShortName = request.WorkStationShortName,
                    WorkStationProfitcenterId = request.WorkStationProfitcenterId,
                    WorkStationRemark = request.WorkStationRemark,
                    WorkStationAuthRemark = request.WorkStationAuthRemark,
                    WorkStationAuth = request.WorkStationAuth,
                    WorkStationIsDiscard = request.WorkStationIsDiscard,
                    WorkStationIsActive = request.WorkStationIsActive,
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now,
                };

                _context.WorkStationMasters.Add(WorkStation);
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
        public async Task DeleteWorkStationAsync(int wid)
        {
            try
            {
                var WorkStation = await _context.WorkStationMasters.FirstOrDefaultAsync(c => c.WorkStationId == wid);

                WorkStation.WorkStationIsActive = false;

                _context.WorkStationMasters.Update(WorkStation);
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
        public async Task<WorkStationMaster?> GetWorkStationByID(int Id)
        {
            return await _context.WorkStationMasters.FirstOrDefaultAsync(c => c.WorkStationId == Id);

        }

        /// <summary>
        /// This is Get Code for All Workstation Details
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<WorkstationMasterResponseDTO>> GetWorkStationDetailsAsync()
        {
            var result = await (from ws in _context.WorkStationMasters
                                join pc in _context.ProfitcenterMasters
                                on ws.WorkStationProfitcenterId equals pc.ProfitCenterId
                                where ws.WorkStationIsActive == true   // ✅ Only active records
                                select new WorkstationMasterResponseDTO
                                {
                                    WorkStationId = ws.WorkStationId,
                                    WorkStationCode = ws.WorkStationCode,
                                    WorkStationName = ws.WorkStationName,
                                    WorkStationShortName = ws.WorkStationShortName,
                                    WorkStationProfitcenterId = ws.WorkStationProfitcenterId,
                                    ProfitCenterName = pc.ProfitCenterName,
                                    WorkStationIsDiscard = ws.WorkStationIsDiscard,
                                    WorkStationRemark = ws.WorkStationRemark,
                                    WorkStationAuthRemark = ws.WorkStationAuthRemark,
                                    WorkStationIsActive = ws.WorkStationIsActive,
                                    CreatedBy = ws.CreatedBy,
                                    CreatedDate = ws.CreatedDate
                                }).ToListAsync();

            return result;
        }




        /// <summary>
        /// This is Update Code
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task UpdateWorkStationAsync(UpdateWorkstationRequest request)
        {
            try
            {
                var WorkStation = await _context.WorkStationMasters.FindAsync(request.WorkStationId);

                // Update fields
                WorkStation.WorkStationCode = request.WorkStationCode;
                WorkStation.WorkStationName = request.WorkStationName;
                WorkStation.WorkStationShortName = request.WorkStationShortName;
                WorkStation.WorkStationProfitcenterId = request.WorkStationProfitcenterId;
                WorkStation.WorkStationRemark = request.WorkStationRemark;
                WorkStation.WorkStationAuthRemark = request.WorkStationAuthRemark;
                WorkStation.WorkStationAuth = request.WorkStationAuth;
                WorkStation.WorkStationIsDiscard = request.WorkStationIsDiscard;
                WorkStation.WorkStationIsActive = request.WorkStationIsActive;
                WorkStation.CreatedBy = request.CreatedBy;
                WorkStation.CreatedDate = request.CreatedDate;
                _context.WorkStationMasters.Update(WorkStation);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
