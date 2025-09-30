using KalaGenset.ERP.HR.Core.Request.GatePassType;
using KalaGenset.ERP.HR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface IGatePassType
    {
        public Task AddGatePassTypeAsync(InsertGatePassTypeRequest request);

        public Task UpdateGatePassTypeAsync(UpdateGatePassTypeRequest request);

        public Task DeleteGatePassTypeAsync(int id);

        public Task<GatePassType?> GetGatePassTypeByIdAsync(int id);

        public Task<IEnumerable<GatePassType>> GetGatePassTypeDetailsAsync();
    }
}
