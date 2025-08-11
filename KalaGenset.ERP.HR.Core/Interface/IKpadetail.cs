using KalaGenset.ERP.HR.Core.Request.KPADetail;
using KalaGenset.ERP.HR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface IKpadetail
    {
        /// <summary>
        /// add KPA Details
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task InsertKPADetailAsync(InsertKpadetailRequest request);
        /// <summary>
        /// uqdate KPA Details
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task UpdateKPADetailAsync(UpdateKpadetailRequest request);
        /// <summary>
        /// delete KPA Details by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task DeleteKPADetailAsync(int id);
        /// <summary>
        /// get all KPA Details
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Kpadetail>> GetAllKPADetailsAsync();
            /// <summary>
            /// get KPA Details by ID
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
        public Task<Kpadetail> GetKPADetailByID(int id);
    }
}
