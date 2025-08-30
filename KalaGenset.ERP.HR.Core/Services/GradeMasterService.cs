using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KalaGenset.ERP.HR.Data.DbContexts;
using KalaGenset.ERP.HR.Data.Models;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.Grade;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using KalaGenset.ERP.HR.Core.ResponseDTO.GradeMaster;

namespace KalaGenset.ERP.HR.Core.Services
{
    public class GradeMasterService : IGradeMaster
    {
        private readonly KalaDbContext _context;
        public GradeMasterService(KalaDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Adds a new grade to the database.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task AddGradeAsync(InsertGradeRequest request)
        {
            try
            {
                var grade = new GradeMaster
                {
                    GradeCode = request.GradeCode,
                    GradeName = request.GradeName,
                    GradeLevel = request.GradeLevel,
                    MinSalCtc = request.MinSalCtc,
                    MaxSalCtc = request.MaxSalCtc,
                    GradeCurrencyId = request.GradeCurrencyId,
                    GradeDescription = request.GradeDescription,
                    LeaveEntitlementAnnual = request.LeaveEntitlementAnnual,
                    ProbationPeriod = request.ProbationPeriod,
                    NoticePeriod = request.NoticePeriod,
                    GradeRemark = request.GradeRemark,
                    GradeAuth = request.GradeAuth,
                    GradeIsDiscard = request.GradeIsDiscard,
                    GradeIsActive = request.GradeIsActive,
                    CreatedBy = request.CreatedBy,
                    CreatedDate = request.CreatedDate
                };
                _context.GradeMasters.Add(grade);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Updates an existing grade in the database.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task UpdateGradeAsync(UpdateGradeRequest request)
        {
            try
            {
                var grade = await _context.GradeMasters.FirstOrDefaultAsync(c => c.GradeId == request.GradeId);
                if (grade == null)
                {
                    throw new Exception("Grade not found.");
                }
                grade.GradeId = request.GradeId;
                grade.GradeCode = request.GradeCode;
                grade.GradeName = request.GradeName;
                grade.GradeLevel = request.GradeLevel;
                grade.MinSalCtc = request.MinSalCtc;
                grade.MaxSalCtc = request.MaxSalCtc;
                grade.GradeCurrencyId = request.GradeCurrencyId;
                grade.GradeDescription = request.GradeDescription;
                grade.LeaveEntitlementAnnual = request.LeaveEntitlementAnnual;
                grade.ProbationPeriod = request.ProbationPeriod;
                grade.NoticePeriod = request.NoticePeriod;
                grade.GradeRemark = request.GradeRemark;
                grade.GradeAuth = request.GradeAuth;
                grade.GradeIsDiscard = request.GradeIsDiscard;
                grade.GradeIsActive = request.GradeIsActive;
                grade.CreatedBy = request.CreatedBy;
                _context.GradeMasters.Update(grade);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Retrieves all Grades from the database.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<GradeMaster>> GetGradeDetailsAsync()
        {
            return await _context.GradeMasters.OrderBy(c => c.GradeId).ToListAsync();
        }
        /// <summary>
        /// Retrieves a grade by its ID from the database.
        /// </summary>
        /// <param name="GradeId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<GradeMaster?> GetGradeById(int GradeId)
        {
            if (await _context.GradeMasters.FirstOrDefaultAsync(c => c.GradeId == GradeId) == null)
            {
                throw new Exception("ID Not available");
            }
            return await _context.GradeMasters.FirstOrDefaultAsync(c => c.GradeId == GradeId);
        }
        public async Task DeleteGradeAsync(int gid)
        {
            try
            {
                var grade = await _context.GradeMasters.FirstOrDefaultAsync(c => c.GradeId == gid);
                if (grade == null)
                {
                    throw new Exception("Grade not found.");
                }
                if (!grade.GradeIsActive)
                {
                    throw new Exception("Grade is already soft-deleted");
                }
                grade.GradeIsActive = false;
                _context.GradeMasters.Update(grade);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        //get GradeId and GradeName from GradeMaster table
        public async Task<List<GradeIdAndNameResponseDTO>> GetGradeIdAndNameFromDB()
        {
            try
            {
                var grades = await _context.GradeMasters
                    .Where(g => g.GradeIsActive) // Only include active grades
                    .Select(g => new GradeIdAndNameResponseDTO
                    {
                        GradeId = g.GradeId,
                        GradeName = g.GradeName
                    })
                    .ToListAsync();
                return grades;
            }
            catch (Exception ex)
            {
                // Log the exception (you can use any logging framework you prefer)
                Debug.WriteLine($"An error occurred while fetching grade IDs and names: {ex.Message}");
                throw; // Re-throw the exception to be handled by the calling code if necessary
            }
        }


    }
}
