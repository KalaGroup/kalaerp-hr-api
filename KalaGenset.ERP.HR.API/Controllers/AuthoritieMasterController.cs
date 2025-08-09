using FluentValidation;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.AuthoritieMaster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace KalaGenset.ERP.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthoritieMasterController : ControllerBase
    {
        /// <summary>
        /// represents the controller for managing authorities in the system.
        /// </summary>
        private readonly IAuthoritieMaster authoritieMaster;
        private readonly IValidator<InsertAuthoritieMasterRequest> insertAuthoritieValidator;
        private readonly IValidator<UpdateAuthoritieMasterRequest> updateAuthoritieValidator;
        /// <summary>
        /// constructor for initializing the AuthoritieMasterController with the required services.
        /// </summary>
        /// <param name="authoritieMaster"></param>
        /// <param name="insertAuthoritieValidator"></param>
        /// <param name="updateAuthoritieValidator"></param>
        public AuthoritieMasterController(IAuthoritieMaster authoritieMaster,
                                          IValidator<InsertAuthoritieMasterRequest> insertAuthoritieValidator,
                                          IValidator<UpdateAuthoritieMasterRequest> updateAuthoritieValidator)
        {
            this.authoritieMaster = authoritieMaster;
            this.insertAuthoritieValidator = insertAuthoritieValidator;
            this.updateAuthoritieValidator = updateAuthoritieValidator;
        }
        /// <summary>
        /// adds a new authoritie to the system based on the provided request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("addauthoritie")]
        public async Task<IActionResult> AddAuthoritie([FromBody] InsertAuthoritieMasterRequest request)
        {
            var validationResult = await insertAuthoritieValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await authoritieMaster.AddAuthoritieAsync(request);
                return Ok("Authoritie Added successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding authoritie: {ex.Message}");
            }
        }
        /// <summary>
        /// deletes an authoritie from the system based on its unique identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("deleteauthoritie/{id}")]
        public async Task<IActionResult> DeleteAuthoritie(int id)
        {
            try
            {              
                await authoritieMaster.DeleteAuthoritieAsync(id);
                return Ok("Authoritie deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting authoritie: {ex.Message}");
            }
        }
        /// <summary>
        /// gets all authoritie details from the system.
        /// </summary>
        /// <returns></returns>
        [HttpGet("getallauthorities")]
        public async Task<IActionResult>GetAllAuthoritieDetails()
        {
            try
            {
                var authorities = await authoritieMaster.GetAllAuthoritieDetailsAsync();
                return Ok(authorities);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving authorities: {ex.Message}");
            }
        }
        /// <summary>
        /// gets an authoritie by its unique identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("getauthoritiebyid/{id}")]
        public async Task<IActionResult> GetAuthoritieByID(int id)
        {
            try
            {
                var authoritie = await authoritieMaster.GetAuthoritieByID(id);
                if (authoritie == null)
                {
                    return NotFound($"Authoritie with ID {id} not found.");
                }
                return Ok(authoritie);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving authoritie: {ex.Message}");
            }
        }
        /// <summary>
        /// updates an existing authoritie in the system based on the provided request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("updateauthoritie")]
        public async Task<IActionResult> UpdateAuthoritie([FromBody] UpdateAuthoritieMasterRequest request)
        {
            var validationResult = await updateAuthoritieValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await authoritieMaster.UpdateAuthoritieAsync(request);
                return Ok("Authoritie updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating authoritie: {ex.Message}");
            }
        }
    }
}
