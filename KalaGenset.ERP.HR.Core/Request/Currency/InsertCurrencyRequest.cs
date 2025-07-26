using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Request.Currency
{
    /// <summary>
    /// Represents a request to insert a new currency into the system.
    /// </summary>
    /// <remarks>This class encapsulates the details required to create a new currency, including its name,
    /// symbol,  activation status, and metadata about the creator and creation date.</remarks>
    public class InsertCurrencyRequest
    {
        public string CurrencyName { get; set; } = null!;

        public string CurrencySymbol { get; set; } = null!;

        public string CurrencyRemark { get; set; } = null!;

        public bool CurrencyAuth { get; set; }

        public bool CurrencyIsDiscard { get; set; }

        public bool CurrencyIsActive { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
