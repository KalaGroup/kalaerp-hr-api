using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.QualificationRequest;
using KalaGenset.ERP.HR.Data.DbContexts;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace KalaGenset.ERP.HR.Core.Services
{
   public class QualificationMasterService : IQualificationMaster
    {
        private readonly KalaDbContext _context;

        public QualificationMasterService(KalaDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// add qual
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task AddQualificationAsync(InsertQualificationRequest request)
        {
            try
            {
                var qualification = new QualificationMaster
                {                 
                    MasterQualificationTypeId = request.MasterQualificationTypeId,
                    QualificationCode = request.QualificationCode,
                    QualificationName = request.QualificationName,
                    QualificationRemark = request.QualificationRemark,
                    QualificationAuth = request.QualificationAuth,
                    QualificationIsDiscard = request.QualificationIsDiscard,
                    QualificationIsActive = request.QualificationIsActive,
                    CreatedBy = request.CreatedBy,
                    CreatedDate = request.CreatedDate,
                };

                _context.QualificationMasters.Add(qualification);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        /// <summary>
        /// delete qual
        /// </summary>
        /// <param name="qid"></param>
        /// <returns></returns>
        public async Task DeleteQualificationAsync(int qid)
        {
            try
            {
                var qualification = await _context.QualificationMasters.FirstOrDefaultAsync(c => c.QualificationId == qid);

                qualification.QualificationIsActive = false;

                _context.QualificationMasters.Update(qualification);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// get qual by id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<QualificationMaster?> GetQualificationByID(int Id)
        {
            return await _context.QualificationMasters.FirstOrDefaultAsync(c => c.QualificationId == Id);

        }
        /// <summary>
        /// get qual
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<QualificationMaster>> GetQualificationDetailsAsync()
        {
            return await _context.QualificationMasters.ToListAsync();
        }

        /// <summary>
        /// This is Update Code
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task UpdateQualificationAsync(UpdateQualificationRequest request)
        {
            try
            {
                var qualification = await _context.QualificationMasters.FindAsync(request.QualificationId);

                // Update fields
                qualification.MasterQualificationTypeId = request.MasterQualificationTypeId;
                qualification.QualificationCode = request.QualificationCode;
                qualification.QualificationName = request.QualificationName;
                qualification.QualificationRemark = request.QualificationRemark;
                qualification.QualificationAuth = request.QualificationAuth;
                qualification.QualificationIsDiscard = request.QualificationIsDiscard;
                qualification.QualificationIsActive = request.QualificationIsActive;
                qualification.CreatedBy = request.CreatedBy;
                qualification.CreatedDate = request.CreatedDate;
                _context.QualificationMasters.Update(qualification);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
