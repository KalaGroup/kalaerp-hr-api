using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using KalaGenset.ERP.HR.Data.Models;

namespace KalaGenset.ERP.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QualificationTypeMasterController : ControllerBase
    {
        private readonly IQualificationTypeMaster _qualificationtypeMaster;
        private readonly IValidator<InsertQualificationTypeMasterRequest> _validator;
        private readonly IValidator<UpdateQualificationTypeMasterRequest> _updateValidator;
        public QualificationTypeMasterController(IQualificationTypeMaster qualificationtypeMaster, IValidator<InsertQualificationTypeMasterRequest> validator, IValidator<UpdateQualificationTypeMasterRequest> updateValidator)
        {
            _qualificationtypeMaster = qualificationtypeMaster;
   
            _validator = validator;
            _updateValidator = updateValidator;
        }

        /// <summary>
        /// insert Qualification Type master
        /// </summary>
        /// <param name="insertQualificationTypeMasterRequest"></param>
        /// <returns></returns>
        [HttpPost("insertqualificationtype")]
        public async Task <IActionResult> InsertQualificationType(InsertQualificationTypeMasterRequest insertQualificationTypeMasterRequest)
        {
            var validationResult = await _validator.ValidateAsync(insertQualificationTypeMasterRequest);
            if (!validationResult.IsValid)
               
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await _qualificationtypeMaster.AddQualificationTypeMasterAsync(insertQualificationTypeMasterRequest);
                return Ok("QualificationType Inserted Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding Qualification Type: {ex.Message}");
            }
        }

        [HttpGet("getallqualificationtype")]
        public async Task<IActionResult> GetQualificationTypeDetails()
        {
            var result = await _qualificationtypeMaster.GetAllQualificationType();
            return Ok(result);

        }
        [HttpGet("GetQualificationTypeByID/{QualificationTypeId}")]
        public async Task<IActionResult> GetQualificationTypeDetails(int QualificationTypeId)
        {
            var result = await _qualificationtypeMaster.GetQualificationTypeById(QualificationTypeId);
            return Ok(result);
        }

        [HttpPut("UpdateQualificationtype")]
        public async Task<IActionResult> UpdateQualifiationType(UpdateQualificationTypeMasterRequest updateQualificationTypeMasterRequest)
        { 
            var validationResult = await _updateValidator.ValidateAsync(updateQualificationTypeMasterRequest);
                 if (!validationResult.IsValid)
                 {                
                    return BadRequest(validationResult.Errors);
                 }
                try
                {
                    await _qualificationtypeMaster.UpdateQualificationTypeMasterAsync(updateQualificationTypeMasterRequest);
                    return Ok("Qualification type Updated Successfully");

                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"An error occured while updating QualificationType:{ex.Message}");
                }

            
        }

            [HttpDelete("DeleteQualificationType")]
            public async Task<IActionResult> DeleteQualificationTypeDetails(int QualificationTypeId)
            {

                try
                {
                    await _qualificationtypeMaster.DeleteQualificationTypeById(QualificationTypeId);
                    return Ok("Record deleted successfully");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"An error occured while deleting QualificationType:{ex.Message}");
                }

            }    
    }
}
