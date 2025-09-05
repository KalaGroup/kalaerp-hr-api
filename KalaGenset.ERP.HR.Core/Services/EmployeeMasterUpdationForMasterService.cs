using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.EmployeeMasterUpdationForMaster;
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
    public class EmployeeMasterUpdationForMasterService : IEmployeeMasterUpdationForMaster
    {
        private readonly KalaDbContext _context;

        public EmployeeMasterUpdationForMasterService(KalaDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// This is Add Code
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>

        public async Task AddEmployeeMasterUpdationForAsync(InsertEmployeeMasterUpdationForMasterRequest request)
        {
            try
            {
                var employeeMasterUpdationFor = new EmployeeMasterUpdationForMaster
                {
                    EmployeeMasterUpdationForName = request.EmployeeMasterUpdationForName,
                    EmployeeMasterUpdationForRemark = request.EmployeeMasterUpdationForRemark,
                    EmployeeMasterUpdationForAuthRemark = request.EmployeeMasterUpdationForAuthRemark,
                    EmployeeMasterUpdationForAuth = request.EmployeeMasterUpdationForAuth,
                    EmployeeMasterUpdationForIsDiscard = request.EmployeeMasterUpdationForIsDiscard,
                    EmployeeMasterUpdationForIsActive = request.EmployeeMasterUpdationForIsActive,
                    CreatedBy = request.CreatedBy,
                    CreatedDate = request.CreatedDate
                };
                _context.EmployeeMasterUpdationForMasters.Add(employeeMasterUpdationFor);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding Employee Master Updation For", ex);
            }
        }

        /// <summary>
        /// /// This is Update Code By ID
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task UpdateEmployeeMasterUpdationForAsync(UpdateEmployeeMasterUpdationForMasterRequest request)
        {
            try
            {
                var employeeMasterUpdationFor = await _context.EmployeeMasterUpdationForMasters.FindAsync(request.EmployeeMasterUpdationForId);

                employeeMasterUpdationFor.EmployeeMasterUpdationForName = request.EmployeeMasterUpdationForName;
                employeeMasterUpdationFor.EmployeeMasterUpdationForRemark = request.EmployeeMasterUpdationForRemark;
                employeeMasterUpdationFor.EmployeeMasterUpdationForAuthRemark = request.EmployeeMasterUpdationForAuthRemark;
                employeeMasterUpdationFor.EmployeeMasterUpdationForAuth = request.EmployeeMasterUpdationForAuth;
                employeeMasterUpdationFor.EmployeeMasterUpdationForIsDiscard = request.EmployeeMasterUpdationForIsDiscard;
                employeeMasterUpdationFor.EmployeeMasterUpdationForIsActive = request.EmployeeMasterUpdationForIsActive;
                employeeMasterUpdationFor.CreatedBy = request.CreatedBy;
                employeeMasterUpdationFor.CreatedDate = request.CreatedDate;
                _context.EmployeeMasterUpdationForMasters.Update(employeeMasterUpdationFor);
                await _context.SaveChangesAsync();
            }

            catch (Exception ex)
            {
                throw new Exception("Error updating Employee Master Updation For", ex);
            }
        }
        /// <summary>
        /// /// This is Delete Code By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>

        public async Task DeleteEmployeeMasterUpdationForAsync(int id)
        {
            try
            {
                var employeeMasterUpdationFor = await _context.EmployeeMasterUpdationForMasters
                    .FirstOrDefaultAsync(c => c.EmployeeMasterUpdationForId == id);

                if (employeeMasterUpdationFor == null)
                {
                    throw new Exception($"Employee Master Updation For with ID {id} not found.");
                }

                employeeMasterUpdationFor.EmployeeMasterUpdationForIsActive = false;
                _context.EmployeeMasterUpdationForMasters.Update(employeeMasterUpdationFor);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting Employee Master Updation For", ex);
            }
        }

        /// <summary>
        /// This is Get Code By ID
        /// </summary>
        /// 

        public async Task<EmployeeMasterUpdationForMaster?> GetEmployeeMasterUpdationForByIdAsync(int id)
        {
            try
            {
                return await _context.EmployeeMasterUpdationForMasters.FirstOrDefaultAsync(c => c.EmployeeMasterUpdationForId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving Employee Master Updation For by ID", ex);
            }
        }

        public async Task<IEnumerable<EmployeeMasterUpdationForMaster>> GetEmployeeMasterUpdationForAsync()
        {
            return await _context.EmployeeMasterUpdationForMasters
                                 .Where(x => x.EmployeeMasterUpdationForIsActive)
                                 .ToListAsync();
        }


        public async Task<EmployeeMasterUpdationForMaster> GetEmployeeMasterUpdationForById(int id)
        {
            return await _context.EmployeeMasterUpdationForMasters.FirstOrDefaultAsync(c => c.EmployeeMasterUpdationForId == id);

        }
    }
}
