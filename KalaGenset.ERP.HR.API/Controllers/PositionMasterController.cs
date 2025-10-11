using FluentValidation;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request;
using KalaGenset.ERP.HR.Core.Request.Department;
using KalaGenset.ERP.HR.Core.Request.PositionMaster;
using KalaGenset.ERP.HR.Core.Request.Workstation;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KalaGenset.ERP.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionMasterController : BaseController
    {
        private readonly IPositionMaster _position;
        private readonly IValidator<InsertPositionRequest> _insertValidator;
        private readonly IValidator<UpdatePositionRequest> _updateValidator;

        public PositionMasterController(IPositionMaster position, IValidator<InsertPositionRequest> Insertvalidator, IValidator<UpdatePositionRequest> UpdateValidator)
        {
            _position = position;
            _insertValidator = Insertvalidator;
            _updateValidator = UpdateValidator;

        }


        [HttpPost("insertPositionmaster")]
        public async Task<IActionResult> InsertPosition(InsertPositionRequest Request)
        {
            var validationResult = await _insertValidator.ValidateAsync(Request);
            if (!validationResult.IsValid)

            {
                var errors = validationResult.Errors
               .Select(e => new { field = e.PropertyName, message = e.ErrorMessage })
               .FirstOrDefault();
                return BadRequest(errors);
            }
            try
            {
                await _position.AddPositionAsync(Request);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding Petrol Allowance Type: {ex.Message}");
            }

        }


        /// <returns></returns>
        [HttpGet("GetAllPosition")]
        public async Task<IActionResult> GetAllPosition()
        {
            try
            {
                var position = await _position.GetPositionDetailsAsync();
                return Ok(position);
            }
            catch
            {
                throw;
            }
        }

        [HttpPut("updatePosition")]
        public async Task<IActionResult> updatePosition(UpdatePositionRequest request)
        {
            var validationResult = await _updateValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                .Select(e => new { field = e.PropertyName, message = e.ErrorMessage })
                .FirstOrDefault();
                return BadRequest(errors);
            }
            try
            {
                await _position.UpdatePositionAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating department: {ex.Message}");
            }
        }

        [HttpDelete("deletePosition/{PositionMasterId}")]
        public async Task<IActionResult> DeleteDepartment(int PositionMasterId)
        {
            try
            {
                await _position.DeletePositionAsync(PositionMasterId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while Soft-Deleting department: {ex.Message}");
            }
        }

        [HttpGet("getallpositiondetailsbymasterid/{PositionMasterId}")]
        public async Task<IActionResult> Getpositiondetails(int PositionMasterId)
        {
            try
            {
                var position = await _position.GetpositionDetailsByMasterId(PositionMasterId);
                if (position == null)
                { 
                    return NotFound("Position not found.");
                }
                return Ok(position);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving Position: {ex.Message}");
            }
        }


    }
}
