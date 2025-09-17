using KalaGenset.ERP.HR.Core.Request.ProfitcenterMaster;
using KalaGenset.ERP.HR.Core.Request.RecruitmentMaster;
using KalaGenset.ERP.HR.Core.Request.RecruitmentReferenceMaster;
using KalaGenset.ERP.HR.Core.ResponseDTO.Company;
using KalaGenset.ERP.HR.Core.ResponseDTO.CompanyMaster;
using KalaGenset.ERP.HR.Core.ResponseDTO.RecruitmentMaster;
using KalaGenset.ERP.HR.Core.ResponseDTO.ResponsibilitiesMaster;
using KalaGenset.ERP.HR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface IRecruitmentMaster
    {
        public Task AddRecruitmentMasterAsync(InsertRecruitmentMasterRequest request);

        public Task UpdateRecruitmentMasterAsync(UpdateRecruitmentMasterRequest request);

        public Task<IEnumerable<RecruitmentMasterDTO>> GetAllRecruitmentMasterAsync();

        public Task<RecruitmentMaster?> GetRecruitmentMasterByIdAsync(int RecruitmentMasterId);

        public Task DeleteRecruitmentMasterAsync(int RecruitmentMasterId);
        public Task<List<GetEmployeeIdAndNameResponseDTO>> GetEmployeeIdAndNameAsync();
        public Task<List<GetPositionIdAnd_NameDTO>> GetPositionIdAndNameAsync();

        public Task<IEnumerable<getrecruitmenDetailsById>> GetrecruitmentDetailsByMsaterId(int RecruitmentMasterId);
    }
}
