using KalaGenset.ERP.HR.Core.Request.ActivityDetails;
using KalaGenset.ERP.HR.Core.Request.Currency;
using KalaGenset.ERP.HR.Core.ResponseDTO.CTC;
using KalaGenset.ERP.HR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface ICTCStructureMaster
    {
        /// <summary>
        /// Add CTC Structure 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task AddCTCStructureAsync(InsertCTCStructureMasterRequest request);
        /// <summary>
        /// update ctc
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task UpdateCTCStructureAsync(UpdateCTCStructureMasterRequest request);
        /// <summary>
        /// Delete ctc
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task DeleteCTCStructureAsync(int id);
        /// <summary>
        /// Get All CTC
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<CTCStructureMasterResponseDTO>> GetCTCStructureAsync();
        /// <summary>
        /// Get By Id CtC
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<CtcstructureMaster> GetCTCStructureByIdAsync(int id);
       
    }
    
}
