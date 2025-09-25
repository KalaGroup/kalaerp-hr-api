using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.LeaveApplication;
using KalaGenset.ERP.HR.Core.Request.OfferLetter;
using KalaGenset.ERP.HR.Core.ResponseDTO.LeaveApplication;
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
    public class LeaveApplicationServices : ILeaveApplication
    {
        private readonly KalaDbContext context;
        public LeaveApplicationServices(KalaDbContext context)
        {
            this.context = context;
        }
        public async Task AddLeaveApplicationAsync(InsertLeaveApplicationRequest request)
        {
            try
            {
                var leaveApplication = new LeaveApplication
                {
                    LeaveApplicationsEmployeeId = request.LeaveApplicationsEmployeeId,
                    LeaveApplicationsLeaveTypeId = request.LeaveApplicationsLeaveTypeId,
                    LeaveApplicationsFromDate = request.LeaveApplicationsFromDate,
                    LeaveApplicationsToDate = request.LeaveApplicationsToDate,
                    LeaveApplicationsLeaveCount = request.LeaveApplicationsLeaveCount,
                    LeaveApplicationsRemark = request.LeaveApplicationsRemark,
                    LeaveApplicationsAuthRemark = request.LeaveApplicationsAuthRemark,
                    LeaveApplicationsAuth = request.LeaveApplicationsAuth,
                    LeaveApplicationsIsDiscard = request.LeaveApplicationsIsDiscard,
                    LeaveApplicationsIsActive = request.LeaveApplicationsIsActive,
                    CreatedBy = request.CreatedBy,
                    CreatedDate = request.CreatedDate,
                    UpdatedBy = request.UpdatedBy,
                    UpdatedDate = request.UpdatedDate,
                };

                context.LeaveApplications.Add(leaveApplication);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // log ex if needed
                throw;
            }
        }


        public async Task DeleteLeaveApplicationAsync(int LeaveApplicationId)
        {
            try
            {
                // Find the leave application by ID
                var leaveApp = await context.LeaveApplications
                    .FirstOrDefaultAsync(x => x.LeaveApplicationId == LeaveApplicationId);

                if (leaveApp == null)
                    throw new KeyNotFoundException($"LeaveApplication with ID {LeaveApplicationId} not found.");

                // Mark as inactive instead of deleting
                leaveApp.LeaveApplicationsIsActive = false;  // Make sure you have this property in your model

                context.LeaveApplications.Update(leaveApp);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Optionally log the exception
                throw;
            }
        }

        public async Task<IEnumerable<LeaveApplicationDTO>> GetAllLeaveApplicationAsync()
        {
            return await context.LeaveApplications
                .Where(x => x.LeaveApplicationsIsActive) // only active leaves
                .OrderBy(x => x.LeaveApplicationId)
                .Select(x => new LeaveApplicationDTO
                {
                    LeaveApplicationId = x.LeaveApplicationId,
                    EmployeeMasterFullName = x.LeaveApplicationsEmployee.EmployeeMasterFullName, // navigation property
                    LeaveTypeMasterName = x.LeaveApplicationsLeaveType.LeaveTypeMasterName,       // navigation property
                    LeaveApplicationsFromDate = x.LeaveApplicationsFromDate,
                    LeaveApplicationsToDate = x.LeaveApplicationsToDate,
                    LeaveApplicationsLeaveCount = x.LeaveApplicationsLeaveCount,
                    LeaveApplicationsRemark = x.LeaveApplicationsRemark,
                    LeaveApplicationsAuthRemark = x.LeaveApplicationsAuthRemark,
                    LeaveApplicationsAuth = x.LeaveApplicationsAuth,
                    LeaveApplicationsIsDiscard = x.LeaveApplicationsIsDiscard,
                    LeaveApplicationsIsActive = x.LeaveApplicationsIsActive
                })
                .ToListAsync();
        }


        public async Task<LeaveApplication?> GetLeaveApplicationById(int LeaveApplicationId)
        {
            return await context.LeaveApplications.FirstOrDefaultAsync(c => c.LeaveApplicationId == LeaveApplicationId);
        }

        public async Task UpdateLeaveApplicationAsync(UpdateLeaveApplicationRequest request)
        {
            try
            {
                // Find the leave application by ID
                var leaveApp = await context.LeaveApplications
                    .FirstOrDefaultAsync(x => x.LeaveApplicationId == request.LeaveApplicationId);

                if (leaveApp == null)
                {
                    throw new Exception("Leave Application not found.");
                }

                // Update fields
                leaveApp.LeaveApplicationsEmployeeId = request.LeaveApplicationsEmployeeId;
                leaveApp.LeaveApplicationsLeaveTypeId = request.LeaveApplicationsLeaveTypeId;
                leaveApp.LeaveApplicationsFromDate = request.LeaveApplicationsFromDate;
                leaveApp.LeaveApplicationsToDate = request.LeaveApplicationsToDate;
                leaveApp.LeaveApplicationsLeaveCount = request.LeaveApplicationsLeaveCount;
                leaveApp.LeaveApplicationsRemark = request.LeaveApplicationsRemark;
                leaveApp.LeaveApplicationsAuthRemark = request.LeaveApplicationsAuthRemark;
                leaveApp.LeaveApplicationsAuth = request.LeaveApplicationsAuth;
                leaveApp.LeaveApplicationsIsDiscard = request.LeaveApplicationsIsDiscard;
                leaveApp.LeaveApplicationsIsActive = request.LeaveApplicationsIsActive;
                leaveApp.CreatedBy = request.CreatedBy;
                leaveApp.CreatedDate = request.CreatedDate;
                leaveApp.UpdatedBy = request.UpdatedBy;
                leaveApp.UpdatedDate = request.UpdatedDate;

                context.LeaveApplications.Update(leaveApp);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
