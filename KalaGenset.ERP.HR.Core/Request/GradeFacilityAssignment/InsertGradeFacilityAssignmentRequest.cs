using KalaGenset.ERP.HR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Request.GradeFacilityAssignment
{
    public class InsertGradeFacilityAssignmentRequest
    {
        //public int GradeFacilityAssignmentId { get; set; }

        public int AssignmentGradeId { get; set; }

        public int AssignmentFacilityId { get; set; }

        //public virtual FacilityMaster AssignmentFacility { get; set; }

       // public virtual GradeMaster AssignmentGrade { get; set; } 
    }
}
