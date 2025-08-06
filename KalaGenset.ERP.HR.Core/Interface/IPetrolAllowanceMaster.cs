using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KalaGenset.ERP.HR.Core.Request;
using KalaGenset.ERP.HR.Data.Models;

namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface IPetrolAllowanceMaster
    {
        public Task AddPetrolAllowanceMasterAsync(InsertPetrolAllowanceMasterRequest insertPetrolAllowanceMasterRequest);
        public Task<IEnumerable<PetrolAllowanceMaster>> GetPetrolAllowance();
        public Task<PetrolAllowanceMaster> GetPetrolAllowanceTypeById(int PetrolAllowanceId);
        public Task UpdatePetrolAllowanceMasterService(UpdatePetrolAllowanceMasterRequest updatePetrolAllowanceMasterRequest);
        public Task DeletePetrolAllowanceById(int petrolallowanceId);
    }

}
