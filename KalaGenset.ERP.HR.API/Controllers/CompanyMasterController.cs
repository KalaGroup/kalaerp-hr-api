using FluentValidation;
using KalaERP.HR.Core.Interface;
using KalaERP.HR.Core.Request.CompanyMaster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KalaERP.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyMasterController : ControllerBase
    {
        private readonly ICompanyMaster companyMaster;// Interface for company master operations
        private readonly IValidator<InsertCompanyRequest> _validator;// Validator for InsertCompanyRequest
        private readonly IValidator<UpdateCompanyRequest> _updateValidator;// Validator for UpdateCompanyRequest
        public CompanyMasterController(ICompanyMaster companyMaster, IValidator<InsertCompanyRequest> validator, IValidator<UpdateCompanyRequest> updateValidator)
        {
            this.companyMaster = companyMaster;
            _validator = validator;
            _updateValidator = updateValidator;
        }
        /// <summary>
        /// adds a new company to the system.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>

        [HttpPost("addcompany")]
        public async Task<IActionResult> AddCompanyAsync([FromBody] InsertCompanyRequest request)
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
                await companyMaster.AddCompanyAsync(request);
                return Ok("Company added successfully.");
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
        /// <summary>
        /// gets a list of all companies in the system.
        /// </summary>
        /// <returns></returns>
        [HttpGet("getcompany")]
        public async Task<IActionResult> GetCompanyAsync()
        {
            try
            {
                var companies = await companyMaster.GetCompanyAsync();
                if (companies == null || !companies.Any())                          
                {
                    return NotFound("No companies found.");
                }
                return Ok(companies);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
        /// <summary>
        /// gets a specific company by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("getcompanybyid/{id}")]
        public async Task<IActionResult> GetCompanyByIdAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid company ID.");
            }
            try
            {
                var company = await companyMaster.GetCompanyByIdAsync(id);
                if (company == null)
                {
                    return NotFound($"Company with ID {id} not found.");
                }
                return Ok(company);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
        /// <summary>
        /// updates an existing company in the system.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("updatecompany")]
        public async Task<IActionResult> UpdateCompanyAsync([FromBody] UpdateCompanyRequest request)
        {
            if (request == null || request.CompanyId <= 0)
            {
                return BadRequest("Invalid request data.");
            }
            var validationResult = await _updateValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await companyMaster.UpdateCompanyAsync(request);
                return Ok("Company updated successfully.");
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
        /// <summary>
        /// deletes a company by its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("deletecompany/{id}")]
        public async Task<IActionResult>DeleteCompanyAsync(int id)
        {
            try
            {
                await companyMaster.DeleteCompanyAsync(id);
                 return Ok("Company deleted successfully.");
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
    }
}
