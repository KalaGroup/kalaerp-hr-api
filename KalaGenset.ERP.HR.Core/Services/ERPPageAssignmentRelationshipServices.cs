using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.ERPPageAssignmentRelationship;
using KalaGenset.ERP.HR.Core.ResponseDTO.ERPPageAssignmentRelationship;
using KalaGenset.ERP.HR.Core.ResponseDTO.OfferLetter;
using KalaGenset.ERP.HR.Core.ResponseDTO.RecruitmentMaster;
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
    public class ERPPageAssignmentRelationshipServices : IERPPageAssignmentRelationship
    {
        private readonly KalaDbContext _context;
        public ERPPageAssignmentRelationshipServices(KalaDbContext context)
        {
            _context = context;
        }
        public async Task AddERPPageAssignmentRelationshipAsync(InsertPageAssignmentRelationshipRequest request)
        {
            try
            {
                // 1️⃣ Insert Master record
                var relationship = new ErppageAssignmentRelationship
                {
                    ErppageAssignmentRelationshipDivisionId = request.ErppageAssignmentRelationshipDivisionId,
                    ErppageAssignmentRelationshipDepartmentId = request.ErppageAssignmentRelationshipDepartmentId,
                    ErppageAssignmentRelationshipProfitcenterId = request.ErppageAssignmentRelationshipProfitcenterId,
                    ErppageAssignmentRelationshipRemark = request.ErppageAssignmentRelationshipRemark,
                    ErppageAssignmentRelationshipAuth1 = request.ErppageAssignmentRelationshipAuth1,
                    ErppageAssignmentRelationshipAuth1Remark = request.ErppageAssignmentRelationshipAuth1Remark,
                    ErppageAssignmentRelationshipAuth2 = request.ErppageAssignmentRelationshipAuth2,
                    ErppageAssignmentRelationshipAuth2Remark = request.ErppageAssignmentRelationshipAuth2Remark,
                    ErppageAssignmentRelationshipIsActive = request.ErppageAssignmentRelationshipIsActive,
                    ErppageAssignmentRelationshipIsDiscard = request.ErppageAssignmentRelationshipIsDiscard,
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now,
                    UpdatedBy = 1,
                    UpdatedDate = DateTime.Now
                };

                _context.ErppageAssignmentRelationships.Add(relationship);
                await _context.SaveChangesAsync();

                // 2️⃣ Retrieve the generated master ID
                int masterId = relationship.ErppageAssignmentRelationshipId;

                // 3️⃣ Insert detail rows (if any)
                if (request.RelationshipDetails != null && request.RelationshipDetails.Any())
                {
                    var detailEntities = request.RelationshipDetails.Select(detail => new ErppageAssignmentRelationshipDetail
                    {
                        DetailsErppageAssignmentRelationshipId = masterId,
                        ErppageAssignmentRelationshipDetailsPageId = detail.ErppageAssignmentRelationshipDetailsPageId,
                        ErppageAssignmentRelationshipDetailschecker1PositiontId = detail.ErppageAssignmentRelationshipDetailschecker1PositiontId,
                        ErppageAssignmentRelationshipDetailschecker2PositiontId = detail.ErppageAssignmentRelationshipDetailschecker2PositiontId,
                        ErppageAssignmentRelationshipDetailschecker3PositiontId = detail.ErppageAssignmentRelationshipDetailschecker3PositiontId,
                        ErppageAssignmentRelationshipDetailschecker4PositiontId = detail.ErppageAssignmentRelationshipDetailschecker4PositiontId,
                        ErppageAssignmentRelationshipDetailschecker5PositiontId = detail.ErppageAssignmentRelationshipDetailschecker5PositiontId,
                        ErppageAssignmentRelationshipDetailsRemark = detail.ErppageAssignmentRelationshipDetailsRemark,
                        ErppageAssignmentRelationshipDetailsIsActive = detail.ErppageAssignmentRelationshipDetailsIsActive,
                        ErppageAssignmentRelationshipDetailsIsDiscard = detail.ErppageAssignmentRelationshipDetailsIsDiscard
                    }).ToList();

                    _context.ErppageAssignmentRelationshipDetails.AddRange(detailEntities);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Optional: log for debugging
                Console.WriteLine($"Error while adding ERP Page Assignment Relationship: {ex.Message}");
                throw;
            }
        }


        public async Task DeleteERPPageAssignmentRelationshipAsync(int erppageAssignmentRelationshipId)
        {
            try
            {
                var relationship = await _context.ErppageAssignmentRelationships
                    .Include(r => r.ErppageAssignmentRelationshipDetails) // load child details
                    .FirstOrDefaultAsync(c => c.ErppageAssignmentRelationshipId == erppageAssignmentRelationshipId);

                if (relationship == null)
                    throw new Exception("ERP Page Assignment Relationship not found");

                // Soft delete children
                foreach (var detail in relationship.ErppageAssignmentRelationshipDetails)
                {
                    detail.ErppageAssignmentRelationshipDetailsIsActive = false;
                }

                // Soft delete parent
                relationship.ErppageAssignmentRelationshipIsActive = false;

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting ERP Page Assignment Relationship", ex);
            }
        }



        public async Task<IEnumerable<AssignmentRelationshipDTO>> GetAllERPPageAssignmentRelationshipAsync()
        {
            var result = await (from rel in _context.ErppageAssignmentRelationships
                                join div in _context.DivisionMasters
                                    on rel.ErppageAssignmentRelationshipDivisionId equals div.DivisionId
                                join dept in _context.DepartmentMasters
                                    on rel.ErppageAssignmentRelationshipDepartmentId equals dept.DepartmentId
                                join pc in _context.ProfitcenterMasters
                                    on rel.ErppageAssignmentRelationshipProfitcenterId equals pc.ProfitCenterId
                                where rel.ErppageAssignmentRelationshipIsActive == true
                                select new AssignmentRelationshipDTO
                                {
                                    ErppageAssignmentRelationshipId = rel.ErppageAssignmentRelationshipId,
                                    DivisionName = rel.ErppageAssignmentRelationshipDivision.DivisionName,
                                    DepartmentName = rel.ErppageAssignmentRelationshipDepartment.DepartmentName,
                                    ProfitCenterName = rel.ErppageAssignmentRelationshipProfitcenter.ProfitCenterName,
                                    ErppageAssignmentRelationshipRemark = rel.ErppageAssignmentRelationshipRemark,
                                    ErppageAssignmentRelationshipAuth1 = rel.ErppageAssignmentRelationshipAuth1,
                                    ErppageAssignmentRelationshipAuth1Remark = rel.ErppageAssignmentRelationshipAuth1Remark,
                                    ErppageAssignmentRelationshipAuth2 = rel.ErppageAssignmentRelationshipAuth2,
                                    ErppageAssignmentRelationshipAuth2Remark = rel.ErppageAssignmentRelationshipAuth2Remark,
                                    ErppageAssignmentRelationshipIsActive = rel.ErppageAssignmentRelationshipIsActive,
                                    ErppageAssignmentRelationshipIsDiscard = rel.ErppageAssignmentRelationshipIsDiscard,

                                    // ✅ Nested detail list
                                    ErppageAssignmentRelationshipDetails = rel.ErppageAssignmentRelationshipDetails
                                        .Select(d => new EPPageAssignmentRelationshipWithDto
                                        {
                                            ErppageAssignmentRelationshipDetailsId = d.ErppageAssignmentRelationshipDetailsId,
                                            DetailsErppageAssignmentRelationshipId = d.DetailsErppageAssignmentRelationshipId,
                                            ErppageAssignmentRelationshipDetailsPageId = d.ErppageAssignmentRelationshipDetailsPageId,
                                            ErppageAssignmentRelationshipDetailschecker1PositiontId = d.ErppageAssignmentRelationshipDetailschecker1PositiontId,
                                            ErppageAssignmentRelationshipDetailschecker2PositiontId = d.ErppageAssignmentRelationshipDetailschecker2PositiontId,
                                            ErppageAssignmentRelationshipDetailschecker3PositiontId = d.ErppageAssignmentRelationshipDetailschecker3PositiontId,
                                            ErppageAssignmentRelationshipDetailschecker4PositiontId = d.ErppageAssignmentRelationshipDetailschecker4PositiontId,
                                            ErppageAssignmentRelationshipDetailschecker5PositiontId = d.ErppageAssignmentRelationshipDetailschecker5PositiontId,
                                            ErppageAssignmentRelationshipDetailsRemark = d.ErppageAssignmentRelationshipDetailsRemark,
                                            ErppageAssignmentRelationshipDetailsIsActive = d.ErppageAssignmentRelationshipDetailsIsActive,
                                            ErppageAssignmentRelationshipDetailsIsDiscard = d.ErppageAssignmentRelationshipDetailsIsDiscard
                                        }).ToList()
                                }).ToListAsync();

            return result;
        }

        public async Task<List<PageAssignmentReleationshipDeatilsDTO>> GetAllERPPageAssignmentRelationshipDeatils()
        {
            return await _context.ErppageAssignmentRelationshipDetails
                .Select(d => new PageAssignmentReleationshipDeatilsDTO
                {
                    ErppageAssignmentRelationshipDetailsId = d.ErppageAssignmentRelationshipDetailsId,
                    DetailsErppageAssignmentRelationshipId = d.DetailsErppageAssignmentRelationshipId,
                    ErppageAssignmentRelationshipDetailsPageId = d.ErppageAssignmentRelationshipDetailsPageId,
                    ErppageAssignmentRelationshipDetailschecker1PositiontId = d.ErppageAssignmentRelationshipDetailschecker1PositiontId,
                    ErppageAssignmentRelationshipDetailschecker2PositiontId = d.ErppageAssignmentRelationshipDetailschecker2PositiontId,
                    ErppageAssignmentRelationshipDetailschecker3PositiontId = d.ErppageAssignmentRelationshipDetailschecker3PositiontId,
                    ErppageAssignmentRelationshipDetailschecker4PositiontId = d.ErppageAssignmentRelationshipDetailschecker4PositiontId,
                    ErppageAssignmentRelationshipDetailschecker5PositiontId = d.ErppageAssignmentRelationshipDetailschecker5PositiontId,
                    ErppageAssignmentRelationshipDetailsRemark = d.ErppageAssignmentRelationshipDetailsRemark,
                    ErppageAssignmentRelationshipDetailsIsDiscard = d.ErppageAssignmentRelationshipDetailsIsDiscard,
                    ErppageAssignmentRelationshipDetailsIsActive = d.ErppageAssignmentRelationshipDetailsIsActive
                })
                .ToListAsync();
        }

        public async Task<List<getDivisionIdandpagetittelDTO>> GetDivivsionIdandPageTittel()
        {
            // Fetch all page details with division ID and page title
            var result = await _context.KalaErppageDetails
                .Select(p => new getDivisionIdandpagetittelDTO
                {
                    KalaErppageDetailsId=p.KalaErppageDetailsId,
                    ErppageAssignmentRelationshipDivisionId = p.KalaErppageDetailsDivisionId,
                    PageTittle = p.PageTittle
                })
                .ToListAsync();

            return result;
        }


        public Task<ErppageAssignmentRelationship?> GetERPPageAssignmentRelationshipById(int ErppageAssignmentRelationshipId)
        {
            return _context.ErppageAssignmentRelationships
                .Include(r => r.ErppageAssignmentRelationshipDetails) // Include related details
                .FirstOrDefaultAsync(r => r.ErppageAssignmentRelationshipId == ErppageAssignmentRelationshipId);
        }

        public async Task<IEnumerable<GetEPRPageAssignmentRelationshipDeatils>> GetERPPageDetailsByMsaterId(int ErppageAssignmentRelationshipId)
        {
            return await _context.ErppageAssignmentRelationshipDetails
        .Where(d => d.DetailsErppageAssignmentRelationshipId == ErppageAssignmentRelationshipId) // filter by master ID
        .Select(d => new GetEPRPageAssignmentRelationshipDeatils
        {
            ErppageAssignmentRelationshipDetailsId = d.ErppageAssignmentRelationshipDetailsId,
            DetailsErppageAssignmentRelationshipId = d.DetailsErppageAssignmentRelationshipId,
            ErppageAssignmentRelationshipDetailsPageId = d.ErppageAssignmentRelationshipDetailsPageId,
            ErppageAssignmentRelationshipDetailschecker1PositiontId = d.ErppageAssignmentRelationshipDetailschecker1PositiontId,
            ErppageAssignmentRelationshipDetailschecker2PositiontId = d.ErppageAssignmentRelationshipDetailschecker2PositiontId,
            ErppageAssignmentRelationshipDetailschecker3PositiontId = d.ErppageAssignmentRelationshipDetailschecker3PositiontId,
            ErppageAssignmentRelationshipDetailschecker4PositiontId = d.ErppageAssignmentRelationshipDetailschecker4PositiontId,
            ErppageAssignmentRelationshipDetailschecker5PositiontId = d.ErppageAssignmentRelationshipDetailschecker5PositiontId,
            ErppageAssignmentRelationshipDetailsRemark = d.ErppageAssignmentRelationshipDetailsRemark,
            ErppageAssignmentRelationshipDetailsIsDiscard = d.ErppageAssignmentRelationshipDetailsIsDiscard,
            ErppageAssignmentRelationshipDetailsIsActive = d.ErppageAssignmentRelationshipDetailsIsActive
        })
        .ToListAsync();
        }

        public async Task UpdateERPPageAssignmentRelationshipAsync(UpdatePageAssignmentRelationshipRequest request)
        {
            try
            {
                // 1️⃣ Retrieve existing master record
                var existing = await _context.ErppageAssignmentRelationships
                    .FirstOrDefaultAsync(x => x.ErppageAssignmentRelationshipId == request.ErppageAssignmentRelationshipId);

                if (existing == null)
                    throw new Exception("ERP Page Assignment Relationship not found.");

                // 2️⃣ Update master fields
                existing.ErppageAssignmentRelationshipDivisionId = request.ErppageAssignmentRelationshipDivisionId;
                existing.ErppageAssignmentRelationshipDepartmentId = request.ErppageAssignmentRelationshipDepartmentId;
                existing.ErppageAssignmentRelationshipProfitcenterId = request.ErppageAssignmentRelationshipProfitcenterId;
                existing.ErppageAssignmentRelationshipRemark = request.ErppageAssignmentRelationshipRemark;
                existing.ErppageAssignmentRelationshipAuth1 = request.ErppageAssignmentRelationshipAuth1;
                existing.ErppageAssignmentRelationshipAuth1Remark = request.ErppageAssignmentRelationshipAuth1Remark;
                existing.ErppageAssignmentRelationshipAuth2 = request.ErppageAssignmentRelationshipAuth2;
                existing.ErppageAssignmentRelationshipAuth2Remark = request.ErppageAssignmentRelationshipAuth2Remark;
                existing.ErppageAssignmentRelationshipIsActive = request.ErppageAssignmentRelationshipIsActive;
                existing.ErppageAssignmentRelationshipIsDiscard = request.ErppageAssignmentRelationshipIsDiscard;
                existing.UpdatedBy = 1;
                existing.UpdatedDate = DateTime.Now;

                // 3️⃣ Remove old relationship detail records
                var existingDetails = await _context.ErppageAssignmentRelationshipDetails
                    .Where(d => d.DetailsErppageAssignmentRelationshipId == request.ErppageAssignmentRelationshipId)
                    .ToListAsync();

                if (existingDetails.Any())
                    _context.ErppageAssignmentRelationshipDetails.RemoveRange(existingDetails);

                // 4️⃣ Add new relationship detail records
                if (request.RelationshipDetails != null && request.RelationshipDetails.Any())
                {
                    var newDetails = request.RelationshipDetails.Select(d => new ErppageAssignmentRelationshipDetail
                    {
                        DetailsErppageAssignmentRelationshipId = request.ErppageAssignmentRelationshipId,
                        ErppageAssignmentRelationshipDetailsPageId = d.ErppageAssignmentRelationshipDetailsPageId,
                        ErppageAssignmentRelationshipDetailschecker1PositiontId = d.ErppageAssignmentRelationshipDetailschecker1PositiontId,
                        ErppageAssignmentRelationshipDetailschecker2PositiontId = d.ErppageAssignmentRelationshipDetailschecker2PositiontId,
                        ErppageAssignmentRelationshipDetailschecker3PositiontId = d.ErppageAssignmentRelationshipDetailschecker3PositiontId,
                        ErppageAssignmentRelationshipDetailschecker4PositiontId = d.ErppageAssignmentRelationshipDetailschecker4PositiontId,
                        ErppageAssignmentRelationshipDetailschecker5PositiontId = d.ErppageAssignmentRelationshipDetailschecker5PositiontId,
                        ErppageAssignmentRelationshipDetailsRemark = d.ErppageAssignmentRelationshipDetailsRemark,
                        ErppageAssignmentRelationshipDetailsIsActive = d.ErppageAssignmentRelationshipDetailsIsActive,
                        ErppageAssignmentRelationshipDetailsIsDiscard = d.ErppageAssignmentRelationshipDetailsIsDiscard
                    }).ToList();

                    await _context.ErppageAssignmentRelationshipDetails.AddRangeAsync(newDetails);
                }

                // 5️⃣ Save all changes together
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating ERP Page Assignment Relationship", ex);
            }
        }


    }
}
