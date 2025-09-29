using FluentValidation;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.RecruitmentAttributeMaster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KalaGenset.ERP.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecruitmentAttributeMasterController : BaseController
    {

        private readonly IRecruitmentAttributeMaster _RecruitmentAttributeMastermaster;
        private readonly IValidator<InsertRecruitmentAttributeMasterRequest> _insertRecruitmentAttributeMasterValidator;
        private readonly IValidator<UpdateRecruitmentAttributeMasterRequest> _updateRecruitmentAttributeMasterValidator;

        public RecruitmentAttributeMasterController(IRecruitmentAttributeMaster RecruitmentAttributeMastermaster, IValidator<InsertRecruitmentAttributeMasterRequest> InsertRecruitmentAttributeMastervalidator, IValidator<UpdateRecruitmentAttributeMasterRequest> UpdateRecruitmentAttributeMasterValidator)
        {
            _RecruitmentAttributeMastermaster = RecruitmentAttributeMastermaster;
            _insertRecruitmentAttributeMasterValidator = InsertRecruitmentAttributeMastervalidator;
            _updateRecruitmentAttributeMasterValidator = UpdateRecruitmentAttributeMasterValidator;

        }

        /// <summary>
        /// Creates a new RecruitmentAttributeMaster.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("CreateRecruitmentAttributeMaster")]
        public async Task<IActionResult> CreateRecruitmentAttributeMaster([FromBody] InsertRecruitmentAttributeMasterRequest request)
        {
            var validationResult = await _insertRecruitmentAttributeMasterValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            try
            {
                await _RecruitmentAttributeMastermaster.AddRecruitmentAttributeMasterAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding RecruitmentAttributeMaster: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates an existing RecruitmentAttributeMaster.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("UpdateRecruitmentAttributeMaster")]
        public async Task<IActionResult> UpdateRecruitmentAttributeMaster([FromBody] UpdateRecruitmentAttributeMasterRequest request)
        {
            var validationResult = await _updateRecruitmentAttributeMasterValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await _RecruitmentAttributeMastermaster.UpdateRecruitmentAttributeMasterAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating RecruitmentAttributeMaster: {ex.Message}");
            }

        }
        /// <summary>
        /// Get All RecruitmentAttributeMaster Details
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllRecruitmentAttributeMaster")]
        public async Task<IActionResult> GetAllRecruitmentAttributeMaster()
        {
            try
            {
                var RecruitmentAttributeMastermaster = await _RecruitmentAttributeMastermaster.GetRecruitmentAttributeMasterDetailsAsync();
                return Ok(RecruitmentAttributeMastermaster);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Deletes a RecruitmentAttributeMaster by its ID.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteRecruitmentAttributeMaster/{Id}")]
        public async Task<IActionResult> DeleteRecruitmentAttributeMaster(int Id)
        {
            try
            {
                await _RecruitmentAttributeMastermaster.DeleteRecruitmentAttributeMasterAsync(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting RecruitmentAttributeMaster: {ex.Message}");
            }
        }
        /// <summary>
        /// Retrieves a RecruitmentAttributeMaster by its ID.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("GetRecruitmentAttributeMasterByID/{Id}")]

        public async Task<IActionResult> GetRecruitmentAttributeMasterByID(int Id)
        {
            try
            {
                var result = await _RecruitmentAttributeMastermaster.GetRecruitmentAttributeMasterByID(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Id is Invalid : {ex.Message}");
            }
        }
    }
}

