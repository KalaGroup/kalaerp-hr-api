using KalaGenset.ERP.HR.Core.Request.ProfitcenterMaster;
using KalaGenset.ERP.HR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface IProfitcenterMaster
    {

        public Task AddProfitCenterAsync(InsertProfitcenterRequest profitCenterMaster);

        public Task UpdateProfitCenterAsync(UpdateProfitcenterRequest updateProfitCenterMaster);

        public Task<IEnumerable<ProfitcenterMaster>> GetAllProfitCenterAsync();

        public Task<ProfitcenterMaster?> GetProfitCenterByIdAsync(int profitCenterId);

        public Task DeleteProfitCenterAsync(int facilityId);
    }
}
