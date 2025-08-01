using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Request.Country
{
    public class InsertCountryRequest
    {
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string CountryShortName { get; set; }
        public int CountryCurrencyId { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
