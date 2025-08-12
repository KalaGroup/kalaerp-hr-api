using KalaGenset.ERP.HR.Core.Request.RecruitmentAttributeMaster;
using KalaGenset.ERP.HR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface IRecruitmentAttributeMaster
    {
        /// <summary>
        /// Add a new RecruitmentAttributeMaster to the system.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task AddRecruitmentAttributeMasterAsync(InsertRecruitmentAttributeMasterRequest request);

        /// <summary>
        /// Get the details of all RecruitmentAttributeMasters in the system.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<RecruitmentAttributeMaster>> GetRecruitmentAttributeMasterDetailsAsync();

        /// <summary>
        /// Update the details of an existing RecruitmentAttributeMaster.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task UpdateRecruitmentAttributeMasterAsync(UpdateRecruitmentAttributeMasterRequest request);

        /// <summary>
        /// Get the details of a RecruitmentAttributeMaster by its ID.
        /// </summary>
        /// <param name="StateId"></param>
        /// <returns></returns>
        public Task<RecruitmentAttributeMaster?> GetRecruitmentAttributeMasterByID(int StateId);

        /// <summary>
        /// Delete a RecruitmentAttributeMaster by its ID. This marks the RecruitmentAttributeMaster as inactive instead of removing it from the database.
        /// </summary>
        /// <param name="wid"></param>
        /// <returns></returns>
        public Task DeleteRecruitmentAttributeMasterAsync(int wid);
    }
}
