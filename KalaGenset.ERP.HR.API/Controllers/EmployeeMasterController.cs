using FluentValidation;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.EmployeeMaster;
using KalaGenset.ERP.HR.Core.Request.OfferLetter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KalaGenset.ERP.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeMasterController : BaseController
    {
        private readonly IEmployeeMaster employeeMaster;
        private readonly IValidator<InsertEmployeeMasterRequest> validator;
        private readonly IValidator<UpdateEmployeeMasterRequest> updateValidator;
        public EmployeeMasterController(IEmployeeMaster employeeMaster,
                                        IValidator<InsertEmployeeMasterRequest> validator,
                                          IValidator<UpdateEmployeeMasterRequest> updateValidator)
        {
            this.employeeMaster = employeeMaster;
            this.validator = validator;
            this.updateValidator = updateValidator;
        }

        [HttpPost("addemployee")]
        public async Task<IActionResult> AddEmployeeMasterAsync([FromBody] InsertEmployeeMasterRequest request)
        {
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await employeeMaster.AddEmployeeMasterAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding Employee: {ex.Message}");
            }
        }

        [HttpGet("getallemployee")]
        public async Task<IActionResult> GetAllEmployeeMasterAsync()
        {
            try
            {
                var employees = await employeeMaster.GetAllEmployeeMasterAsync();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving Employees: {ex.Message}");
            }
        }

        [HttpPut("updateemployee")]

        public async Task<IActionResult> UpdateEmployeeMasterAsync([FromBody] UpdateEmployeeMasterRequest request)
        {
            var validationResult = await updateValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await employeeMaster.UpdateEmployeeMasterAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating Employee: {ex.Message}");
            }
        }

        [HttpDelete("deleteemployee/{EmployeeMasterId}")]
        public async Task<IActionResult> DeleteEmployeeMasterAsync(int EmployeeMasterId)
        {
            try
            {
                await employeeMaster.DeleteEmployeeMasterAsync(EmployeeMasterId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting Employee: {ex.Message}");
            }
        }

        [HttpGet("getemployeebyid/{EmployeeMasterId}")] 
        public async Task<IActionResult> GetEmployeeById(int EmployeeMasterId)
        {
            try
            {
                var employees = await employeeMaster.GetAllEmployeeMasterAsync();
                var employee = employees.FirstOrDefault(e => e.EmployeeMasterId == EmployeeMasterId);
                if (employee == null)
                {
                    return NotFound($"Employee with ID {EmployeeMasterId} not found.");
                }
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving Employee: {ex.Message}");
            }
        }
    }
}
