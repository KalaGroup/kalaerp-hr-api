using KalaGenset.ERP.HR.Core.Request.DailyAttendance;
using KalaGenset.ERP.HR.Core.Request.LeaveApplication;
using KalaGenset.ERP.HR.Core.ResponseDTO.DailyAttendance;
using KalaGenset.ERP.HR.Core.ResponseDTO.LeaveApplication;
using KalaGenset.ERP.HR.Core.ResponseDTO.RecruitmentMaster;
using KalaGenset.ERP.HR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface IDailyAttendance
    {
        public Task AddDailyAttendanceAsync(InsertDailyAttendanceRequest request);
        public Task<IEnumerable<DailyAttendanceDTO>> GetAllDailyAttendanceAsync();
        public Task<DailyAttendance?> GetDailyAttendancenById(int AttendanceId);
        public Task DeleteDailyAttendanceAsync(int AttendanceId);
        public Task UpdateDailyAttendanceAsync(UpdateDailyAttendanceRequest request);

        public Task<List<EmployeeNameAndCompanyNameDTO>> GetEmployeeIdAndNameAsync();
    }
}
