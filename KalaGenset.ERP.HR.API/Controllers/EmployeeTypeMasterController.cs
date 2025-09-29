using System.ComponentModel.DataAnnotations;
using FluentValidation;
using FluentValidation.Results;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request;
using KalaGenset.ERP.HR.Core.Request.ClassOfTravel;
using KalaGenset.ERP.HR.Core.Request.CompanyEntityTypeMaster;
using KalaGenset.ERP.HR.Core.Request.EmployeeTypeMaster;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace KalaGenset.ERP.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EmployeeTypeMasterController : BaseController
    {
        private readonly IEmployeeTypeMaster _employeeTypeMaster;
        private readonly IValidator<InsertEmployeeTypeRequest> _validator;
        private readonly IValidator<UpdateEmployeeTypeRequest> _updateValidator;

        public EmployeeTypeMasterController(IEmployeeTypeMaster employeeTypeMaster, IValidator<InsertEmployeeTypeRequest> validator, IValidator<UpdateEmployeeTypeRequest> Updatevalidator)
        {
            _employeeTypeMaster = employeeTypeMaster;
            _validator = validator;
            _updateValidator = Updatevalidator;

        }
        /// <summary>
        /// This method is used to insert a new employee type into the system.
        /// </summary>
        /// <param name="resquest"></param>
        /// <returns></returns>
        [HttpPost("InsertEmployeeType")]

        public async Task<IActionResult> InsertEmployeeType([FromBody] InsertEmployeeTypeRequest resquest)
        {

            var validationResult = await _validator.ValidateAsync(resquest);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await _employeeTypeMaster.AddEmployeetype(resquest);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding employee entity type: {ex.Message}");
            }
        }
        /// <summary>
        /// This method retrieves all employee type details from the system.
        /// </summary>
        /// <returns></returns>
        [HttpGet("getallEmployeetype")]
        public async Task<IActionResult> GetEmployeeTypeDetails()
        {
            var result = await _employeeTypeMaster.GetAllEmployeeType();
            return Ok(result);


        }
        /// <summary>
        /// This method retrieves the details of a specific employee type by its ID.
        /// </summary>
        /// <param name="EmployeeTypeId"></param>
        /// <returns></returns>
        [HttpGet("GetEmployeeTypeByID")]
        public async Task<IActionResult> GetEmployeeTypeDetails(int EmployeeTypeId)
        {
            var result = await _employeeTypeMaster.EmployeeTypeById(EmployeeTypeId);
            return Ok(result);
        }
        /// <summary>
        /// This method updates the details of an existing employee type in the system.
        /// </summary>
        /// <param name="updateEmployeeTypeRequest"></param>
        /// <returns></returns>

        [HttpPut("UpdateEmployeetype")]
        public async Task<IActionResult> UpdateEmployeeType(UpdateEmployeeTypeRequest updateEmployeeTypeRequest)
        {
            var validationResult = await _updateValidator.ValidateAsync(updateEmployeeTypeRequest);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await _employeeTypeMaster.UpdateEmployeeTypeMasterAsync(updateEmployeeTypeRequest);
                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occured while updating EmployeeType:{ex.Message}");
            }

        }
        /// <summary>
        /// This method deletes an employee type by its ID from the system.
        /// </summary>
        /// <param name="EmployeeTypeId"></param>
        /// <returns></returns>
        [HttpDelete("DeleteEmployeeTypeById/{EmployeeTypeId}")]
        public async Task<IActionResult> DeleteEmplyeeTypeDetails(int EmployeeTypeId)
        {
            try
            {
                await _employeeTypeMaster.DeleteEmployeeTypeById(EmployeeTypeId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occured while deleting EmployeeType:{ex.Message}");
            }

        }
    }
}

    

           
