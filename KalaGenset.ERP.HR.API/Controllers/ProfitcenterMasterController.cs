using FluentValidation;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.Facility;
using KalaGenset.ERP.HR.Core.Request.ProfitcenterMaster;
using KalaGenset.ERP.HR.Core.Validation.ProfitcenterMaster;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KalaGenset.ERP.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfitcenterMasterController : BaseController
    {
        private readonly IProfitcenterMaster _iProfitCenter;    
        private readonly IValidator<InsertProfitcenterRequest> _insertValidator;
        private readonly IValidator<UpdateProfitcenterRequest> _updateValidator;


        public ProfitcenterMasterController(IProfitcenterMaster iProfitCenterMaster, IValidator<InsertProfitcenterRequest> insProfitCenterReqValidator, IValidator<UpdateProfitcenterRequest> updtProfitCenterReqValidator)
        {
            _iProfitCenter = iProfitCenterMaster;
            _insertValidator = insProfitCenterReqValidator;
            _updateValidator = updtProfitCenterReqValidator;
        }

        [HttpPost("addprofitcenter")]
        public async Task<IActionResult> AddProfitCenterAsync([FromBody] InsertProfitcenterRequest insertProfitCenterReq)
        {
            var validationResult = await _insertValidator.ValidateAsync(insertProfitCenterReq);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await _iProfitCenter.AddProfitCenterAsync(insertProfitCenterReq);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding Facility: {ex.Message}");
            }
        }

        [HttpPut("updateprofitcenter")]
        public async Task<IActionResult> UpdateProfiCneterAsync([FromBody] UpdateProfitcenterRequest updateProfitCenterRequest)
        {
            var validationResult = await _updateValidator.ValidateAsync(updateProfitCenterRequest);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await _iProfitCenter.UpdateProfitCenterAsync(updateProfitCenterRequest);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating Profit Center: {ex.Message}");
            }
        }

        [HttpGet("getallprofitcenter")]
        public async Task<IActionResult> GetAllProfitCenter()
        {
            var profitCenter = await _iProfitCenter.GetAllProfitCenterAsync();
            return Ok(profitCenter);
        }

      
        [HttpGet("getprofitcenterbyid")]
        public async Task<IActionResult> GetProfitCenterByIdAsync(int profitCeterId)
        {
            var profitcenter = await _iProfitCenter.GetProfitCenterByIdAsync(profitCeterId);
            return Ok(profitcenter);
        }

        [HttpDelete("deleteprofitcenter/{ProfitCenterId}")]
        public async Task<IActionResult> DeletProfitCenter(int profitCenterId)
        {
            try
            {
                await _iProfitCenter.DeleteProfitCenterAsync(profitCenterId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating Profit Center: {ex.Message}");
            }
        }

    }
}
