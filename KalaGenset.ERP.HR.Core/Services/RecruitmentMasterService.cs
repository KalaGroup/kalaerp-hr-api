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
        private readonly KalaDbContext Context;
        public RecruitmentMasterService(KalaDbContext context)
        {
            Context = context;
        }
        public async Task AddRecruitmentMasterAsync(InsertRecruitmentMasterRequest request)
        {
            using var transaction = await Context.Database.BeginTransactionAsync();
            try
            {
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

                Context.RecruitmentMasters.Add(recruitmentmaster);
                await Context.SaveChangesAsync();

                int recruitmentMstId = recruitmentmaster.RecruitmentMasterId;

                if (request.RecruitmentDetails != null && request.RecruitmentDetails.Any())
                {
                    var details = request.RecruitmentDetails.Select(item => new RecruitmentDetail
                    {
                        DetailsRecruitmentMasterId = recruitmentMstId,
                        RecruitmentDetailsInterviewRoundNumber = item.newRound,
                        RecruitmentDetailsMarksObtained = item.newMarks,
                        RecruitmentDetailsAttributeId = item.newAttributeId
                    }).ToList();

                    Context.RecruitmentDetails.AddRange(details);
                    await Context.SaveChangesAsync();
                }

                // ✅ Commit only if all operations succeed
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                // ❌ Rollback if any operation fails
                await transaction.RollbackAsync();
                throw new Exception($"Error adding RecruitmentMaster: {ex.Message}", ex);
            }
        }



        public async Task DeleteRecruitmentMasterAsync(int recruitmentMasterId)
        {
            try
            {
                var recruitmentmaster = await Context.RecruitmentMasters
                    .Include(r => r.RecruitmentDetails) // 👈 load child details
                    .FirstOrDefaultAsync(c => c.RecruitmentMasterId == recruitmentMasterId);

                if (recruitmentmaster == null)
                    throw new Exception("RecruitmentMaster not found");
               
                // Remove details first
                if (recruitmentmaster.RecruitmentDetails.Any())
                    Context.RecruitmentDetails.RemoveRange(recruitmentmaster.RecruitmentDetails);
                recruitmentmaster.RecruitmentMasterIsActive = false;
              
                
                await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting RecruitmentMaster", ex);
            }
        }


        public async Task<IEnumerable<RecruitmentMasterDTO>> GetAllRecruitmentMasterAsync()
        {
            var recruitments = await (
                from rm in Context.RecruitmentMasters

                join pos in Context.PositionMasters
                    on rm.RecruitmentMasterPositionId equals pos.PositionMasterId   // ✅ FIXED

                join refm in Context.RecruitmentReferenceMasters
                    on rm.RecruitmentMasterReferenceId equals refm.RecruitmentReferenceId

                join city in Context.CityMasters
                    on rm.RecruitmentMasterCityId equals city.CityId

                join comp in Context.CompanyMasters
                    on rm.RecruitmentMasterCompanyId equals comp.CompanyId

                join emp in Context.EmployeeMasterPersonalDetails
                    on rm.RecruitmentMasterInterviewerEmployeeId equals emp.EmployeeMasterId

                join g in Context.GradeMasters
                    on rm.RecruitmentMasterGradeId equals g.GradeId

                join d in Context.DesignationMasters
                    on rm.RecruitmentMasterDesignationId equals d.DesignationId

                join stage in Context.RecruitmentStageStatusMasters
                    on rm.RecruitmentMasterRecruitmentStageStatusId equals stage.RecruitmentStageStatusId

                select new RecruitmentMasterDTO
                {
                    RecruitmentMasterId = rm.RecruitmentMasterId,
                    PositionMasterName = pos.PositionMasterName,
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
                    EmployeeMasterFullName = emp.EmployeeMasterFullName,
                    RecruitmentMasterInterviewerComment = rm.RecruitmentMasterInterviewerComment,
                    GradeName = g.GradeName,
                    DesignationName = d.DesignationName,
                    RecruitmentMasterCurrentCtcpa = rm.RecruitmentMasterCurrentCtcpa,
                    RecruitmentMasterExpectedCtcpa = rm.RecruitmentMasterExpectedCtcpa,
                    RecruitmentMasterRecommendedCtcpa = rm.RecruitmentMasterRecommendedCtcpa,
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
            var employees = await Context.EmployeeMasterPersonalDetails
                .Where(c => c.EmployeeMasterIsActive)
                //.Include(c => c.RecruitmentMasterInterviewerEmployee)
                .Select(c => new GetEmployeeIdAndNameResponseDTO
                {
                    EmployeeMasterId = c.EmployeeMasterId,
                    EmployeeMasterFullName = c.EmployeeMasterFullName,
                    EmployeeMasterCode=c.EmployeeMasterCode,
                     LeaveBalancesClosing=c.EmployeeLeaveBalances
                                        .Where(lb => lb.LeaveBalancesIsActive)
                                        .Sum(lb => lb.LeaveBalancesClosing)
                })
                .ToListAsync();

            return employees;
        }

        public async Task<List<GetPositionIdAnd_NameDTO>> GetPositionIdAndNameAsync()
        {
          var position=await Context.PositionMasters
                .Where(c=>c.PositionMasterIsActive)
                .Select(c=> new GetPositionIdAnd_NameDTO
                {
                    PositionMasterId = c.PositionMasterId,
                    PositionMasterName = c.PositionMasterName,
                })
                .ToListAsync();
            return position;
        }

        public async Task<IEnumerable<getrecruitmenDetailsById>> GetrecruitmentDetailsByMsaterId(int RecruitmentMasterId)
        {
            return await Context.RecruitmentDetails  // assuming your DbSet is called RecruitmentDetails
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

        public async Task<RecruitmentMaster?> GetRecruitmentMasterByIdAsync(int RecruitmentMasterId)
        {
            return await Context.RecruitmentMasters.FirstOrDefaultAsync(c => c.RecruitmentMasterId == RecruitmentMasterId);
        }

      
        public async Task UpdateRecruitmentMasterAsync(UpdateRecruitmentMasterRequest request)
        {
            using var transaction = await Context.Database.BeginTransactionAsync();
            try
            {
                var recruitmentmaster = await Context.RecruitmentMasters
                    .Include(r => r.RecruitmentDetails)
                    .FirstOrDefaultAsync(r => r.RecruitmentMasterId == request.RecruitmentMasterId);

                if (recruitmentmaster == null)
                    throw new Exception("RecruitmentMaster not found");

                // Update master fields (same as before)...
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

                // Remove + re-add details
                Context.RecruitmentDetails.RemoveRange(recruitmentmaster.RecruitmentDetails);

                if (request.RecruitmentDetails != null && request.RecruitmentDetails.Any())
                {
                    Context.RecruitmentDetails.RemoveRange(recruitmentmaster.RecruitmentDetails);
                    var newDetails = request.RecruitmentDetails.Select(item => new RecruitmentDetail
                    {
                        DetailsRecruitmentMasterId = recruitmentmaster.RecruitmentMasterId,
                        RecruitmentDetailsInterviewRoundNumber = item.newRound,
                        RecruitmentDetailsMarksObtained = item.newMarks,
                        RecruitmentDetailsAttributeId = item.newAttributeId
                    }).ToList();

                    await Context.RecruitmentDetails.AddRangeAsync(newDetails);
                }

                await Context.SaveChangesAsync();
                await transaction.CommitAsync(); // ✅ commit
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(); // ❌ rollback
                throw new Exception($"Error updating RecruitmentMaster: {ex.Message}", ex);
            }
        }


    }
}
