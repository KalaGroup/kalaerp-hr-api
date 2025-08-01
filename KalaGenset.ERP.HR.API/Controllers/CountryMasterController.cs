using System.ComponentModel.DataAnnotations;
using KalaGenset.ERP.HR.Core.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using FluentValidation.Results;
using KalaGenset.ERP.HR.Core.Request.Country;

namespace KalaGenset.ERP.HR.API.Controllers
{
    /// <summary>
    ///  Controller for managing country master data.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CountryMasterController : ControllerBase
    {
        private readonly ICountryMaster _countryMaster;
        private readonly IValidator<InsertCountryRequest> _insertCountryValidator;
        private readonly IValidator<UpdateCountryRequest> _updateCountryValidator;
        public CountryMasterController(ICountryMaster CountryMaster, IValidator<InsertCountryRequest> InsertCountryValidator, IValidator<UpdateCountryRequest> UpdateCountryValidator)
        {
            _countryMaster = CountryMaster;
            _insertCountryValidator = InsertCountryValidator;
            _updateCountryValidator = UpdateCountryValidator;
        }

        /// <summary>
        /// Creates a new country in the system.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("createcountry")]
        public async Task<IActionResult> CreateCountry([FromBody] InsertCountryRequest request)
        {
            var validationResult = await _insertCountryValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await _countryMaster.AddCountryAsync(request);
                return Ok("Country added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding country: {ex.Message}");
            }
        }
        /// <summary>
        /// Updates an existing country in the system.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("updatecountry")]
        public async Task<IActionResult> UpdateCountry(UpdateCountryRequest request)
        {
            var validationResult = await _updateCountryValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try 
            {
                await _countryMaster.UpdateCountryAsync(request);
                return Ok("Country updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating country: {ex.Message}");
            }
        }
        /// <summary>
        /// Retrieves all countries from the system.
        /// </summary>
        /// <returns></returns>
        [HttpGet("getallcountries")]
        public async Task<IActionResult> GetAllCountries()
        {
            var countries = await _countryMaster.GetCountryDetailsAsync();
            return Ok(countries);
        }
        /// <summary>
        /// Retrieves details of a specific country by its ID.
        /// </summary>
        /// <param name="CountryId"></param>
        /// <returns></returns>
        [HttpGet("getcountrybyid/{CountryId}")]
        public async Task<IActionResult> GetCountryDetails(int CountryId)
        {
            var result = await _countryMaster.GetCountryById(CountryId);
            return Ok(result);
        }
        /// <summary>
        /// Soft-deletes a country by setting its IsActive flag to false.
        /// </summary>
        /// <param name="CountryId"></param>
        /// <returns></returns>
        [HttpDelete("deletecountry/{CountryId}")]
        public async Task<IActionResult> DeleteCountry(int CountryId)
        {
            try
            {
                await _countryMaster.DeleteCountryAsync(CountryId);
                return Ok("Country soft-deleted successfully (CountryIsActive = false).");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while Soft-Deleting country: {ex.Message}");
            }
        }
    }
}
