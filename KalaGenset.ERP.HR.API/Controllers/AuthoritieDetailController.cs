using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.AuthoritiesDetail;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace KalaGenset.ERP.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthoritieDetailController : ControllerBase
    {
        /// <summary>
        /// service for managing authorities details in the system.
        /// </summary>
        private readonly IAuthoritiesDetail authoritiesDetailService;
        public AuthoritieDetailController(IAuthoritiesDetail authoritiesDetailService)
        {
            this.authoritiesDetailService = authoritiesDetailService;
        }
        /// <summary>
        /// adds a new authorities detail to the system based on the provided request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("addauthoritiesdetail")]
        public async Task<IActionResult> AddAuthoritiesDetail([FromBody] InsertAuthoritiesDetailRequest request)
        {
            try
            {
                await authoritiesDetailService.AddAuthoritiesDetailAsync(request);
                return Ok("Authorities Detail Added successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding authorities detail: {ex.Message}");
            }
        }
        /// <summary>
        /// gets all authorities details from the system.
        /// </summary>
        /// <returns></returns>
        [HttpGet("getallauthoritiesdetails")]
        public async Task<IActionResult> GetAllAuthoritiesDetails()
        {
            try
            {
                var authoritiesDetails = await authoritiesDetailService.GetAllAuthoritiesDetailsAsync();
                return Ok(authoritiesDetails);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving authorities details: {ex.Message}");
            }
        }
        /// <summary>
        /// gets authorities detail by ID from the system.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("getauthoritiesdetailbyid/{id}")]
        public async Task<IActionResult> GetAuthoritiesDetailByID(int id)
        {
            try
            {
                var authoritiesDetail = await authoritiesDetailService.GetAuthoritiesDetailByID(id);
                if (authoritiesDetail == null)
                {
                    return NotFound($"Authorities Detail with ID {id} not found.");
                }
                return Ok(authoritiesDetail);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving authorities detail: {ex.Message}");
            }
        }
        /// <summary>
        /// updates an existing authorities detail in the system based on the provided request.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("updateauthoritiesdetail")]
        public async Task<IActionResult> UpdateAuthoritiesDetail([FromBody] UpdateAuthoritiesaDetailsRequest request)
        {
            try
            {
                await authoritiesDetailService.UpdateAuthoritiesDetailAsync(request);
                return Ok("Authorities Detail Updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating authorities detail: {ex.Message}");
            }
        }
        /// <summary>
        ///deletes an authorities detail from the system based on its unique identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("deleteauthoritiesdetail/{id}")]
        public async Task<IActionResult> DeleteAuthoritiesDetail(int id)
        {
            try
            {
                await authoritiesDetailService.DeleteAuthoritiesDetailAsync(id);
                return Ok("Authorities Detail Deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting authorities detail: {ex.Message}");
            }
        }
    }
}

     