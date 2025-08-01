using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Request.Currency
{
    /// <summary>
    /// Represents a request to update the details of a currency in the system.
    /// </summary>
    /// <remarks>This class is used to encapsulate the data required for updating a currency, including its
    /// identifier, name, symbol,  and status. It also includes metadata about the creator and creation date of the
    /// request.</remarks>

    public class UpdateCurrencyRequest
    {
        public int CurrencyId { get; set; }

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
