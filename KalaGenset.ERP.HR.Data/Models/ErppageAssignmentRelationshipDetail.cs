using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class ErppageAssignmentRelationshipDetail
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

    public virtual ErppageAssignmentRelationship DetailsErppageAssignmentRelationship { get; set; } = null!;

    public virtual KalaErppageDetail ErppageAssignmentRelationshipDetailsPage { get; set; } = null!;

    public virtual PositionMaster? ErppageAssignmentRelationshipDetailschecker1Positiont { get; set; }

    public virtual PositionMaster? ErppageAssignmentRelationshipDetailschecker2Positiont { get; set; }

    public virtual PositionMaster? ErppageAssignmentRelationshipDetailschecker3Positiont { get; set; }

    public virtual PositionMaster? ErppageAssignmentRelationshipDetailschecker4Positiont { get; set; }

    public virtual PositionMaster? ErppageAssignmentRelationshipDetailschecker5Positiont { get; set; }
}
