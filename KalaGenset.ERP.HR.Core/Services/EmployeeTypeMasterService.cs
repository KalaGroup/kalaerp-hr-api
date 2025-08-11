using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request;
using KalaGenset.ERP.HR.Core.Request.EmployeeTypeMaster;
using KalaGenset.ERP.HR.Data.DbContexts;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace KalaGenset.ERP.HR.Core.Services
{
    public class EmployeeTypeMasterService : IEmployeeTypeMaster
    {
        private readonly KalaDbContext _Context;
        public EmployeeTypeMasterService(KalaDbContext Context)
        {
            _Context = Context;
        }
        /// <summary>
        /// This method is used to add a new employee type to the database.
        /// </summary>
        /// <param name="insertEmployeeTypeRequest"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Task AddEmployeetype(InsertEmployeeTypeRequest insertEmployeeTypeRequest)
        {
            try
            {
                var EmployeeTypeMaster = new EmployeeTypeMaster
                {
                    //EmployeeTypeId = insertEmployeeTypeRequest.EmployeeTypeId,
                    EmployeeTypeCode = insertEmployeeTypeRequest.EmployeeTypeCode,
                    EmployeeTypeName = insertEmployeeTypeRequest.EmployeeTypeName,
                    EmployeeTypeDescription = insertEmployeeTypeRequest.EmployeeTypeDescription,
                    EmployeeTypeRemark = insertEmployeeTypeRequest.EmployeeTypeRemark,
                    EmployeeTypeAuthRemark = insertEmployeeTypeRequest.EmployeeTypeAuthRemark,
                    EmployeeTypeAuth = insertEmployeeTypeRequest.EmployeeTypeAuth,
                    EmployeeTypeIsDiscard = insertEmployeeTypeRequest.EmployeeTypeIsDiscard,
                    EmployeeTypeIsActive = insertEmployeeTypeRequest.EmployeeTypeIsActive,
                    CreatedBy = insertEmployeeTypeRequest.CreatedBy,
                    CreatedDate = insertEmployeeTypeRequest.CreatedDate,
                };
                _Context.EmployeeTypeMasters.Add(EmployeeTypeMaster);
                return _Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new Exception("An error occurred while adding the employee type.", ex);
            }
        }
        /// <summary>
        /// This method retrieves all employee types from the database.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<EmployeeTypeMaster>> GetAllEmployeeType()
        {
            return await _Context.EmployeeTypeMasters.ToListAsync();

        }
        /// <summary>
        /// This method retrieves an employee type by its ID from the database.
        /// </summary>
        /// <param name="EmployeeTypeId"></param>
        /// <returns></returns>
        public async Task<EmployeeTypeMaster?> EmployeeTypeById(int EmployeeTypeId)
        {
            return await _Context.EmployeeTypeMasters.FirstOrDefaultAsync(c => c.EmployeeTypeId == EmployeeTypeId);
        }
        /// <summary>
        /// This method updates an existing employee type in the database.
        /// </summary>
        /// <param name="UpdateEmployeeTypeRequest"></param>
        /// <returns></returns>
        public async Task UpdateEmployeeTypeMasterAsync(UpdateEmployeeTypeRequest UpdateEmployeeTypeRequest)
        {

            try
            {
                var EmployeeType = await _Context.EmployeeTypeMasters.FirstOrDefaultAsync(c => c.EmployeeTypeId == UpdateEmployeeTypeRequest.EmployeeTypeId);

                EmployeeType.EmployeeTypeId = UpdateEmployeeTypeRequest.EmployeeTypeId;
                EmployeeType.EmployeeTypeCode = UpdateEmployeeTypeRequest.EmployeeTypeCode;
                EmployeeType.EmployeeTypeName = UpdateEmployeeTypeRequest.EmployeeTypeName;
                EmployeeType.EmployeeTypeDescription = UpdateEmployeeTypeRequest.EmployeeTypeDescription;
                EmployeeType.EmployeeTypeRemark = UpdateEmployeeTypeRequest.EmployeeTypeRemark;
                EmployeeType.EmployeeTypeAuthRemark = UpdateEmployeeTypeRequest.EmployeeTypeAuthRemark;
                EmployeeType.EmployeeTypeAuth = UpdateEmployeeTypeRequest.EmployeeTypeAuth;
                EmployeeType.EmployeeTypeIsDiscard = UpdateEmployeeTypeRequest.EmployeeTypeIsDiscard;
                EmployeeType.EmployeeTypeIsActive = UpdateEmployeeTypeRequest.EmployeeTypeIsActive;

                _Context.EmployeeTypeMasters.Update(EmployeeType);
                await _Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// This method soft deletes an employee type by setting its active status to false.
        /// </summary>
        /// <param name="EmployeeTypeId"></param>
        /// <returns></returns>
        public async Task DeleteEmployeeTypeById(int EmployeeTypeId)
        {
            try
            {

                var employee = await _Context.EmployeeTypeMasters.FirstOrDefaultAsync(c => c.EmployeeTypeId == EmployeeTypeId);
                if (employee == null)
                {
                    throw new Exception("Employee Type not found");
                }
                if (!employee.EmployeeTypeIsActive)
                {
                    throw new Exception("Employee type is alredy Soft Deleted");
                }
                employee.EmployeeTypeIsActive = false;
                _Context.EmployeeTypeMasters.Update(employee);
                await _Context.SaveChangesAsync();


            }
            catch (Exception)
            {

                throw;

            }
        }
    }
}
