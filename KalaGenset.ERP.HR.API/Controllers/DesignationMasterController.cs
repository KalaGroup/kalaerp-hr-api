using FluentValidation;
using KalaERP.HR.Core.Interface;
using KalaERP.HR.Core.Request.CompanyMaster;
using KalaERP.HR.Core.Request.DesignationMaster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KalaERP.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationMasterController : ControllerBase
    {
        private readonly IDesignationMaster designationMaster;
        private readonly IValidator<InsertDesignationMasterRequest> _validator;// Validator for InsertCompanyRequest
        private readonly IValidator<UpdateDesignationMasterRequest> _updateValidator;// Validator for UpdateCompanyRequest

        /// <summary>
        /// method to initialize the DesignationMasterController with the required services.
        /// </summary>
        /// <param name="designationMaster"></param>
        /// <param name="validator"></param>
        /// <param name="updatevalidator"></param>
        public DesignationMasterController(IDesignationMaster designationMaster,IValidator<InsertDesignationMasterRequest>validator,IValidator<UpdateDesignationMasterRequest>updatevalidator)
        {
            this.designationMaster = designationMaster;
            _validator = validator;
            _updateValidator = updatevalidator;
        }
        /// <summary>
        /// adds a new designation to the system.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("adddesignation")]
        public async Task<IActionResult> AddDesignationAsync([FromBody] InsertDesignationMasterRequest request)
        {
            if (request == null)// Check if the request is null
            {
                return BadRequest("Invalid request data.");// Return a BadRequest response if the request is null
            }
            var validationResult = await _validator.ValidateAsync(request);// Validate the request using the validator
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);// Return a BadRequest response if validation fails
            }
            try
            {
                await designationMaster.AddDesignationAsync(request);
                return Ok("Designation added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error adding designation: {ex.Message}");
            }
        }
        /// <summary>
        /// gets all designations from the system.
        /// </summary>
        /// <returns></returns>
        [HttpGet("getdesignation")]
        public async Task<IActionResult> GetDesignationAsync()
        {
            try
            {
                var result = await designationMaster.GetDesignationAsync();// Retrieve all designations
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving designations: {ex.Message}");
            }
        }   
        /// <summary>
        /// updates an existing designation in the system.
        /// </summary>
        /// <param name="request"></param>
        [HttpPut("updatedesignation")]
        public async Task<IActionResult>UpdateDesignationAsync([FromBody] UpdateDesignationMasterRequest request)
        {
            if (request == null)// Check if the request is null
            {
                return BadRequest("Invalid request data.");// Return a BadRequest response if the request is null
            }   
            var validationResult = await _updateValidator.ValidateAsync(request);// Validate the request using the update validator
            if (!validationResult.IsValid)
            {   
                return BadRequest(validationResult.Errors);
            }   
            try 
            {                 
                await designationMaster.UpdateDesignationAsync(request);
                return Ok("Designation updated successfully.");
            }   
            catch (Exception ex)
            {   
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating designation: {ex.Message}");
            }   
        }       
        /// <summary>
        /// gets a designation by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("getdesignationbyid/{id}")]
        public async Task<IActionResult> GetDesignationByIdAsync(int id)
        {       
            try 
            {   
                var designation = await designationMaster.GetDesigationByIdAsync(id);
                if (designation == null)
                {
                    return NotFound($"Designation with ID {id} not found.");
                }
                return Ok(designation);
            }   
            catch (Exception ex)
            {   
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving designation: {ex.Message}");
            }   
        }       
        /// <summary>
        /// deletes a designation by its ID.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("deletedesignation/{id}")]
        public async Task<IActionResult> DeleteDesignationAsync(int id)
        {       
            try 
            {   
                await designationMaster.DeleteDesignationAsync(id);
                return Ok("Designation deleted successfully.");
            }   
            catch (Exception ex)
            {   
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting designation: {ex.Message}");
            }   
        }       
    }           
}               
                