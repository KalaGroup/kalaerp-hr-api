using FluentValidation;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.DepartmentBudget;
using KalaGenset.ERP.HR.Core.Request.LeaveTypeMaster;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace KalaGenset.ERP.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypeMasterController : BaseController
    {
        private readonly ILeaveTypeMaster _LeaveTypeMaster;
        private readonly IValidator<InsertleaveTypeMasterRequest> _insertLeaveTypeValidator;
         private readonly IValidator<UpdateLeaveTypeMasterRequest> _updateLeaveTypeValidator;

        public LeaveTypeMasterController(ILeaveTypeMaster leavetype, IValidator<InsertleaveTypeMasterRequest> Insertleavetypevalidator,IValidator<UpdateLeaveTypeMasterRequest> UpdateleavetypeValidator)
        {
            _LeaveTypeMaster = leavetype;
            _insertLeaveTypeValidator = Insertleavetypevalidator;
            _updateLeaveTypeValidator = UpdateleavetypeValidator; // Corrected assignment here
        }
    
    [HttpPost("InsertleaveType")]
        public async Task<IActionResult> InsertLeaveType(InsertleaveTypeMasterRequest InsertleaveTypeMasterRequest)
        {
            var validationResult = await _insertLeaveTypeValidator.ValidateAsync(InsertleaveTypeMasterRequest);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await _LeaveTypeMaster.AddLeaveTypeAsync(InsertleaveTypeMasterRequest);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding leave Type: {ex.Message}");
            }
        }
        [HttpGet("GetLeaveLeaveByID/{Id}")]
        public async Task<IActionResult> GetDepartmentBudgetByID(int Id)
        {
            try
            {
                var result = await _LeaveTypeMaster.GetLeaveTypeById(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Id is Invalid : {ex.Message}");
            }
        }
        [HttpGet("GetAllLeaveType")]
        public async Task<IActionResult> GetAllLeaveType()
        {
            var LeaveTypeMasters = await _LeaveTypeMaster.GetLeaveTypeDetailsAsync();
            return Ok(LeaveTypeMasters);

        }
        [HttpPut("UpdateLeaveType")]
        public async Task<IActionResult> UpdateLeaveType([FromBody] UpdateLeaveTypeMasterRequest request)
        {
            var validationResult = await _updateLeaveTypeValidator.ValidateAsync(request); // Corrected validator usage here
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await _LeaveTypeMaster.UpdateLeaveTypeAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating Leave Type: {ex.Message}");
            }
        }

        [HttpDelete("DeleteLeaveType/{Id}")]
        public async Task<IActionResult> DeleteLeaveType (int Id)
        {
            try
            {
                await _LeaveTypeMaster.DeleteLeaveTypeAsync(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting Leave Type: {ex.Message}");
            }
        }
    }
}
