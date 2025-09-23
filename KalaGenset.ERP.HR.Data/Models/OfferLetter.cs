using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class OfferLetter
{
    public int OfferLetterId { get; set; }

    public int OfferLetterPositionId { get; set; }

    public int OfferLetterRecruitmentId { get; set; }

    public DateOnly OfferLetterJoinindate { get; set; }

    public string OfferLetterRemark { get; set; } = null!;

    public string OfferLetterAuth1Remark { get; set; } = null!;

    public bool OfferLetterAuth1 { get; set; }

    public string OfferLetterAuth2Remark { get; set; } = null!;

    public bool OfferLetterAuth2 { get; set; }

    public string OfferLetterAuth3Remark { get; set; } = null!;

    public bool OfferLetterAuth3 { get; set; }

    public bool OfferLetterIsDiscard { get; set; }

    public bool OfferLetterIsActive { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int UpdatedBy { get; set; }

    public DateTime UpdatedDate { get; set; }

    public virtual ICollection<OfferLetterCtc> OfferLetterCtcs { get; set; } = new List<OfferLetterCtc>();

    public virtual PositionMaster OfferLetterPosition { get; set; } = null!;

    public virtual RecruitmentMaster OfferLetterRecruitment { get; set; } = null!;
}
