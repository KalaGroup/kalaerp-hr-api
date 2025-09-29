using FluentValidation;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.District;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace KalaGenset.ERP.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictMasterController : BaseController
    {

        private readonly IDistrictMaster _districtmaster;
        private readonly IValidator<InsertDistrictRequest> _insertvalidator;
        private readonly IValidator<UpdateDistrictRequest> _updatevalidator;
        public DistrictMasterController(IDistrictMaster districtmaster,
            IValidator<InsertDistrictRequest> insertvalidator,
            IValidator<UpdateDistrictRequest> updatevalidator)
        {
            _districtmaster = districtmaster;
            _insertvalidator = insertvalidator;
            _updatevalidator = updatevalidator;
        }

        /// <summary>
        /// CreatedDistrict
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("CreatedDistrict")]
        public async Task<IActionResult> CreatedDistrict([FromBody] InsertDistrictRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request data.");
            }
            var validationResult = await _insertvalidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                .Select(e => new { field = e.PropertyName, message = e.ErrorMessage })
                .FirstOrDefault();

                return BadRequest(errors);
            }
            try
            {
                await _districtmaster.AddDistrictMasterAsync(request);
                return Ok();

            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// GetAllDistrict
        /// </summary>
        /// <returns></returns>

        [HttpGet("GetAllDistrict")]
        public async Task<IActionResult> GetAllDistrict()
        {
            var district = await _districtmaster.GetDistrictMasterDetailsAsync();
            return Ok(district);
        }
        /// <summary>
        /// GetDistrictById
        /// </summary>
        /// <param name="DistrictId"></param>
        /// <returns></returns>

        [HttpGet("GetDistrictById/{DistrictId}")]
        public async Task<IActionResult> GetDistrictById(int DistrictId)
        {
            var district = await _districtmaster.GetDistrictMasterById(DistrictId);
            return Ok(district);

        }
        /// <summary>
        /// UpdateDistrict
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("UpdateDistrict")]
        public async Task<IActionResult> UpdateDistrict(UpdateDistrictRequest request)
        {
            var validationResult = await _updatevalidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await _districtmaster.UpdateDistrictMasterAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating District: {ex.Message}");
            }
        }

        /// <summary>
        /// DeleteCompany
        /// </summary>
        /// <param name="DistrictId"></param>
        /// <returns></returns>
        [HttpDelete("DeleteDistrict/{DistrictId}")]
        public async Task<IActionResult> DeleteCompany(int DistrictId)
        {
            try
            {
                await _districtmaster.DeleteDistrictMasterAsync(DistrictId);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("getdistrictdetailsbycountryid/{stateid}")]
        public async Task<IActionResult> GetDistrictDetailsByCountryId(int stateid)
        {
            try
            {
                var district = await _districtmaster.GetDistrictDetailsByStateIdAsync(stateid);
                return Ok(district);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching district details: {ex.Message}");
            }
        }
    }
}
