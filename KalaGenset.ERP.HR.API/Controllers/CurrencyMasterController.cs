using FluentValidation;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.Currency;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KalaGenset.ERP.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyMasterController : ControllerBase
    {
        private readonly ICurrencyMaster currencyMaster;
        private readonly IValidator<InsertCurrencyRequest> _validator;
        private readonly IValidator<UpdateCurrencyRequest> _updatevalidator;

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyMasterController"/> class.
        /// </summary>
        /// <remarks>This constructor sets up the dependencies required for the <see
        /// cref="CurrencyMasterController"/> to handle currency-related operations and validate incoming
        /// requests.</remarks>
        /// <param name="currencyMaster">The service responsible for managing currency-related operations.</param>
        /// <param name="validator">The validator used to validate <see cref="InsertCurrencyRequest"/> objects.</param>
        /// <param name="updatevalidator">The validator used to validate <see cref="UpdateCurrencyRequest"/> objects.</param>
      

        public CurrencyMasterController(ICurrencyMaster currencyMaster,
            IValidator<InsertCurrencyRequest> validator,
            IValidator<UpdateCurrencyRequest> updatevalidator)
        {
            this.currencyMaster = currencyMaster;
            _validator = validator;
            _updatevalidator = updatevalidator;
        }
        [HttpPost("createcurrency")]

        ///<summary>
        ///Create a new currency.
        ///
        public async Task<IActionResult> CreateCurrency([FromBody] InsertCurrencyRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await currencyMaster.AddCurrencyAsync(request);
                return Ok("Currency added successfully.");
            }
            catch (Exception )
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while adding the currency.");
            }

        }

        /// <summary>
        /// Fetch All Currency method.
        /// </summary>
        /// <returns></returns>

        [HttpGet("getallcurrency")]

        public async Task<IActionResult> GetAllCurrency()
        {
            var currencyMsts = await currencyMaster.GetCurrencyMstsAsync();
            return Ok(currencyMsts);
        }

        /// <summary>
        /// Update Currency method.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>

        [HttpPut("updatecurrency")]
        public async Task<IActionResult> UpdateCurrency([FromBody] UpdateCurrencyRequest request)
        {
            var validationResult = await _updatevalidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            try
            {
                await currencyMaster.UpdateCurrencyAsync(request);
                return Ok("Currency updated successfully.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while updating the currency.");
            }
        }


        /// <summary>
        /// Get Currency by Id method.  
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>

        [HttpGet("getcurrencybyid/{Id}")]
        public async Task<IActionResult> GetCurrencyById(int Id)
        {
            var result = await currencyMaster.GetCurrencyByIdAsync(Id);
            return Ok(result);
        }

        /// <summary>
        /// Delete Currency method.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>

        [HttpDelete("deletecurrency/{CurrencyId}")]
        public async Task<IActionResult> DeleteCurrency(int Id)
        {
            try
            {
                await currencyMaster.DeleteCurrencyAsync(Id);
                return Ok("Currency deleted successfully.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting the currency.");
            }
        }

    }

}

