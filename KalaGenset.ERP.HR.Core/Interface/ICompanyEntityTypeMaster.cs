using KalaGenset.ERP.HR.Core.Request.CompanyEntityTypeMaster;
using KalaGenset.ERP.HR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface ICompanyEntityTypeMaster
    {
        /// <summary>
        ///  Add CompanyEntityTypeMaster Method Declaration
        /// </summary>
        /// <param name="insertCompanyEntityTypeMasterRequest"></param>
        /// <returns></returns>
        public Task InsertCompanyEntityTypeMaster(InsertCompanyEntityTypeMasterRequest insertCompanyEntityTypeMasterRequest);
        /// <summary>
        /// update CompanyEntityTypeMaster Method Declaration
        /// </summary>
        /// <param name="updateCompanyEntityTypeMasterRequest"></param>
        /// <returns></returns>
        public Task UpdateCompanyEntityMaster(UpdateCompanyEntityTypeMasterRequest updateCompanyEntityTypeMasterRequest);
        /// <summary>
        /// Delete CompanyEntityTypeMaster
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public Task DeleteCompanyAsync(int cid);

        /// <summary>
        /// Get CompanyEntityTypeMaster By ID
        /// </summary>
        /// <param name="cEntityId"></param>
        /// <returns></returns>
        public Task<CompanyEntityTypeMaster?> GetCompanyEntityTypeID(int cEntityId);

        /// <summary>
        /// Get All Details from CompanyEntityTypeMaster
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<CompanyEntityTypeMaster?>> GetCompanyEntityTypeAll();
    }
    }
