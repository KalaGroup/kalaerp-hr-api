using KalaGenset.ERP.HR.Core.Request.PositionDetails;
using KalaGenset.ERP.HR.Core.ResponseDTO.PositionDetails;
using KalaGenset.ERP.HR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface IPositionDetails
    {
        /// <summary>
        /// adds a new position detail to the system based on the provided request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task AddPositionDetailAsync(InsertPositionDetailRequest request);

        /// <summary>
        /// updates an existing position detail in the system based on the provided request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task UpdatePositionDetailAsync(UpdatePositionDetailRequest request);

        /// <summary>
        /// gets all position details from the system.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<PositionMasterQualificationDetail>> GetAllPositionDetailsAsync();

        /// <summary>
        /// gets position detail by ID from the system.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<PositionMasterQualificationDetail> GetPositionDetailById(int id);

        /// <summary>
        /// deletes a position detail from the system based on its unique identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task DeletePositionDetailAsync(int id);

        /// <summary>
        /// gets position details from the system based on grade, designation, and division.
        /// </summary>
        /// <param name="gradeId"></param>
        /// <param name="designationId"></param>
        /// <param name="divisionId"></param>
        /// <returns></returns>
        public Task<IEnumerable<PositionDetailsResponseDTO>> GetPositionDetailsByCombination(int gradeId, int designationId, int divisionId);

    }
}
