using FluentValidation;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.QualificationRequest;
using KalaGenset.ERP.HR.Core.Request.StateRequest;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KalaGenset.ERP.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QualificationMasterController : BaseController
    {
        private readonly IQualificationMaster _qualificationMaster;
        private readonly IValidator<InsertQualificationRequest> _insertQualificationValidator;
        private readonly IValidator<UpdateQualificationRequest> _updateQualificationValidator;

        public QualificationMasterController(IQualificationMaster qualificationMaster, IValidator<InsertQualificationRequest> InsertQualificationvalidator, IValidator<UpdateQualificationRequest> UpdateQualificationValidator)
        {
            _qualificationMaster = qualificationMaster;
            _insertQualificationValidator = InsertQualificationvalidator;
            _updateQualificationValidator = UpdateQualificationValidator;
        }
        /// <summary>
        /// create qual
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("CreateQualification")]
        public async Task<IActionResult> CreateQualification([FromBody] InsertQualificationRequest request)
        {
            var validationResult = await _insertQualificationValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                .Select(e => new { field = e.PropertyName, message = e.ErrorMessage })
                .FirstOrDefault();
                return BadRequest(errors);
            }

            try
            {
                await _qualificationMaster.AddQualificationAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding Qualification: {ex.Message}");
            }
        }
        /// <summary>
        /// update loc
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("updatequalification")]
        public async Task<IActionResult> UpdateQualification([FromBody] UpdateQualificationRequest request)
        {
            var validationResult = await _updateQualificationValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
               .Select(e => new { field = e.PropertyName, message = e.ErrorMessage })
               .FirstOrDefault();
                return BadRequest(errors);
            }
            try
            {
                await _qualificationMaster.UpdateQualificationAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating Qualification: {ex.Message}");
            }

        }
        /// <summary>
        /// get loc
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllQualification")]
        public async Task<IActionResult> GetAllQualification()
        {
            var qualifications = await _qualificationMaster.GetQualificationDetailsAsync();
            return Ok(qualifications);
        }

        /// <summary>
        /// delete loc
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteQualification/{Id}")]
        public async Task<IActionResult> DeleteQualification(int Id)
        {
            try
            {
                await _qualificationMaster.DeleteQualificationAsync(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting Qualification: {ex.Message}");
            }
        }
        /// <summary>
        /// Get qualification by id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("GetQualificationByID/{Id}")]

        public async Task<IActionResult> GetQualificationByID(int Id)
        {
            try
            {
                var result = await _qualificationMaster.GetQualificationByID(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Id is Invalid : {ex.Message}");
            }
        }
        /// <summary>
        /// GetQualification Id And Name
        /// </summary>
        /// <returns></returns>
        [HttpGet("getallqualificationidandname")]
        public async Task<IActionResult> GetAllQualificationIdAndName()
        {
            var qualifications = await _qualificationMaster.GetQualificationIdAndNameFromDB();
            return Ok(qualifications);
        }


    }
}
