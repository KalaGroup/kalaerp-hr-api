using KalaERP.HR.Core.Request.CompanyMaster;
using KalaERP.HR.Core.Request.DesignationMaster;

using KalaGenset.ERP.HR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaERP.HR.Core.Interface
{
    public interface IDesignationMaster
    {
        public Task AddDesignationAsync(InsertDesignationMasterRequest request);
        public Task<IEnumerable<DesignationMaster>> GetDesignationAsync();
        public Task<DesignationMaster> GetDesigationByIdAsync(int id);

        public Task UpdateDesignationAsync(UpdateDesignationMasterRequest request);

        public Task DeleteDesignationAsync(int id);
    }
}
