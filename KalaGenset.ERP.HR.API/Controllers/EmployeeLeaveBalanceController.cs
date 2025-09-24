using FluentValidation;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.EmployeeLeaveBalance;
using KalaGenset.ERP.HR.Core.Request.Workstation;
using KalaGenset.ERP.HR.Core.Validation.EmployeeLeaveBalanceValidation;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace KalaGenset.ERP.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeLeaveBalanceController : ControllerBase
    {
        private readonly IEmployeeLeaveBalance _employeeleavebalance;
        private readonly IValidator<InsertEmployeeLeaveBalanceRequest> _insertEmployeeLeaveBalanceValidator;
        private readonly IValidator<UpdateEmployeeLeaveBalanceRequest> _updateEmployeeLeaveBalanceValidator;

        public EmployeeLeaveBalanceController(IEmployeeLeaveBalance employeeleavebalance, IValidator<InsertEmployeeLeaveBalanceRequest> InsertEmployeeLeaveBalancevalidator, IValidator<UpdateEmployeeLeaveBalanceRequest> UpdateEmployeeLeaveBalanceValidator)
        {
            _employeeleavebalance = employeeleavebalance;
            _insertEmployeeLeaveBalanceValidator = InsertEmployeeLeaveBalancevalidator;
            _updateEmployeeLeaveBalanceValidator = UpdateEmployeeLeaveBalanceValidator;
        }

        /// <summary>
        /// Creates a new EmployeeLeaveBalance.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("CreateEmployeeLeaveBalance")]
        public async Task<IActionResult> CreateEmployeeLeaveBalance([FromBody] InsertEmployeeLeaveBalanceRequest request)
        {
            var validationResult = await _insertEmployeeLeaveBalanceValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            try
            {
                await _employeeleavebalance.AddEmployeeLeaveBalanceAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding Employee Leave Balance: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates an EmployeeLeaveBalance.
        /// </summary>
        [HttpPut("UpdateEmployeeLeaveBalance")]
        public async Task<IActionResult> UpdateEmployeeLeaveBalance([FromBody] UpdateEmployeeLeaveBalanceRequest request)
        {
            var validationResult = await _updateEmployeeLeaveBalanceValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            try
            {
                await _employeeleavebalance.UpdateEmployeeLeaveBalanceAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating Employee Leave Balance: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets all EmployeeLeaveBalances.
        /// </summary>
        [HttpGet("GetAllEmployeeLeaveBalance")]
        public async Task<IActionResult> GetAllEmployeeLeaveBalances()
        {
            try
            {
                var result = await _employeeleavebalance.GetEmployeeLeaveBalancesAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching Employee Leave Balances: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets an EmployeeLeaveBalance by ID.
        /// </summary>
        [HttpGet("GetEmployeeLeaveBalanceByID/{id}")]
        public async Task<IActionResult> GetEmployeeLeaveBalanceById(int id)
        {
            try
            {
                var result = await _employeeleavebalance.GetEmployeeLeaveBalanceByIdAsync(id);
                if (result == null)
                    return NotFound($"Employee Leave Balance with ID {id} not found.");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Id is Invalid : {ex.Message}");
            }
        }

        /// <summary>
        /// Deletes (soft delete) an EmployeeLeaveBalance by ID.
        /// </summary>
        [HttpDelete("DeleteEmployeeLeaveBalance/{id}")]
        public async Task<IActionResult> DeleteEmployeeLeaveBalance(int id)
        {
            try
            {
                await _employeeleavebalance.DeleteEmployeeLeaveBalanceAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting Employee Leave Balance: {ex.Message}");
            }
        }
    }
}