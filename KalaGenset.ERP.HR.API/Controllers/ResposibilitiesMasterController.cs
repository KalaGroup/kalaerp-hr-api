using FluentValidation;
using KalaERP.HR.Core.Interface;
using KalaERP.HR.Core.Request.DesignationMaster;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.ResposibilitiesMaster;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KalaGenset.ERP.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResposibilitiesMasterController : ControllerBase
    {
        private readonly IResposibilitiesMaster resposibilitiesMaster;
        private readonly IValidator<InsertResposibilitiesMasterRequest> _validator;// Validator for InsertCompanyRequest
        private readonly IValidator<UpdateResposibilitiesMasterRequest> _updateValidator;// Validator for UpdateCompanyRequest

        public ResposibilitiesMasterController(IResposibilitiesMaster resposibilitiesMaster, IValidator<InsertResposibilitiesMasterRequest> validator, IValidator<UpdateResposibilitiesMasterRequest> updatevalidator)
        {
            this.resposibilitiesMaster = resposibilitiesMaster;
            _validator = validator;
            _updateValidator = updatevalidator;
        }

        [HttpPost("addresponsibilities")]
        public async Task<IActionResult> AddResponsibilitiesAsync([FromBody] InsertResposibilitiesMasterRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request data.");
            }

            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            try
            {
                await resposibilitiesMaster.AddResposibilitiesAsync(request);
                return Ok("Responsibility added successfully.");
            }
            catch (Exception ex)
            {
                // You can log the exception here if needed
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error adding responsibility: {ex.Message}");
            }
        }

        [HttpGet("getresposibilities")]

        public async Task<IActionResult> GetResposibilitiesAsync()
        {
            try
            {
                var resposibilities = await resposibilitiesMaster.GetResposibilitiesAsync();
                return Ok(resposibilities);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving resposibilities: {ex.Message}");
            }
        }

        [HttpDelete("deleteresposibilities/{id}")]
        public async Task<IActionResult> DeleteResposibilitiesAsync(int id)
        {
            try
            {
                await resposibilitiesMaster.DeleteResposibilitiesAsync(id);
                return Ok("Resposibility deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting resposibility: {ex.Message}");
            }
        }

        [HttpGet("getresposibilitiesbyid/{id}")]

        public async Task<IActionResult> GetResposibilitiesByIdAsync(int id)
        {
            try
            {
                var resposibility = await resposibilitiesMaster.GetResposibilitiesByIdAsync(id);
                if (resposibility == null)
                {
                    return NotFound("Resposibility not found.");
                }
                return Ok(resposibility);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving resposibility: {ex.Message}");
            }
        }
        [HttpPut("updateresposibilities")]
        public async Task<IActionResult> UpdateResposibilitiesAsync([FromBody] UpdateResposibilitiesMasterRequest request)
        {
            if (request == null) // Check if the request is null
            {
                return BadRequest("Invalid request data."); // Return a BadRequest response if the request is null
            }
            var validationResult = await _updateValidator.ValidateAsync(request); // Validate the request using the validator
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors); // Return a BadRequest response if validation fails
            }
            try
            {
                await resposibilitiesMaster.UpdateResposibilitiesAsync(request);
                return Ok("Resposibility updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating resposibility: {ex.Message}");
            }
        }
    }
}
