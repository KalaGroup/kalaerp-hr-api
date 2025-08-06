using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.Country;
using KalaGenset.ERP.HR.Core.Request.Department;
using KalaGenset.ERP.HR.Data.DbContexts;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace KalaGenset.ERP.HR.Core.Services
{
    public class DepartmentMasterService : IDepartmentMaster
    {
        private readonly KalaDbContext _context;
        public DepartmentMasterService(KalaDbContext context)
        {
            _context = context;
        }
        // Insert Code
        /// <summary>
        /// Adds a new Department to the database.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task AddDepartmentAsync(InsertDepartmentRequest request)
        {
            try
            {
                var department = new DepartmentMaster
                {
                    DepartmentCode = request.DepartmentCode,
                    DepartmentName = request.DepartmentName,
                    DepartmentShortName = request.DepartmentShortName,
                    ParentDepartmentId = request.ParentDepartmentId,
                    DepartmentProfitcenterId = request.DepartmentProfitcenterId,
                    DepartmentRemark = request.DepartmentRemark,
                    DepartmentType = request.DepartmentType,
                    DepartmentAuthRemark = request.DepartmentAuthRemark,
                    DepartmentAuth = request.DepartmentAuth,
                    DepartmentIsDiscard = request.DepartmentIsDiscard,
                    DepartmentIsActive = request.DepartmentIsActive,
                    CreatedBy = request.CreatedBy,
                    CreatedDate = request.CreatedDate  
                };
                _context.DepartmentMasters.Add(department);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
        // Update Code
        /// <summary>
        /// Updates an existing Department in the database.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task UpdateDepartmentAsync(UpdateDepartmentRequest request)
        {
            try
            {
                var department = await _context.DepartmentMasters.FirstOrDefaultAsync(c => c.DepartmentId == request.DepartmentId);
                if (department == null)
                {
                    throw new Exception("Department not found.");
                }
                // Update fields
                department.DepartmentId = request.DepartmentId;
                department.DepartmentCode = request.DepartmentCode;
                department.DepartmentName = request.DepartmentName;
                department.DepartmentShortName = request.DepartmentShortName;
                department.ParentDepartmentId = request.ParentDepartmentId;
                department.DepartmentProfitcenterId = request.DepartmentProfitcenterId;
                department.DepartmentRemark = request.DepartmentRemark;
                department.DepartmentType = request.DepartmentType;
                department.DepartmentAuthRemark = request.DepartmentAuthRemark;
                department.DepartmentAuth = request.DepartmentAuth;
                department.DepartmentIsDiscard = request.DepartmentIsDiscard;
                department.DepartmentIsActive = request.DepartmentIsActive;
                department.CreatedBy = request.CreatedBy;
                _context.DepartmentMasters.Update(department);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
        //Get Code
        /// <summary>
        /// Retrieves all active Departments from the database.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DepartmentMaster>> GetDepartmentDetailsAsync()
        {
            return await _context.DepartmentMasters.OrderBy(c => c.DepartmentId).ToListAsync();
        }

        // Get By ID Code
        /// <summary>
        /// Retrieves a Department by its ID from the database.
        /// </summary>
        /// <param name="DepartmentId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<DepartmentMaster?> GetDepartmentById(int DepartmentId)
        {
            if (await _context.DepartmentMasters.FirstOrDefaultAsync(c => c.DepartmentId == DepartmentId) == null)
            {
                throw new Exception("ID Not available");
            }
            return await _context.DepartmentMasters.FirstOrDefaultAsync(c => c.DepartmentId == DepartmentId);
        }
        // Soft-Delete Code
        /// <summary>
        /// Soft-deletes a Department by setting its IsActive property to false.
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public async Task DeleteDepartmentAsync(int did)
        {
            try
            {
                var department = await _context.DepartmentMasters.FirstOrDefaultAsync(c => c.DepartmentId == did);
                if (department == null)
                {
                    throw new Exception("Department not found.");
                }
                if (!department.DepartmentIsActive)
                {
                    throw new Exception("Department is already soft-deleted");
                }
                department.DepartmentIsActive = false;
                _context.DepartmentMasters.Update(department);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

    }
}
