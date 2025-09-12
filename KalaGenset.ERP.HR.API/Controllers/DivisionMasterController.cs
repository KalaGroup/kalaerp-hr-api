using FluentValidation;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.DivisionMaster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KalaGenset.ERP.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisionMasterController : ControllerBase
    {
        private readonly IDivisionMaster _Divisionmaster;
        private readonly IValidator<InsertDivisionMasterRequest> _insertDivisionValidator;
        private readonly IValidator<UpdateDivisionMasterRequest> _updateDivisionValidator;

        public DivisionMasterController(IDivisionMaster Divisionmaster, IValidator<InsertDivisionMasterRequest> InsertDivisionvalidator, IValidator<UpdateDivisionMasterRequest> UpdateDivisionValidator)
        {
            _Divisionmaster = Divisionmaster;
            _insertDivisionValidator = InsertDivisionvalidator;
            _updateDivisionValidator = UpdateDivisionValidator;

        }

        /// <summary>
        /// Creates a new Division.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("CreateDivision")]
        public async Task<IActionResult> CreateDivision([FromBody] InsertDivisionMasterRequest request)
        {
            var validationResult = await _insertDivisionValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            try
            {
                await _Divisionmaster.AddDivisionAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding Location: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates an existing Division.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("UpdateDivision")]
        public async Task<IActionResult> UpdateDivision([FromBody] UpdateDivisionMasterRequest request)
        {
            var validationResult = await _updateDivisionValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await _Divisionmaster.UpdateDivisionAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating Division: {ex.Message}");
            }

        }
        /// <summary>
        /// Get All Division Details
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllDivision")]
        public async Task<IActionResult> GetAllDivision()
        {
            try
            {
                var Divisionmaster = await _Divisionmaster.GetDivisionDetailsAsync();
                return Ok(Divisionmaster);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Deletes a Division by its ID.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteDivision/{DivisionId}")]
        public async Task<IActionResult> DeleteDivision(int DivisionId)
        {
            try
            {
                await _Divisionmaster.DeleteDivisionAsync(DivisionId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting Division: {ex.Message}");
            }
        }
        /// <summary>
        /// Retrieves a Division by its ID.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("GetDivisionByID/{Id}")]

        public async Task<IActionResult> GetDivisionByID(int Id)
        {
            try
            {
                var result = await _Divisionmaster.GetDivisionByID(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Id is Invalid : {ex.Message}");
            }
        }

        [HttpGet("getdivisionidandname")]
        public async Task<IActionResult> GetDivisionIdAndName()
        {
            try
            {
                var result = await _Divisionmaster.GetDivisionIdAndNameFromDB();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving Division ID and Name: {ex.Message}");
            }
        }
    }
}
