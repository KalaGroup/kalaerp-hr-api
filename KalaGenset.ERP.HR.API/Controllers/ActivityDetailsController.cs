using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.ActivityDetails;
using KalaGenset.ERP.HR.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace KalaGenset.ERP.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityDetailsController : BaseController
    {
        private readonly IActivityDetails activityDetails;
        public ActivityDetailsController(IActivityDetails activityDetails)
        {
            this.activityDetails = activityDetails;
        }
        /// <summary>
        /// add add activity details
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("addactivitydetails")]
        public async Task<IActionResult> AddCompanyAsync([FromBody] InsertActivityDetailsRequest request)
        {
            try
            {
                await activityDetails.AddActivityDetailAsync(request);
                return Ok("ActivityDeatils added successfully.");
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
        /// <summary>
        /// get activity detail
        /// </summary>
        /// <returns></returns>
        [HttpGet("getactivitydetail")]
        public async Task<IActionResult> GetAllActivity()
        {
            try
            {
                var activityDetail = await activityDetails.GetAllActivityDetailAsync();
                if (activityDetail == null || !activityDetail.Any())
                {
                    return NotFound("No activities found.");
                }
                return Ok(activityDetail);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
        /// <summary>
        /// get activity details by id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("getactivitydetailsbyid/{Id}")]
        public async Task<IActionResult> getbyid(int Id)
        {
            var result = await activityDetails.GetActivityDetailByID(Id);
            return Ok(result);
        }
        /// <summary>
        /// delete activity details
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("deleteactivitydetails/{Id}")]
        public async Task<IActionResult> DeleteActivity(int Id)
        {
            try
            {
                await activityDetails.DeleteActivityDetailAsync(Id);
                return Ok("activity soft-deleted successfully ");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while Soft-Deleting : {ex.Message}");
            }
        }
        /// <summary>
        /// update activity detail
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("updateactivitydetail")]
        public async Task<IActionResult> updateActivity(UpdateActivityDetailsRequest request)
        {
            try
            {
                await activityDetails.updateActivityDetailAsync(request);
                return Ok("Activity updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating : {ex.Message}");
            }
        }

        [HttpGet("getActivitydetails/{gradeId}/{designationId}/{divisionId}")]
        public async Task<IActionResult> GetActivityDetailsByCombination(int gradeId, int designationId, int divisionId)
        {
            try
            {
                var details = await activityDetails.GetActivityDetailsByCombination(gradeId, designationId, divisionId);
                return Ok(details);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error fetching Activity details: {ex.Message}");
            }
        }

    }
}
