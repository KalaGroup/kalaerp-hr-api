using KalaGenset.ERP.HR.Core.Request.Currency;
using KalaGenset.ERP.HR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Interface
{
    public interface ICurrencyMaster
    {
        /// <summary>
        /// Add new currency to this interface.
        /// 
        ///  AddCurrencyAsycn method.
        /// </summary>
        public Task AddCurrencyAsync(InsertCurrencyRequest request);
        /// <summary>
        /// get all currency from this interface.
        /// 
        /// GetCurrencyMstsAsync method.
        /// </summary>
        public Task<IEnumerable<CurrencyMaster>> GetCurrencyMstsAsync();
        /// <summary>
        /// update Currency in this interface.
        /// 
        /// UpdateCurrencyAsync method.
        /// </summary>  
        public Task UpdateCurrencyAsync(UpdateCurrencyRequest request);
        /// <summary>
        /// Get Currency by Id from this interface.
        /// 
        ///        GetCurrencyByIdAsync method.
        public Task<CurrencyMaster> GetCurrencyByIdAsync(int id);
        /// <summary>
        /// Delete Currency by Id from this interface.
        /// 
        /// DeleteCurrencyAsync
        /// </summary>
        public Task DeleteCurrencyAsync(int id);
    
    }
}
