using KalaGenset.ERP.HR.Core.Request.LeaveApplication;
using KalaGenset.ERP.HR.Core.Request.OfferLetter;
using KalaGenset.ERP.HR.Core.ResponseDTO.LeaveApplication;
using KalaGenset.ERP.HR.Core.ResponseDTO.OfferLetter;
using KalaGenset.ERP.HR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface ILeaveApplication
    {
        public Task AddLeaveApplicationAsync(InsertLeaveApplicationRequest request);
        public Task<IEnumerable<LeaveApplicationDTO>> GetAllLeaveApplicationAsync();
        public Task<LeaveApplication?> GetLeaveApplicationById(int LeaveApplicationId);
        public Task DeleteLeaveApplicationAsync(int LeaveApplicationId);
        public Task UpdateLeaveApplicationAsync(UpdateLeaveApplicationRequest request);
    }
}
