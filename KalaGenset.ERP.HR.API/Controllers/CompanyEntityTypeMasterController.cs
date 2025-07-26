using FluentValidation;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace KalaGenset.ERP.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyEntityTypeMasterController : ControllerBase
    {
        private readonly ICompanyEntityTypeMaster _companyEntityTypeMaster;
        private readonly IValidator<CompanyEntityTypeMasterRequest> _validator;

        public CompanyEntityTypeMasterController(ICompanyEntityTypeMaster companyEntityTypeMaster, IValidator<CompanyEntityTypeMasterRequest> validator)
        {
            _companyEntityTypeMaster = companyEntityTypeMaster;
            _validator = validator;
        }

        [HttpPost("addcompanyentitytype")]
        public async Task<IActionResult> AddCompanyEntityType(CompanyEntityTypeMasterRequest insertCompanyEntityTypeMasterRequest)
        {
            var validationResult = await _validator.ValidateAsync(insertCompanyEntityTypeMasterRequest);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await _companyEntityTypeMaster.InsertCompanyEntityTypeMaster(insertCompanyEntityTypeMasterRequest);
                return Ok("Company Entity Type Created Successfully ");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding company entity type: {ex.Message}");
            }
        }

        [HttpPut("updatecompanyentitytype")]
        public async Task<IActionResult> UpdateCompanyEntityType(CompanyEntityTypeMasterRequest updateCompanyEntityTypeMasterRequest)
        {
            var validationResult = await _validator.ValidateAsync(updateCompanyEntityTypeMasterRequest);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await _companyEntityTypeMaster.UpdateCompanyEntityMaster(updateCompanyEntityTypeMasterRequest);
                return Ok("Company Entity Type Updated Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating company entity type: {ex.Message}");
            }
        }
        [HttpDelete("deletecompanyentitytype/{companyId}")]
        public async Task<IActionResult> DeleteCompany(int companyId)
        {
            try
            {
                await _companyEntityTypeMaster.DeleteCompanyAsync(companyId);
                return Ok("Company Entity Type Deactivated Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deactivating company entity type: {ex.Message}");
            }
        }


    }
}
