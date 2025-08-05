using KalaGenset.ERP.HR.Core.Request.Facility;
using KalaGenset.ERP.HR.Core.Request.GradeFacilityAssignment;
using KalaGenset.ERP.HR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface IGradeFacilityAssignment
    {
        /// <summary>
        /// Add Grade Facility Assignment 
        /// </summary>
        /// <param name="insertGradeFacilityAssignmentRequest"></param>
        /// <returns></returns>
        public Task AddGradeFacilityAssignmentAsync(InsertGradeFacilityAssignmentRequest insertGradeFacilityAssignmentRequest);

        /// <summary>
        /// Update Grade Facility Assignment
        /// </summary>
        /// <param name="updateGradeFacilityAssignmentRequest"></param>
        /// <returns></returns>
        public Task UpdateGradeFacilityAssignmentAsync(UpdateGradeFacilityAssignmentRequest updateGradeFacilityAssignmentRequest);

        /// <summary>
        /// To Get All Grade Facilities
        /// </summary>
        /// <returns></returns>
        public Task <IEnumerable<GradeFacilityAssignment>> GetAllGradeFacilityAssignmentsAsync();

        /// <summary>
        /// To get Grade Facilities  By Id
        /// </summary> 
        /// <param name="gradeFacilityAssignmentId"></param>
        /// <returns></returns>
        public Task<GradeFacilityAssignment?> GetGradeFacilityAssignmentsByIdAsync(int gradeFacilityAssignmentId);

        public Task DeleteGradeFacilityAsync(int gradeFacilityId);
    }
}
