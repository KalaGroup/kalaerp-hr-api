using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.DailyAttendance;
using KalaGenset.ERP.HR.Core.ResponseDTO.DailyAttendance;
using KalaGenset.ERP.HR.Core.ResponseDTO.RecruitmentMaster;
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
    public class DailyAttendanceServices : IDailyAttendance
    {
        private readonly KalaDbContext context;
        public DailyAttendanceServices(KalaDbContext _context)
        {
            context = _context;
        }
        public async Task AddDailyAttendanceAsync(InsertDailyAttendanceRequest request)
        {
            try
            {
                var dailyAttendance = new DailyAttendance
                {
                    AttendanceEmployeeId = request.AttendanceEmployeeId,
                    AttendanceCompanyId = request.AttendanceCompanyId,
                    AttendanceDate = request.AttendanceDate,
                    InTime = request.InTime,
                    OutTime = request.OutTime,
                    AttendanceShiftId = request.AttendanceShiftId,
                    InTimeAuth = request.InTimeAuth,
                    OutTimeAuth = request.OutTimeAuth,
                    AttendanceStatus = request.AttendanceStatus,
                    AttendanceRemark = request.AttendanceRemark,
                    AttendanceInTimeAuthRemark = request.AttendanceInTimeAuthRemark,
                    AttendanceOutTimeAuthRemark = request.AttendanceOutTimeAuthRemark,
                    AttendanceIsDiscard = request.AttendanceIsDiscard,
                    AttendanceIsActive = request.AttendanceIsActive,
                    CreatedBy = request.CreatedBy,
                    CreatedDate = request.CreatedDate,
                    UpdatedBy = request.UpdatedBy,
                    UpdatedDate = request.UpdatedDate
                };

                context.DailyAttendances.Add(dailyAttendance);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // log ex if needed
                throw;
            }
        }


        public async Task DeleteDailyAttendanceAsync(int AttendanceId)
        {
            try
            {
                // Find the daily attendance record by ID
                var attendance = await context.DailyAttendances
                    .FirstOrDefaultAsync(x => x.AttendanceId == AttendanceId);

                if (attendance == null)
                    throw new KeyNotFoundException($"DailyAttendance with ID {AttendanceId} not found.");

                // Mark as inactive instead of deleting
                attendance.AttendanceIsActive = false;  // Make sure you have this property in your entity

                context.DailyAttendances.Update(attendance);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Optionally log the exception
                throw;
            }
        }


        public async Task<IEnumerable<DailyAttendanceDTO>> GetAllDailyAttendanceAsync()
        {
            return await context.DailyAttendances
                .Where(x => x.AttendanceIsActive) // only active records
                .OrderBy(x => x.AttendanceId)
                .Select(x => new DailyAttendanceDTO
                {
                    AttendanceId = x.AttendanceId,
                    EmployeeMasterFullName = x.AttendanceEmployee.EmployeeMasterFullName, // navigation property
                    CompanyName = x.AttendanceCompany.CompanyName,                         // navigation property
                    AttendanceDate = x.AttendanceDate,                                     // convert if needed
                    InTime = x.InTime,
                    OutTime = x.OutTime,
                    InTimeAuth = x.InTimeAuth,
                    OutTimeAuth = x.OutTimeAuth,
                    ShiftMasterName = x.AttendanceShift.ShiftMasterName,                  // navigation property
                    AttendanceStatus = x.AttendanceStatus,
                    AttendanceRemark = x.AttendanceRemark,
                    AttendanceInTimeAuthRemark = x.AttendanceInTimeAuthRemark,
                    AttendanceOutTimeAuthRemark = x.AttendanceOutTimeAuthRemark,
                    AttendanceIsDiscard = x.AttendanceIsDiscard,
                    AttendanceIsActive = x.AttendanceIsActive
                })
                .ToListAsync();
        }


        public async Task<DailyAttendance?> GetDailyAttendancenById(int AttendanceId)
        {
          return await context.DailyAttendances
                .FirstOrDefaultAsync(x => x.AttendanceId == AttendanceId && x.AttendanceIsActive);
        }

        public async Task<List<EmployeeNameAndCompanyNameDTO>> GetEmployeeIdAndNameAsync()
        {
            var employees = await context.CompanyMasters
                .Where(c => c.CompanyIsActive)
                .Select(c => new EmployeeNameAndCompanyNameDTO
                {
                 
                  CompanyId = c.CompanyId,
                  CompanyName = c.CompanyName,
                  //EmployeeMasterFullName = c.EmployeeMasters
                  //      .Where(e => e.EmployeeIsActive)
                  //      .Select(e => e.EmployeeMasterFullName)
                  //      .FirstOrDefault() ?? "No Active Employee"

                })
                .ToListAsync();

            return employees;
        }




        public async Task UpdateDailyAttendanceAsync(UpdateDailyAttendanceRequest request)
        {
            try
            {
                // Find the attendance record by ID
                var attendance = await context.DailyAttendances
                    .FirstOrDefaultAsync(x => x.AttendanceId == request.AttendanceId);

                if (attendance == null)
                {
                    throw new Exception("Daily Attendance record not found.");
                }

                // Update fields
                attendance.AttendanceEmployeeId = request.AttendanceEmployeeId;
                attendance.AttendanceCompanyId = request.AttendanceCompanyId;
                attendance.AttendanceDate = request.AttendanceDate; // convert if entity is DateTime
                attendance.InTime = request.InTime;
                attendance.OutTime = request.OutTime;
                attendance.AttendanceShiftId = request.AttendanceShiftId;
                attendance.InTimeAuth = request.InTimeAuth;
                attendance.OutTimeAuth = request.OutTimeAuth;
                attendance.AttendanceStatus = request.AttendanceStatus;
                attendance.AttendanceRemark = request.AttendanceRemark;
                attendance.AttendanceInTimeAuthRemark = request.AttendanceInTimeAuthRemark;
                attendance.AttendanceOutTimeAuthRemark = request.AttendanceOutTimeAuthRemark;
                attendance.AttendanceIsDiscard = request.AttendanceIsDiscard;
                attendance.AttendanceIsActive = request.AttendanceIsActive;
                attendance.CreatedBy = request.CreatedBy;
                attendance.CreatedDate = request.CreatedDate;
                attendance.UpdatedBy = request.UpdatedBy;
                attendance.UpdatedDate = request.UpdatedDate;

                context.DailyAttendances.Update(attendance);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
