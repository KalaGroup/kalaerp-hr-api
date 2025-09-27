using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Request.ERPPageDetails
{
    public class InsertERPPageDetailsRequest
    {
        public int KalaErppageDetailsDivisionId { get; set; }

        public string PageTittle { get; set; } = null!;

        public string PageUrl { get; set; } = null!;

        public int PageType { get; set; }

        public string PageIsonumber { get; set; } = null!;

        public string KalaErppageDetailsRemark { get; set; } = null!;

        public string KalaErppageDetailsAuthRemark { get; set; } = null!;

        public bool KalaErppageDetailsAuth { get; set; }

        public bool KalaErppageDetailsIsDiscard { get; set; }

        public bool KalaErppageDetailsIsActive { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
