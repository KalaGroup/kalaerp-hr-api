using FluentValidation;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.Facility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KalaGenset.ERP.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilityMasterController : ControllerBase
    {
        private readonly IFacilityMaster _facilityMaster;
        private readonly IValidator<InsertFacilityRequest> _validator;
        private readonly IValidator<UpdateFacilityRequest> _updatevalidator;

        public FacilityMasterController(IFacilityMaster facilitymaster, IValidator<InsertFacilityRequest> validator, IValidator<UpdateFacilityRequest> updatevalidator)
        {
            _facilityMaster = facilitymaster;
            _validator = validator;
            _updatevalidator = updatevalidator;
        }

        /// <summary>
        /// Add New Facility Details in Facility Master
        /// </summary>
        /// <param name="insertfacilityrequest"></param>
        /// <returns></returns>
        [HttpPost("addfacility")]
        public async Task<IActionResult> AddFacilityAsync([FromBody] InsertFacilityRequest insertfacilityrequest)
        {
            var validationResult = await _validator.ValidateAsync(insertfacilityrequest);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await _facilityMaster.AddFacilityAsync(insertfacilityrequest);
                return Ok("Facility added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding Facility: {ex.Message}");
            }
        }

        /// <summary>
        /// Update Facility against Facility Id
        /// </summary>
        /// <param name="updateFacilityRequest"></param>
        /// <returns></returns>
        [HttpPut("updatefacility")]
        public async Task<IActionResult> UpdateFacilityAsync([FromBody] UpdateFacilityRequest updateFacilityRequest)
        {
            var validationResult = await _updatevalidator.ValidateAsync(updateFacilityRequest);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await _facilityMaster.UpdateFacilityAsync(updateFacilityRequest);
                return Ok("Facility updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating Facility: {ex.Message}");
            }
        }

        /// <summary>
        /// Get All Facility
        /// </summary>
        /// <returns></returns>
        [HttpGet("getallfacility")]
        public async Task<IActionResult> GetAllFacility()
        {
            var facility = await _facilityMaster.GetFacilityAsync();
            return Ok(facility);
        }

        /// <summary>
        /// Get Facility by FacilityId
        /// </summary>
        /// <param name="facilityId"></param>
        /// <returns></returns>
        [HttpGet("getfacilitybyid")]
        public async Task<IActionResult> GetFacilityByIdAsync(int facilityId)
        {
            var facility = await _facilityMaster.GetFacilityByIdAsync(facilityId);
            return Ok(facility);
        }

        /// <summary>
        /// Delete Facility By FacilityId
        /// </summary>
        /// <param name="FacilityId"></param>
        /// <returns></returns>
        [HttpDelete("deletefacility")]
        public async Task<IActionResult> DeleteFacility(int FacilityId)
        {
            try
            {
                await _facilityMaster.DeleteFacilityAsync(FacilityId);
                return Ok("Facility Id Softly Deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating Facility: {ex.Message}");
            }
        }


    }
}
