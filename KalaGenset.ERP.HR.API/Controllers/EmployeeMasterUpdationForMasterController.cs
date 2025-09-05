using FluentValidation;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.EmployeeMasterUpdationForMaster;
using KalaGenset.ERP.HR.Core.Request.Workstation;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KalaGenset.ERP.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeMasterUpdationForMasterController : ControllerBase
    {
        private readonly IEmployeeMasterUpdationForMaster _employeeMasterUpdationForMaster;
        private readonly IValidator<InsertEmployeeMasterUpdationForMasterRequest> _insertEmployeeMasterUpdationForMasterValidator;
        private readonly IValidator<UpdateEmployeeMasterUpdationForMasterRequest> _updateEmployeeMasterUpdationForMasterValidator;

        public EmployeeMasterUpdationForMasterController(
            IEmployeeMasterUpdationForMaster employeeMasterUpdationForMaster,
            IValidator<InsertEmployeeMasterUpdationForMasterRequest> insertEmployeeMasterUpdationForMasterValidator,
            IValidator<UpdateEmployeeMasterUpdationForMasterRequest> updateEmployeeMasterUpdationForMasterValidator)
        {
            _employeeMasterUpdationForMaster = employeeMasterUpdationForMaster;
            _insertEmployeeMasterUpdationForMasterValidator = insertEmployeeMasterUpdationForMasterValidator;
            _updateEmployeeMasterUpdationForMasterValidator = updateEmployeeMasterUpdationForMasterValidator;
        }

        /// <summary>
        /// Creates a new Employee Master Updation For.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("CreateEmployeeMasterUpdationFor")]
        public async Task<IActionResult> CreateEmployeeMasterUpdationFor([FromBody] InsertEmployeeMasterUpdationForMasterRequest request)
        {
            var validationResult = await _insertEmployeeMasterUpdationForMasterValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await _employeeMasterUpdationForMaster.AddEmployeeMasterUpdationForAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding Employee Master Updation For: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates an existing Employee Master Updation For.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("UpdateEmployeeMasterUpdationFor")]
        public async Task<IActionResult> UpdateEmployeeMasterUpdationFor([FromBody] UpdateEmployeeMasterUpdationForMasterRequest request)
        {
            var validationResult = await _updateEmployeeMasterUpdationForMasterValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await _employeeMasterUpdationForMaster.UpdateEmployeeMasterUpdationForAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating Employee Master Updation For: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets all Employee Master Updation For details.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetEmployeeMasterUpdationForDetails")]
        public async Task<IActionResult> GetEmployeeMasterUpdationForDetails()
        {
            var result = await _employeeMasterUpdationForMaster.GetEmployeeMasterUpdationForAsync();
            return Ok(result);
        }

        /// <summary>
        /// Gets an Employee Master Updation For by ID.
        /// </summary>
        /// <param name="EmployeeMasterUpdationForId"></param>
        /// <returns></returns>
        [HttpGet("GetEmployeeMasterUpdationForById/{EmployeeMasterUpdationForId}")]
        public async Task<IActionResult> GetEmployeeMasterUpdationForById(int EmployeeMasterUpdationForId)
        {
            try
            {
                var result = await _employeeMasterUpdationForMaster.GetEmployeeMasterUpdationForById(EmployeeMasterUpdationForId);
                if (result == null)
                {
                    return NotFound($"Employee Master Updation For with ID {EmployeeMasterUpdationForId} not found.");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving Employee Master Updation For: {ex.Message}");
            }
        }

        /// <summary>
        /// Deletes an Employee Master Updation For by ID.
        /// </summary>
        /// <param name="EmployeeMasterUpdationForId"></param>
        /// <returns></returns>
        [HttpDelete("DeleteEmployeeMasterUpdationFor/{EmployeeMasterUpdationForId}")]
        public async Task<IActionResult> DeleteEmployeeMasterUpdationFor(int EmployeeMasterUpdationForId)
        {
            try
            {
                await _employeeMasterUpdationForMaster.DeleteEmployeeMasterUpdationForAsync(EmployeeMasterUpdationForId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting Employee Master Updation For: {ex.Message}");
            }
        }
    }

}