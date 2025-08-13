using FluentValidation;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.ActivityMaster;
using KalaGenset.ERP.HR.Core.Request.RecruitmentStageStatusMaster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KalaGenset.ERP.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecruitmentStageStatusMasterController : ControllerBase
    {
        private readonly IRecruitmentStageStatusMaster recruitmentStage;
        private readonly IValidator<InsertRecruitmentStageStatusMasterRequest> validator;
        private readonly IValidator<UpdateRecruitmentStageStatusMasterRequest> updateValidator;
        public RecruitmentStageStatusMasterController(IRecruitmentStageStatusMaster recruitmentStage,
                                         IValidator<InsertRecruitmentStageStatusMasterRequest> validator,
                                         IValidator<UpdateRecruitmentStageStatusMasterRequest> updateValidator)
        {
            this.recruitmentStage = recruitmentStage;
            this.validator = validator;
            this.updateValidator = updateValidator;
        }
        /// <summary>
        /// Add RecruitmentStageStatus 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("addrecruitmentstagestatus")]
        public async Task<IActionResult> RecruitmentStageStatuAsync([FromBody] InsertRecruitmentStageStatusMasterRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request data.");
            }
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await recruitmentStage.AddRecruitmentStageAsync(request);
                return Ok("Recruitment added successfully.");
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
        /// <summary>
        /// get all getrecruitmentstagestatus
        /// </summary>
        /// <returns></returns>
        [HttpGet("getrecruitmentstagestatus")]
        public async Task<IActionResult> RecruitmentStageStatus()
        {
            try
            {
                var Recruitment = await recruitmentStage.GetAllRecruitmentStageAsync();
                if (Recruitment == null || !Recruitment.Any())
                {
                    return NotFound("No Recruitment found.");
                }
                return Ok(Recruitment);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
        /// <summary>
        /// get by id getrecruitmentstagestatusbyid
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("getrecruitmentstagestatusbyid/{Id}")]
        public async Task<IActionResult> getbyid(int Id)
        {
            var result = await recruitmentStage.GetRecruitmentStageByID(Id);
            return Ok(result);
        }
        /// <summary>
        /// delete getrecruitmentstagestatus record 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("deletegetrecruitmentstagestatus/{Id}")]
        public async Task<IActionResult> DeleteRecruitmentStageStatus(int Id)
        {
            try
            {
                await recruitmentStage.DeleteRecruitmentStageAsync(Id);
                return Ok("Recruitment soft-deleted successfully ");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while Soft-Deleting : {ex.Message}");
            }
        }
        /// <summary>
        /// update actitvity 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("updategetrecruitmentstagestatus")]
        public async Task<IActionResult> updateRecruitmentStageStatusAsync(UpdateRecruitmentStageStatusMasterRequest request)
        {
            var validationResult = await updateValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await recruitmentStage.updateRecruitmentStageAsync(request);
                return Ok("Recruitment updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating : {ex.Message}");
            }
        }
    }
}
