using FluentValidation;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request;
using KalaGenset.ERP.HR.Core.Request.LocationRequest;
using KalaGenset.ERP.HR.Core.Request.QualificationRequest;
using KalaGenset.ERP.HR.Core.Request.ShiftMaster;
using KalaGenset.ERP.HR.Core.Validation.LocationValidator;
using KalaGenset.ERP.HR.Core.Validation.QualificationValidator;
using KalaGenset.ERP.HR.Core.Validation.ShiftMasterValidation;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace KalaGenset.ERP.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftMasterController : BaseController
    {
        private readonly IShiftMaster _shiftMaster;
        private readonly IValidator<InsertShiftMasterRequest> _insertshiftValidator;
        private readonly IValidator<UpdateShiftMasterRequest> _updateshiftValidator; // Corrected type here

        public ShiftMasterController(IShiftMaster shiftMaster, IValidator<InsertShiftMasterRequest> Insertshiftvalidator, IValidator<UpdateShiftMasterRequest> UpdateshiftValidator)
        {
            _shiftMaster = shiftMaster;
            _insertshiftValidator = Insertshiftvalidator;
            _updateshiftValidator = UpdateshiftValidator; // Corrected assignment here
        }

        /// <summary>
        /// insert shift master
        /// </summary>
        /// <param name="insertshiftRequest"></param>
        /// <returns></returns>
        [HttpPost("insertshift")]
        public async Task<IActionResult> InsertShiftType(InsertShiftMasterRequest InsertShiftMasterRequest)
        {
            var validationResult = await _insertshiftValidator.ValidateAsync(InsertShiftMasterRequest);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await _shiftMaster.AddShiftAsync(InsertShiftMasterRequest);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding  Shift Type: {ex.Message}");
            }
        }

        /// <summary>
        /// Get Shift By ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("GetShiftByID/{Id}")]
        public async Task<IActionResult> GetShiftByID(int Id)
        {
            try
            {
                var result = await _shiftMaster.GetShiftByIDAsync(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Id is Invalid : {ex.Message}");
            }
        }

        /// <summary>
        /// Get All Shift
        /// </summary>
        /// <returns></returns>

        [HttpGet("GetAllShift")]
        public async Task<IActionResult> GetAllShift()
        {
            var shifts = await _shiftMaster.GetShiftDetailsAsync();
            return Ok(shifts);
        }
        /// <summary>
        /// Update Shift
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>

        [HttpPut("UpdateShift")]
        public async Task<IActionResult> UpdateShift([FromBody] UpdateShiftMasterRequest request)
        {
            var validationResult = await _updateshiftValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await _shiftMaster.UpdateShiftAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating Shift: {ex.Message}");
            }
        }

        /// <summary>
        /// Delete Shift
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>

        [HttpDelete("DeleteShift/{Id}")]
        public async Task<IActionResult> DeleteShift(int Id)
        {
            try
            {
                await _shiftMaster.DeleteshiftAsync(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting Shift: {ex.Message}");
            }
        }
    }
}