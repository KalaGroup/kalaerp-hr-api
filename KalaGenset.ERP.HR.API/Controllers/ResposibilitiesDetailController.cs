using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.ResposibilitiesDetail;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KalaGenset.ERP.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResposibilitiesDetailController : ControllerBase
    {
        private readonly IResposibilitiesDetail resposibilitiesDetail;
        public ResposibilitiesDetailController(IResposibilitiesDetail resposibilitiesDetail)
        {
            this.resposibilitiesDetail = resposibilitiesDetail;
        }
        ///addresponsibilitiesdetail add record 
        [HttpPost("addresponsibilitiesdetail")]
        public async Task<IActionResult> AddResponsibilitiesDetailAsync([FromBody] InsertResposibilitiesDetailrequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request data.");
            }
            try
            {
                await resposibilitiesDetail.AddResposibilitiesDetailAsync(request);
                return Ok("Responsibility detail added successfully.");
            }
            catch (Exception ex)
            {
                // You can log the exception here if needed
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error adding responsibility detail: {ex.Message}");
            }
        }
        // getresponsibilitiesdetail get all record
        [HttpGet("getresponsibilitiesdetail")]
        public async Task<IActionResult> GetResponsibilitiesDetail()
        {
            try
            {
                var resposibilities = await resposibilitiesDetail.GetResposibilitiesDetailAsync();
                return Ok(resposibilities);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving resposibilities: {ex.Message}");
            }
        }
        // getresponsibilitiesdetailbyid get record by id
        [HttpDelete("deleteresponsibilitiesdetail/{id}")]
        public async Task<IActionResult> DeleteResponsibilitiesDetailAsync(int id)
        {
            try
            {
                await resposibilitiesDetail.DeleteResposibilitiesDetailAsync(id);
                return Ok("Responsibility detail deleted successfully.");
            }
            catch (Exception ex)
            {
                // You can log the exception here if needed
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting responsibility detail: {ex.Message}");
            }
        }
        // getresponsibilitiesdetailbyid get record by id
        [HttpGet("getresponsibilitiesdetailbyid/{id}")]
        public async Task<IActionResult> GetResponsibilitiesDetailByIdAsync(int id)
        {

            try
            {
                var resposibility = await resposibilitiesDetail.GetResposibilitiesDetailByIdAsync(id);
                if (resposibility == null)
                {
                    return NotFound("Resposibility not found.");
                }
                return Ok(resposibility);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving resposibility: {ex.Message}");
            }
        }
        // update responsibilities detail
        [HttpPut("updateresponsibilitiesdetail")]
        public async Task<IActionResult> UpdateResponsibilitiesDetailAsync([FromBody] UpdateResposibilitiesDetailRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request data.");
            }
            try
            {
                await resposibilitiesDetail.UpdateResposibilitiesDetailAsync(request);
                return Ok("Responsibility detail updated successfully.");
            }
            catch (Exception ex)
            {
                // You can log the exception here if needed
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating responsibility detail: {ex.Message}");
            }
        }
    }
}
