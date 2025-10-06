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
        /// 
        public async Task AddGradeDetailsAsync(InsertGradeRequest request)
        {
            //using var transaction = await _context.Database.BeginTransactionAsync();
            //try
            //{
            //    // 1. Insert Grade Master
            //    var grade = new GradeMaster
            //    {
            //        GradeCode = request.gradeData.GradeCode,
            //        GradeName = request.gradeData.GradeName,
            //        GradeLevel = request.gradeData.GradeLevel,
            //        MinSalCtc = request.gradeData.MinSalCTC,
            //        MaxSalCtc = request.gradeData.MaxSalCTC,
            //        GradeCurrencyId = request.gradeData.GradeCurrencyId,
            //        GradeDescription = request.gradeData.GradeDescription,
            //        LeaveEntitlementAnnual = request.gradeData.LeaveEntitlementAnnual,
            //        ProbationPeriod = request.gradeData.ProbationPeriod,
            //        NoticePeriod = request.gradeData.NoticePeriod,
            //        ExperiencedRequired = request.gradeData.ExperiencedRequired,
            //        ExperiencedRemark = request.gradeData.ExperiencedRemark,
            //        GradeRemark = request.gradeData.GradeRemark,
            //        GradeAuth = request.gradeData.GradeAuth,
            //        GradeIsDiscard = request.gradeData.GradeIsDiscard,
            //        GradeIsActive = request.gradeData.GradeIsActive,
            //        CreatedBy = 1, // Set appropriate user ID
            //        CreatedDate = DateTime.Now
            //    };
            //    _context.GradeMasters.Add(grade);
            //    await _context.SaveChangesAsync();

            //    // Get the generated GradeId
            //    var gradeId = grade.GradeId;

            //    // 2. Insert CTC Structure
            //    if (request.ctcStructure != null)
            //    {
            //        var ctcStructure = new CtcstructureMaster // Assuming table name is CTCMaster
            //        {
            //            CtcmasterGradeId = gradeId, // Link to the generated GradeId
            //            CtcmasterBasic = request.ctcStructure.CTCMasterBasic,
            //            CtcmasterBonus = request.ctcStructure.CTCMasterBonus,
            //            CtcmasterCarAllowance = request.ctcStructure.CTCMasterCarAllowance,
            //            CtcmasterCityCompensatoryAlowance = request.ctcStructure.CTCMasterCityCompensatoryAlowance,
            //            CtcmasterConvAllowance = request.ctcStructure.CTCMasterConvAllowance,
            //            CtcmasterDa = request.ctcStructure.CTCMasterDA,
            //            CtcmasterDriverAllowance = request.ctcStructure.CTCMasterDriverAllowance,
            //            CtcmasterEsic = request.ctcStructure.CTCMasterEsic,
            //            CtcmasterFuelAllowance = request.ctcStructure.CTCMasterFuelAllowance,
            //            CtcmasterGraduity = request.ctcStructure.CTCMasterGraduity,
            //            CtcmasterGross = request.ctcStructure.CTCMasterGross,
            //            CtcmasterHra = request.ctcStructure.CTCMasterHRA,
            //            CtcmasterLeaveTravelAllowance = request.ctcStructure.CTCMasterLeaveTravelAllowance,
            //            CtcmasterMlwf = request.ctcStructure.CTCMasterMLWF,
            //            CtcmasterMedicalInsurance = request.ctcStructure.CTCMasterMedicalInsurance,
            //            CtcmasterMiscAllowance = request.ctcStructure.CTCMasterMiscAllowance,
            //            CtcmasterPfemployee = request.ctcStructure.CTCMasterPFEmployee,
            //            CtcmasterPfemployer = request.ctcStructure.CTCMasterPFEmployer,
            //            CtcmasterPt = request.ctcStructure.CTCMasterPT,
            //            CtcmasterPerformanceKpa = request.ctcStructure.CTCMasterPerformanceKPA,
            //          //  CreatedBy = 1, // Set appropriate user ID
            //           // CreatedDate = DateTime.Now,
            //           // IsActive = true // Assuming you want to set it as active by default
            //        };
            //        _context.CtcstructureMasters.Add(ctcStructure);
            //        await _context.SaveChangesAsync();
            //    }

            //    // 3. Insert Designations
            //    if (request.designations != null && request.designations.Any())
            //    {
            //        var designations = request.designations.Select(d => new DesignationMaster
            //        {
            //            DesignationGradeId = gradeId,
            //            DesignationCode = d.DesignationCode,
            //            DesignationName = d.DesignationName,
            //            DesignationQualificationId = d.DesignationQualificationId,
            //            DesignationDescription = d.DesignationDescription,
            //            GradeQualificationRemark = d.GradeQualificationRemark,
            //            RequiredSkills = d.RequiredSkills,
            //            DesignationRemark = d.DesignationRemark,
            //        }).ToList();
            //        _context.DesignationMasters.AddRange(designations);
            //        await _context.SaveChangesAsync();
            //    }

            //    // 4. Insert Facility Assignments
            //    if (request.facilityAssignments != null && request.facilityAssignments.Any())
            //    {
            //        var facilityAssignments = request.facilityAssignments.Select(f => new GradeFacilityAssignment
            //        {
            //            AssignmentGradeId = gradeId,
            //            AssignmentFacilityId = f.AssignmentFacilityId,
            //        }).ToList();
            //        _context.GradeFacilityAssignments.AddRange(facilityAssignments);
            //        await _context.SaveChangesAsync();
            //    }

            //    // Commit transaction
            //    await transaction.CommitAsync();
            //}
            //catch (Exception)
            //{
            //    // Rollback transaction on error
            //    await transaction.RollbackAsync();
            //    throw;
            //}

            var strategy = _context.Database.CreateExecutionStrategy();

            await strategy.ExecuteAsync(async () =>
            {
                await using var transaction = await _context.Database.BeginTransactionAsync();
                try
                {
                    // 1. Insert Grade Master
                    var grade = new GradeMaster
                    {
                        GradeCode = request.gradeData.GradeCode,
                        GradeName = request.gradeData.GradeName,
                        GradeLevel = request.gradeData.GradeLevel,
                        MinSalCtc = request.gradeData.MinSalCTC,
                        MaxSalCtc = request.gradeData.MaxSalCTC,
                        GradeCurrencyId = request.gradeData.GradeCurrencyId,
                        GradeDescription = request.gradeData.GradeDescription,
                        LeaveEntitlementAnnual = request.gradeData.LeaveEntitlementAnnual,
                        ProbationPeriod = request.gradeData.ProbationPeriod,
                        NoticePeriod = request.gradeData.NoticePeriod,
                        ExperiencedRequired = request.gradeData.ExperiencedRequired,
                        ExperiencedRemark = request.gradeData.ExperiencedRemark,
                        GradeRemark = request.gradeData.GradeRemark,
                        GradeAuth = request.gradeData.GradeAuth,
                        GradeIsDiscard = request.gradeData.GradeIsDiscard,
                        GradeIsActive = request.gradeData.GradeIsActive,
                        CreatedBy = 1,
                        CreatedDate = DateTime.Now
                    };

                    _context.GradeMasters.Add(grade);
                    await _context.SaveChangesAsync();

                    var gradeId = grade.GradeId;

                    // 2. Insert CTC Structure
                    if (request.ctcStructure != null)
                    {
                        var ctcStructure = new CtcstructureMaster
                        {
                            CtcmasterGradeId = gradeId,
                            CtcmasterBasic = request.ctcStructure.CTCMasterBasic,
                            CtcmasterBonus = request.ctcStructure.CTCMasterBonus,
                            CtcmasterCarAllowance = request.ctcStructure.CTCMasterCarAllowance,
                            CtcmasterCityCompensatoryAlowance = request.ctcStructure.CTCMasterCityCompensatoryAlowance,
                            CtcmasterConvAllowance = request.ctcStructure.CTCMasterConvAllowance,
                            CtcmasterDa = request.ctcStructure.CTCMasterDA,
                            CtcmasterDriverAllowance = request.ctcStructure.CTCMasterDriverAllowance,
                            CtcmasterEsic = request.ctcStructure.CTCMasterEsic,
                            CtcmasterFuelAllowance = request.ctcStructure.CTCMasterFuelAllowance,
                            CtcmasterGraduity = request.ctcStructure.CTCMasterGraduity,
                            CtcmasterGross = request.ctcStructure.CTCMasterGross,
                            CtcmasterHra = request.ctcStructure.CTCMasterHRA,
                            CtcmasterLeaveTravelAllowance = request.ctcStructure.CTCMasterLeaveTravelAllowance,
                            CtcmasterMlwf = request.ctcStructure.CTCMasterMLWF,
                            CtcmasterMedicalInsurance = request.ctcStructure.CTCMasterMedicalInsurance,
                            CtcmasterMiscAllowance = request.ctcStructure.CTCMasterMiscAllowance,
                            CtcmasterPfemployee = request.ctcStructure.CTCMasterPFEmployee,
                            CtcmasterPfemployer = request.ctcStructure.CTCMasterPFEmployer,
                            CtcmasterPt = request.ctcStructure.CTCMasterPT,
                            CtcmasterPerformanceKpa = request.ctcStructure.CTCMasterPerformanceKPA,
                        };

                        _context.CtcstructureMasters.Add(ctcStructure);
                        await _context.SaveChangesAsync();
                    }

                    // 3. Insert Designations
                    if (request.designations != null && request.designations.Any())
                    {
                        var designations = request.designations.Select(d => new DesignationMaster
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

                    // 4. Insert Facility Assignments
                    if (request.facilityAssignments != null && request.facilityAssignments.Any())
                    {
                        var facilityAssignments = request.facilityAssignments.Select(f => new GradeFacilityAssignment
                        {
                            AssignmentGradeId = gradeId,
                            AssignmentFacilityId = f.AssignmentFacilityId,
                        }).ToList();

                        _context.GradeFacilityAssignments.AddRange(facilityAssignments);
                        await _context.SaveChangesAsync();
                    }

                    // ✅ Commit transaction
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    // ❌ Rollback on any failure
                    await transaction.RollbackAsync();
                    Console.Error.WriteLine($"Transaction failed: {ex.Message}");
                    throw;
                }
            });

        }

        /// <summary>
        /// Updates an existing grade in the database.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// 
        public async Task UpdateGradeDetailsAsync(UpdateGradeDetailsRequest request)
        {
            //using var transaction = await _context.Database.BeginTransactionAsync();
            //try
            //{
            //    // Validate that GradeId exists
            //    if (request.gradeData.GradeId == null)
            //    {                                  
            //        throw new ArgumentException("GradeId is required for update operation");
            //    }

            //    var gradeId = request.gradeData.GradeId.Value;

            //    // 1. Update Grade Master
            //    var existingGrade = await _context.GradeMasters.FindAsync(gradeId);
            //    if (existingGrade == null)
            //    {
            //        throw new ArgumentException($"Grade with ID {gradeId} not found");
            //    }

            //    // Update grade properties
            //    existingGrade.GradeCode = request.gradeData.GradeCode;
            //    existingGrade.GradeName = request.gradeData.GradeName;
            //    existingGrade.GradeLevel = request.gradeData.GradeLevel;
            //    existingGrade.MinSalCtc = request.gradeData.MinSalCTC;
            //    existingGrade.MaxSalCtc = request.gradeData.MaxSalCTC;
            //    existingGrade.GradeCurrencyId = request.gradeData.GradeCurrencyId;
            //    existingGrade.GradeDescription = request.gradeData.GradeDescription;
            //    existingGrade.LeaveEntitlementAnnual = request.gradeData.LeaveEntitlementAnnual;
            //    existingGrade.ProbationPeriod = request.gradeData.ProbationPeriod;
            //    existingGrade.NoticePeriod = request.gradeData.NoticePeriod;
            //    existingGrade.ExperiencedRequired = request.gradeData.ExperiencedRequired;
            //    existingGrade.ExperiencedRemark = request.gradeData.ExperiencedRemark;
            //    existingGrade.GradeRemark = request.gradeData.GradeRemark;
            //    existingGrade.GradeAuth = request.gradeData.GradeAuth;
            //    existingGrade.GradeIsDiscard = request.gradeData.GradeIsDiscard;
            //    existingGrade.GradeIsActive = request.gradeData.GradeIsActive;
            //    //existingGrade.ModifiedBy = 1; // Set appropriate user ID
            //    //existingGrade.ModifiedDate = DateTime.Now;

            //    _context.GradeMasters.Update(existingGrade);
            //    await _context.SaveChangesAsync();

            //    // 2. Update or Insert CTC Structure
            //    if (request.ctcStructure != null)
            //    {
            //        var existingCtc = await _context.CtcstructureMasters
            //            .FirstOrDefaultAsync(c => c.CtcmasterGradeId == gradeId);

            //        if (existingCtc != null)
            //        {
            //            // Update existing CTC structure
            //            existingCtc.CtcmasterBasic = request.ctcStructure.CTCMasterBasic;
            //            existingCtc.CtcmasterBonus = request.ctcStructure.CTCMasterBonus;
            //            existingCtc.CtcmasterCarAllowance = request.ctcStructure.CTCMasterCarAllowance;
            //            existingCtc.CtcmasterCityCompensatoryAlowance = request.ctcStructure.CTCMasterCityCompensatoryAlowance;
            //            existingCtc.CtcmasterConvAllowance = request.ctcStructure.CTCMasterConvAllowance;
            //            existingCtc.CtcmasterDa = request.ctcStructure.CTCMasterDA;
            //            existingCtc.CtcmasterDriverAllowance = request.ctcStructure.CTCMasterDriverAllowance;
            //            existingCtc.CtcmasterEsic = request.ctcStructure.CTCMasterEsic;
            //            existingCtc.CtcmasterFuelAllowance = request.ctcStructure.CTCMasterFuelAllowance;
            //            existingCtc.CtcmasterGraduity = request.ctcStructure.CTCMasterGraduity;
            //            existingCtc.CtcmasterGross = request.ctcStructure.CTCMasterGross;
            //            existingCtc.CtcmasterHra = request.ctcStructure.CTCMasterHRA;
            //            existingCtc.CtcmasterLeaveTravelAllowance = request.ctcStructure.CTCMasterLeaveTravelAllowance;
            //            existingCtc.CtcmasterMlwf = request.ctcStructure.CTCMasterMLWF;
            //            existingCtc.CtcmasterMedicalInsurance = request.ctcStructure.CTCMasterMedicalInsurance;
            //            existingCtc.CtcmasterMiscAllowance = request.ctcStructure.CTCMasterMiscAllowance;
            //            existingCtc.CtcmasterPfemployee = request.ctcStructure.CTCMasterPFEmployee;
            //            existingCtc.CtcmasterPfemployer = request.ctcStructure.CTCMasterPFEmployer;
            //            existingCtc.CtcmasterPt = request.ctcStructure.CTCMasterPT;
            //            existingCtc.CtcmasterPerformanceKpa = request.ctcStructure.CTCMasterPerformanceKPA;

            //            _context.CtcstructureMasters.Update(existingCtc);
            //        }
            //        else
            //        {
            //            // Insert new CTC structure
            //            var ctcStructure = new CtcstructureMaster
            //            {
            //                CtcmasterGradeId = gradeId,
            //                CtcmasterBasic = request.ctcStructure.CTCMasterBasic,
            //                CtcmasterBonus = request.ctcStructure.CTCMasterBonus,
            //                CtcmasterCarAllowance = request.ctcStructure.CTCMasterCarAllowance,
            //                CtcmasterCityCompensatoryAlowance = request.ctcStructure.CTCMasterCityCompensatoryAlowance,
            //                CtcmasterConvAllowance = request.ctcStructure.CTCMasterConvAllowance,
            //                CtcmasterDa = request.ctcStructure.CTCMasterDA,
            //                CtcmasterDriverAllowance = request.ctcStructure.CTCMasterDriverAllowance,
            //                CtcmasterEsic = request.ctcStructure.CTCMasterEsic,
            //                CtcmasterFuelAllowance = request.ctcStructure.CTCMasterFuelAllowance,
            //                CtcmasterGraduity = request.ctcStructure.CTCMasterGraduity,
            //                CtcmasterGross = request.ctcStructure.CTCMasterGross,
            //                CtcmasterHra = request.ctcStructure.CTCMasterHRA,
            //                CtcmasterLeaveTravelAllowance = request.ctcStructure.CTCMasterLeaveTravelAllowance,
            //                CtcmasterMlwf = request.ctcStructure.CTCMasterMLWF,
            //                CtcmasterMedicalInsurance = request.ctcStructure.CTCMasterMedicalInsurance,
            //                CtcmasterMiscAllowance = request.ctcStructure.CTCMasterMiscAllowance,
            //                CtcmasterPfemployee = request.ctcStructure.CTCMasterPFEmployee,
            //                CtcmasterPfemployer = request.ctcStructure.CTCMasterPFEmployer,
            //                CtcmasterPt = request.ctcStructure.CTCMasterPT,
            //                CtcmasterPerformanceKpa = request.ctcStructure.CTCMasterPerformanceKPA,
            //            };
            //            _context.CtcstructureMasters.Add(ctcStructure);
            //        }
            //        await _context.SaveChangesAsync();
            //    }

            //    // 3. Update Designations (Update existing only)
            //    if (request.designations != null && request.designations.Any())
            //    {
            //        foreach (var designationData in request.designations)
            //        {
            //            if (designationData.DesignationId.HasValue && designationData.DesignationId.Value > 0)
            //            {
            //                // Find and update existing designation by DesignationId and GradeId
            //                var existingDesignation = await _context.DesignationMasters
            //                    .FirstOrDefaultAsync(d => d.DesignationId == designationData.DesignationId.Value
            //                                           && d.DesignationGradeId == gradeId);

            //                if (existingDesignation != null)
            //                {
            //                    // Update existing designation properties
            //                    existingDesignation.DesignationCode = designationData.DesignationCode;
            //                    existingDesignation.DesignationName = designationData.DesignationName;
            //                    existingDesignation.DesignationQualificationId = designationData.DesignationQualificationId;
            //                    existingDesignation.DesignationDescription = designationData.DesignationDescription;
            //                    existingDesignation.GradeQualificationRemark = designationData.GradeQualificationRemark;
            //                    existingDesignation.RequiredSkills = designationData.RequiredSkills;
            //                    existingDesignation.DesignationRemark = designationData.DesignationRemark;

            //                    _context.DesignationMasters.Update(existingDesignation);
            //                }
            //            }
            //        }
            //        await _context.SaveChangesAsync();
            //    }

            //    // 4. Update Facility Assignments (Delete existing and insert new)
            //    // Remove existing facility assignments
            //    var existingFacilityAssignments = await _context.GradeFacilityAssignments
            //        .Where(f => f.AssignmentGradeId == gradeId)
            //        .ToListAsync();

            //    if (existingFacilityAssignments.Any())
            //    {
            //        _context.GradeFacilityAssignments.RemoveRange(existingFacilityAssignments);
            //        await _context.SaveChangesAsync();
            //    }

            //    // Insert new facility assignments
            //    if (request.facilityAssignments != null && request.facilityAssignments.Any())
            //    {
            //        var facilityAssignments = request.facilityAssignments.Select(f => new GradeFacilityAssignment
            //        {
            //            AssignmentGradeId = gradeId,
            //            AssignmentFacilityId = f.AssignmentFacilityId,
            //        }).ToList();
            //        _context.GradeFacilityAssignments.AddRange(facilityAssignments);
            //        await _context.SaveChangesAsync();
            //    }

            //    // Commit transaction
            //    await transaction.CommitAsync();
            //}
            //catch (Exception)
            //{
            //    // Rollback transaction on error
            //    await transaction.RollbackAsync();
            //    throw;
            //}
            var strategy = _context.Database.CreateExecutionStrategy();

            await strategy.ExecuteAsync(async () =>
            {
                await using var transaction = await _context.Database.BeginTransactionAsync();
                try
                {
                    // Validate that GradeId exists
                    if (request.gradeData.GradeId == null)
                    {
                        throw new ArgumentException("GradeId is required for update operation");
                    }

                    var gradeId = request.gradeData.GradeId.Value;

                    // 1. Update Grade Master
                    var existingGrade = await _context.GradeMasters.FindAsync(gradeId);
                    if (existingGrade == null)
                    {
                        throw new ArgumentException($"Grade with ID {gradeId} not found");
                    }

                    // Update grade properties
                    existingGrade.GradeCode = request.gradeData.GradeCode;
                    existingGrade.GradeName = request.gradeData.GradeName;
                    existingGrade.GradeLevel = request.gradeData.GradeLevel;
                    existingGrade.MinSalCtc = request.gradeData.MinSalCTC;
                    existingGrade.MaxSalCtc = request.gradeData.MaxSalCTC;
                    existingGrade.GradeCurrencyId = request.gradeData.GradeCurrencyId;
                    existingGrade.GradeDescription = request.gradeData.GradeDescription;
                    existingGrade.LeaveEntitlementAnnual = request.gradeData.LeaveEntitlementAnnual;
                    existingGrade.ProbationPeriod = request.gradeData.ProbationPeriod;
                    existingGrade.NoticePeriod = request.gradeData.NoticePeriod;
                    existingGrade.ExperiencedRequired = request.gradeData.ExperiencedRequired;
                    existingGrade.ExperiencedRemark = request.gradeData.ExperiencedRemark;
                    existingGrade.GradeRemark = request.gradeData.GradeRemark;
                    existingGrade.GradeAuth = request.gradeData.GradeAuth;
                    existingGrade.GradeIsDiscard = request.gradeData.GradeIsDiscard;
                    existingGrade.GradeIsActive = request.gradeData.GradeIsActive;

                    _context.GradeMasters.Update(existingGrade);
                    await _context.SaveChangesAsync();

                    // 2. Update or Insert CTC Structure
                    if (request.ctcStructure != null)
                    {
                        var existingCtc = await _context.CtcstructureMasters
                            .FirstOrDefaultAsync(c => c.CtcmasterGradeId == gradeId);

                        if (existingCtc != null)
                        {
                            // Update existing CTC structure
                            existingCtc.CtcmasterBasic = request.ctcStructure.CTCMasterBasic;
                            existingCtc.CtcmasterBonus = request.ctcStructure.CTCMasterBonus;
                            existingCtc.CtcmasterCarAllowance = request.ctcStructure.CTCMasterCarAllowance;
                            existingCtc.CtcmasterCityCompensatoryAlowance = request.ctcStructure.CTCMasterCityCompensatoryAlowance;
                            existingCtc.CtcmasterConvAllowance = request.ctcStructure.CTCMasterConvAllowance;
                            existingCtc.CtcmasterDa = request.ctcStructure.CTCMasterDA;
                            existingCtc.CtcmasterDriverAllowance = request.ctcStructure.CTCMasterDriverAllowance;
                            existingCtc.CtcmasterEsic = request.ctcStructure.CTCMasterEsic;
                            existingCtc.CtcmasterFuelAllowance = request.ctcStructure.CTCMasterFuelAllowance;
                            existingCtc.CtcmasterGraduity = request.ctcStructure.CTCMasterGraduity;
                            existingCtc.CtcmasterGross = request.ctcStructure.CTCMasterGross;
                            existingCtc.CtcmasterHra = request.ctcStructure.CTCMasterHRA;
                            existingCtc.CtcmasterLeaveTravelAllowance = request.ctcStructure.CTCMasterLeaveTravelAllowance;
                            existingCtc.CtcmasterMlwf = request.ctcStructure.CTCMasterMLWF;
                            existingCtc.CtcmasterMedicalInsurance = request.ctcStructure.CTCMasterMedicalInsurance;
                            existingCtc.CtcmasterMiscAllowance = request.ctcStructure.CTCMasterMiscAllowance;
                            existingCtc.CtcmasterPfemployee = request.ctcStructure.CTCMasterPFEmployee;
                            existingCtc.CtcmasterPfemployer = request.ctcStructure.CTCMasterPFEmployer;
                            existingCtc.CtcmasterPt = request.ctcStructure.CTCMasterPT;
                            existingCtc.CtcmasterPerformanceKpa = request.ctcStructure.CTCMasterPerformanceKPA;

                            _context.CtcstructureMasters.Update(existingCtc);
                        }
                        else
                        {
                            // Insert new CTC structure
                            var ctcStructure = new CtcstructureMaster
                            {
                                CtcmasterGradeId = gradeId,
                                CtcmasterBasic = request.ctcStructure.CTCMasterBasic,
                                CtcmasterBonus = request.ctcStructure.CTCMasterBonus,
                                CtcmasterCarAllowance = request.ctcStructure.CTCMasterCarAllowance,
                                CtcmasterCityCompensatoryAlowance = request.ctcStructure.CTCMasterCityCompensatoryAlowance,
                                CtcmasterConvAllowance = request.ctcStructure.CTCMasterConvAllowance,
                                CtcmasterDa = request.ctcStructure.CTCMasterDA,
                                CtcmasterDriverAllowance = request.ctcStructure.CTCMasterDriverAllowance,
                                CtcmasterEsic = request.ctcStructure.CTCMasterEsic,
                                CtcmasterFuelAllowance = request.ctcStructure.CTCMasterFuelAllowance,
                                CtcmasterGraduity = request.ctcStructure.CTCMasterGraduity,
                                CtcmasterGross = request.ctcStructure.CTCMasterGross,
                                CtcmasterHra = request.ctcStructure.CTCMasterHRA,
                                CtcmasterLeaveTravelAllowance = request.ctcStructure.CTCMasterLeaveTravelAllowance,
                                CtcmasterMlwf = request.ctcStructure.CTCMasterMLWF,
                                CtcmasterMedicalInsurance = request.ctcStructure.CTCMasterMedicalInsurance,
                                CtcmasterMiscAllowance = request.ctcStructure.CTCMasterMiscAllowance,
                                CtcmasterPfemployee = request.ctcStructure.CTCMasterPFEmployee,
                                CtcmasterPfemployer = request.ctcStructure.CTCMasterPFEmployer,
                                CtcmasterPt = request.ctcStructure.CTCMasterPT,
                                CtcmasterPerformanceKpa = request.ctcStructure.CTCMasterPerformanceKPA,
                            };
                            _context.CtcstructureMasters.Add(ctcStructure);
                        }
                        await _context.SaveChangesAsync();
                    }

                    // 3. Update Designations (Update existing only)
                    if (request.designations != null && request.designations.Any())
                    {
                        foreach (var designationData in request.designations)
                        {
                            if (designationData.DesignationId.HasValue && designationData.DesignationId.Value > 0)
                            {
                                var existingDesignation = await _context.DesignationMasters
                                    .FirstOrDefaultAsync(d => d.DesignationId == designationData.DesignationId.Value
                                                           && d.DesignationGradeId == gradeId);

                                if (existingDesignation != null)
                                {
                                    existingDesignation.DesignationCode = designationData.DesignationCode;
                                    existingDesignation.DesignationName = designationData.DesignationName;
                                    existingDesignation.DesignationQualificationId = designationData.DesignationQualificationId;
                                    existingDesignation.DesignationDescription = designationData.DesignationDescription;
                                    existingDesignation.GradeQualificationRemark = designationData.GradeQualificationRemark;
                                    existingDesignation.RequiredSkills = designationData.RequiredSkills;
                                    existingDesignation.DesignationRemark = designationData.DesignationRemark;

                                    _context.DesignationMasters.Update(existingDesignation);
                                }
                            }
                        }
                        await _context.SaveChangesAsync();
                    }

                    // 4. Update Facility Assignments (Delete existing and insert new)
                    var existingFacilityAssignments = await _context.GradeFacilityAssignments
                        .Where(f => f.AssignmentGradeId == gradeId)
                        .ToListAsync();

                    if (existingFacilityAssignments.Any())
                    {
                        _context.GradeFacilityAssignments.RemoveRange(existingFacilityAssignments);
                        await _context.SaveChangesAsync();
                    }

                    if (request.facilityAssignments != null && request.facilityAssignments.Any())
                    {
                        var facilityAssignments = request.facilityAssignments.Select(f => new GradeFacilityAssignment
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
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            });
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
                                where g.GradeIsActive == true
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
                                    CTCStructure = null, // Will be populated later
                                    Designations = new List<DesignationResponse>(),
                                    FacilityAssignments = new List<FacilityResponse>()
                                }).ToListAsync();

            // Get all grade IDs
            var gradeIds = result.Select(r => r.GradeId).ToList();

            // Fetch all CTC structures for these grades
            var allCTCStructures = await (from ctc in _context.CtcstructureMasters
                                          where ctc.CtcmasterGradeId.HasValue && gradeIds.Contains(ctc.CtcmasterGradeId.Value)
                                          select new
                                          {
                                              ctc.CtcmasterGradeId,
                                              CTCStructure = new CTCStructureResponse
                                              {
                                                  CTCId = ctc.CtcstructureId,
                                                  CTCMasterBasic = ctc.CtcmasterBasic,
                                                  CTCMasterBonus = ctc.CtcmasterBonus,
                                                  CTCMasterCarAllowance = ctc.CtcmasterCarAllowance,
                                                  CTCMasterCityCompensatoryAlowance = ctc.CtcmasterCityCompensatoryAlowance,
                                                  CTCMasterConvAllowance = ctc.CtcmasterConvAllowance,
                                                  CTCMasterDA = ctc.CtcmasterDa,
                                                  CTCMasterDriverAllowance = ctc.CtcmasterDriverAllowance,
                                                  CTCMasterEsic = ctc.CtcmasterEsic,
                                                  CTCMasterFuelAllowance = ctc.CtcmasterFuelAllowance,
                                                  CTCMasterGraduity = ctc.CtcmasterGraduity,
                                                  CTCMasterGross = ctc.CtcmasterGross,
                                                  CTCMasterHRA = ctc.CtcmasterHra,
                                                  CTCMasterLeaveTravelAllowance = ctc.CtcmasterLeaveTravelAllowance,
                                                  CTCMasterMLWF = ctc.CtcmasterMlwf,
                                                  CTCMasterMedicalInsurance = ctc.CtcmasterMedicalInsurance,
                                                  CTCMasterMiscAllowance = ctc.CtcmasterMiscAllowance,
                                                  CTCMasterPFEmployee = ctc.CtcmasterPfemployee,
                                                  CTCMasterPFEmployer = ctc.CtcmasterPfemployer,
                                                  CTCMasterPT = ctc.CtcmasterPt,
                                                  CTCMasterPerformanceKPA = ctc.CtcmasterPerformanceKpa,
                                              }
                                          }).ToListAsync();

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
            var allFacilities = (await (from gfa in _context.GradeFacilityAssignments
                                        join f in _context.FacilityMasters
                                            on gfa.AssignmentFacilityId equals f.FacilityId
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
                                        })
                             .ToListAsync()) // ✅ fetch from DB first
                             .DistinctBy(x => new { x.AssignmentGradeId, x.Facility.AssignmentFacilityId }) // ✅ apply in memory
                             .ToList();

            // Group and assign to result
            foreach (var grade in result)
            {
                // Assign CTC Structure
                grade.CTCStructure = allCTCStructures
                    .FirstOrDefault(ctc => ctc.CtcmasterGradeId == grade.GradeId)?.CTCStructure;

                // Assign Designations
                grade.Designations = allDesignations
                    .Where(d => d.DesignationGradeId == grade.GradeId)
                    .Select(d => d.Designation)
                    .ToList();

                // Assign Facility Assignments
                grade.FacilityAssignments = allFacilities
                    .Where(f => f.AssignmentGradeId == grade.GradeId)
                    .Select(f => f.Facility)
                    .ToList();
            }

            return result;
        }
        //delete grade and its dependency
        public async Task DeleteGradeDetailsAsync(int gradeId)
        {
            try
            {
                // Validate that Grade exists
                var existingGrade = await _context.GradeMasters.FindAsync(gradeId);
                if (existingGrade == null)
                {
                    throw new ArgumentException($"Grade with ID {gradeId} not found");
                }              
                existingGrade.GradeIsActive = false;
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
