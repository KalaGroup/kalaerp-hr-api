using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.PositionMaster;
using KalaGenset.ERP.HR.Core.ResponseDTO.PositionMaster;
using KalaGenset.ERP.HR.Core.ResponseDTO.WorkstationMaster;
using KalaGenset.ERP.HR.Data.DbContexts;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace KalaGenset.ERP.HR.Core.Services
{
    public class PositionMasterService : IPositionMaster
    {
        private readonly KalaDbContext _context;

        public PositionMasterService(KalaDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// This is Add Code
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// 

        public async Task AddPositionAsync(InsertPositionRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            try
            {
                var position = new PositionMaster
                {
                    PositionMasterCode = request.PositionMasterCode,
                    PositionMasterName = request.PositionMasterName,
                    PositionMasterCompanyId = request.PositionMasterCompanyId,
                    PositionMasterDivisionId = request.PositionMasterDivisionId,
                    PositionMasterProfitcenterId = request.PositionMasterProfitcenterId,
                    PositionMasterGradeId = request.PositionMasterGradeId,
                    PositionMasterDesignationId = request.PositionMasterDesignationId,
                    PositionMasterWorkStationId = request.PositionMasterWorkStationId,
                    PositionMasterRolesId = request.PositionMasterRolesId,
                    PositionMasterResponsibilitiesId = request.PositionMasterResponsibilitiesId,
                    PositionMasterPositionCount = request.PositionMasterPositionCount,
                    PositionMasterActivityId = request.PositionMasterActivityId,
                    PositionMasterAuthoritiesId = request.PositionMasterAuthoritiesId,
                    PositionMasterKpaid = request.PositionMasterKpaid,
                    PositionMasterEmployeeTypeId = request.PositionMasterEmployeeTypeId,
                    PositionMasterDepartmentId = request.PositionMasterDepartmentId,
                    PositionMasterRemark = request.PositionMasterRemark,
                    PositionMasterAuthRemark = request.PositionMasterAuthRemark,
                    PositionMasterAuth = request.PositionMasterAuth,
                    PositionMasterIsDiscard = request.PositionMasterIsDiscard,
                    PositionMasterIsActive = request.PositionMasterIsActive,
                    CreatedBy = 1,   // 🔄 TODO: Replace with current logged-in user
                    CreatedDate = DateTime.UtcNow
                };

                // ✅ Insert master
                _context.PositionMasters.Add(position);
                await _context.SaveChangesAsync();

                // ✅ Get the auto-generated ID after save
                int positionMstId = position.PositionMasterId;

                // ✅ Insert child qualification details
                if (request.PositionMasterQualificationDetails?.Any() == true)
                {
                    var details = request.PositionMasterQualificationDetails.Select(item => new PositionMasterQualificationDetail
                    {
                        DetailsPositionMasterId = positionMstId,
                        PositionQualificationId = item.qual,
                        SrNo = item.srno,
                        PositionMasterQualificationDetailsDescription = item.desc
                    });

                    await _context.PositionMasterQualificationDetails.AddRangeAsync(details);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Log properly instead of wrapping in a generic exception
                throw new ApplicationException("Error adding Position", ex);
            }
        }



        /// <summary>
        /// This is Delete Code
        /// </summary>
        /// <param name="wid"></param>
        /// <returns></returns>
        public async Task DeletePositionAsync(int wid)
        {
            try
            {
                var Position = await _context.PositionMasters.FirstOrDefaultAsync(c => c.PositionMasterId == wid);

                if (Position == null)
                    throw new Exception("Position not found");

                var details = await _context.PositionMasterQualificationDetails
                    .Where(d => d.DetailsPositionMasterId == wid)
                    .ToListAsync();
                // ✅ Remove child details
                if (details.Any())
                {
                    _context.PositionMasterQualificationDetails.RemoveRange(details);
                }

                // ✅ Soft delete master
                Position.PositionMasterIsActive = false;
                _context.PositionMasters.Update(Position);
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
        public async Task<PositionMaster?> GetPositionByID(int Id)
        {
            return await _context.PositionMasters.FirstOrDefaultAsync(c => c.PositionMasterId == Id);

        }

        /// <summary>
        /// This is Get Code for All Position Details
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<PositionResponseDTO>> GetPositionDetailsAsync()
        {
            var result = await (from pm in _context.PositionMasters

                                join comp in _context.CompanyMasters
                                    on pm.PositionMasterCompanyId equals comp.CompanyId

                                join div in _context.DivisionMasters
                                    on pm.PositionMasterDivisionId equals div.DivisionId

                                join dept in _context.DepartmentMasters   // ✅ Added Department join
                                    on pm.PositionMasterDepartmentId equals dept.DepartmentId

                                join pc in _context.ProfitcenterMasters
                                    on pm.PositionMasterProfitcenterId equals pc.ProfitCenterId

                                join grade in _context.GradeMasters
                                    on pm.PositionMasterGradeId equals grade.GradeId

                                join desig in _context.DesignationMasters
                                    on pm.PositionMasterDesignationId equals desig.DesignationId

                                join ws in _context.WorkStationMasters
                                    on pm.PositionMasterWorkStationId equals ws.WorkStationId

                                join role in _context.RolesMasters
                                    on pm.PositionMasterRolesId equals role.RolesId

                                join resp in _context.ResponsibilitiesMasters
                                    on pm.PositionMasterResponsibilitiesId equals resp.ResponsibilitiesId

                                join act in _context.ActivityMasters
                                    on pm.PositionMasterActivityId equals act.ActivityId

                                join auth in _context.AuthoritiesMasters
                                    on pm.PositionMasterAuthoritiesId equals auth.AuthoritiesId

                                join kpa in _context.Kpamasters
                                    on pm.PositionMasterKpaid equals kpa.Kpaid

                                join emptype in _context.EmployeeTypeMasters
                                    on pm.PositionMasterEmployeeTypeId equals emptype.EmployeeTypeId

                                where pm.PositionMasterIsActive == true   // ✅ Only active positions

                                select new PositionResponseDTO
                                {
                                    // PK
                                    PositionMasterId = pm.PositionMasterId,

                                    // Basic details
                                    PositionMasterCode = pm.PositionMasterCode,
                                    PositionMasterName = pm.PositionMasterName,
                                    PositionMasterPositionCount=pm.PositionMasterPositionCount,

                                    // Foreign Key Names
                                    DivisionName = div.DivisionName,
                                    DepartmentName = dept.DepartmentName,
                                    ProfitCenterName = pc.ProfitCenterName,
                                    GradeName = grade.GradeName,
                                    DesignationName = desig.DesignationName,
                                    WorkStationName = ws.WorkStationName,
                                    EmployeeTypeName = emptype.EmployeeTypeName,

                                    // Foreign Key IDs
                                    PositionMasterCompanyId = pm.PositionMasterCompanyId,
                                    PositionMasterDivisionId = pm.PositionMasterDivisionId,
                                    PositionMasterDepartmentId = pm.PositionMasterDepartmentId, // ✅ Added DeptId
                                    PositionMasterProfitcenterId = pm.PositionMasterProfitcenterId,
                                    PositionMasterGradeId = pm.PositionMasterGradeId,
                                    PositionMasterDesignationId = pm.PositionMasterDesignationId,
                                    PositionMasterWorkStationId = pm.PositionMasterWorkStationId,
                                    PositionMasterRolesId = pm.PositionMasterRolesId,
                                    PositionMasterResponsibilitiesId = pm.PositionMasterResponsibilitiesId,
                                    PositionMasterActivityId = pm.PositionMasterActivityId,
                                    PositionMasterAuthoritiesId = pm.PositionMasterAuthoritiesId,
                                    PositionMasterKpaid = pm.PositionMasterKpaid,
                                    PositionMasterEmployeeTypeId = pm.PositionMasterEmployeeTypeId,


                                    // Other fields
                                    PositionMasterRemark = pm.PositionMasterRemark,
                                    PositionMasterAuthRemark = pm.PositionMasterAuthRemark,
                                    PositionMasterAuth = pm.PositionMasterAuth,
                                    PositionMasterIsDiscard = pm.PositionMasterIsDiscard,
                                    PositionMasterIsActive = pm.PositionMasterIsActive,
                                    CreatedBy = pm.CreatedBy,
                                    CreatedDate = pm.CreatedDate
                                }).ToListAsync();

            return result;
        }







        /// <summary>
        /// This is Update Code
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task UpdatePositionAsync(UpdatePositionRequest request)
        {
            try
            {
                var Position = await _context.PositionMasters.FindAsync(request.PositionMasterId);

                // Update fields
                Position.PositionMasterCode = request.PositionMasterCode;
                Position.PositionMasterName = request.PositionMasterName;
                Position.PositionMasterCompanyId = request.PositionMasterCompanyId;
                Position.PositionMasterDivisionId = request.PositionMasterDivisionId;
                Position.PositionMasterProfitcenterId = request.PositionMasterProfitcenterId;
                Position.PositionMasterGradeId = request.PositionMasterGradeId;
                Position.PositionMasterDesignationId = request.PositionMasterDesignationId;
                Position.PositionMasterWorkStationId = request.PositionMasterWorkStationId;
                Position.PositionMasterRolesId = request.PositionMasterRolesId;
                Position.PositionMasterResponsibilitiesId = request.PositionMasterResponsibilitiesId;
                Position.PositionMasterActivityId = request.PositionMasterActivityId;
                Position.PositionMasterDepartmentId = request.PositionMasterDepartmentId;
                Position.PositionMasterPositionCount = request.PositionMasterPositionCount;
                Position.PositionMasterAuthoritiesId = request.PositionMasterAuthoritiesId;
                Position.PositionMasterKpaid = request.PositionMasterKpaid;
                Position.PositionMasterEmployeeTypeId = request.PositionMasterEmployeeTypeId;
                Position.PositionMasterRemark = request.PositionMasterRemark;
                Position.PositionMasterAuthRemark = request.PositionMasterAuthRemark;
                Position.PositionMasterAuth = request.PositionMasterAuth;
                Position.PositionMasterIsDiscard = request.PositionMasterIsDiscard;
                Position.PositionMasterIsActive = request.PositionMasterIsActive;
                Position.CreatedBy = request.CreatedBy;
                Position.CreatedDate = request.CreatedDate;
                _context.PositionMasters.Update(Position);

                // ✅ Delete old details and insert new ones
                var existingDetails = await _context.PositionMasterQualificationDetails
                    .Where(d => d.DetailsPositionMasterId == request.PositionMasterId)
                    .ToListAsync();

                if (existingDetails.Any())
                {
                    _context.PositionMasterQualificationDetails.RemoveRange(existingDetails);
                }

                if (request.PositionMasterQualificationDetails != null && request.PositionMasterQualificationDetails.Any())
                {
                    var newDetails = request.PositionMasterQualificationDetails.Select(item => new PositionMasterQualificationDetail
                    {
                        DetailsPositionMasterId = request.PositionMasterId,
                        PositionQualificationId=item.qual,
                        SrNo = item.srno,
                        PositionMasterQualificationDetailsDescription = item.desc
                    });

                    await _context.PositionMasterQualificationDetails.AddRangeAsync(newDetails);
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating Position", ex);
            }
        }

        public async Task<IEnumerable<getpositionDetailsById>> GetpositionDetailsByMasterId(int PositionMasterId)
        {
            return await _context.PositionMasterQualificationDetails  // assuming your DbSet is called RecruitmentDetails
                .Where(d => d.DetailsPositionMasterId == PositionMasterId)  // filter by master ID
                .Select(d => new getpositionDetailsById
                {
                    PositionQualificationDetailsId = d.PositionQualificationDetailsId,
                    DetailsPositionMasterId = d.DetailsPositionMasterId,
                    PositionQualificationId = d.PositionQualificationId,
                    SrNo=d.SrNo,
                    PositionMasterQualificationDetailsDescription = d.PositionMasterQualificationDetailsDescription,
                })
                .ToListAsync();
        }

    }
}
