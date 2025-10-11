using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.ResponseDTO.ERPPageAssignmentRelationship
{
    public class PageAssignmentReleationshipDeatilsDTO
    {
        public int ErppageAssignmentRelationshipDetailsId { get; set; }

        public int DetailsErppageAssignmentRelationshipId { get; set; }

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
