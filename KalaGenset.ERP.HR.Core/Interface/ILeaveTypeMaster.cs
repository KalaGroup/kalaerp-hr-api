using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KalaGenset.ERP.HR.Core.Request;
using KalaGenset.ERP.HR.Core.Request.LeaveTypeMaster;
using KalaGenset.ERP.HR.Core.ResponseDTO.LeaveTypeMaster;
using KalaGenset.ERP.HR.Data.Models;

namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface ILeaveTypeMaster
    {
        public Task AddLeaveTypeAsync(InsertleaveTypeMasterRequest request);
        public Task<IEnumerable<LeaveTypeMasterResponseDTO>> GetLeaveTypeDetailsAsync();
        public Task<LeaveTypeMaster?> GetLeaveTypeById(int LeaveTypeMasterId);
        public Task DeleteLeaveTypeAsync(int id);
        public Task UpdateLeaveTypeAsync(UpdateLeaveTypeMasterRequest request);
    }
}
