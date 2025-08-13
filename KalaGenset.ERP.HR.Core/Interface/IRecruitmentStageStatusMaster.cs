using KalaGenset.ERP.HR.Core.Request.ActivityMaster;
using KalaGenset.ERP.HR.Core.Request.RecruitmentStageStatusMaster;
using KalaGenset.ERP.HR.Core.Services;
using KalaGenset.ERP.HR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface IRecruitmentStageStatusMaster
    {
        /// <summary>
        /// Add RecruitmentStageStatusMaster Async
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task AddRecruitmentStageAsync(InsertRecruitmentStageStatusMasterRequest request);
        /// <summary>
        /// update RecruitmentStageStatusMaster Async
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task updateRecruitmentStageAsync(UpdateRecruitmentStageStatusMasterRequest request);
        /// <summary>
        /// Delete RecruitmentStageStatusMaster Async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task DeleteRecruitmentStageAsync(int id);
        /// <summary>
        /// Get by id RecruitmentStageStatusMaster Async
        /// </summary>
        /// <returns></returns>
        public Task<RecruitmentStageStatusMaster> GetRecruitmentStageByID(int id);
        /// <summary>
        /// Get All RecruitmentStageStatusMaster  Async
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<RecruitmentStageStatusMaster>> GetAllRecruitmentStageAsync();
    }
}
