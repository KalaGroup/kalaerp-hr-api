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
        //public async Task AddGradeAsync(InsertGradeRequest request)
        //{
        //    try
        //    {
        //        var grade = new GradeMaster
        //        {
        //            GradeCode = request.GradeData.GradeCode,
        //            GradeName = request.GradeData.GradeName,
        //            GradeLevel = request.GradeData.GradeLevel,
        //            MinSalCtc = request.GradeData.MinSalCTC,
        //            MaxSalCtc = request.GradeData.MaxSalCTC,
        //            GradeCurrencyId = request.GradeData.GradeCurrencyId,
        //            GradeDescription = request.GradeData.GradeDescription,
        //            LeaveEntitlementAnnual = request.GradeData.LeaveEntitlementAnnual,
        //            ProbationPeriod = request.GradeData.ProbationPeriod,
        //            NoticePeriod = request.GradeData.NoticePeriod,
        //            GradeRemark = request.GradeData.GradeRemark,
        //            GradeAuth = request.GradeData.GradeAuth,
        //            GradeIsDiscard = request.GradeData.GradeIsDiscard,
        //            GradeIsActive = request.GradeData.GradeIsActive,
        //            //CreatedBy = request.GradeData.CreatedBy,
        //            //CreatedDate = request.GradeData.CreatedDate
        //        };
        //        _context.GradeMasters.Add(grade);
        //        await _context.SaveChangesAsync();
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        public async Task AddGradeDetailsAsync(InsertGradeRequest request)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // 1. Insert Grade Master
                var grade = new GradeMaster
                {
                    GradeCode = request.GradeData.GradeCode,
                    GradeName = request.GradeData.GradeName,
                    GradeLevel = request.GradeData.GradeLevel,
                    MinSalCtc = request.GradeData.MinSalCTC,
                    MaxSalCtc = request.GradeData.MaxSalCTC,
                    GradeCurrencyId = request.GradeData.GradeCurrencyId,
                    GradeDescription = request.GradeData.GradeDescription,
                    LeaveEntitlementAnnual = request.GradeData.LeaveEntitlementAnnual,
                    ProbationPeriod = request.GradeData.ProbationPeriod,
                    NoticePeriod = request.GradeData.NoticePeriod,
                    ExperiencedRequired = request.GradeData.ExperiencedRequired,
                    ExperiencedRemark = request.GradeData.ExperiencedRemark,
                    GradeRemark = request.GradeData.GradeRemark,
                    GradeAuth = request.GradeData.GradeAuth,
                    GradeIsDiscard = request.GradeData.GradeIsDiscard,
                    GradeIsActive = request.GradeData.GradeIsActive,
                    CreatedBy = 1, // Set appropriate user ID
                    CreatedDate = DateTime.Now
                };

                _context.GradeMasters.Add(grade);
                await _context.SaveChangesAsync();

                // Get the generated GradeId
                var gradeId = grade.GradeId;

                // 2. Insert Designations
                if (request.Designations != null && request.Designations.Any())
                {
                    var designations = request.Designations.Select(d => new DesignationMaster
                    {
                        DesignationGradeId = gradeId,
                        DesignationCode = d.DesignationCode,
                        DesignationName = d.DesignationName,
                        DesignationQualificationId = d.DesignationQualificationId,
                        DesignationDescription = d.DesignationDescription,
                        GradeQualificationRemark = d.GradeQualificationRemark,
                        RequiredSkills = d.RequiredSkills,
                        DesignationRemark = d.DesignationRemark,
                    }).ToList();

                    _context.DesignationMasters.AddRange(designations);
                    await _context.SaveChangesAsync();
                }

                // 3. Insert Facility Assignments
                if (request.FacilityAssignments != null && request.FacilityAssignments.Any())
                {
                    var facilityAssignments = request.FacilityAssignments.Select(f => new GradeFacilityAssignment
                    {
                        AssignmentGradeId = gradeId,
                        AssignmentFacilityId = f.AssignmentFacilityId,
                    }).ToList();

                    _context.GradeFacilityAssignments.AddRange(facilityAssignments);
                    await _context.SaveChangesAsync();
                }

                // Commit transaction
                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                // Rollback transaction on error
                await transaction.RollbackAsync();
                throw;
            }
        }

        //public async Task AddGradeDetailsAsync(InsertGradeRequest request)
        //{
        //    using var transaction = await _context.Database.BeginTransactionAsync();
        //    try
        //    {
        //        // 1. Insert Grade Master
        //        var grade = new GradeMaster
        //        {
        //            GradeCode = request.GradeData.GradeCode,
        //            GradeName = request.GradeData.GradeName,
        //            GradeLevel = request.GradeData.GradeLevel,
        //            MinSalCtc = request.GradeData.MinSalCTC,
        //            MaxSalCtc = request.GradeData.MaxSalCTC,
        //            GradeCurrencyId = request.GradeData.GradeCurrencyId,
        //            GradeDescription = request.GradeData.GradeDescription,
        //            LeaveEntitlementAnnual = request.GradeData.LeaveEntitlementAnnual,
        //            ProbationPeriod = request.GradeData.ProbationPeriod,
        //            NoticePeriod = request.GradeData.NoticePeriod,
        //            ExperiencedRequired = request.GradeData.ExperiencedRequired,
        //            ExperiencedRemark = request.GradeData.ExperiencedRemark,
        //            GradeRemark = request.GradeData.GradeRemark,
        //            GradeAuth = request.GradeData.GradeAuth,
        //            GradeIsDiscard = request.GradeData.GradeIsDiscard,
        //            GradeIsActive = request.GradeData.GradeIsActive,
        //            CreatedBy = 1, // Set appropriate user ID
        //            CreatedDate = DateTime.Now
        //        };
        //        _context.GradeMasters.Add(grade);
        //        await _context.SaveChangesAsync();

        //        // Get the generated GradeId
        //        var gradeId = grade.GradeId;

        //        // 2. Insert Designations and their Facility Assignments
        //        if (request.Designations != null && request.Designations.Any())
        //        {
        //            foreach (var designationData in request.Designations)
        //            {
        //                // Insert designation
        //                var designation = new DesignationMaster
        //                {
        //                    DesignationGradeId = gradeId,
        //                    DesignationCode = designationData.DesignationCode,
        //                    DesignationName = designationData.DesignationName,
        //                    DesignationQualificationId = designationData.DesignationQualificationId,
        //                    DesignationDescription = designationData.DesignationDescription,
        //                    GradeQualificationRemark = designationData.GradeQualificationRemark,
        //                    RequiredSkills = designationData.RequiredSkills,
        //                    DesignationRemark = designationData.DesignationRemark,
        //                };

        //                _context.DesignationMasters.Add(designation);
        //                await _context.SaveChangesAsync();

        //                // Get the generated DesignationId
        //                var designationId = designation.DesignationId;

        //                // Insert facility assignments for this designation
        //                if (designationData.FacilityAssignments != null && designationData.FacilityAssignments.Any())
        //                {
        //                    var facilityAssignments = designationData.FacilityAssignments.Select(f => new GradeFacilityAssignment
        //                    {
        //                        AssignmentGradeId = gradeId,
        //                       // AssignmentDesignationId = designationId, // Assuming you have this field in your table
        //                        AssignmentFacilityId = f.AssignmentFacilityId,
        //                    }).ToList();

        //                    _context.GradeFacilityAssignments.AddRange(facilityAssignments);
        //                    await _context.SaveChangesAsync();
        //                }
        //            }
        //        }

        //        // Commit transaction
        //        await transaction.CommitAsync();
        //    }
        //    catch (Exception)
        //    {
        //        // Rollback transaction on error
        //        await transaction.RollbackAsync();
        //        throw;
        //    }
        //}


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

        public async Task<List<GradeWithDetailsResponseDTO>> GetAllGradesWithDetailsAsync()
        {
            var result = await (from g in _context.GradeMasters
                                join c in _context.CurrencyMasters on g.GradeCurrencyId equals c.CurrencyId
                                select new GradeWithDetailsResponseDTO
                                {
                                    GradeId = g.GradeId,
                                    GradeCode = g.GradeCode,
                                    GradeName = g.GradeName,
                                    GradeLevel = g.GradeLevel,
                                    MinSalCTC = g.MinSalCtc,
                                    MaxSalCTC = g.MaxSalCtc,
                                    GradeCurrencyId = g.GradeCurrencyId,
                                    CurrencyName = c.CurrencyName,
                                    GradeDescription = g.GradeDescription,
                                    LeaveEntitlementAnnual = g.LeaveEntitlementAnnual,
                                    ProbationPeriod = g.ProbationPeriod,
                                    NoticePeriod = g.NoticePeriod,
                                    GradeRemark = g.GradeRemark,
                                    GradeAuth = g.GradeAuth,
                                    GradeIsDiscard = g.GradeIsDiscard,
                                    GradeIsActive = g.GradeIsActive,
                                    ExperiencedRequired = g.ExperiencedRequired,
                                    ExperiencedRemark = g.ExperiencedRemark,
                                    Designations = new List<DesignationResponse>(),
                                    FacilityAssignments = new List<FacilityResponse>()
                                }).ToListAsync();

            // Get all grade IDs
            var gradeIds = result.Select(r => r.GradeId).ToList();

            // Fetch all designations for these grades
            var allDesignations = await (from d in _context.DesignationMasters
                                         join q in _context.QualificationMasters on d.DesignationQualificationId equals q.QualificationId
                                         where gradeIds.Contains(d.DesignationGradeId)
                                         select new
                                         {
                                             d.DesignationGradeId,
                                             Designation = new DesignationResponse
                                             {
                                                 DesignationId = d.DesignationId,
                                                 DesignationCode = d.DesignationCode,
                                                 DesignationName = d.DesignationName,
                                                 DesignationQualificationId = d.DesignationQualificationId,
                                                 QualificationName = q.QualificationName,
                                                 DesignationDescription = d.DesignationDescription,
                                                 GradeQualificationRemark = d.GradeQualificationRemark,
                                                 RequiredSkills = d.RequiredSkills,
                                                 DesignationRemark = d.DesignationRemark
                                             }
                                         }).ToListAsync();

            // Fetch all facilities for these grades
            var allFacilities = await (from gfa in _context.GradeFacilityAssignments
                                       join f in _context.FacilityMasters on gfa.AssignmentFacilityId equals f.FacilityId
                                       where gradeIds.Contains(gfa.AssignmentGradeId)
                                       select new
                                       {
                                           gfa.AssignmentGradeId,
                                           Facility = new FacilityResponse
                                           {
                                               GradeFacilityAssignmentId = gfa.GradeFacilityAssignmentId,
                                               AssignmentFacilityId = gfa.AssignmentFacilityId,
                                               FacilityName = f.FacilityName
                                           }
                                       }).ToListAsync();

            // Group and assign to result
            foreach (var grade in result)
            {
                grade.Designations = allDesignations
                    .Where(d => d.DesignationGradeId == grade.GradeId)
                    .Select(d => d.Designation)
                    .ToList();

                grade.FacilityAssignments = allFacilities
                    .Where(f => f.AssignmentGradeId == grade.GradeId)
                    .Select(f => f.Facility)
                    .ToList();
            }

            return result;
        }
    }
}
