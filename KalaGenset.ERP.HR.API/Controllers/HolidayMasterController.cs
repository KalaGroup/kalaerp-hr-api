using FluentValidation;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request;
using KalaGenset.ERP.HR.Core.Request.HolidayMaster;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace KalaGenset.ERP.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class HolidayMasterController : ControllerBase
    {
        private readonly IHolidayMaster _holidayMaster;
        private readonly IValidator<InsertHolidayMasterRequest> _validator;
        private readonly IValidator<UpdateHolidayMasterRequest> _updateValidator;
        public HolidayMasterController(IHolidayMaster holidayMaster, IValidator<InsertHolidayMasterRequest> validator, IValidator<UpdateHolidayMasterRequest> updatevalidator)
        {
            _holidayMaster = holidayMaster;
            _validator = validator;
            _updateValidator = updatevalidator;
        }
        /// <summary>
        /// Insert Holiday Master
        /// </summary>
        /// <param name="insertHolidayMasterRequest"></param>
        /// <returns></returns>
        [HttpPost("insertholidaymaster")]
        public async Task<IActionResult> InsertHolidayMaster(InsertHolidayMasterRequest insertHolidayMasterRequest)
        {
            var validationResult = await _validator.ValidateAsync(insertHolidayMasterRequest);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await _holidayMaster.HolidayMasterAsync(insertHolidayMasterRequest);
                return Ok("Holiday Master Inserted Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding Holiday Master: {ex.Message}");
            }

        }
        /// <summary>
        /// Get All Holiday Masters
        /// </summary>
        /// <returns></returns>
        [HttpGet("getallholidaymasters")]
        public async Task<IActionResult> GetAllHolidayMasters()
        {
            try
            {
                var holidayMasters = await _holidayMaster.GetAllHolidayMasters();
                return Ok(holidayMasters);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving Holiday Masters: {ex.Message}");
            }
        }
        /// <summary>
        /// Get Holiday Master by ID
        /// </summary>
        /// <param name="holidayId"></param>
        /// <returns></returns>
        [HttpGet("getholidaymasterbyID")]
        public async Task<IActionResult> GetHolidayMasterById(int holidayId)
        {
            try
            {
                var holidayMaster = await _holidayMaster.GetHolidayMasterById(holidayId);
                if (holidayMaster == null)
                {
                    return NotFound($"Holiday Master with ID {holidayId} not found.");
                }
                return Ok(holidayMaster);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving Holiday Master: {ex.Message}");
            }
        }
        /// <summary>
        /// Update Holiday Master
        /// </summary>
        /// <param name="updateHolidayMasterRequest"></param>
        /// <returns></returns>
        [HttpPut("updateholidaymaster")]

        public async Task<IActionResult> UpdateHolidaymaster(UpdateHolidayMasterRequest updateHolidayMasterRequest)
        {
            var validationResult = await _updateValidator.ValidateAsync(updateHolidayMasterRequest);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await _holidayMaster.UpdateHolidayMasterAsync(updateHolidayMasterRequest);
                return Ok("Holiday type Updated Successfully");

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occured while updating Holiday:{ex.Message}");
            }
        }
        /// <summary>
        /// Delete Holiday Details by ID
        /// </summary>
        /// <param name="holidayId"></param>
        /// <returns></returns>
        [HttpDelete("DeleteHoliday")]
        public async Task<IActionResult> DeleteHolidayDetails(int holidayId)
        {
                try
                {
                    await _holidayMaster.DeleteHolidayById(holidayId);
                    return Ok("Record deleted successfully");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"An error occured while deleting Holiday:{ex.Message}");
                }

            }

        }
    
}
