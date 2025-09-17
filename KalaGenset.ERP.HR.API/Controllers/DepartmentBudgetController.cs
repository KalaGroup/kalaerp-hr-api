using FluentValidation;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.DepartmentBudget;
using KalaGenset.ERP.HR.Core.Request.ShiftMaster;
using KalaGenset.ERP.HR.Core.ResponseDTO.DepartmentBudget;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KalaGenset.ERP.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentBudgetController : Controller
    {
        private readonly IDepartmentBudget _DepartmentBudget;
        private readonly IValidator<InsertDepartmentBudgetRequest> _insertdepartmetbudgetValidator;
        private readonly IValidator<UpdateDepartmentBudgetRequest> _updatedepartmentbudgetValidator; // Corrected type here

        public DepartmentBudgetController(IDepartmentBudget departmentbudget, IValidator<InsertDepartmentBudgetRequest> Insertdepartmentbudgetvalidator, IValidator<UpdateDepartmentBudgetRequest> UpdatedepartmentbudgetValidator)
        {
            _DepartmentBudget = departmentbudget;
            _insertdepartmetbudgetValidator = Insertdepartmentbudgetvalidator;
            _updatedepartmentbudgetValidator = UpdatedepartmentbudgetValidator; // Corrected assignment here
        }
        /// <summary>
        /// Insert Department Budget
        /// </summary>
        /// <param name="InsertDepartmentBudgetRequest"></param>
        /// <returns></returns>
        [HttpPost("InsertDepartmentBudget")]
        public async Task<IActionResult> InsertDepartmentBudget(InsertDepartmentBudgetRequest InsertDepartmentBudgetRequest)
        {
            var validationResult = await _insertdepartmetbudgetValidator.ValidateAsync(InsertDepartmentBudgetRequest);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await _DepartmentBudget.AddDepartmentBudgetAsync(InsertDepartmentBudgetRequest);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding Department Budget: {ex.Message}");
            }
        }
        /// <summary>
        /// Get Department Budget By ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("GetDepartmentBudgetByID/{Id}")]
        public async Task<IActionResult> GetDepartmentBudgetByID(int Id)
        {
            try
            {
                var result = await _DepartmentBudget.GetDepartmentBudgetByIDAsync(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Id is Invalid : {ex.Message}");
            }
        }
        /// <summary>
        /// Get All Department Budget Details
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllDepartmentBudget")]
        public async Task<IActionResult> GetAllDepartmentBudget()
        {
            var Departmentbudgets = await _DepartmentBudget.GetDepartmentBudgetDetailsAsync();
            return Ok(Departmentbudgets);

        }
        /// <summary>
        /// Update Department Budget
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("UpdateDepartmentBudget")]
        public async Task<IActionResult> UpdateDepartmentbudget([FromBody] UpdateDepartmentBudgetRequest request)
        {
            var validationResult = await _updatedepartmentbudgetValidator.ValidateAsync(request); // Corrected validator usage here
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await _DepartmentBudget.UpdatedepartmentBudgetAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating Department Budget: {ex.Message}");
            }
        }
        /// <summary>
        /// Get Year End
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetFinancialYear")]
        public async Task<IActionResult> GetYearEnd()
        {
            var results = await _DepartmentBudget.GetYearEndAsync();
            return Ok(results);
        }
        /// <summary>
        /// Delete Department Budget
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteDepartmentBudget/{Id}")]
        public async Task<IActionResult> DeleteShift(int Id)
        {
            try
            {
                await _DepartmentBudget.DeleteDepartmentBudgetAsync(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting Department Budget: {ex.Message}");
            }
        }
    }
}
