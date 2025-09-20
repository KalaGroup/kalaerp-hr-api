using System;
using System.Collections.Generic;

namespace KalaGenset.ERP.HR.Data.Models;

public partial class OfferLetterCtc
{
    public int OfferLetterCtcid { get; set; }

    public int OfferLetterCtcofferLetterId { get; set; }

    public double OfferLetterBasic { get; set; }

    public double OfferLetterDa { get; set; }

    public double OfferLetterHra { get; set; }

    public double OfferLetterConvAllowance { get; set; }

    public double OfferLetterCityCompensatoryAlowance { get; set; }

    public double OfferLetterLeaveTravelAllowance { get; set; }

    public double OfferLetterCarAllowance { get; set; }

    public double OfferLetterFuelAllowance { get; set; }

    public double OfferLetterDriverAllowance { get; set; }

    public double OfferLetterMiscAllowance { get; set; }

    public double OfferLetterGross { get; set; }

    public double OfferLetterPt { get; set; }

    public double OfferLetterEsic { get; set; }

    public double OfferLetterPfemployer { get; set; }

    public double OfferLetterPfemployee { get; set; }

    public double OfferLetterMedicalInsurance { get; set; }

    public double OfferLetterPerformanceKpa { get; set; }

    public double OfferLetterGraduity { get; set; }

    public double OfferLetterBonus { get; set; }

    public double OfferLetterMlwf { get; set; }

    public virtual OfferLetter OfferLetterCtcofferLetter { get; set; } = null!;
}
