using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.RecruitmentReferenceMaster;
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
    public class RecruitmentReferenceMasterServices : IRecruitmentReferenceMaster
    {
        private readonly KalaDbContext _context;

        public RecruitmentReferenceMasterServices(KalaDbContext context)
        {
            _context = context;
        }
        public async Task AddRecruitmentReferenceAsync(InsertRecruitmentReferenceMasterRequest request)
        {
            try
            {
                var RecruitmentReferenceMaster = new RecruitmentReferenceMaster
                {
                    RecruitmentReferenceName=request.RecruitmentReferenceName,
                    RecruitmentReferenceAuth=request.RecruitmentReferenceAuth,
                    RecruitmentReferenceAuthRemark=request.RecruitmentReferenceAuthRemark,
                    RecruitmentReferenceRemark=request.RecruitmentReferenceRemark,
                    RecruitmentReferenceIsDiscard=request.RecruitmentReferenceIsDiscard,
                    RecruitmentReferenceIsActive=request.RecruitmentReferenceIsActive,
                    CreatedBy = request.CreatedBy,
                    CreatedDate = request.CreatedDate,
                };
                _context.RecruitmentReferenceMasters.Add(RecruitmentReferenceMaster);
                await _context.SaveChangesAsync(); 
               
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task DeleteRecruitmentReferenceAsync(int Id)
        {
            try
            {
                var recruitmentReference = await _context.RecruitmentReferenceMasters.FirstOrDefaultAsync(c => c.RecruitmentReferenceId == Id);

                recruitmentReference.RecruitmentReferenceIsActive = false;

                _context.RecruitmentReferenceMasters.Update(recruitmentReference);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<RecruitmentReferenceMaster>> GetAllRecruitmentReferenceAsync()
        {
            return await _context.RecruitmentReferenceMasters
                .Where(e => e.RecruitmentReferenceIsActive == true)
                .ToListAsync();
        }

        public async Task<RecruitmentReferenceMaster?> GetRecruitmentReferenceByIdAsync(int Id)
        {
            return await _context.RecruitmentReferenceMasters.FirstOrDefaultAsync(c => c.RecruitmentReferenceId == Id);
        }

        public async Task UpdateRecruitmentReferenceAsync(UpdateRecruitmentReferenceMasterRequest request)
        {
            try
            {
                var recruitmentReference = await _context.RecruitmentReferenceMasters.FindAsync(request.RecruitmentReferenceId);

                // Update fields

                recruitmentReference.RecruitmentReferenceName=request.RecruitmentReferenceName;
                recruitmentReference.RecruitmentReferenceRemark=request.RecruitmentReferenceRemark;
                recruitmentReference.RecruitmentReferenceAuthRemark = request.RecruitmentReferenceAuthRemark;
                    recruitmentReference.RecruitmentReferenceAuth=request.RecruitmentReferenceAuth;
                recruitmentReference.RecruitmentReferenceIsActive=request.RecruitmentReferenceIsActive;
                recruitmentReference.RecruitmentReferenceIsDiscard=request.RecruitmentReferenceIsDiscard;
                recruitmentReference.CreatedBy=request.CreatedBy;
                recruitmentReference.CreatedDate=request.CreatedDate;
                _context.RecruitmentReferenceMasters.Update(recruitmentReference);

                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
