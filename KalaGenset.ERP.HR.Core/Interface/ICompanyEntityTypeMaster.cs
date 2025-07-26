using KalaGenset.ERP.HR.Core.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface ICompanyEntityTypeMaster
    {
        /// <summary>
        ///  Add CompanyEntityTypeMaster Method Declaration
        /// </summary>
        /// <param name="insertCompanyEntityTypeMasterRequest"></param>
        /// <returns></returns>
        public  Task InsertCompanyEntityTypeMaster(CompanyEntityTypeMasterRequest insertCompanyEntityTypeMasterRequest);
        /// <summary>
        /// update CompanyEntityTypeMaster Method Declaration
        /// </summary>
        /// <param name="updateCompanyEntityTypeMasterRequest"></param>
        /// <returns></returns>
        public Task UpdateCompanyEntityMaster(CompanyEntityTypeMasterRequest updateCompanyEntityTypeMasterRequest);
        /// <summary>
        /// Delete CompanyEntityTypeMaster
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public Task DeleteCompanyAsync(int cid);
    }
}
