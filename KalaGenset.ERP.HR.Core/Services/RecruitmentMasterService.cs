using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.HolidayMaster;
using KalaGenset.ERP.HR.Core.Request.RecruitmentMaster;
using KalaGenset.ERP.HR.Core.Request.RecruitmentReferenceMaster;
using KalaGenset.ERP.HR.Core.ResponseDTO.CompanyMaster;
using KalaGenset.ERP.HR.Core.ResponseDTO.Location;
using KalaGenset.ERP.HR.Core.ResponseDTO.RecruitmentMaster;
using KalaGenset.ERP.HR.Core.ResponseDTO.ResponsibilitiesMaster;
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
    public class RecruitmentMasterService : IRecruitmentMaster
    {
        private readonly KalaDbContext context;
        public RecruitmentMasterService(KalaDbContext context)
        {
            this.context = context;
        }
        public async Task AddRecruitmentMasterAsync(InsertRecruitmentMasterRequest request)
        {
            //using var transaction = await context.Database.BeginTransactionAsync();
            //try
            //{
            //    var recruitmentmaster = new RecruitmentMaster
            //    {
            //        RecruitmentMasterPositionId = request.RecruitmentMasterPositionId,
            //        RecruitmentMasterCode = request.RecruitmentMasterCode,
            //        RecruitmentMasterReferenceId = request.RecruitmentMasterReferenceId,
            //        RecruitmentMasterReferenceName = request.RecruitmentMasterReferenceName,
            //        RecruitmentMasterReferenceCode = request.RecruitmentMasterReferenceCode,
            //        RecruitmentMasterNameOfCandidates = request.RecruitmentMasterNameOfCandidates,
            //        RecruitmentMasterCityId = request.RecruitmentMasterCityId,
            //        RecruitmentMasterCompanyId = request.RecruitmentMasterCompanyId,
            //        RecruitmentMasterCandidateEmailId = request.RecruitmentMasterCandidateEmailId,
            //        RecruitmentMasterCandidateContactNumber = request.RecruitmentMasterCandidateContactNumber,
            //        RecruitmentMasterAppropriateForJobRole = request.RecruitmentMasterAppropriateForJobRole,
            //        RecruitmentMasterInterviewerEmployeeId = request.RecruitmentMasterInterviewerEmployeeId,
            //        RecruitmentMasterInterviewerComment = request.RecruitmentMasterInterviewerComment,
            //        RecruitmentMasterGradeId = request.RecruitmentMasterGradeId,
            //        RecruitmentMasterDesignationId = request.RecruitmentMasterDesignationId,
            //        RecruitmentMasterCurrentCtcpa = request.RecruitmentMasterCurrentCtcpa,
            //        RecruitmentMasterExpectedCtcpa = request.RecruitmentMasterExpectedCtcpa,
            //        RecruitmentMasterRecommendedCtcpa = request.RecruitmentMasterRecommendedCtcpa,
            //        RecruitmentMasterExpectedJoiningDate = request.RecruitmentMasterExpectedJoiningDate,
            //        RecruitmentMasterHrcomment = request.RecruitmentMasterHrcomment,
            //        RecruitmentMasterRecruitmentStageStatusId = request.RecruitmentMasterRecruitmentStageStatusId,
            //        RecruitmentMasterOfferLetterStatus = request.RecruitmentMasterOfferLetterStatus,
            //        RecruitmentMasterRemark = request.RecruitmentMasterRemark,
            //        RecruitmentMasterAuthRemark = request.RecruitmentMasterAuthRemark,
            //        RecruitmentMasterAuth = request.RecruitmentMasterAuth,
            //        RecruitmentMasterIsDiscard = request.RecruitmentMasterIsDiscard,
            //        RecruitmentMasterIsActive = request.RecruitmentMasterIsActive,
            //        CreatedBy = request.CreatedBy,
            //        CreatedDate = DateTime.Now
            //    };

            //    context.RecruitmentMasters.Add(recruitmentmaster);
            //    await context.SaveChangesAsync();

            //    int recruitmentMstId = recruitmentmaster.RecruitmentMasterId;

            //    if (request.RecruitmentDetails != null && request.RecruitmentDetails.Any())
            //    {
            //        var details = request.RecruitmentDetails.Select(item => new RecruitmentDetail
            //        {
            //            DetailsRecruitmentMasterId = recruitmentMstId,
            //            RecruitmentDetailsInterviewRoundNumber = item.newRound,
            //            RecruitmentDetailsMarksObtained = item.newMarks,
            //            RecruitmentDetailsAttributeId = item.newAttributeId
            //        }).ToList();

            //        context.RecruitmentDetails.AddRange(details);
            //        await context.SaveChangesAsync();
            //    }

            //    // ✅ Commit only if all operations succeed
            //    await transaction.CommitAsync();
            //}
            //catch (Exception ex)
            //{
            //    // ❌ Rollback if any operation fails
            //    await transaction.RollbackAsync();
            //    throw new Exception($"Error adding RecruitmentMaster: {ex.Message}", ex);
            //}

            var strategy = context.Database.CreateExecutionStrategy();

            await strategy.ExecuteAsync(async () =>
            {
                await using var transaction = await context.Database.BeginTransactionAsync();
                try
                {
                    // 1️⃣ Insert Recruitment Master
                    var recruitmentmaster = new RecruitmentMaster
                    {
                        RecruitmentMasterPositionId = request.RecruitmentMasterPositionId,
                        RecruitmentMasterCode = request.RecruitmentMasterCode,
                        RecruitmentMasterReferenceId = request.RecruitmentMasterReferenceId,
                        RecruitmentMasterReferenceName = request.RecruitmentMasterReferenceName,
                        RecruitmentMasterReferenceCode = request.RecruitmentMasterReferenceCode,
                        RecruitmentMasterNameOfCandidates = request.RecruitmentMasterNameOfCandidates,
                        RecruitmentMasterCityId = request.RecruitmentMasterCityId,
                        RecruitmentMasterCompanyId = request.RecruitmentMasterCompanyId,
                        RecruitmentMasterCandidateEmailId = request.RecruitmentMasterCandidateEmailId,
                        RecruitmentMasterCandidateContactNumber = request.RecruitmentMasterCandidateContactNumber,
                        RecruitmentMasterAppropriateForJobRole = request.RecruitmentMasterAppropriateForJobRole,
                        RecruitmentMasterInterviewerEmployeeId = request.RecruitmentMasterInterviewerEmployeeId,
                        RecruitmentMasterInterviewerComment = request.RecruitmentMasterInterviewerComment,
                        RecruitmentMasterGradeId = request.RecruitmentMasterGradeId,
                        RecruitmentMasterDesignationId = request.RecruitmentMasterDesignationId,
                        RecruitmentMasterCurrentCtcpa = request.RecruitmentMasterCurrentCtcpa,
                        RecruitmentMasterExpectedCtcpa = request.RecruitmentMasterExpectedCtcpa,
                        RecruitmentMasterRecommendedCtcpa = request.RecruitmentMasterRecommendedCtcpa,
                        RecruitmentMasterExpectedJoiningDate = request.RecruitmentMasterExpectedJoiningDate,
                        RecruitmentMasterHrcomment = request.RecruitmentMasterHrcomment,
                        RecruitmentMasterRecruitmentStageStatusId = request.RecruitmentMasterRecruitmentStageStatusId,
                        RecruitmentMasterOfferLetterStatus = request.RecruitmentMasterOfferLetterStatus,
                        RecruitmentMasterRemark = request.RecruitmentMasterRemark,
                        RecruitmentMasterAuthRemark = request.RecruitmentMasterAuthRemark,
                        RecruitmentMasterAuth = request.RecruitmentMasterAuth,
                        RecruitmentMasterIsDiscard = request.RecruitmentMasterIsDiscard,
                        RecruitmentMasterIsActive = request.RecruitmentMasterIsActive,
                        CreatedBy = request.CreatedBy,
                        CreatedDate = DateTime.Now
                    };

                    context.RecruitmentMasters.Add(recruitmentmaster);
                    await context.SaveChangesAsync();

                    int recruitmentMstId = recruitmentmaster.RecruitmentMasterId;

                    // 2️⃣ Insert Recruitment Details
                    if (request.RecruitmentDetails != null && request.RecruitmentDetails.Any())
                    {
                        var details = request.RecruitmentDetails.Select(item => new RecruitmentDetail
                        {
                            DetailsRecruitmentMasterId = recruitmentMstId,
                            RecruitmentDetailsInterviewRoundNumber = item.newRound,
                            RecruitmentDetailsMarksObtained = item.newMarks,
                            RecruitmentDetailsAttributeId = item.newAttributeId
                        }).ToList();

                        context.RecruitmentDetails.AddRange(details);
                        await context.SaveChangesAsync();
                    }

                    // ✅ Commit transaction
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    // ❌ Rollback on any failure
                    await transaction.RollbackAsync();
                    Console.Error.WriteLine($"Recruitment transaction failed: {ex.Message}");
                    throw new Exception($"Error adding RecruitmentMaster: {ex.Message}", ex);
                }
            });
        }



        public async Task DeleteRecruitmentMasterAsync(int recruitmentMasterId)
        {
            try
            {
                var recruitmentmaster = await context.RecruitmentMasters
                    .Include(r => r.RecruitmentDetails) 
                    .FirstOrDefaultAsync(c => c.RecruitmentMasterId == recruitmentMasterId);

                if (recruitmentmaster == null)
                    throw new Exception("RecruitmentMaster not found");

                // Remove details first
                if (recruitmentmaster.RecruitmentDetails.Any())
                    context.RecruitmentDetails.RemoveRange(recruitmentmaster.RecruitmentDetails);
                recruitmentmaster.RecruitmentMasterIsActive = false;


                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting RecruitmentMaster", ex);
            }
        }


        public async Task<IEnumerable<RecruitmentMasterDTO>> GetAllRecruitmentMasterAsync()
        {
            var recruitments = await (
                from rm in context.RecruitmentMasters

                join pos in context.PositionMasters
                    on rm.RecruitmentMasterPositionId equals pos.PositionMasterId   

                join refm in context.RecruitmentReferenceMasters
                    on rm.RecruitmentMasterReferenceId equals refm.RecruitmentReferenceId

                join city in context.CityMasters
                    on rm.RecruitmentMasterCityId equals city.CityId

                join comp in context.CompanyMasters
                    on rm.RecruitmentMasterCompanyId equals comp.CompanyId

                join emp in context.EmployeeMasterPersonalDetails
                    on rm.RecruitmentMasterInterviewerEmployeeId equals emp.EmployeeMasterId

                join g in context.GradeMasters
                    on rm.RecruitmentMasterGradeId equals g.GradeId

                join d in context.DesignationMasters
                    on rm.RecruitmentMasterDesignationId equals d.DesignationId

                join stage in context.RecruitmentStageStatusMasters
                    on rm.RecruitmentMasterRecruitmentStageStatusId equals stage.RecruitmentStageStatusId

                select new RecruitmentMasterDTO
                {
                    RecruitmentMasterId = rm.RecruitmentMasterId,
                    RecruitmentMasterPositionName = pos.PositionMasterName,
                    RecruitmentMasterCode = rm.RecruitmentMasterCode,
                    RecruitmentReferenceName = refm.RecruitmentReferenceName,
                    RecruitmentMasterReferenceName = rm.RecruitmentMasterReferenceName,
                    RecruitmentMasterReferenceCode = rm.RecruitmentMasterReferenceCode,
                    RecruitmentMasterNameOfCandidates = rm.RecruitmentMasterNameOfCandidates,
                    CityName = city.CityName,
                    CompanyName = comp.CompanyName,
                    RecruitmentMasterCandidateEmailId = rm.RecruitmentMasterCandidateEmailId,
                    RecruitmentMasterCandidateContactNumber = rm.RecruitmentMasterCandidateContactNumber,
                    RecruitmentMasterAppropriateForJobRole = rm.RecruitmentMasterAppropriateForJobRole,
                    RecruiterFullName = emp.EmployeeMasterFullName,
                    RecruitmentMasterInterviewerComment = rm.RecruitmentMasterInterviewerComment,
                    GradeName = g.GradeName,
                    DesignationName = d.DesignationName,
                    RecruitmentMasterCurrentCTCPA = rm.RecruitmentMasterCurrentCtcpa,
                    RecruitmentMasterExpectedCTCPA = rm.RecruitmentMasterExpectedCtcpa,
                    RecruitmentMasterRecommendedCTCPA = rm.RecruitmentMasterRecommendedCtcpa,
                    RecruitmentMasterExpectedJoiningDate = rm.RecruitmentMasterExpectedJoiningDate,
                    RecruitmentMasterHrcomment = rm.RecruitmentMasterHrcomment,
                    RecruitmentStageStatusName = stage.RecruitmentStageStatusName,
                    RecruitmentMasterOfferLetterStatus = rm.RecruitmentMasterOfferLetterStatus,
                    RecruitmentMasterRemark = rm.RecruitmentMasterRemark,
                    RecruitmentMasterAuthRemark = rm.RecruitmentMasterAuthRemark,
                    RecruitmentMasterAuth = rm.RecruitmentMasterAuth,
                    RecruitmentMasterIsDiscard = rm.RecruitmentMasterIsDiscard,
                    RecruitmentMasterIsActive = rm.RecruitmentMasterIsActive
                }
            ).ToListAsync();

            return recruitments;
        }


        public async Task<List<GetEmployeeIdAndNameResponseDTO>> GetEmployeeIdAndNameAsync()
        {
            var employees = await context.EmployeeMasterPersonalDetails
                .Where(c => c.EmployeeMasterIsActive)
                .Select(c => new GetEmployeeIdAndNameResponseDTO
                {
                    EmployeeMasterId = c.EmployeeMasterId,
                    EmployeeMasterFullName = c.EmployeeMasterFullName,
                    EmployeeMasterCode = c.EmployeeMasterCode,
                    LeaveBalancesClosing = c.EmployeeLeaveBalances
                                        .Where(lb => lb.LeaveBalancesIsActive)
                                        .Sum(lb => lb.LeaveBalancesClosing)
                   
                })
                .ToListAsync();

            return employees;
        }

        public async Task<List<GetPositionIdAnd_NameDTO>> GetPositionIdAndNameAsync()
        {
            var position = await context.PositionMasters
                  .Where(c => c.PositionMasterIsActive)
                  .Select(c => new GetPositionIdAnd_NameDTO
                  {
                      PositionMasterId = c.PositionMasterId,
                      PositionMasterName = c.PositionMasterName,
                  })
                  .ToListAsync();
            return position;
        }

        public async Task<IEnumerable<getrecruitmenDetailsById>> GetrecruitmentDetailsByMsaterId(int RecruitmentMasterId)
        {
            return await context.RecruitmentDetails  // assuming your DbSet is called RecruitmentDetails
                .Where(d => d.DetailsRecruitmentMasterId == RecruitmentMasterId)  // filter by master ID
                .Select(d => new getrecruitmenDetailsById
                {
                    RecruitmentDetailsId = d.RecruitmentDetailsId,
                    DetailsRecruitmentMasterId = d.DetailsRecruitmentMasterId,
                    RecruitmentDetailsInterviewRoundNumber = d.RecruitmentDetailsInterviewRoundNumber,
                    RecruitmentDetailsMarksObtained = d.RecruitmentDetailsMarksObtained,
                    RecruitmentDetailsAttributeId = d.RecruitmentDetailsAttributeId
                })
                .ToListAsync();
        }

        public async Task<RecruitmentMasterDTO?> GetRecruitmentMasterByIdAsync(int recruitmentMasterId)
        {
            var recruitment = await (
                from rm in context.RecruitmentMasters

                join pos in context.PositionMasters
                    on rm.RecruitmentMasterPositionId equals pos.PositionMasterId

                join refm in context.RecruitmentReferenceMasters
                    on rm.RecruitmentMasterReferenceId equals refm.RecruitmentReferenceId

                join city in context.CityMasters
                    on rm.RecruitmentMasterCityId equals city.CityId

                join comp in context.CompanyMasters
                    on rm.RecruitmentMasterCompanyId equals comp.CompanyId

                join emp in context.EmployeeMasterPersonalDetails
                    on rm.RecruitmentMasterInterviewerEmployeeId equals emp.EmployeeMasterId

                join g in context.GradeMasters
                    on rm.RecruitmentMasterGradeId equals g.GradeId

                join d in context.DesignationMasters
                    on rm.RecruitmentMasterDesignationId equals d.DesignationId

                join stage in context.RecruitmentStageStatusMasters
                    on rm.RecruitmentMasterRecruitmentStageStatusId equals stage.RecruitmentStageStatusId

                where rm.RecruitmentMasterId == recruitmentMasterId   // ✅ filter by ID

                select new RecruitmentMasterDTO
                {
                    RecruitmentMasterId = rm.RecruitmentMasterId,
                    RecruitmentMasterPositionName = pos.PositionMasterName,
                    RecruitmentMasterCode = rm.RecruitmentMasterCode,
                    RecruitmentReferenceName = refm.RecruitmentReferenceName,
                    RecruitmentMasterReferenceName = rm.RecruitmentMasterReferenceName,
                    RecruitmentMasterReferenceCode = rm.RecruitmentMasterReferenceCode,
                    RecruitmentMasterNameOfCandidates = rm.RecruitmentMasterNameOfCandidates,
                    CityName = city.CityName,
                    CompanyName = comp.CompanyName,
                    RecruitmentMasterCandidateEmailId = rm.RecruitmentMasterCandidateEmailId,
                    RecruitmentMasterCandidateContactNumber = rm.RecruitmentMasterCandidateContactNumber,
                    RecruitmentMasterAppropriateForJobRole = rm.RecruitmentMasterAppropriateForJobRole,
                    RecruiterFullName = emp.EmployeeMasterFullName,
                    RecruitmentMasterInterviewerComment = rm.RecruitmentMasterInterviewerComment,
                    GradeName = g.GradeName,
                    DesignationName = d.DesignationName,
                    RecruitmentMasterCurrentCTCPA = rm.RecruitmentMasterCurrentCtcpa,
                    RecruitmentMasterExpectedCTCPA = rm.RecruitmentMasterExpectedCtcpa,
                    RecruitmentMasterRecommendedCTCPA = rm.RecruitmentMasterRecommendedCtcpa,
                    RecruitmentMasterExpectedJoiningDate = rm.RecruitmentMasterExpectedJoiningDate,
                    RecruitmentMasterHrcomment = rm.RecruitmentMasterHrcomment,
                    RecruitmentStageStatusName = stage.RecruitmentStageStatusName,
                    RecruitmentMasterOfferLetterStatus = rm.RecruitmentMasterOfferLetterStatus,
                    RecruitmentMasterRemark = rm.RecruitmentMasterRemark,
                    RecruitmentMasterAuthRemark = rm.RecruitmentMasterAuthRemark,
                    RecruitmentMasterAuth = rm.RecruitmentMasterAuth,
                    RecruitmentMasterIsDiscard = rm.RecruitmentMasterIsDiscard,
                    RecruitmentMasterIsActive = rm.RecruitmentMasterIsActive
                }
            ).FirstOrDefaultAsync();

            return recruitment;
        }



        public async Task UpdateRecruitmentMasterAsync(UpdateRecruitmentMasterRequest request)
        {
            //using var transaction = await context.Database.BeginTransactionAsync();
            //try
            //{
            //    var recruitmentmaster = await context.RecruitmentMasters
            //        .Include(r => r.RecruitmentDetails)
            //        .FirstOrDefaultAsync(r => r.RecruitmentMasterId == request.RecruitmentMasterId);

            //    if (recruitmentmaster == null)
            //        throw new Exception("RecruitmentMaster not found");

            //    // Update master fields (same as before)...
            //    recruitmentmaster.RecruitmentMasterPositionId = request.RecruitmentMasterPositionId;
            //    recruitmentmaster.RecruitmentMasterCode = request.RecruitmentMasterCode;
            //    recruitmentmaster.RecruitmentMasterReferenceId = request.RecruitmentMasterReferenceId;
            //    recruitmentmaster.RecruitmentMasterReferenceName = request.RecruitmentMasterReferenceName;
            //    recruitmentmaster.RecruitmentMasterReferenceCode = request.RecruitmentMasterReferenceCode;
            //    recruitmentmaster.RecruitmentMasterNameOfCandidates = request.RecruitmentMasterNameOfCandidates;
            //    recruitmentmaster.RecruitmentMasterCityId = request.RecruitmentMasterCityId;
            //    recruitmentmaster.RecruitmentMasterCompanyId = request.RecruitmentMasterCompanyId;
            //    recruitmentmaster.RecruitmentMasterCandidateEmailId = request.RecruitmentMasterCandidateEmailId;
            //    recruitmentmaster.RecruitmentMasterCandidateContactNumber = request.RecruitmentMasterCandidateContactNumber;
            //    recruitmentmaster.RecruitmentMasterAppropriateForJobRole = request.RecruitmentMasterAppropriateForJobRole;
            //    recruitmentmaster.RecruitmentMasterInterviewerEmployeeId = request.RecruitmentMasterInterviewerEmployeeId;
            //    recruitmentmaster.RecruitmentMasterInterviewerComment = request.RecruitmentMasterInterviewerComment;
            //    recruitmentmaster.RecruitmentMasterGradeId = request.RecruitmentMasterGradeId;
            //    recruitmentmaster.RecruitmentMasterDesignationId = request.RecruitmentMasterDesignationId;
            //    recruitmentmaster.RecruitmentMasterCurrentCtcpa = request.RecruitmentMasterCurrentCtcpa;
            //    recruitmentmaster.RecruitmentMasterExpectedCtcpa = request.RecruitmentMasterExpectedCtcpa;
            //    recruitmentmaster.RecruitmentMasterRecommendedCtcpa = request.RecruitmentMasterRecommendedCtcpa;
            //    recruitmentmaster.RecruitmentMasterExpectedJoiningDate = request.RecruitmentMasterExpectedJoiningDate;
            //    recruitmentmaster.RecruitmentMasterHrcomment = request.RecruitmentMasterHrcomment;
            //    recruitmentmaster.RecruitmentMasterRecruitmentStageStatusId = request.RecruitmentMasterRecruitmentStageStatusId;
            //    recruitmentmaster.RecruitmentMasterOfferLetterStatus = request.RecruitmentMasterOfferLetterStatus;
            //    recruitmentmaster.RecruitmentMasterRemark = request.RecruitmentMasterRemark;
            //    recruitmentmaster.RecruitmentMasterAuthRemark = request.RecruitmentMasterAuthRemark;
            //    recruitmentmaster.RecruitmentMasterAuth = request.RecruitmentMasterAuth;
            //    recruitmentmaster.RecruitmentMasterIsDiscard = request.RecruitmentMasterIsDiscard;
            //    recruitmentmaster.RecruitmentMasterIsActive = request.RecruitmentMasterIsActive;
            //    recruitmentmaster.CreatedBy = request.CreatedBy;
            //    recruitmentmaster.CreatedDate = request.CreatedDate;

            //    // Remove + re-add details
            //    context.RecruitmentDetails.RemoveRange(recruitmentmaster.RecruitmentDetails);

            //    if (request.RecruitmentDetails != null && request.RecruitmentDetails.Any())
            //    {
            //        context.RecruitmentDetails.RemoveRange(recruitmentmaster.RecruitmentDetails);
            //        var newDetails = request.RecruitmentDetails.Select(item => new RecruitmentDetail
            //        {
            //            DetailsRecruitmentMasterId = recruitmentmaster.RecruitmentMasterId,
            //            RecruitmentDetailsInterviewRoundNumber = item.newRound,
            //            RecruitmentDetailsMarksObtained = item.newMarks,
            //            RecruitmentDetailsAttributeId = item.newAttributeId
            //        }).ToList();

            //        await context.RecruitmentDetails.AddRangeAsync(newDetails);
            //    }

            //    await context.SaveChangesAsync();
            //    await transaction.CommitAsync(); // ✅ commit
            //}
            //catch (Exception ex)
            //{
            //    await transaction.RollbackAsync(); // ❌ rollback
            //    throw new Exception($"Error updating RecruitmentMaster: {ex.Message}", ex);
            //}

            var strategy = context.Database.CreateExecutionStrategy();

            await strategy.ExecuteAsync(async () =>
            {
                await using var transaction = await context.Database.BeginTransactionAsync();
                try
                {
                    var recruitmentmaster = await context.RecruitmentMasters
                        .Include(r => r.RecruitmentDetails)
                        .FirstOrDefaultAsync(r => r.RecruitmentMasterId == request.RecruitmentMasterId);

                    if (recruitmentmaster == null)
                        throw new Exception("RecruitmentMaster not found");

                    // Update master fields
                    recruitmentmaster.RecruitmentMasterPositionId = request.RecruitmentMasterPositionId;
                    recruitmentmaster.RecruitmentMasterCode = request.RecruitmentMasterCode;
                    recruitmentmaster.RecruitmentMasterReferenceId = request.RecruitmentMasterReferenceId;
                    recruitmentmaster.RecruitmentMasterReferenceName = request.RecruitmentMasterReferenceName;
                    recruitmentmaster.RecruitmentMasterReferenceCode = request.RecruitmentMasterReferenceCode;
                    recruitmentmaster.RecruitmentMasterNameOfCandidates = request.RecruitmentMasterNameOfCandidates;
                    recruitmentmaster.RecruitmentMasterCityId = request.RecruitmentMasterCityId;
                    recruitmentmaster.RecruitmentMasterCompanyId = request.RecruitmentMasterCompanyId;
                    recruitmentmaster.RecruitmentMasterCandidateEmailId = request.RecruitmentMasterCandidateEmailId;
                    recruitmentmaster.RecruitmentMasterCandidateContactNumber = request.RecruitmentMasterCandidateContactNumber;
                    recruitmentmaster.RecruitmentMasterAppropriateForJobRole = request.RecruitmentMasterAppropriateForJobRole;
                    recruitmentmaster.RecruitmentMasterInterviewerEmployeeId = request.RecruitmentMasterInterviewerEmployeeId;
                    recruitmentmaster.RecruitmentMasterInterviewerComment = request.RecruitmentMasterInterviewerComment;
                    recruitmentmaster.RecruitmentMasterGradeId = request.RecruitmentMasterGradeId;
                    recruitmentmaster.RecruitmentMasterDesignationId = request.RecruitmentMasterDesignationId;
                    recruitmentmaster.RecruitmentMasterCurrentCtcpa = request.RecruitmentMasterCurrentCtcpa;
                    recruitmentmaster.RecruitmentMasterExpectedCtcpa = request.RecruitmentMasterExpectedCtcpa;
                    recruitmentmaster.RecruitmentMasterRecommendedCtcpa = request.RecruitmentMasterRecommendedCtcpa;
                    recruitmentmaster.RecruitmentMasterExpectedJoiningDate = request.RecruitmentMasterExpectedJoiningDate;
                    recruitmentmaster.RecruitmentMasterHrcomment = request.RecruitmentMasterHrcomment;
                    recruitmentmaster.RecruitmentMasterRecruitmentStageStatusId = request.RecruitmentMasterRecruitmentStageStatusId;
                    recruitmentmaster.RecruitmentMasterOfferLetterStatus = request.RecruitmentMasterOfferLetterStatus;
                    recruitmentmaster.RecruitmentMasterRemark = request.RecruitmentMasterRemark;
                    recruitmentmaster.RecruitmentMasterAuthRemark = request.RecruitmentMasterAuthRemark;
                    recruitmentmaster.RecruitmentMasterAuth = request.RecruitmentMasterAuth;
                    recruitmentmaster.RecruitmentMasterIsDiscard = request.RecruitmentMasterIsDiscard;
                    recruitmentmaster.RecruitmentMasterIsActive = request.RecruitmentMasterIsActive;
                    recruitmentmaster.CreatedBy = request.CreatedBy;
                    recruitmentmaster.CreatedDate = request.CreatedDate;

                    // Remove existing details
                    context.RecruitmentDetails.RemoveRange(recruitmentmaster.RecruitmentDetails);

                    // Add new details
                    if (request.RecruitmentDetails != null && request.RecruitmentDetails.Any())
                    {
                        var newDetails = request.RecruitmentDetails.Select(item => new RecruitmentDetail
                        {
                            DetailsRecruitmentMasterId = recruitmentmaster.RecruitmentMasterId,
                            RecruitmentDetailsInterviewRoundNumber = item.newRound,
                            RecruitmentDetailsMarksObtained = item.newMarks,
                            RecruitmentDetailsAttributeId = item.newAttributeId
                        }).ToList();

                        await context.RecruitmentDetails.AddRangeAsync(newDetails);
                    }

                    await context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            });

        }

        public async Task<List<GetRecruitmentNameandIdByPositionId>> GetRecruitmentIdandNameByPositonIdFromDB(int PositionId)
        {
            var result = await (from r in context.RecruitmentMasters
                                where r.RecruitmentMasterPositionId == PositionId
                                      && r.RecruitmentMasterOfferLetterStatus == "SEL"
                                select new GetRecruitmentNameandIdByPositionId
                                {
                                    RecruitmentMasterId = r.RecruitmentMasterId,
                                    RecruitmentMasterNameOfCandidates = r.RecruitmentMasterNameOfCandidates
                                }).ToListAsync();

            return result;
        }
    }
}
