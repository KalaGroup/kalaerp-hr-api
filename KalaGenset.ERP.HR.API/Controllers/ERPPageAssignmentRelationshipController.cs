using FluentValidation;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.ActivityMaster;
using KalaGenset.ERP.HR.Core.Request.ERPPageAssignmentRelationship;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KalaGenset.ERP.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ERPPageAssignmentRelationshipController : ControllerBase
    {
        private readonly IERPPageAssignmentRelationship relationship;
        private readonly IValidator<InsertPageAssignmentRelationshipRequest> validator;
        private readonly IValidator<UpdatePageAssignmentRelationshipRequest> updateValidator;
        public ERPPageAssignmentRelationshipController(IERPPageAssignmentRelationship relationship,
                                       IValidator<InsertPageAssignmentRelationshipRequest> validator,
                                        IValidator<UpdatePageAssignmentRelationshipRequest> updateValidator)
        {
            this.relationship = relationship;
            this.validator = validator;
            this.updateValidator = updateValidator;
        }

      
        [HttpPost("adderpPageAssignmentRelationship")]

        public async Task<IActionResult> AddERPPageAssignmentRelationshipAsync([FromBody] InsertPageAssignmentRelationshipRequest request)
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
                await relationship.AddERPPageAssignmentRelationshipAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("updateerpPageAssignmentRelationship")]
        public async Task<IActionResult> UpdateERPPageAssignmentRelationshipAsync([FromBody] UpdatePageAssignmentRelationshipRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request data.");
            }
            var validationResult = await updateValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                .Select(e => new { field = e.PropertyName, message = e.ErrorMessage })
                .FirstOrDefault();

                return BadRequest(errors);
            }
            try
            {
                await relationship.UpdateERPPageAssignmentRelationshipAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("getAllerpPageAssignmentRelationship")]
        public async Task<IActionResult> GetAllERPPageAssignmentRelationshipAsync()
        {
            try
            {
                var result = await relationship.GetAllERPPageAssignmentRelationshipAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("geterpPageAssignmentRelationshipById/{id}")]
        public async Task<IActionResult> GetERPPageAssignmentRelationshipById(int id)
        {
            try
            {
                var result = await relationship.GetERPPageAssignmentRelationshipById(id);
                if (result == null)
                {
                    return NotFound($"ERP Page Assignment Relationship with ID {id} not found.");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("geterpPageDetailsByMasterId/{masterId}")]
        public async Task<IActionResult> GetERPPageDetailsByMasterId(int masterId)
        {
            try
            {
                var result = await relationship.GetERPPageDetailsByMsaterId(masterId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("deleteerpPageAssignmentRelationship/{id}")]
        public async Task<IActionResult> DeleteERPPageAssignmentRelationshipAsync(int id)
        {
            try
            {
                await relationship.DeleteERPPageAssignmentRelationshipAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("getallrelationshipdetails")]
        public async Task<IActionResult> GetallRelationshipDetails()
        {
            try
            {
                var result = await relationship.GetAllERPPageAssignmentRelationshipDeatils();
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("getdivisionidandpahetittel")]
        public async Task<IActionResult> GetDivisionidandPageTittel()
        {
            try
            {
                var result = await relationship.GetDivivsionIdandPageTittel();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
