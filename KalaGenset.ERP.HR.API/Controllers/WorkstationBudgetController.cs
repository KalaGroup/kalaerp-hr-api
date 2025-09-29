using Azure.Core;
using FluentValidation;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.DepartmentBudget;
using KalaGenset.ERP.HR.Core.Request.WorkstationBudget;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace KalaGenset.ERP.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkstationBudgetController : BaseController
    {
        private readonly IWorkstationBudget _WorkstationBudget;
        private readonly IValidator<InsertWorkstationBudgetRequest> _insertworkstaionbudgetValidator;
        private readonly IValidator<UpdateWorkstaionBudgetRequest> _updatedepartmentbudgetValidator; // Corrected type here

        public WorkstationBudgetController(IWorkstationBudget workstationBudget, IValidator<InsertWorkstationBudgetRequest> insertWorkstationBudgetValidator, IValidator<UpdateWorkstaionBudgetRequest> updatedepartmentbudgetValidator)
        {
            _WorkstationBudget = workstationBudget;
            _insertworkstaionbudgetValidator = insertWorkstationBudgetValidator;
            _updatedepartmentbudgetValidator = updatedepartmentbudgetValidator;
        }
        /// <summary>
        /// Insert Workstation Budget
        /// </summary>
        /// <param name="InsertWorkstationBudgetRequest"></param>
        /// <returns></returns>
        [HttpPost("InsertworkstationBudget")]
        public async Task<IActionResult> InsertWorkstaionBudget(InsertWorkstationBudgetRequest InsertWorkstationBudgetRequest)
        {
            if (InsertWorkstationBudgetRequest == null)
            {
                return BadRequest("Invalid request data.");
            }

            var validationResult = await _insertworkstaionbudgetValidator.ValidateAsync(InsertWorkstationBudgetRequest);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                .Select(e => new { field = e.PropertyName, message = e.ErrorMessage })
                .FirstOrDefault();

                return BadRequest(errors);
            }

            try
            {
                await _WorkstationBudget.AddWorkstationBudgetAsync(InsertWorkstationBudgetRequest);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(); // 409 Conflict
            }
        }
        /// <summary>
        /// Get All Workstation Budget Details
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllWorkstaionBudget")]
        public async Task<IActionResult> GetAllWorkstationBudget()
        {
            var Workstationbudgets = await _WorkstationBudget.GetWorkstationBudgetDetailsAsync();
            return Ok(Workstationbudgets);

        }
        /// <summary>
        /// Get Workstation Budget By ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("GetWorkstationBudgetByID/{Id}")]
        public async Task<IActionResult> GetDepartmentBudgetByID(int Id)
        {
            try
            {
                var result = await _WorkstationBudget.GetWorkstationBudgetByIDAsync(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Id is Invalid : {ex.Message}");
            }
        }
        /// <summary>
        /// Update Workstation Budget
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("UpdateWorkstationBudget")]
        public async Task<IActionResult> UpdateWorkstationbudget([FromBody] UpdateWorkstaionBudgetRequest request)
        {
            var validationResult = await _updatedepartmentbudgetValidator.ValidateAsync(request); // Corrected validator usage here
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await _WorkstationBudget.UpdateWorkstationBudgetAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating Department Budget: {ex.Message}");
            }
        }
        /// <summary>
        /// Delete Workstation Budget
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteWorkstationBudget/{Id}")]
        public async Task<IActionResult> DeleteWorkstationBudget(int Id)
        {
            try
            {
                await _WorkstationBudget.DeleteWorkstationBudgetAsync(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting Workstation Budget: {ex.Message}");
            }
        }
    }
}
