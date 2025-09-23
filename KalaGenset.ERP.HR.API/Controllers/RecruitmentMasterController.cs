using FluentValidation;
using KalaERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.Currency;
using KalaGenset.ERP.HR.Core.Request.RecruitmentMaster;
using KalaGenset.ERP.HR.Core.Services;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KalaGenset.ERP.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecruitmentMasterController : ControllerBase
    {
        private readonly IRecruitmentMaster recruitmentMaster;
        private readonly IValidator<InsertRecruitmentMasterRequest> _validator;
        private readonly IValidator<UpdateRecruitmentMasterRequest> _updatevalidator;

        public RecruitmentMasterController(IRecruitmentMaster recruitmentMaster,
            IValidator<InsertRecruitmentMasterRequest> validator,
            IValidator<UpdateRecruitmentMasterRequest> updatevalidator)
        {
            this.recruitmentMaster = recruitmentMaster;
            _validator = validator;
            _updatevalidator = updatevalidator;
        }
        [HttpPost("createrecruitmentmaster")]
        /// <summary>
        /// Create a new Recruitment Master record.
        /// </summary>
        public async Task<IActionResult> CreateRecruitmentMaster([FromBody] InsertRecruitmentMasterRequest request)
        {
            // Run validation
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            try
            {
                await recruitmentMaster.AddRecruitmentMasterAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    $"An error occurred while adding the Recruitment Master: {ex.Message}"
                );
            }
        }
        [HttpGet("getallrecruitmentMaster")]
        public async Task<IActionResult> getallrecruitmentMaster()
        {
            var recruitment = await recruitmentMaster.GetAllRecruitmentMasterAsync();
            return Ok(recruitment);
        }

        [HttpPut("updaterecruitmentMaster")]
        public async Task<IActionResult> UpdateCurrency([FromBody] UpdateRecruitmentMasterRequest request)
        {
            var validationResult = await _updatevalidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await recruitmentMaster.UpdateRecruitmentMasterAsync(request);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating the currency.");
            }
        }

        [HttpGet("getrecruitmentMasterbyid/{Id}")]
        public async Task<IActionResult> GetrecruitmentMasterById(int Id)
        {
            var result = await recruitmentMaster.GetRecruitmentMasterByIdAsync(Id);
            return Ok(result);
        }

        [HttpDelete("deleterecruitmentMaster/{RecruitmentMasterId}")]
        public async Task<IActionResult> DeleteCurrency(int RecruitmentMasterId)
        {
            try
            {
                await recruitmentMaster.DeleteRecruitmentMasterAsync(RecruitmentMasterId);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting the currency.");
            }
        }

        [HttpGet("getemployeeidandname")]
        public async Task<IActionResult> GetEmployeeIdAndNameAsync()
        {
            try
            {
                var emp = await recruitmentMaster.GetEmployeeIdAndNameAsync();
                if (emp == null || !emp.Any())
                {
                    return NotFound("No companies found.");
                }
                return Ok(emp);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet("getepositionidandname")]
        public async Task<IActionResult> GetPositionIdAndNameAsync()
        {
            try
            {
                var pos = await recruitmentMaster.GetPositionIdAndNameAsync();
                if (pos == null || !pos.Any())
                {
                    return NotFound("No position found.");
                }
                return Ok(pos);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet("getallrecruitmentdetailsbymasterid/{RecruitmentMasterId}")]
        public async Task<IActionResult> Getrecruitmentdetails(int RecruitmentMasterId)
        {
            try
            {
                var recruitment = await recruitmentMaster.GetrecruitmentDetailsByMsaterId(RecruitmentMasterId);
                if (recruitment == null)
                {
                    return NotFound("Resposibility not found.");
                }
                return Ok(recruitment);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving resposibility: {ex.Message}");
            }
        }
    }
}
