using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.ResponseDTO.CityMaster
{
    public class CityMasterResponseDTO
    {
        public int CityId { get; set; }
        public string CityName { get; set; } = null!;
        public string CityShortName { get; set; } = null!;

        public string StateName { get; set; } = null!;
        public string CountryName { get; set; } = null!;
        public string DistrictName { get; set; } = null!;

        public string CityCode { get; set; }

        public double? CityLatitude { get; set; }

        public double? CityLongitude { get; set; }

        public int CityTierTypeId { get; set; }

        public string CityRemark { get; set; }

        public bool CityAuth { get; set; } = false;

        public bool CityIsDiscard { get; set; }

        public bool CityIsActive { get; set; } = true;

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }


    }
}
