using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.Facility;
using KalaGenset.ERP.HR.Core.Request.GradeFacilityAssignment;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KalaGenset.ERP.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeFacilityAssignmentController : ControllerBase
    {
        private readonly IGradeFacilityAssignment _iGradeFacilityAssignment;

        public GradeFacilityAssignmentController(IGradeFacilityAssignment iGradeFacilityAssignment)
        {
            _iGradeFacilityAssignment = iGradeFacilityAssignment;
        }

        /// <summary>
        /// To Insert New Grade Facility Assignment
        /// </summary>
        /// <param name="insertGradeFacilityAssignmentRequest"></param>
        /// <returns></returns>
        [HttpPost("addgradefacilityassignment")]
        public async Task<IActionResult> AddGradeFacilityAssignmentAsync([FromBody] InsertGradeFacilityAssignmentRequest insertGradeFacilityAssignmentRequest)
        {
            //var validationResult = await _validator.ValidateAsync(insertfacilityrequest);
            //if (!validationResult.IsValid)
            //{
            //    return BadRequest(validationResult.Errors);
            //}
            try
            {
                await _iGradeFacilityAssignment.AddGradeFacilityAssignmentAsync(insertGradeFacilityAssignmentRequest);
                return Ok("Grade Facility added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding Grade Facility: {ex.Message}");
            }
        }

        /// <summary>
        /// To Get All Grade Facility Assignment
        /// </summary>
        /// <returns></returns>
        [HttpGet("getallgradeassignmentFacility")]
        public async Task<IActionResult> GetAllGradeFacilityAssignment()
        {
            var gradeAssignfacility = await _iGradeFacilityAssignment.GetAllGradeFacilityAssignmentsAsync();
            return Ok(gradeAssignfacility);
        }

        /// <summary>
        /// To Update Grade Facility Assignment
        /// </summary>
        /// <param name="updateGradeFacilityAssignmentRequest"></param>
        /// <returns></returns>
        [HttpPut("updategradefacilityassignment")]
        public async Task<IActionResult> UpdateGradeFacilityAssignmentAsync([FromBody] UpdateGradeFacilityAssignmentRequest updateGradeFacilityAssignmentRequest)
        {
            //var validationResult = await _updatevalidator.ValidateAsync(updateFacilityRequest);
            //if (!validationResult.IsValid)
            //{
            //    return BadRequest(validationResult.Errors);
            //}
            try
            {
                await _iGradeFacilityAssignment.UpdateGradeFacilityAssignmentAsync(updateGradeFacilityAssignmentRequest);
                return Ok("Grade Facility updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating Grade Facility: {ex.Message}");
            }
        }

        /// <summary>
        /// To get garde Facility by GradeFacilityAssignmentid
        /// </summary>
        /// <param name="GradeAssignmentfacilityId"></param>
        /// <returns></returns>
        [HttpGet("getgradefacilityassignmentsbyid")]
        public async Task<IActionResult?> GetGradeFacilityAssignmentsByIdsync(int GradeAssignmentfacilityId)
        {
            var facility = await _iGradeFacilityAssignment.GetGradeFacilityAssignmentsByIdAsync(GradeAssignmentfacilityId);
            return Ok(facility);
        }

        /// <summary>
        /// Delete GradeFacility By FacilityId
        /// </summary>
        /// <param name="FacilityId"></param>
        /// <returns></returns>
        [HttpDelete("deletegradefacility")]
        public async Task<IActionResult> DeleteGradeFacility(int gradeFacilityId)
        {
            try
            {
                await _iGradeFacilityAssignment.DeleteGradeFacilityAsync(gradeFacilityId);
                return Ok("Grade Facility Id Softly Deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating Grade Facility: {ex.Message}");
            }
        }

    }
}
