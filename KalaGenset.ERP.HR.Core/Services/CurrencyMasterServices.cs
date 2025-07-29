using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.Currency;
using KalaGenset.ERP.HR.Data.DbContexts;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Services 
{
    public class CurrencyMasterServices:ICurrencyMaster
    {
        private readonly KalaDbContext context;
        public CurrencyMasterServices(KalaDbContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// AddCurrency Method
        /// </summary>
        public async Task AddCurrencyAsync(InsertCurrencyRequest request)
        {
            try
            {
                var currency = new CurrencyMaster
                {
                    CurrencyName = request.CurrencyName,
                    CurrencySymbol = request.CurrencySymbol,
                    CurrencyIsActive = request.CurrencyIsActive,
                    CreatedBy = request.CreatedBy,
                    CreatedDate = request.CreatedDate,
                    CurrencyRemark = request.CurrencyRemark,
                    CurrencyAuth = request.CurrencyAuth,
                    CurrencyIsDiscard = request.CurrencyIsDiscard
                };				
                context.CurrencyMasters.Add(currency);
                await context.SaveChangesAsync();
            }
            catch (Exception )
            {
                throw;//  Handle Error
            }
        }
        /// <summary>
        /// Delete Currency Method
        /// </summary>
        public async Task DeleteCurrencyAsync(int id)
        {
            try
            {
                var currency = await context.CurrencyMasters.FirstOrDefaultAsync(c => c.CurrencyId == id);
                currency.CurrencyIsActive = false;
                context.CurrencyMasters.Update(currency);
                await context.SaveChangesAsync();
            }
            catch (Exception )
            {
                throw;
            }
        }
        /// <summary>
        /// Get Currency by Id Method
        /// </summary>
        public async Task<CurrencyMaster> GetCurrencyByIdAsync(int id)
        {
            return await context.CurrencyMasters.FirstOrDefaultAsync(c => c.CurrencyId == id);
        }
        public async Task<IEnumerable<CurrencyMaster>> GetCurrencyMstsAsync()
        {
            return await context.CurrencyMasters.ToListAsync();
        }
        /// <summary>
        /// Update Currency Method
        /// </summary>
        public async Task UpdateCurrencyAsync(UpdateCurrencyRequest request)
        {          
            try
            {
                var currency = await context.CurrencyMasters.FirstOrDefaultAsync(c => c.CurrencyId == request.CurrencyId);
                currency.CurrencyName = request.CurrencyName;
                currency.CurrencySymbol = request.CurrencySymbol;
                currency.CurrencyIsActive = request.CurrencyIsActive;
                currency.CreatedBy = request.CreatedBy;
                currency.CreatedDate = request.CreatedDate;
                currency.CurrencyRemark = request.CurrencyRemark;
                currency.CurrencyIsDiscard = request.CurrencyIsDiscard;
                currency.CurrencyAuth = request.CurrencyAuth;
                context.CurrencyMasters.Update(currency);
                await context.SaveChangesAsync();
            }
            catch (Exception )
            {
                throw;  //Handle Error
            }
        }

    }
}
