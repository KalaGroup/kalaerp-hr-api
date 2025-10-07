using FluentValidation;
using KalaGenset.ERP.HR.Data.Models;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.Grade;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KalaGenset.ERP.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeMasterController : BaseController
    {
        private readonly IGradeMaster _gradeMaster;
        private readonly IValidator<InsertGradeRequest> _insertGradeValidator;
        private readonly IValidator<UpdateGradeDetailsRequest> _updateGradeValidator;
        public GradeMasterController(IGradeMaster GradeMaster, IValidator<InsertGradeRequest> InsertGradeValidator, IValidator<UpdateGradeDetailsRequest> UpdateGradeValidator)
        {
            _gradeMaster = GradeMaster;
            _insertGradeValidator = InsertGradeValidator;
            _updateGradeValidator = UpdateGradeValidator;
        }
        /// <summary>
        /// Creates a new Grade in the system.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("creategrade")]
        public async Task<IActionResult> CreateGrade([FromBody] InsertGradeRequest request)
        {
            var validationResult = await _insertGradeValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                // Return a structured error response
                var errors = validationResult.Errors
                    .Select(e => new { field = e.PropertyName, message = e.ErrorMessage })
                    .FirstOrDefault();

                return BadRequest(new
                {
                    Message = "Validation failed.",
                    Errors = errors
                });
            }
            try
            {
                await _gradeMaster.AddGradeDetailsAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding grade: {ex.Message}");
            }
        }
        /// <summary>
        /// Updates an existing Grade in the system.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("updategrade")]
        public async Task<IActionResult> UpdateGrade(UpdateGradeDetailsRequest request)
        {
            var validationResult = await _updateGradeValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .Select(e => new { field = e.PropertyName, message = e.ErrorMessage })
                    .FirstOrDefault();

                return BadRequest(errors);
            }
            try
            {
                await _gradeMaster.UpdateGradeDetailsAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating grade: {ex.Message}");
            }
        }
        /// <summary>
        /// Retrieves all grades from the system.
        /// </summary>
        /// <returns></returns>
        [HttpGet("getallgrades")]
        public async Task<IActionResult> GetAllGrades()
        {
            var grades = await _gradeMaster.GetGradeDetailsAsync();
            return Ok(grades);
        }
        /// <summary>
        /// Retrieves details of a specific grade by its ID.
        /// </summary>
        /// <param name="GradeId"></param>
        /// <returns></returns>
        [HttpGet("getgradebyid/{GradeId}")]
        public async Task<IActionResult> GetGradeDetails(int GradeId)
        {
            var result = await _gradeMaster.GetGradeById(GradeId);
            return Ok(result);
        }
        /// <summary>
        /// Soft-deletes a grade by setting its GradeIsActive flag to false.
        /// </summary>
        /// <param name="GradeId"></param>
        /// <returns></returns>
        [HttpDelete("deletegrade/{GradeId}")]
        public async Task<IActionResult> DeleteGradeAndDetails(int GradeId)
        {
            try
            {
                await _gradeMaster.DeleteGradeDetailsAsync(GradeId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while Soft-Deleting grade: {ex.Message}");
            }
        }
        /// <summary>
        /// Retrieves a list of active grades with only their IDs and Names.
        /// </summary>
        /// <returns></returns>
        [HttpGet("getgradeidandname")]
        public async Task<IActionResult> GetGradeIdAndName()
        {
            try
            {
                var grades = await _gradeMaster.GetGradeIdAndNameFromDB();
                return Ok(grades);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching grade IDs and names: {ex.Message}");
            }
        }

        [HttpGet("getgradedesignationandfacility")]
        public async Task<IActionResult> GetGradeDesignationAndFacility()
        {
            try
            {
                var gradeDesignationAndFacility = await _gradeMaster.GetAllGradesWithDetailsAsync();
                return Ok(gradeDesignationAndFacility);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"An error occurred while fetching grade IDs and names: {ex.Message}");
            }
        }

    }
}
