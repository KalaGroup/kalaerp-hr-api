using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request;
using KalaGenset.ERP.HR.Data.DbContexts;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace KalaGenset.ERP.HR.Core.Services
{
    public class QualificationTypeMasterService : IQualificationTypeMaster

    {
        private readonly KalaDbContext _context;
        public QualificationTypeMasterService(KalaDbContext context)
        {
            _context = context;
        }

        public async Task AddQualificationTypeMasterAsync(InsertQualificationTypeMasterRequest InsertQualificationTypeMasterRequest)
        {
            try
            {
                var QualificationType = new QualificationTypeMaster
                {
                    QualificationTypeCode = InsertQualificationTypeMasterRequest.QualificationTypeCode,
                    QualificationTypeName = InsertQualificationTypeMasterRequest.QualificationTypeName,
                    QualificationTypeRemark = InsertQualificationTypeMasterRequest.QualificationTypeRemark,
                    QualificationTypeAuth = InsertQualificationTypeMasterRequest.QualificationTypeAuth,
                    QualificationTypeIsDiscard = InsertQualificationTypeMasterRequest.QualificationTypeIsDiscard,
                    QualificationTypeIsActive = InsertQualificationTypeMasterRequest.QualificationTypeIsActive,
                    CreatedBy = InsertQualificationTypeMasterRequest.CreatedBy,
                    CreatedDate = InsertQualificationTypeMasterRequest.CreatedDate,
                };
                await _context.QualificationTypeMasters.AddAsync(QualificationType);
                await _context.SaveChangesAsync();

            }
            catch
            {
                throw; // Let the controller handle the error
            }
        }

        public async Task<IEnumerable<QualificationTypeMaster>> GetAllQualificationType()
        {
            return await _context.QualificationTypeMasters.ToListAsync();

        }


        public async Task<QualificationTypeMaster?> GetQualificationTypeById(int QualificationTypeId)
        {
            return await _context.QualificationTypeMasters.FirstOrDefaultAsync(c => c.QualificationTypeId == QualificationTypeId);
        }
        public async Task UpdateQualificationTypeMasterAsync(UpdateQualificationTypeMasterRequest UpdateQualificationTypeMasterRequest)
        {
           
            try
            {
                var QualificationType = await _context.QualificationTypeMasters.FirstOrDefaultAsync(c => c.QualificationTypeId == UpdateQualificationTypeMasterRequest.QualificationTypeId);

                QualificationType.QualificationTypeCode = UpdateQualificationTypeMasterRequest.QualificationTypeCode;
                QualificationType.QualificationTypeId = UpdateQualificationTypeMasterRequest.QualificationTypeId;
                QualificationType.QualificationTypeName = UpdateQualificationTypeMasterRequest.QualificationTypeName;
                QualificationType.QualificationTypeRemark = UpdateQualificationTypeMasterRequest.QualificationTypeCode;
                QualificationType.QualificationTypeAuth = UpdateQualificationTypeMasterRequest.QualificationTypeAuth;
                QualificationType.QualificationTypeIsDiscard = UpdateQualificationTypeMasterRequest.QualificationTypeIsDiscard;
                QualificationType.QualificationTypeIsActive = UpdateQualificationTypeMasterRequest.QualificationTypeIsActive;
                QualificationType.CreatedBy = UpdateQualificationTypeMasterRequest.CreatedBy;
                QualificationType.CreatedDate = UpdateQualificationTypeMasterRequest.CreatedDate;

                _context.QualificationTypeMasters.Update(QualificationType);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    


        public  async Task DeleteQualificationTypeById(int QualificationTypeId)
        {
            try
            {

                var qualification = await _context.QualificationTypeMasters.FirstOrDefaultAsync(c => c.QualificationTypeId == QualificationTypeId);
                if (qualification == null)
                {
                    throw new Exception("Qualification Type not found");
                }
                if (!qualification.QualificationTypeIsActive)
                {
                    throw new Exception("Qualification type is alredy Soft Deleted");
                }
                qualification.QualificationTypeIsActive = false;
                _context.QualificationTypeMasters.Update(qualification);
                await _context.SaveChangesAsync();


            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}



// using var transaction = await _context.Database.BeginTransactionAsync();

//try
//{
//    var company = await _context.QualificationTypeMasters.FirstOrDefaultAsync(c => c.QualificationTypeId == QualificationTypeId);

//    if (company == null)
//    {

//    }

//    company.IsActive = false;
//    company.UpdatedDate = DateTime.Now;

//    _context.QualificationTypeMasters.Update(QualificationTypeId);
//    await _context.SaveChangesAsync();
//    await transaction.CommitAsync();


//}
//catch (Exception ex)
//{
//    await transaction.RollbackAsync();
