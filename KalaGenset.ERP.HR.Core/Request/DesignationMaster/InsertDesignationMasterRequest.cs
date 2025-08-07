using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaERP.HR.Core.Request.DesignationMaster
{
    public class InsertDesignationMasterRequest
    {
        /// <summary>
        /// model for inserting a new designation into the database.
        /// </summary>
        public int DesignationGradeId { get; set; }

        public string DesignationCode { get; set; } = null!;

        public string DesignationName { get; set; } = null!;

        public int DesignationQualificationId { get; set; }

        public string DesignationDescription { get; set; } = null!;

        public string GradeQualificationRemark { get; set; } = null!;

        public int? ExperiencedRequired { get; set; }

        public string ExperiencedRemark { get; set; } = null!;

        public string RequiredSkills { get; set; } = null!;

        public string DesignationRemark { get; set; } = null!;
    }
}
