using FluentValidation;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.Country;
using KalaGenset.ERP.HR.Core.Request.Department;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KalaGenset.ERP.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentMasterController : ControllerBase
    {
        private readonly IDepartmentMaster _departmentMaster;
        private readonly IValidator<InsertDepartmentRequest> _insertDepartmentValidator;
        private readonly IValidator<UpdateDepartmentRequest> _updateDepartmentValidator;
        public DepartmentMasterController(IDepartmentMaster DepartmentMaster, IValidator<InsertDepartmentRequest> InsertDepartmentValidator, IValidator<UpdateDepartmentRequest> UpdateDepartmentValidator)
        {
            _departmentMaster = DepartmentMaster;
            _insertDepartmentValidator = InsertDepartmentValidator;
            _updateDepartmentValidator = UpdateDepartmentValidator;
        }

        /// <summary>
        /// Creates a new Department in the system.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("createdepartment")]
        public async Task<IActionResult> CreateDepartment([FromBody] InsertDepartmentRequest request)
        {
            var validationResult = await _insertDepartmentValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await _departmentMaster.AddDepartmentAsync(request);
                return Ok("Department added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding department: {ex.Message}");
            }
        }
        /// <summary>
        /// Updates an existing Department in the system.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("updatedepartment")]
        public async Task<IActionResult> UpdateDepartment(UpdateDepartmentRequest request)
        {
            var validationResult = await _updateDepartmentValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await _departmentMaster.UpdateDepartmentAsync(request);
                return Ok("Department updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating department: {ex.Message}");
            }
        }
        /// <summary>
        /// Retrieves all Departments from the system.
        /// </summary>
        /// <returns></returns>
        [HttpGet("getalldepartments")]
        public async Task<IActionResult> GetAllDepartments()
        {
            var departments = await _departmentMaster.GetDepartmentDetailsAsync();
            return Ok(departments);
        }
        /// <summary>
        /// Retrieves details of a specific Department by its ID.
        /// </summary>
        /// <param name="DepartmentId"></param>
        /// <returns></returns>
        [HttpGet("getdepartmentbyid/{DepartmentId}")]
        public async Task<IActionResult> GetDepartmentDetails(int DepartmentId)
        {
            var result = await _departmentMaster.GetDepartmentById(DepartmentId);
            return Ok(result);
        }
        /// <summary>
        /// Soft-deletes a Department by setting its IsActive flag to false.
        /// </summary>
        /// <param name="DepartmentId"></param>
        /// <returns></returns>
        [HttpDelete("deletedepartment/{DepartmentId}")]
        public async Task<IActionResult> DeleteDepartment(int DepartmentId)
        {
            try
            {
                await _departmentMaster.DeleteDepartmentAsync(DepartmentId);
                return Ok("Department soft-deleted successfully (DepartmentIsActive = false).");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while Soft-Deleting department: {ex.Message}");
            }
        }
    }
}
