using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.ResponseDTO.Currency
{
    public class CurrencyResponseDto
    {
        public int CurrencyId { get; set; }
        public string CurrencyName { get; set; } = null!;
    }
}
