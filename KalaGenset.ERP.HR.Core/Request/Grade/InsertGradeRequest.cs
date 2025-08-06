using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KalaGenset.ERP.HR.Data.DbContexts;
using KalaGenset.ERP.HR.Data.Models;
namespace KalaGenset.ERP.HR.Core.Request.Grade
{
    public class InsertGradeRequest
    {
        public string GradeCode { get; set; }
        public string GradeName { get; set; }
        public string GradeLevel { get; set; }
        public int MinSalCtc { get; set; }
        public int MaxSalCtc { get; set; }
        public int GradeCurrencyId { get; set; }
        public string GradeDescription { get; set; }
        public int LeaveEntitlementAnnual { get; set; }
        public int ProbationPeriod { get; set; }
        public int NoticePeriod { get; set; }
        public string GradeRemark { get; set; }
        public bool GradeAuth { get; set; }
        public bool GradeIsDiscard { get; set; }
        public bool GradeIsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
