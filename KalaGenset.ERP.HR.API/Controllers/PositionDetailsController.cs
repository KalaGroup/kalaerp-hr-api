using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.PositionDetails;
using KalaGenset.ERP.HR.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace KalaGenset.ERP.HR.API.Controllers
{
    /// <summary>
    /// controller for managing position details in the system.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class PositionDetailController : BaseController
    {
        private readonly IPositionDetails positionDetailService;

        public PositionDetailController(IPositionDetails positionDetailService)
        {
            this.positionDetailService = positionDetailService;
        }

        /// <summary>
        /// adds a new position detail to the system based on the provided request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("addpositiondetail")]
        public async Task<IActionResult> AddPositionDetail([FromBody] InsertPositionDetailRequest request)
        {
            try
            {
                await positionDetailService.AddPositionDetailAsync(request);
                return Ok("Position Detail Added successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding position detail: {ex.Message}");
            }
        }

        /// <summary>
        /// gets all position details from the system.
        /// </summary>
        /// <returns></returns>
        [HttpGet("getallpositiondetails")]
        public async Task<IActionResult> GetAllPositionDetails()
        {
            try
            {
                var positionDetails = await positionDetailService.GetAllPositionDetailsAsync();
                return Ok(positionDetails);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving position details: {ex.Message}");
            }
        }

        /// <summary>
        /// gets position detail by ID from the system.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("getpositiondetailbyid/{id}")]
        public async Task<IActionResult> GetPositionDetailById(int id)
        {
            try
            {
                var positionDetail = await positionDetailService.GetPositionDetailById(id);
                if (positionDetail == null)
                {
                    return NotFound($"Position Detail with ID {id} not found.");
                }
                return Ok(positionDetail);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving position detail: {ex.Message}");
            }
        }

        /// <summary>
        /// updates an existing position detail in the system based on the provided request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("updatepositiondetail")]
        public async Task<IActionResult> UpdatePositionDetail([FromBody] UpdatePositionDetailRequest request)
        {
            try
            {
                await positionDetailService.UpdatePositionDetailAsync(request);
                return Ok("Position Detail Updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating position detail: {ex.Message}");
            }
        }

        /// <summary>
        /// deletes a position detail from the system based on its unique identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("deletepositiondetail/{id}")]
        public async Task<IActionResult> DeletePositionDetail(int id)
        {
            try
            {
                await positionDetailService.DeletePositionDetailAsync(id);
                return Ok("Position Detail Deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting position detail: {ex.Message}");
            }
        }

        /// <summary>
        /// gets position details by grade, designation and division combination.
        /// </summary>
        /// <param name="gradeId"></param>
        /// <param name="designationId"></param>
        /// <param name="divisionId"></param>
        /// <returns></returns>
        [HttpGet("getpositiondetails/{gradeId}/{designationId}/{divisionId}")]
        public async Task<IActionResult> GetPositionDetailsByCombination(int gradeId, int designationId, int divisionId)
        {
            try
            {
                var details = await positionDetailService.GetPositionDetailsByCombination(gradeId, designationId, divisionId);
                return Ok(details);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error fetching position details: {ex.Message}");
            }
        }
    }

}
