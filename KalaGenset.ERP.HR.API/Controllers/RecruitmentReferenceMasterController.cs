using FluentValidation;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.RecruitmentReferenceMaster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KalaGenset.ERP.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecruitmentReferenceMasterController : BaseController
    {
        private readonly IRecruitmentReferenceMaster _recruitmentReferenceMaster;
        private readonly IValidator<InsertRecruitmentReferenceMasterRequest> _insertValidator;
        private readonly IValidator<UpdateRecruitmentReferenceMasterRequest> _updateValidator;

        public RecruitmentReferenceMasterController(
            IRecruitmentReferenceMaster recruitmentReferenceMaster,
            IValidator<InsertRecruitmentReferenceMasterRequest> insertValidator,
            IValidator<UpdateRecruitmentReferenceMasterRequest> updateValidator)
        {
            _recruitmentReferenceMaster = recruitmentReferenceMaster;
            _insertValidator = insertValidator;
            _updateValidator = updateValidator;
        }

        [HttpPost("addrecruitmentReferenc")]
        public async Task<IActionResult> AddRecruitmentReference([FromBody] InsertRecruitmentReferenceMasterRequest request)
        {
            if (request == null)
                return BadRequest("Request cannot be null.");

            var validationResult = await _insertValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                .Select(e => new { field = e.PropertyName, message = e.ErrorMessage })
                .FirstOrDefault();
                return BadRequest(errors);
            }

            try
            {
                await _recruitmentReferenceMaster.AddRecruitmentReferenceAsync(request); // ✅ awaited
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"An error occurred while adding Recruitment Reference: {ex.Message}");
            }
        }

        [HttpGet("getallrecruitmentReferenc")]
        public async Task<IActionResult> GetAllRecruitmentReferences()
        {
            try
            {
                var references = await _recruitmentReferenceMaster.GetAllRecruitmentReferenceAsync();
                return Ok(references);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"An error occurred while retrieving Recruitment References: {ex.Message}");
            }
        }

        [HttpPut("updaterecruitmentReferenc")]

        public async Task<IActionResult> UpdateRecruitmentReferenc([FromBody]UpdateRecruitmentReferenceMasterRequest request)
        {
            if (request == null)
                return BadRequest("Request cannot be null.");

            var validationResult = await _updateValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                .Select(e => new { field = e.PropertyName, message = e.ErrorMessage })
                .FirstOrDefault();
                return BadRequest(errors);
            }
            try
            {
                await _recruitmentReferenceMaster.UpdateRecruitmentReferenceAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [HttpGet("getbyId")]

        public async Task<IActionResult> GetByIdreference(int RecruitmentReferenceId)
        {
            var profitcenter = await _recruitmentReferenceMaster.GetRecruitmentReferenceByIdAsync(RecruitmentReferenceId);
            return Ok(profitcenter);
        }

        [HttpDelete("deleterecruitmentReferenc/{RecruitmentReferenceId}")]

        public async Task<IActionResult> DeleterecRuitmentReferenc(int RecruitmentReferenceId)
        {
            try
            {
                await _recruitmentReferenceMaster.DeleteRecruitmentReferenceAsync(RecruitmentReferenceId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating: {ex.Message}");
            }
        }

        
    }
}
