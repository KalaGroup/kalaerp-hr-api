using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.ResponseDTO.CompanyMaster
{
    public class GetComanyIdAndNameResponseDTO
    {
        public int ParentCompanyId { get; set; }

        public string ParentCompanyName { get; set; } = null!;
    }
}
