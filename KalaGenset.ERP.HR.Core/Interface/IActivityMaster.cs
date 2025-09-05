using KalaGenset.ERP.HR.Core.Request.ActivityMaster;
using KalaGenset.ERP.HR.Core.Request.AuthoritieMaster;
using KalaGenset.ERP.HR.Core.Request.ResposibilitiesMaster;
using KalaGenset.ERP.HR.Core.ResponseDTO.ActivityMaster;
using KalaGenset.ERP.HR.Core.ResponseDTO.KPA;
using KalaGenset.ERP.HR.Core.ResponseDTO.ResponsibilitiesMaster;
using KalaGenset.ERP.HR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface IActivityMaster
    {
        public Task AddActivityAsync(InsertActivityMasterRequest request);
        public Task<IEnumerable<ActivityMaster>> GetActivityAsync();
        public Task<ActivityMaster> GetActivityByIdAsync(int id);
        public Task UpdateActivityAsync(UpdateActivityMasterRequest request);
        public Task DeleteActivityAsync(int id);
        public Task<List<InsertActivityMasterDTO>> GetActivityDetails();

      //  public Task<IEnumerable<getActivitydetailsById>> GetActivityDetailsByMsaterId(int masterId);

        public Task<IEnumerable<getActivitydetailsById>> GetActivityDetailsByMsaterId(int activityMstId);
    }
}
