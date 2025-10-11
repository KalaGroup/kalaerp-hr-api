using FluentValidation;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.GatePassType;
using KalaGenset.ERP.HR.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace KalaGenset.ERP.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GatePassTypeController : ControllerBase
    {
        private readonly IGatePassType _gatePassTypeService;
        private readonly IValidator<InsertGatePassTypeRequest> _insertGatePassTypeValidator;
        private readonly IValidator<UpdateGatePassTypeRequest> _updateGatePassTypeValidator;

        public GatePassTypeController(IGatePassType gatePassTypeService,IValidator<InsertGatePassTypeRequest> insertGatePassTypeValidator,IValidator<UpdateGatePassTypeRequest> updateGatePassTypeValidator)
        {
            _gatePassTypeService = gatePassTypeService;
            _insertGatePassTypeValidator = insertGatePassTypeValidator;
            _updateGatePassTypeValidator = updateGatePassTypeValidator;
        }

        /// <summary>
        /// Creates a new GatePassType.
        /// </summary>
        [HttpPost("creategatepasstype")]
        public async Task<IActionResult> CreateGatePassType([FromBody] InsertGatePassTypeRequest request)
        {
            var validationResult = await _insertGatePassTypeValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                .Select(e => new { field = e.PropertyName, message = e.ErrorMessage })
                .FirstOrDefault();
                return BadRequest(errors);
            }

            try
            {
                await _gatePassTypeService.AddGatePassTypeAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while creating GatePassType: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates an existing GatePassType.
        /// </summary>
        [HttpPut("updategatepasstype")]
        public async Task<IActionResult> UpdateGatePassType([FromBody] UpdateGatePassTypeRequest request)
        {
            var validationResult = await _updateGatePassTypeValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                .Select(e => new { field = e.PropertyName, message = e.ErrorMessage })
                .FirstOrDefault();
                return BadRequest(errors);
            }

            try
            {
                await _gatePassTypeService.UpdateGatePassTypeAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating GatePassType: {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves all active GatePassTypes.
        /// </summary>
        [HttpGet("getallgatepasstype")]
        public async Task<IActionResult> GetAllGatePassTypes()
       {
            try
            {
                var gatePassTypes = await _gatePassTypeService.GetGatePassTypeDetailsAsync();
                return Ok(gatePassTypes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving GatePassTypes: {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves a GatePassType by ID.
        /// </summary>
        [HttpGet("getgatepasstypebyid/{id}")]
        public async Task<IActionResult> GetGatePassTypeByID(int id)
        {
            try
            {
                var gatePassType = await _gatePassTypeService.GetGatePassTypeByIdAsync(id);
                if (gatePassType == null)
                    return NotFound();

                return Ok(gatePassType);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Invalid Id: {ex.Message}");
            }
        }

        /// <summary>
        /// Deletes (soft deletes) a GatePassType by ID.
        /// </summary>
        [HttpDelete("deletegatepasstype/{id}")]
        public async Task<IActionResult> DeleteGatePassType(int id)
        {
            try
            {
                await _gatePassTypeService.DeleteGatePassTypeAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting GatePassType: {ex.Message}");
            }
        }
    }
}
