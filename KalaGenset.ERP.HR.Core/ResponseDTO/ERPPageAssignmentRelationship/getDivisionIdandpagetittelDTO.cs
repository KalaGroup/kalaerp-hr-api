using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.ResponseDTO.ERPPageAssignmentRelationship
{
    public class getDivisionIdandpagetittelDTO
    {
        public int KalaErppageDetailsId { get; set; }
        public int ErppageAssignmentRelationshipDivisionId { get; set; }
        public string PageTittle { get; set; } = null!;
    }
}
