using KalaGenset.ERP.HR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Request.ERPPageAssignmentRelationship
{
    public class InsertPageAssignmentRelationshipRequest
    {
        public int ErppageAssignmentRelationshipDivisionId { get; set; }

        public int ErppageAssignmentRelationshipDepartmentId { get; set; }

        public int ErppageAssignmentRelationshipProfitcenterId { get; set; }

        public string ErppageAssignmentRelationshipRemark { get; set; } = null!;

        public string ErppageAssignmentRelationshipAuth1Remark { get; set; } = null!;

        public string ErppageAssignmentRelationshipAuth2Remark { get; set; } = null!;

        public bool ErppageAssignmentRelationshipAuth1 { get; set; }

        public bool ErppageAssignmentRelationshipAuth2 { get; set; }

        public bool ErppageAssignmentRelationshipIsDiscard { get; set; }

        public bool ErppageAssignmentRelationshipIsActive { get; set; }

        public List<ErppageAssignmentRelationshipdto> RelationshipDetails { get; set; }
    }
    public class ErppageAssignmentRelationshipdto
    {
       // public int ErppageAssignmentRelationshipDetailsId { get; set; }

       //public int DetailsErppageAssignmentRelationshipId { get; set; }

        public int ErppageAssignmentRelationshipDetailsPageId { get; set; }

        public int? ErppageAssignmentRelationshipDetailschecker1PositiontId { get; set; }

        public int? ErppageAssignmentRelationshipDetailschecker2PositiontId { get; set; }

        public int? ErppageAssignmentRelationshipDetailschecker3PositiontId { get; set; }

        public int? ErppageAssignmentRelationshipDetailschecker4PositiontId { get; set; }

        public int? ErppageAssignmentRelationshipDetailschecker5PositiontId { get; set; }

        public string ErppageAssignmentRelationshipDetailsRemark { get; set; } = null!;

        public bool ErppageAssignmentRelationshipDetailsIsDiscard { get; set; }

        public bool ErppageAssignmentRelationshipDetailsIsActive { get; set; }

    }
}
