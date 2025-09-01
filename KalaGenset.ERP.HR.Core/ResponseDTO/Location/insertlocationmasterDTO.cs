using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.ResponseDTO.Location
{
    public class InsertLocationMasterDTO
    {
        public int LocationId { get; set; }

        public string LocationCode { get; set; } = null!;

        public string LocationName { get; set; } = null!;

        public string ProfitCenterName { get; set; } = null!;

        public string LocationRemark { get; set; } = null!;

        public string LocationType { get; set; } = null!;

        public string LocationAuthRemark { get; set; } = null!;

        public bool LocationAuth { get; set; }

        public bool LocationIsDiscard { get; set; }

        public bool LocationIsActive { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
