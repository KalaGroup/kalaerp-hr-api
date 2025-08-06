using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Request.ClassOfTravel
{
    public class InsertClassOfTravelRequest
    {
        public string ClassOfTravelCode { get; set; }
        public string ClassOfTravelName { get; set; }
        public int ClassOfTravelGradeId { get; set; }
        public int DafoodAllowancePerday { get; set; }
        public int ClassOfTravelTierType { get; set; }
        public string ClassOfTravelRemark { get; set; }
        public bool ClassOfTravelIsAuth { get; set; }
        public bool ClassOfTravelIsDiscard { get; set; }
        public bool ClassOfTravelIsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
