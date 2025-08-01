using FluentValidation;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.District;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KalaGenset.ERP.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictMasterController : ControllerBase
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
            var validationResult = await _insertvalidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await _districtmaster.AddDistrictMasterAsync(request);
                return Ok("District Added Successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding District: {ex.Message}");
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
                return Ok("District updated successfully.");
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
                return Ok("District Deleted Successfully.");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
