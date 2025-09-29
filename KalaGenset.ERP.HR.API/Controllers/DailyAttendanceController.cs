using FluentValidation;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.ActivityMaster;
using KalaGenset.ERP.HR.Core.Request.DailyAttendance;
using KalaGenset.ERP.HR.Core.Services;
using KalaGenset.ERP.HR.Core.Validation.DailyAttendance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KalaGenset.ERP.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyAttendanceController : BaseController
    {
        private readonly IDailyAttendance dailyAttendance;
        private readonly IValidator<InsertDailyAttendanceRequest> validator;
        private readonly IValidator<UpdateDailyAttendanceRequest> updateValidator;
        public DailyAttendanceController(IDailyAttendance dailyAttendance,
                                         IValidator<InsertDailyAttendanceRequest> validator,
                                         IValidator<UpdateDailyAttendanceRequest> updateValidator)
        {
            this.dailyAttendance = dailyAttendance;
            this.validator = validator;
            this.updateValidator = updateValidator;
        }
        [HttpPost("InsertDailyAttendance")]
        public async Task<IActionResult> InsertDailyAttendance(InsertDailyAttendanceRequest request)
        {
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            try
            {
                await dailyAttendance.AddDailyAttendanceAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding daily attendance: {ex.Message}");
            }
        }

        [HttpGet("GetDailyAttendanceByID/{Id}")]
        public async Task<IActionResult> GetDailyAttendanceByID(int Id)
        {
            try
            {
                var result = await dailyAttendance.GetDailyAttendancenById(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Id is Invalid : {ex.Message}");
            }
        }

        [HttpGet("GetAllDailyAttendance")]
        public async Task<IActionResult> GetAllDailyAttendance()
        {
            var dailyAttendances = await dailyAttendance.GetAllDailyAttendanceAsync();
            return Ok(dailyAttendances);
        }

        [HttpPut("UpdateDailyAttendance")]
        public async Task<IActionResult> UpdateDailyAttendance([FromBody] UpdateDailyAttendanceRequest request)
        {
            var validationResult = await updateValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            try
            {
                await dailyAttendance.UpdateDailyAttendanceAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating Daily Attendance: {ex.Message}");
            }
        }

        [HttpDelete("DeleteDailyAttendance/{Id}")]
        public async Task<IActionResult> DeleteDailyAttendance(int Id)
        {
            try
            {
                await dailyAttendance.DeleteDailyAttendanceAsync(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting Daily Attendance: {ex.Message}");
            }
        }

        [HttpGet("GetEmployeNameAndCompanyName")]
        public async Task<IActionResult> GetEmployeNameAndCompanyName()
        {
            try
            {
                var result = await dailyAttendance.GetEmployeeIdAndNameAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving data: {ex.Message}");
            }
        }

    }
}
