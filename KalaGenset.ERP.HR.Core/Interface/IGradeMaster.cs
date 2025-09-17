using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KalaGenset.ERP.HR.Data.Models;
using KalaGenset.ERP.HR.Core.Request.Grade;
using KalaGenset.ERP.HR.Core.ResponseDTO.GradeMaster;

namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface IGradeMaster
    {
        /// <summary>
        /// Adds a new grade to the database.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task AddGradeDetailsAsync(InsertGradeRequest request);
        /// <summary>
        /// Updates an existing grade in the database.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task UpdateGradeDetailsAsync(UpdateGradeDetailsRequest request);
        /// <summary>
        /// Retrieves all Grades from the database.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<GradeMaster>> GetGradeDetailsAsync();
        /// <summary>
        /// Retrieves a grade by its ID from the database.
        /// </summary>
        /// <param name="GradeId"></param>
        /// <returns></returns>
        public Task<GradeMaster?> GetGradeById(int GradeId);
        /// <summary>
        /// Deletes a grade by its ID from the database.
        /// </summary>
        /// <param name="gid"></param>
        /// <returns></returns>
        public Task DeleteGradeAsync(int gid);

        //Get Grade Id and Name
        public Task<List<GradeIdAndNameResponseDTO>> GetGradeIdAndNameFromDB();

        //Get Grade Details along with designation and facility
        public Task<List<GradeWithDetailsResponseDTO>> GetAllGradesWithDetailsAsync();

        //Delete Grade and its dependency
        public Task DeleteGradeDetailsAsync(int gradeId);
    }
}
