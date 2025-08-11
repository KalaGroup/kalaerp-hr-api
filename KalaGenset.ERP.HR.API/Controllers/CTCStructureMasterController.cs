using FluentValidation;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.ActivityDetails;
using KalaGenset.ERP.HR.Core.Request.AuthoritiesDetail;
using KalaGenset.ERP.HR.Core.Request.City;
using KalaGenset.ERP.HR.Core.Services;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KalaGenset.ERP.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CTCStructureMasterController : ControllerBase
    {
        private readonly ICTCStructureMaster cTC;
        private readonly IValidator<InsertCTCStructureMasterRequest> InsertCTC;
        private readonly IValidator<UpdateCTCStructureMasterRequest> UpdateCTC;

        public CTCStructureMasterController(ICTCStructureMaster cTC, 
                                    IValidator<InsertCTCStructureMasterRequest> InsertCTC,
                                    IValidator<UpdateCTCStructureMasterRequest> UpdateCTC)
        {
            this.cTC = cTC;
            this.InsertCTC = InsertCTC;
            this.UpdateCTC = UpdateCTC;
        }
        /// <summary>
        /// Add ctc add ctc api
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("addctc")]
        public async Task<IActionResult> AddCTC([FromBody] InsertCTCStructureMasterRequest request)
        {
            var validationResult = await InsertCTC.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await cTC.AddCTCStructureAsync(request);
                return Ok("CTC Added successfully");
            }
            catch (Exception ex)
            {
                // Better: Log the exception before throwing
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        /// <summary>
        /// get allctc api
        /// </summary>
        /// <returns></returns>
        [HttpGet("getallctc")]
        public async Task<IActionResult> getallctc()
        {
            var result = await cTC.GetCTCStructureAsync();
            return Ok(result);
        }
        /// <summary>
        /// get by id ctc
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("getctcbyid/{id}")]
        public async Task<IActionResult> getctcbyid(int id)
        {
            try
            {
                var result = await cTC.GetCTCStructureByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $" ID Is Invalid: {ex.Message}");
            }
        }
        /// <summary>
        /// delete ctc 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("deletectc/{id}")]
        public async Task<IActionResult> deletectc(int id)
        {
            try
            {
                await cTC.DeleteCTCStructureAsync(id);
                return Ok("Deleted Sucessfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting : {ex.Message}");
            }
        }
        /// <summary>
        ///  update ctc 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("updatectc")]
        public async Task<IActionResult> updatectc([FromBody] UpdateCTCStructureMasterRequest request)
        {
            var validationResult = await UpdateCTC.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await cTC.UpdateCTCStructureAsync(request);
                return Ok("ctc Updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating  : {ex.Message}");
            }
        }
    }
}
