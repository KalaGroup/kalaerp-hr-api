using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.AuthoritiesDetail;
using KalaGenset.ERP.HR.Core.Request.PositionDetails;
using KalaGenset.ERP.HR.Core.ResponseDTO.AuthoritiesDetails;
using KalaGenset.ERP.HR.Core.ResponseDTO.PositionDetails;
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
    public class PositionDetailService : IPositionDetails
    {
        private readonly KalaDbContext context;
        public PositionDetailService(KalaDbContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// Adds a new authorities detail to the system based on the provided request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Task AddPositionDetailAsync(InsertPositionDetailRequest request)
        {
            try
            {
                var positionDetail = new PositionMasterQualificationDetail
                {
                    DetailsPositionMasterId = request.DetailsPositionMasterId,
                    PositionQualificationId = request.PositionQualificationId,
                    SrNo = request.SrNo,
                    PositionMasterQualificationDetailsDescription = request.PositionMasterQualificationDetailsDescription,
                };

                context.PositionMasterQualificationDetails.Add(positionDetail);
                return context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new Exception("An error occurred while adding position detail.", ex);
            }
        }

        /// <summary>
        /// deletes an authorities detail from the system based on its unique identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Task DeletePositionDetailAsync(int id)
        {
            try
            {
                var positionDetail = context.PositionMasterQualificationDetails.FirstOrDefault(c => c.PositionQualificationDetailsId == id);

                if (positionDetail == null)
                {
                    throw new Exception("Position detail not found.");
                }

                context.PositionMasterQualificationDetails.Remove(positionDetail);
                return context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new Exception("An error occurred while deleting position detail.", ex);
            }
        }

        /// <summary>
        /// gets all authorities details from the system.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<PositionMasterQualificationDetail>> GetAllPositionDetailsAsync()
        {
            return await context.PositionMasterQualificationDetails.ToListAsync();
        }

        /// <summary>
        /// gets authorities detail by ID from the system.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<PositionMasterQualificationDetail> GetPositionDetailById(int id)
        {
            return await context.PositionMasterQualificationDetails.FirstOrDefaultAsync(c => c.PositionQualificationDetailsId == id);
        }

        /// <summary>
        /// updates an existing authorities detail in the system based on the provided request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Task UpdatePositionDetailAsync(UpdatePositionDetailRequest request)
        {
            try
            {
                var positionDetail = context.PositionMasterQualificationDetails.FirstOrDefault(c => c.PositionQualificationDetailsId == request.PositionQualificationDetailsId);

                if (positionDetail == null)
                {
                    throw new Exception("Position detail not found.");
                }

                positionDetail.DetailsPositionMasterId = request.DetailsPositionMasterId;
                positionDetail.PositionQualificationId = request.PositionQualificationId;
                positionDetail.SrNo = request.SrNo;
                positionDetail.PositionMasterQualificationDetailsDescription = request.PositionMasterQualificationDetailsDescription;

                context.PositionMasterQualificationDetails.Update(positionDetail);
                return context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new Exception("An error occurred while updating position detail.", ex);
            }
        }


        public async Task<IEnumerable<PositionDetailsResponseDTO>> GetPositionDetailsByCombination(int gradeId, int designationId, int divisionId)
        {
            var result = await (from p in context.PositionMasters
                                join pd in context.PositionMasterQualificationDetails
                                    on p.PositionMasterId equals pd.DetailsPositionMasterId
                                where p.PositionMasterGradeId == gradeId
                                      && p.PositionMasterDesignationId == designationId
                                      && p.PositionMasterDivisionId == divisionId
                                      && p.PositionMasterIsActive == true
                                select new PositionDetailsResponseDTO
                                {
                                    PositionMasterId = p.PositionMasterId,
                                    PositionQualificationDetailsId = pd.PositionQualificationDetailsId,
                                    SrNo = pd.SrNo,
                                    PositionQualificationId = pd.PositionQualificationId,
                                    PositionMasterQualificationDetailsDescription = pd.PositionMasterQualificationDetailsDescription
                                }).ToListAsync();

            return result;
        }

    }
}
