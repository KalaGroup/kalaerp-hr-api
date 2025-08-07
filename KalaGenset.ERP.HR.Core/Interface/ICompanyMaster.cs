using KalaERP.HR.Core.Request.CompanyMaster;

using KalaGenset.ERP.HR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaERP.HR.Core.Interface
{
    public interface ICompanyMaster
    {
        public Task AddCompanyAsync(InsertCompanyRequest request);// Adds a new company to the system
        public Task<IEnumerable<CompanyMaster>> GetCompanyAsync();// Retrieves a list of all companies in the system
        public Task<CompanyMaster> GetCompanyByIdAsync(int id);// Retrieves a specific company by its ID

        public Task UpdateCompanyAsync(UpdateCompanyRequest request);// Updates an existing company in the system

        public Task DeleteCompanyAsync(int id);// Deletes a company from the system by its ID
    }
}
