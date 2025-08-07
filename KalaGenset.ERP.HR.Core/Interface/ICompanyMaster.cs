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
        /// <summary>
        /// adds a new company to the system.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task AddCompanyAsync(InsertCompanyRequest request);
        /// <summary>
        /// gets a list of all companies in the system.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<CompanyMaster>> GetCompanyAsync();
        /// <summary>
        /// get by id of company
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<CompanyMaster> GetCompanyByIdAsync(int id);
        /// <summary>
        /// updates an existing company in the system.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task UpdateCompanyAsync(UpdateCompanyRequest request);
        /// <summary>
        /// deletes a company by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task DeleteCompanyAsync(int id);
    }
}
