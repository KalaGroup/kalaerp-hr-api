using KalaERP.HR.Core.Interface;
using KalaERP.HR.Core.Request.CompanyMaster;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.Currency;
using KalaGenset.ERP.HR.Data.DbContexts;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace KalaERP.HR.Core.Services
{
    public class CompanyMasterServices : ICompanyMaster
    {
        private readonly KalaDbContext context;// Database context for accessing company data
        public CompanyMasterServices(KalaDbContext context)// Constructor to initialize the context
        {
            this.context = context;
        }
        /// <summary>
        /// adds a new company to the system.
        /// it takes an InsertCompanyRequest object as input and saves the company details to the database.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task AddCompanyAsync(InsertCompanyRequest request)
        {
            try
            {
                var company = new CompanyMaster()
                {
                    CompanyCode = request.CompanyCode,
                    CompanyName = request.CompanyName,
                    ShortName = request.ShortName,
                    RegisteredAddress = request.RegisteredAddress,
                    RegisteredCountryId = request.RegisteredCountryId,
                    RegisteredStateId = request.RegisteredStateId,
                    RegisteredDistrictId = request.RegisteredDistrictId,
                    RegisteredCityId = request.RegisteredCityId,
                    RegisteredPinCode = request.RegisteredPinCode,
                    CorporateAddress = request.CorporateAddress,
                    CorporateCountryId = request.CorporateCountryId,
                    CorporateStateId = request.CorporateStateId,
                    CorporateDistrictId = request.CorporateDistrictId,
                    CorporateCityId = request.CorporateCityId,
                    CorporatePinCode = request.CorporatePinCode,
                    PhoneNumber = request.PhoneNumber,
                    EmailId = request.EmailId,
                    Website = request.Website,
                    SocialMedialink = request.SocialMedialink,
                    Pan = request.Pan,
                    Gst = request.Gst,
                    Cin = request.Cin,
                    EstablishedDate = request.EstablishedDate,
                    CompanyMasterEntityTypeId = request.CompanyMasterEntityTypeId,
                    ParentCompanyId = request.ParentCompanyId,
                    OwnershipPercentage = request.OwnershipPercentage,
                    CompanyCurrencyId = request.CompanyCurrencyId,     
                    FiscalYearStart = request.FiscalYearStart,
                    Logo = request.Logo,
                    AiinsightsEnabled = request.AiinsightsEnabled,
                    PredictiveAnalyticsLevel = request.PredictiveAnalyticsLevel,
                    InterCompanyTransactions = request.InterCompanyTransactions,
                    LocationAdvantageScore = request.LocationAdvantageScore,
                    TalentAccessibilityScore = request.TalentAccessibilityScore,
                    CostEfficiencyRating = request.CostEfficiencyRating,
                    CompanyIsAuth = request.CompanyIsAuth,
                    CompanyRemark = request.CompanyRemark,
                    CompanyIsDiscard = request.CompanyIsDiscard,
                    CompanyIsActive = request.CompanyIsActive,
                    CreatedBy = request.CreatedBy,
                    CreatedDate = request.CreatedDate,
                };
                context.CompanyMasters.Add(company);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;//  Handle Error
            }
        }
        public Task AddCurrencyAsync(InsertCurrencyRequest request)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// deletes a company from the system by its ID.
        /// soft delete is implemented by setting the CompanyIsActive property to false.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteCompanyAsync(int id)
        {
            try
            {
                var company = await context.CompanyMasters.FirstOrDefaultAsync(c => c.CompanyId == id);
                company.CompanyIsActive = false;
                context.CompanyMasters.Update(company);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// /gets a list of all companies in the system.
        /// fetches all records from the CompanyMasters table and returns them as a list of CompanyMaster objects.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CompanyMaster>> GetCompanyAsync()
        {
            return await context.CompanyMasters.Where(c=>c.CompanyIsActive==true).ToListAsync();
        }
        /// <summary>
        /// gets a company by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CompanyMaster> GetCompanyByIdAsync(int id)
        {
            return await context.CompanyMasters.FirstOrDefaultAsync(c => c.CompanyId == id);
        }
        /// <summary>
        /// updates an existing company in the system.
        /// updates the details of a company based on the provided UpdateCompanyRequest object.
        /// validates the request and updates the corresponding company record in the database.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task UpdateCompanyAsync(UpdateCompanyRequest request)
        {
            try
            {
                var company = await context.CompanyMasters.FirstOrDefaultAsync(c => c.CompanyId == request.CompanyId);
                company.CompanyCode = request.CompanyCode;
                company.CompanyName = request.CompanyName;
                company.ShortName = request.ShortName;
                company.RegisteredAddress = request.RegisteredAddress;
                company.RegisteredCountryId = request.RegisteredCountryId;
                company.RegisteredStateId = request.RegisteredStateId;
                company.RegisteredDistrictId = request.RegisteredDistrictId;
                company.RegisteredCityId = request.RegisteredCityId;
                company.RegisteredPinCode = request.RegisteredPinCode;
                company.CorporateAddress = request.CorporateAddress;
                company.CorporateCountryId = request.CorporateCountryId;
                company.CorporateStateId = request.CorporateStateId;
                company.CorporateDistrictId = request.CorporateDistrictId;
                company.CorporateCityId = request.CorporateCityId;
                company.CorporatePinCode = request.CorporatePinCode;
                company.PhoneNumber = request.PhoneNumber;
                company.EmailId = request.EmailId;
                company.Website = request.Website;
                company.SocialMedialink = request.SocialMedialink;
                company.Pan = request.Pan;
                company.Gst = request.Gst;
                company.Cin = request.Cin;
                company.EstablishedDate = request.EstablishedDate;
                company.CompanyMasterEntityTypeId = request.CompanyMasterEntityTypeId;
                company.ParentCompanyId = request.ParentCompanyId;
                company.OwnershipPercentage = request.OwnershipPercentage;
                company.CompanyCurrencyId = request.CompanyCurrencyId;
                company.FiscalYearStart = request.FiscalYearStart;
                company.Logo = request.Logo;
                company.AiinsightsEnabled = request.AiinsightsEnabled;
                company.PredictiveAnalyticsLevel = request.PredictiveAnalyticsLevel;
                company.InterCompanyTransactions = request.InterCompanyTransactions;
                company.LocationAdvantageScore = request.LocationAdvantageScore;
                company.TalentAccessibilityScore = request.TalentAccessibilityScore;
                company.CostEfficiencyRating = request.CostEfficiencyRating;
                company.CompanyIsAuth = request.CompanyIsAuth;
                company.CompanyRemark = request.CompanyRemark;
                company.CompanyIsDiscard = request.CompanyIsDiscard;
                company.CompanyIsActive = request.CompanyIsActive;
                company.CreatedBy = request.CreatedBy;
                company.CreatedDate = request.CreatedDate;
                context.CompanyMasters.Update(company);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;  //Handle Error
            }
        }
    }
}
