using FluentValidation;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request;
using Microsoft.AspNetCore.Mvc;

namespace KalaGenset.ERP.HR.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PetrolAllowanceController : ControllerBase
    {
        private readonly IPetrolAllowanceMaster _petrolAllowancemaster;
        private readonly IValidator<InsertPetrolAllowanceMasterRequest> _validator;
        private readonly IValidator<UpdatePetrolAllowanceMasterRequest> _updateValidator;

        public PetrolAllowanceController(IPetrolAllowanceMaster petrolAllowanceMaster, IValidator<InsertPetrolAllowanceMasterRequest> validator, IValidator<UpdatePetrolAllowanceMasterRequest> updatevalidator)
        {
            _petrolAllowancemaster = petrolAllowanceMaster;

            _validator = validator;
            _updateValidator = updatevalidator;

        }
        [HttpPost("insertPetrolAllowance")]
        public async Task<IActionResult> InsertPetrolAllowance(InsertPetrolAllowanceMasterRequest insertPetrolAllowanceMasterRequest)
        {
            var validationResult = await _validator.ValidateAsync(insertPetrolAllowanceMasterRequest);
            if (!validationResult.IsValid)

            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await _petrolAllowancemaster.AddPetrolAllowanceMasterAsync(insertPetrolAllowanceMasterRequest);
                return Ok("Petrol Allowance Inserted Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding Petrol Allowance Type: {ex.Message}");
            }

        }

        [HttpGet("GetAllPetrolAllowanceData")]
        public async Task<IActionResult> GetPetrolAllowance()
        {
            var result = await _petrolAllowancemaster.GetPetrolAllowance();
            return Ok(result);

        }

        [HttpGet("GetPetrolAllowanceById")]

        public async Task<IActionResult> GetPetrolAllowance(int PetrolAllowanceId)
        {
            var result = await _petrolAllowancemaster.GetPetrolAllowanceTypeById(PetrolAllowanceId);
            return Ok(result);
        }

        [HttpPut("updatePetrolAllowance")]
        public async Task<IActionResult> UpdatePetrolAllowance(UpdatePetrolAllowanceMasterRequest updatePetrolAllowanceMasterRequest)
        {
            var validationResult = await _updateValidator.ValidateAsync(updatePetrolAllowanceMasterRequest);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await _petrolAllowancemaster.UpdatePetrolAllowanceMasterService(updatePetrolAllowanceMasterRequest);
                return Ok("Petrol Allowance Updated Successfully");

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occured while updating petrol Allowance:{ex.Message}");
            }


        }
        [HttpDelete("DeletePetrolAllowance")]
        public async Task<IActionResult> DeletePertrolAllowanceDetails(int PetrolAllowanceId)
        {

            try
            {
                await _petrolAllowancemaster.DeletePetrolAllowanceById(PetrolAllowanceId);
                return Ok("Record deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occured while deleting Petrol Allowance:{ex.Message}");
            }

        }


    }

}
