using FluentValidation;
using KalaERP.HR.Core.Interface;
using KalaERP.HR.Core.Request.CompanyMaster;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.ActivityMaster;
using KalaGenset.ERP.HR.Core.Request.Country;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KalaGenset.ERP.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityMasterController : ControllerBase
    {
        private readonly IActivityMaster activityMaster;
        private readonly IValidator<InsertActivityMasterRequest> validator;
        private readonly IValidator<UpdateActivityMasterRequest> updateValidator;
        public  ActivityMasterController(IActivityMaster activityMaster,
                                         IValidator<InsertActivityMasterRequest>validator,
                                         IValidator<UpdateActivityMasterRequest> updateValidator)
        {
            this.activityMaster = activityMaster;
            this.validator = validator;
            this.updateValidator = updateValidator;
        }
        /// <summary>
        /// Add activity 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("addactivity")]
        public async Task<IActionResult> AddCompanyAsync([FromBody] InsertActivityMasterRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request data.");
            }
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await activityMaster.AddActivityAsync(request);
                return Ok("Activity added successfully.");
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
        /// <summary>
        /// get all activity
        /// </summary>
        /// <returns></returns>
        [HttpGet("getactivity")]
        public async Task<IActionResult> GetAllActivity()
        {
            try
            {
                var activities = await activityMaster.GetAllActivityMasterAsync();
                if (activities == null || !activities.Any())
                {
                    return NotFound("No activities found.");
                }
                return Ok(activities);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
        /// <summary>
        /// get by id 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("getactivitybyid/{Id}")]
        public async Task<IActionResult> getbyid(int Id)
        {
            var result = await activityMaster.GetActivityByID(Id);
            return Ok(result);
        }
        /// <summary>
        /// delete activity record 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("deleteactivity/{Id}")]
        public async Task<IActionResult> DeleteActivity(int Id)
        {
            try
            {
                await activityMaster.DeleteActivityAsync(Id);
                return Ok("activity soft-deleted successfully ");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while Soft-Deleting : {ex.Message}");
            }
        }
        /// <summary>
        /// update actitvity 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("updateactivity")] 
        public async Task<IActionResult> updateActivity(UpdateActivityMasterRequest request)
        {
            var validationResult = await updateValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await activityMaster.updateActivityAsync(request);
                return Ok("Activity updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating : {ex.Message}");
            }
        }
    }
}