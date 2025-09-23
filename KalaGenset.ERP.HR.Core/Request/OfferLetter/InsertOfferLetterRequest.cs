using KalaGenset.ERP.HR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Request.OfferLetter
{
    public class InsertOfferLetterRequest
    {

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

        public List<OfferLetterCtcDetail> offerLetterCtcs { get; set; }

       
    }
    public class OfferLetterCtcDetail
    { 

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
    }
}
