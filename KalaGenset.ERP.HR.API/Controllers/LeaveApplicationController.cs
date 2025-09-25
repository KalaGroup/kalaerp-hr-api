using FluentValidation;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.HolidayMaster;
using KalaGenset.ERP.HR.Core.Request.LeaveApplication;
using KalaGenset.ERP.HR.Core.Services;
using KalaGenset.ERP.HR.Core.Validation.LeaveApplication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KalaGenset.ERP.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveApplicationController : ControllerBase
    {
        private readonly ILeaveApplication leaveApplication;
        private readonly IValidator<InsertLeaveApplicationRequest> _validator;
        private readonly IValidator<UpdateLeaveApplicationRequest> _updateValidator;
        public LeaveApplicationController(ILeaveApplication leaveApplication, IValidator<InsertLeaveApplicationRequest> validator, IValidator<UpdateLeaveApplicationRequest> updatevalidator)
        {
          this.  leaveApplication = leaveApplication;
            _validator = validator;
            _updateValidator = updatevalidator;
        }


        [HttpPost("InsertLeaveApplication")]
        public async Task<IActionResult> InsertLeaveApplication(InsertLeaveApplicationRequest request)
        {
            // Validate the request first
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            try
            {
                // Call the service to add the leave application
                await leaveApplication.AddLeaveApplicationAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding Leave Application: {ex.Message}");
            }
        }

        [HttpGet("GetLeaveApplicationByID/{Id}")]
        public async Task<IActionResult> GetLeaveApplicationByID(int Id)
        {
            try
            {
                var result = await leaveApplication.GetLeaveApplicationById(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Id is Invalid: {ex.Message}");
            }
        }

        [HttpGet("GetAllLeaveApplications")]
        public async Task<IActionResult> GetAllLeaveApplications()
        {
            var leaveApplications = await leaveApplication.GetAllLeaveApplicationAsync();
            return Ok(leaveApplications);
        }

        [HttpPut("UpdateLeaveApplication")]
        public async Task<IActionResult> UpdateLeaveApplication([FromBody] UpdateLeaveApplicationRequest request)
        {
            var validationResult = await _updateValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            try
            {
                await leaveApplication.UpdateLeaveApplicationAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating Leave Application: {ex.Message}");
            }
        }

        [HttpDelete("DeleteLeaveApplication/{Id}")]
        public async Task<IActionResult> DeleteLeaveApplication(int Id)
        {
            try
            {
                await leaveApplication.DeleteLeaveApplicationAsync(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting Leave Application: {ex.Message}");
            }
        }


    }
}
