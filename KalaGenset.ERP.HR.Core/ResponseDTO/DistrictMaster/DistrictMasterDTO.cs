using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.ResponseDTO.DistrictMaster
{
    public class DistrictMasterDTO
    {
        public int DistrictId { get; set; }

        public string CountryName { get; set; } = null!;

        public string StateName { get; set; } = null!;

        public string DistrictCode { get; set; } = null!;

        public string DistrictName { get; set; } = null!;

        public string ShortName { get; set; } = null!;

        public bool IsDiscard { get; set; }

        public bool IsActive { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string DistrictMasterRemark { get; set; } = null!;

        public string DistrictMasterAuthRemark { get; set; } = null!;

        public bool DistrictMasterAuth { get; set; }
    }
}
