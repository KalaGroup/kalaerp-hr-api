using KalaGenset.ERP.HR.Core.Request.District;
using KalaGenset.ERP.HR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface IDistrictMaster
    {

        public Task AddDistrictMasterAsync(InsertDistrictRequest request); 
        public Task UpdateDistrictMasterAsync(UpdateDistrictRequest request);
        public Task<IEnumerable<DistrictMaster>> GetDistrictMasterDetailsAsync();
        public Task<DistrictMaster?> GetDistrictMasterById(int DistrictId);
        public Task DeleteDistrictMasterAsync(int DistrictId);
    }
}
