using FluentValidation;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.ActivityMaster;
using KalaGenset.ERP.HR.Core.Request.ProfitcenterBudget;
using KalaGenset.ERP.HR.Core.Request.ProfitcenterMaster;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KalaGenset.ERP.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfitcenterBudgetController : BaseController
    {
        private readonly IProfitcenterBudget profitcenterBudget;
        private readonly IValidator<InsertProfitcenterBudgetRequest> validator;
        private readonly IValidator<UpdateProfitcenterBudgetRequest> updateValidator;
        public ProfitcenterBudgetController(IProfitcenterBudget profitcenterBudget,
                                         IValidator<InsertProfitcenterBudgetRequest> validator,
                                         IValidator<UpdateProfitcenterBudgetRequest> updateValidator)
        {
            this.profitcenterBudget = profitcenterBudget;
            this.validator = validator;
            this.updateValidator = updateValidator;
        }


        [HttpPost("addprofitcenterbudget")]
        public async Task<IActionResult> Addprofitcenterbudget([FromBody] InsertProfitcenterBudgetRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request data.");
            }

            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                .Select(e => new { field = e.PropertyName, message = e.ErrorMessage })
                .FirstOrDefault();

                return BadRequest(errors);
            }

            try
            {
                await profitcenterBudget.AddProfitCenterBudgetAsync(request);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(); // 409 Conflict
            }
          
        }

        [HttpGet("getprofitcenterbudget")]
        public async Task<IActionResult> GetAllprofitcenterbudget()
        {
            try
            {
                var budget = await profitcenterBudget.GetAllProfitCenterBudgetAsync();
                if (budget == null || !budget.Any())
                {
                    return NotFound("No budget found.");
                }
                return Ok(budget);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet("getprofitcenterbudgetbyid/{ProfitcenterBudgetId}")]
        public async Task<IActionResult> getprofitcenterbudgetById(int ProfitcenterBudgetId)
        {
            var result = await profitcenterBudget.GetProfitCenterBudgetByIdAsync(ProfitcenterBudgetId);
            return Ok(result);
        }

        [HttpPut("updateprofitcenterbudget")]
       
        public async Task<IActionResult> UpdateProfitCenterBudget([FromBody] UpdateProfitcenterBudgetRequest request)
        {
            if (request == null)
                return BadRequest(new { message = "Invalid request data." });

            // Validate request using FluentValidation
            var validationResult = await updateValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .Select(e => new { field = e.PropertyName, message = e.ErrorMessage })
                    .ToList();

                return BadRequest(new { errors });
            }

            try
            {
                await profitcenterBudget.UpdateProfitCenterBudgetAsync(request);
                return Ok(new { message = "Profit Center Budget updated successfully." });
            }
            catch (Exception ex)
            {
                // Log exception if you have logging service
                // _logger.LogError(ex, "Error updating Profit Center Budget");

                return StatusCode(500, new { message = $"An error occurred while updating Profit Center Budget: {ex.Message}" });
            }
        }


        [HttpDelete("deleteprofitcenterbudge/{ProfitcenterBudgetId}")]
        public async Task<IActionResult> DeleteProfitCenterBudget(int ProfitcenterBudgetId)
        {
            try
            {
                await profitcenterBudget.DeleteProfitCenterBudgetAsync(ProfitcenterBudgetId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while Soft-Deleting department: {ex.Message}");
            }
        }

        [HttpGet("GetFinancialYear")]
        public async Task<IActionResult> GetYearEnd()
        {
            var results = await profitcenterBudget.GetYearEndAsync();
            return Ok(results);
        }

    }
}
