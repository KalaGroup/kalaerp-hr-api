using KalaGenset.ERP.HR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Request.ResposibilitiesMaster
{
    public class UpdateResposibilitiesMasterRequest
    {
        public int ResposibilitiesId { get; set; }

        public int ResposibilitiesGradeId { get; set; }

        public int ResposibilitiesDesignationId { get; set; }

        public string ResposibilitiesRemark { get; set; } = null!;

        public string ResposibilitiesType { get; set; } = null!;

        public string ResposibilitiesAuthRemark { get; set; } = null!;

        public bool ResposibilitiesAuth { get; set; }

        public bool ResposibilitiesIsDiscard { get; set; }

        public bool ResposibilitiesIsActive { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

       // public virtual DesignationMaster ResposibilitiesDesignation { get; set; } = null!;
    }
}
