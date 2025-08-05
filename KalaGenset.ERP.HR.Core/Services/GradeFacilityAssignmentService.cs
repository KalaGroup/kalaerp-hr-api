using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.Facility;
using KalaGenset.ERP.HR.Core.Request.GradeFacilityAssignment;
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
    public class GradeFacilityAssignmentService : IGradeFacilityAssignment
    {
        private readonly KalaDbContext _context;

        public GradeFacilityAssignmentService(KalaDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Insert Grande Facility Assignment
        /// </summary>
        /// <param name="insertGradeFacilityAssignmentRequest"></param>
        /// <returns></returns>
        public async Task AddGradeFacilityAssignmentAsync(InsertGradeFacilityAssignmentRequest insertGradeFacilityAssignmentReq)
        {
            try
            {
                var gradeFacilityAssignmentRequest = new GradeFacilityAssignment
                {
                  // GradeFacilityAssignmentId = insertGradeFacilityAssignmentRequest.GradeFacilityAssignmentId,
                    AssignmentGradeId = insertGradeFacilityAssignmentReq.AssignmentGradeId,
                    AssignmentFacilityId = insertGradeFacilityAssignmentReq.AssignmentFacilityId                  

                };

                _context.GradeFacilityAssignments.Add(gradeFacilityAssignmentRequest);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
                
        /// <summary>
        /// Get All Grade Facility Assignment
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<GradeFacilityAssignment>> GetAllGradeFacilityAssignmentsAsync()
        {
            return await _context.GradeFacilityAssignments.ToListAsync();
        }

        /// <summary>
        /// Get GradeFacility by GradeFacilityAssignment Id
        /// </summary>
        /// <param name="gradeFacilityAssignmentId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<GradeFacilityAssignment?> GetGradeFacilityAssignmentsByIdAsync(int gradeFacilityAssignmentId)
        {
            if (await _context.GradeFacilityAssignments.FirstOrDefaultAsync(c => c.GradeFacilityAssignmentId == gradeFacilityAssignmentId) == null)
            {
                throw new Exception("Grade Facility Assignment Id Not available");
            }

            return await _context.GradeFacilityAssignments.FirstOrDefaultAsync(f => f.GradeFacilityAssignmentId == gradeFacilityAssignmentId);
           
        }
                
        /// <summary>
        /// Update Grade Facility Assignment 
        /// </summary>
        /// <param name="updateGradeFacilityAssignmentRequest"></param>
        /// <returns></returns>
        public async Task UpdateGradeFacilityAssignmentAsync(UpdateGradeFacilityAssignmentRequest updtGradeFacilityAssignmentReq)
        {
            try
            {
                var gradeFacilityAssignmentRequest = await _context.GradeFacilityAssignments.FindAsync(updtGradeFacilityAssignmentReq.GradeFacilityAssignmentId);
                if (gradeFacilityAssignmentRequest == null)
                {
                    throw new Exception("grade Facility Assignment Request Id not found.");
                }

                gradeFacilityAssignmentRequest.AssignmentFacilityId = updtGradeFacilityAssignmentReq.AssignmentFacilityId;
                gradeFacilityAssignmentRequest.AssignmentGradeId = updtGradeFacilityAssignmentReq.AssignmentGradeId;                        

                await _context.SaveChangesAsync();
            }
            catch
            {
                throw; // Let the controller handle the error
            }
        }

        public async Task DeleteGradeFacilityAsync(int gradeFacilityId)
        {
            try
            {
                var gradefacilityId= await _context.GradeFacilityAssignments.FirstOrDefaultAsync(f => f.GradeFacilityAssignmentId == gradeFacilityId);
               // gradefacilityId.FacilityIsActive = false; //Need IsActive Column
               // _context.GradeFacilityAssignments.Update(gradeFacilityId);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
