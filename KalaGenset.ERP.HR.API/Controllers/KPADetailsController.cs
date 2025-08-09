using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.KPADetail;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KalaGenset.ERP.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KPADetailsController : ControllerBase
    {
        /// <summary>
        /// constructor for KPADetailsController
        /// </summary>
        private readonly IKpadetail _kpaDetailsService;
        /// <summary>
        /// method to initialize KPADetailsController
        /// </summary>
        /// <param name="kpaDetailsService"></param>
        public KPADetailsController(IKpadetail kpaDetailsService)
        {
            _kpaDetailsService = kpaDetailsService;
        }
        /// <summary>
        /// add KPA Details
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("addkpdetails")]
        public async Task<IActionResult> AddKPADetails([FromBody] InsertKpadetailRequest request)
        {
            try
            {
                await _kpaDetailsService.InsertKPADetailAsync(request);
                return Ok("KPA Details Added successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding KPA Details: {ex.Message}");
            }
        }
        /// <summary>
        /// get all KPA Details
        /// </summary>
        /// <returns></returns>
        [HttpGet("getallkpdetails")]
        public async Task<IActionResult> GetAllKPADetails()
        {
            try
            {
                var kpaDetails = await _kpaDetailsService.GetAllKPADetailsAsync();
                return Ok(kpaDetails);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving KPA Details: {ex.Message}");
            }
        }
        /// <summary>
        /// get KPA Details by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("getkpdetailsbyid/{id}")]
        public async Task<IActionResult> GetKPADetailsByID(int id)
        {
            try
            {
                var kpaDetail = await _kpaDetailsService.GetKPADetailByID(id);
                if (kpaDetail == null)
                {
                    return NotFound($"No KPA Details found with ID {id}");
                }
                return Ok(kpaDetail);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving KPA Details by ID: {ex.Message}");
             }
        }
        /// <summary>
        /// delete KPA Details by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("deletekpdetails/{id}")]
        public async Task<IActionResult> DeleteKPADetails(int id)
        {
            try
            {
                await _kpaDetailsService.DeleteKPADetailAsync(id);
                return Ok("KPA Details deleted successfully");
            }
            catch (Exception ex)// Catch any exceptions that occur during the deletion process
            {
                return StatusCode(500, $"An error occurred while deleting KPA Details: {ex.Message}");
            }
        }
        /// <summary>
        /// update KPA Details
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("updatekpdetails")]
         public async Task<IActionResult> UpdateKPADetails([FromBody] UpdateKpadetailRequest request)
        {
            try 
            { 
                await _kpaDetailsService.UpdateKPADetailAsync(request);
                return Ok("KPA Details updated successfully");
            }
            catch (Exception ex) // Catch any exceptions that occur during the update process
            {
                return StatusCode(500, $"An error occurred while updating KPA Details: {ex.Message}");
            }
        }
    }
}
