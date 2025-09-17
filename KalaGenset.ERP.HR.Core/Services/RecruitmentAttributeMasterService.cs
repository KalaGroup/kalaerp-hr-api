using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.RecruitmentAttributeMaster;
using KalaGenset.ERP.HR.Data.DbContexts;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.EntityFrameworkCore;


namespace KalaGenset.ERP.HR.Core.Services
{
    public class RecruitmentAttributeMasterService : IRecruitmentAttributeMaster
    {
        private readonly KalaDbContext _context;

        public RecruitmentAttributeMasterService(KalaDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// This is Add Code
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task AddRecruitmentAttributeMasterAsync(InsertRecruitmentAttributeMasterRequest request)
        {
            try
            {
                var RecruitmentAttributeMaster = new RecruitmentAttributeMaster
                {
                    RecruitmentAttributeName = request.RecruitmentAttributeName,
                    RecruitmentAttributeMarks = request.RecruitmentAttributeMarks,
                    RecruitmentAttributeRemark = request.RecruitmentAttributeRemark,
                    RecruitmentAttributeAuthRemark = request.RecruitmentAttributeAuthRemark,
                    RecruitmentAttributeAuth = request.RecruitmentAttributeAuth,
                    RecruitmentAttributeIsDiscard = request.RecruitmentAttributeIsDiscard,
                    RecruitmentAttributeIsActive = request.RecruitmentAttributeIsActive,
                    CreatedBy = request.CreatedBy,
                    CreatedDate = request.CreatedDate,
                };

                _context.RecruitmentAttributeMasters.Add(RecruitmentAttributeMaster);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        /// <summary>
        /// This is Delete Code
        /// </summary>
        /// <param name="wid"></param>
        /// <returns></returns>
        public async Task DeleteRecruitmentAttributeMasterAsync(int wid)
        {
            try
            {
                var RecruitmentAttributeMaster = await _context.RecruitmentAttributeMasters.FirstOrDefaultAsync(c => c.RecruitmentAttributeId == wid);

                RecruitmentAttributeMaster.RecruitmentAttributeIsActive = false;

                _context.RecruitmentAttributeMasters.Update(RecruitmentAttributeMaster);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// This is Get Code By ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<RecruitmentAttributeMaster?> GetRecruitmentAttributeMasterByID(int Id)
        {
            return await _context.RecruitmentAttributeMasters.FirstOrDefaultAsync(c => c.RecruitmentAttributeId == Id);

        }

        /// <summary>
        /// This is Get Code for All RecruitmentAttributeMaster Details
        /// </summary>

        public async Task<IEnumerable<RecruitmentAttributeMaster>> GetRecruitmentAttributeMasterDetailsAsync()
        {
            var attributes = await (
                from e in _context.RecruitmentAttributeMasters
                where e.RecruitmentAttributeIsActive == true
                select e
            ).ToListAsync();

            return attributes;
        }


        /// <summary>
        /// This is Update Code
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task UpdateRecruitmentAttributeMasterAsync(UpdateRecruitmentAttributeMasterRequest request)
        {
            try
            {
                var RecruitmentAttributeMaster = await _context.RecruitmentAttributeMasters.FindAsync(request.RecruitmentAttributeId);

                // Update fields
                RecruitmentAttributeMaster.RecruitmentAttributeName = request.RecruitmentAttributeName;
                RecruitmentAttributeMaster.RecruitmentAttributeMarks = request.RecruitmentAttributeMarks;
                RecruitmentAttributeMaster.RecruitmentAttributeRemark = request.RecruitmentAttributeRemark;
                RecruitmentAttributeMaster.RecruitmentAttributeAuthRemark = request.RecruitmentAttributeAuthRemark;
                RecruitmentAttributeMaster.RecruitmentAttributeAuth = request.RecruitmentAttributeAuth;
                RecruitmentAttributeMaster.RecruitmentAttributeIsDiscard = request.RecruitmentAttributeIsDiscard;
                RecruitmentAttributeMaster.RecruitmentAttributeIsActive = request.RecruitmentAttributeIsActive;
                RecruitmentAttributeMaster.CreatedBy = request.CreatedBy;
                RecruitmentAttributeMaster.CreatedDate = request.CreatedDate;
                _context.RecruitmentAttributeMasters.Update(RecruitmentAttributeMaster);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}