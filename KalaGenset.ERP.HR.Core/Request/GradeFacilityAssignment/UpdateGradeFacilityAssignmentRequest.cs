using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Request.GradeFacilityAssignment
{
    public class UpdateGradeFacilityAssignmentRequest
    {
        public int GradeFacilityAssignmentId { get; set; }
        public int AssignmentGradeId { get; set; }
        public int AssignmentFacilityId { get; set; }
    }
}
