using FluentValidation;
using KalaGenset.ERP.HR.Data.Models;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.ClassOfTravel;
using KalaGenset.ERP.HR.Core.Request.Grade;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KalaGenset.ERP.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassOfTravelMasterController : ControllerBase
    {
        private readonly IClassOfTravelMaster _classOfTravelMaster;
        private readonly IValidator<InsertClassOfTravelRequest> _insertClassOfTravelValidator;
        private readonly IValidator<UpdateClassOfTravelRequest> _updateClassOfTravelValidator;
        public ClassOfTravelMasterController(IClassOfTravelMaster ClassOfTravelMaster, IValidator<InsertClassOfTravelRequest> InsertClassOfTravelValidator, IValidator<UpdateClassOfTravelRequest> UpdateClassOfTravelValidator)
        {
            _classOfTravelMaster = ClassOfTravelMaster;
            _insertClassOfTravelValidator = InsertClassOfTravelValidator;
            _updateClassOfTravelValidator = UpdateClassOfTravelValidator;
        }
        /// <summary>
        /// Creates a new ClassOfTravel in the system.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("createclassOfTravel")]
        public async Task<IActionResult> CreateClassOfTravel([FromBody] InsertClassOfTravelRequest request)
        {
            var validationResult = await _insertClassOfTravelValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await _classOfTravelMaster.AddClassOfTravelAsync(request);
                return Ok("ClassOfTravel added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding ClassOfTravel: {ex.Message}");
            }
        }
        /// <summary>
        /// Updates an existing ClassOfTravel in the system.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("updateclassOfTravel")]
        public async Task<IActionResult> UpdateClassOfTravel(UpdateClassOfTravelRequest request)
        {
            var validationResult = await _updateClassOfTravelValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await _classOfTravelMaster.UpdateClassOfTravelAsync(request);
                return Ok("ClassOfTravel updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating ClassOfTravel: {ex.Message}");
            }
        }
        /// <summary>
        /// Retrieves all ClassOfTravels from the system.
        /// </summary>
        /// <returns></returns>
        [HttpGet("getallClassOfTravels")]
        public async Task<IActionResult> GetAllClassOfTravels()
        {
            var classOfTravels = await _classOfTravelMaster.GetClassOfTravelDetailsAsync();
            return Ok(classOfTravels);
        }
        /// <summary>
        /// Retrieves details of a specific ClassOfTravel by its ID.
        /// </summary>
        /// <param name="ClassOfTravelId"></param>
        /// <returns></returns>
        [HttpGet("getclassoftravelbyid/{ClassOfTravelId}")]
        public async Task<IActionResult> GetClassOfTravelDetails(int ClassOfTravelId)
        {
            var result = await _classOfTravelMaster.GetClassOfTravelById(ClassOfTravelId);
            return Ok(result);
        }
        /// <summary>
        /// Soft-deletes a ClassOfTravel by setting its IsActive flag to false.
        /// </summary>
        /// <param name="ClassOfTravelId"></param>
        /// <returns></returns>
        [HttpDelete("deleteclassoftravel/{ClassOfTravelId}")]
        public async Task<IActionResult> DeleteClassOfTravel(int ClassOfTravelId)
        {
            try
            {
                await _classOfTravelMaster.DeleteClassOfTravelAsync(ClassOfTravelId);
                return Ok("ClassOfTravel soft-deleted successfully (ClassOfTravelIsActive = false).");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while Soft-Deleting ClassOfTravel: {ex.Message}");
            }
        }

    }
}
