using KalaGenset.ERP.HR.Core.Request.EmployeeMaster;
using KalaGenset.ERP.HR.Core.Request.OfferLetter;
using KalaGenset.ERP.HR.Core.ResponseDTO.EmployeeMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface IEmployeeMaster
    {
        public Task AddEmployeeMasterAsync(InsertEmployeeMasterRequest request);
        public Task UpdateEmployeeMasterAsync(UpdateEmployeeMasterRequest request);
        public Task<IEnumerable<EmployeeMasterDTO>> GetAllEmployeeMasterAsync();
        public Task DeleteEmployeeMasterAsync(int EmployeeMasterId  );
        public Task<EmployeeMasterDTO?> GetEmployeeMasterById(int EmployeeMasterId);
    }
}
