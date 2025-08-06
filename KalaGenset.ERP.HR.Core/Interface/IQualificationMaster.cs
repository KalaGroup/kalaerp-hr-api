using KalaGenset.ERP.HR.Core.Request.QualificationRequest;
using KalaGenset.ERP.HR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface IQualificationMaster
    {
        /// <summary>
        /// add qual
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task AddQualificationAsync(InsertQualificationRequest request);
        /// <summary>
        /// update qual
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task UpdateQualificationAsync(UpdateQualificationRequest request);

        /// <summary>
        /// get qual
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<QualificationMaster>> GetQualificationDetailsAsync();
        /// <summary>
        /// get qual by id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Task<QualificationMaster?> GetQualificationByID(int Id);

        /// <summary>
        /// delete qual
        /// </summary>
        /// <param name="qid"></param>
        /// <returns></returns>
        public Task DeleteQualificationAsync(int qid);
    }
}
