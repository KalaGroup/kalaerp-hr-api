using KalaGenset.ERP.HR.Core.Request.ProfitcenterMaster;
using KalaGenset.ERP.HR.Core.Request.RecruitmentAttributeMaster;
using KalaGenset.ERP.HR.Core.Request.RecruitmentReferenceMaster;
using KalaGenset.ERP.HR.Core.ResponseDTO.Company;
using KalaGenset.ERP.HR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Interface
{

    public interface IRecruitmentReferenceMaster
    {
        public Task AddRecruitmentReferenceAsync(InsertRecruitmentReferenceMasterRequest request);
        public Task UpdateRecruitmentReferenceAsync(UpdateRecruitmentReferenceMasterRequest request);

        public Task<IEnumerable<RecruitmentReferenceMaster>> GetAllRecruitmentReferenceAsync();

        public Task<RecruitmentReferenceMaster?> GetRecruitmentReferenceByIdAsync(int Id);

        public Task DeleteRecruitmentReferenceAsync(int Id);



    }
}
