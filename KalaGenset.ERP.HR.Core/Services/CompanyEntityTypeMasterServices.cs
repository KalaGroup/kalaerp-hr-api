using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.CompanyEntityTypeMaster;
using KalaGenset.ERP.HR.Data.DbContexts;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.Core.Services
{
    public class CompanyEntityTypeMasterServices : ICompanyEntityTypeMaster
    {

        private readonly KalaDbContext _context;
        public CompanyEntityTypeMasterServices(KalaDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Insert Data in CompanyEntityTYpeMaster Table
        /// </summary>
        /// <param name="insertCompanyEntityTypeMasterRequest"></param>
        /// <returns></returns>
        public async Task InsertCompanyEntityTypeMaster(InsertCompanyEntityTypeMasterRequest insertCompanyEntityTypeMasterRequest)
        {
            try
            {
                var companyEntity = new CompanyEntityTypeMaster
                {
                    CompanyEntityTypeName = insertCompanyEntityTypeMasterRequest.CompanyEntityTypeName,
                    CompanyEntityTypeShortName = insertCompanyEntityTypeMasterRequest.CompanyEntityTypeShortName,
                    CompanyEntityTypeRemark = insertCompanyEntityTypeMasterRequest.CompanyEntityTypeRemark,
                    CompanyEntityTypeAuth = insertCompanyEntityTypeMasterRequest.CompanyEntityTypeAuth,
                    CompanyEntityTypeIsDiscard = insertCompanyEntityTypeMasterRequest.CompanyEntityTypeIsDiscard,
                    CompanyEntityTypeIsActive = insertCompanyEntityTypeMasterRequest.CompanyEntityTypeIsActive,
                    CreatedBy = insertCompanyEntityTypeMasterRequest.CreatedBy,
                    CreatedDate = insertCompanyEntityTypeMasterRequest.CreatedDate
                };
                _context.CompanyEntityTypeMasters.Add(companyEntity);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

        }
        /// <summary>
        /// Update Company Entity
        /// </summary>
        /// <param name="updateCompanyEntityTypeMasterRequest"></param>
        /// <returns></returns>
        public async Task UpdateCompanyEntityMaster(UpdateCompanyEntityTypeMasterRequest updateCompanyEntityTypeMasterRequest)
        {
            try
            {
                var companyEntityType = await _context.CompanyEntityTypeMasters.FindAsync(updateCompanyEntityTypeMasterRequest.CompEntityTypeId);
                if (companyEntityType == null)
                {
                    throw new Exception("Company Entity Type not found.");
                }

                companyEntityType.CompanyEntityTypeName = updateCompanyEntityTypeMasterRequest.CompanyEntityTypeName;
                companyEntityType.CompanyEntityTypeShortName = updateCompanyEntityTypeMasterRequest.CompanyEntityTypeShortName;
                companyEntityType.CompanyEntityTypeRemark = updateCompanyEntityTypeMasterRequest.CompanyEntityTypeRemark;
                _context.CompanyEntityTypeMasters.Update(companyEntityType);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Delete Company Type Entity
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public async Task DeleteCompanyAsync(int cid)
        {
            try
            {
                var companyEntityType = await _context.CompanyEntityTypeMasters.FirstOrDefaultAsync(c => c.CompEntityTypeId == cid);
                companyEntityType.CompanyEntityTypeIsActive = false;
                // company.UpdatedDate = DateTime.Now;
                _context.CompanyEntityTypeMasters.Update(companyEntityType);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<CompanyEntityTypeMaster?> GetCompanyEntityTypeID(int cEntityId)
        {
            try
            {
                return await _context.CompanyEntityTypeMasters.FirstOrDefaultAsync(c => c.CompEntityTypeId == cEntityId);

            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<CompanyEntityTypeMaster?>> GetCompanyEntityTypeAll()
        {
            try
            {
                return await _context.CompanyEntityTypeMasters.ToListAsync();

            }
            catch
            {
                throw;
            }
        }
    }
    }
