using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core
{
    public class CountryDetailResponseDto
    {
        public int CountryId { get; set; }
        public string CountryCode { get; set; } = null!;
        public string CountryName { get; set; } = null!;
        public string CountryShortName { get; set; } = null!;
        public string CurrencyName { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
