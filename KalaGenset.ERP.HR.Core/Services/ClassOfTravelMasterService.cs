using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KalaGenset.ERP.HR.Data.DbContexts;
using KalaGenset.ERP.HR.Data.Models;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.ClassOfTravel;
using KalaGenset.ERP.HR.Core.Request.Grade;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace KalaGenset.ERP.HR.Core.Services
{
    public class ClassOfTravelMasterService : IClassOfTravelMaster
    {
        private readonly KalaDbContext _context;
        public ClassOfTravelMasterService(KalaDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Adds a new classOfTravel to the database.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task AddClassOfTravelAsync(InsertClassOfTravelRequest request)
        {
            try
            {
                var classOfTravel = new ClassOfTravelMaster
                {
                    ClassOfTravelCode = request.ClassOfTravelCode,
                    ClassOfTravelName = request.ClassOfTravelName,
                    ClassOfTravelGradeId = request.ClassOfTravelGradeId,
                    DafoodAllowancePerday = request.DafoodAllowancePerday,
                    ClassOfTravelTierType = request.ClassOfTravelTierType,
                    ClassOfTravelRemark = request.ClassOfTravelRemark,
                    ClassOfTravelIsAuth = request.ClassOfTravelIsAuth,
                    ClassOfTravelIsDiscard = request.ClassOfTravelIsDiscard,
                    ClassOfTravelIsActive = request.ClassOfTravelIsActive,
                    CreatedBy = request.CreatedBy,
                    CreatedDate = request.CreatedDate
                };
                _context.ClassOfTravelMasters.Add(classOfTravel);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Updates an existing classOfTravel in the database.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task UpdateClassOfTravelAsync(UpdateClassOfTravelRequest request)
        {
            try
            {
                var classOfTravel = await _context.ClassOfTravelMasters.FirstOrDefaultAsync(c => c.ClassOfTravelId == request.ClassOfTravelId);
                if (classOfTravel == null)
                {
                    throw new Exception("ClassOfTravel not found.");
                }
                classOfTravel.ClassOfTravelId = request.ClassOfTravelId;
                classOfTravel.ClassOfTravelCode = request.ClassOfTravelCode;
                classOfTravel.ClassOfTravelName = request.ClassOfTravelName;
                classOfTravel.ClassOfTravelGradeId = request.ClassOfTravelGradeId;
                classOfTravel.DafoodAllowancePerday = request.DafoodAllowancePerday;
                classOfTravel.ClassOfTravelTierType = request.ClassOfTravelTierType;
                classOfTravel.ClassOfTravelRemark = request.ClassOfTravelRemark;
                classOfTravel.ClassOfTravelIsAuth = request.ClassOfTravelIsAuth;
                classOfTravel.ClassOfTravelIsDiscard = request.ClassOfTravelIsDiscard;
                classOfTravel.ClassOfTravelIsActive = request.ClassOfTravelIsActive;
                classOfTravel.CreatedBy = request.CreatedBy;
                _context.ClassOfTravelMasters.Update(classOfTravel);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Retrieves all classOfTravel from the database.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ClassOfTravelMaster>> GetClassOfTravelDetailsAsync()
        {
            return await _context.ClassOfTravelMasters.OrderBy(c => c.ClassOfTravelId).ToListAsync();
        }
        // Get By ID Code
        /// <summary>
        /// Retrieves a ClassOfTravel by its ID from the database.
        /// </summary>
        /// <param name="ClassOfTravelId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ClassOfTravelMaster?> GetClassOfTravelById(int ClassOfTravelId)
        {
            if (await _context.ClassOfTravelMasters.FirstOrDefaultAsync(c => c.ClassOfTravelId == ClassOfTravelId) == null)
            {
                throw new Exception("ID Not available");
            }
            return await _context.ClassOfTravelMasters.FirstOrDefaultAsync(c => c.ClassOfTravelId == ClassOfTravelId);
        }
        // Soft-Delete Code
        /// <summary>
        /// Soft-deletes a ClassOfTravel by setting its ClassOfTravelIsActive property to false.
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public async Task DeleteClassOfTravelAsync(int cid)
        {
            try
            {
                var classOfTravel = await _context.ClassOfTravelMasters.FirstOrDefaultAsync(c => c.ClassOfTravelId == cid);
                if (classOfTravel == null)
                {
                    throw new Exception("ClassOfTravel not found.");
                }
                if (!classOfTravel.ClassOfTravelIsActive)
                {
                    throw new Exception("ClassOfTravel is already soft-deleted");
                }
                classOfTravel.ClassOfTravelIsActive = false;
                _context.ClassOfTravelMasters.Update(classOfTravel);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
