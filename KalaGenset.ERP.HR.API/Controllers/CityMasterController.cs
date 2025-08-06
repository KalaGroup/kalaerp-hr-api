using FluentValidation;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.City;
using KalaGenset.ERP.HR.Core.Validation.CityMasterValidation;
using KalaGenset.ERP.HR.Data.DbContexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.ComponentModel.Design;

namespace KalaGenset.ERP.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityMasterController : ControllerBase
    {
        private readonly ICityMaster _CityMaster;
        private readonly IValidator<InsertCityRequest> _insertCityValidator;
        private readonly IValidator<UpdateCityRequest> _updateCityValidator;

        public CityMasterController(ICityMaster cityMaster, IValidator<InsertCityRequest> validator, IValidator<UpdateCityRequest> updateCityValidator)
        {
            _insertCityValidator = validator;
            _CityMaster = cityMaster;
            _updateCityValidator = updateCityValidator;
        }

        /// <summary>
        /// Adds a new city to the system based on the provided request data.
        /// </summary>
        /// <remarks>This method validates the input request using the configured validator.  If
        /// validation fails, a 400 Bad Request response is returned with the validation errors.  If an exception occurs
        /// during the operation, a 500 Internal Server Error response is returned  with the exception
        /// details.</remarks>
        /// <param name="request">The request object containing the details of the city to be added.  This must include all required fields
        /// for city creation.</param>
        /// <returns>An <see cref="IActionResult"/> indicating the result of the operation.  Returns <see
        /// cref="BadRequestObjectResult"/> if the request is invalid,  <see cref="OkObjectResult"/> with a success
        /// message if the city is added successfully,  or <see cref="ObjectResult"/> with a status code of 500 if an
        /// unexpected error occurs.</returns>
        [HttpPost("AddCity")]
        public async Task<IActionResult> AddCity([FromBody] InsertCityRequest request)
        {
            var validationResult = await _insertCityValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            try
            {
                await _CityMaster.AddCityAsync(request);
                return Ok("City Added successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding city: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates the details of an existing city based on the provided request data.
        /// </summary>
        /// <remarks>This method validates the input request before performing the update operation.  If
        /// validation fails, a list of validation errors is returned in the response.  In case of an unexpected error,
        /// a generic error message is returned with a 500 status code.</remarks>
        /// <param name="request">The request object containing the updated city details. This must include all required fields for the update
        /// operation.</param>
        /// <returns>An <see cref="IActionResult"/> indicating the result of the operation.  Returns <see
        /// cref="BadRequestObjectResult"/> if the request is invalid,  <see cref="OkObjectResult"/> with a success
        /// message if the update is successful,  or <see cref="ObjectResult"/> with a status code of 500 if an
        /// unexpected error occurs.</returns>
        [HttpPut("UpdateCity")]
        public async Task<IActionResult> UpdateCity([FromBody] UpdateCityRequest request)
        {
            var validationResult = await _updateCityValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await _CityMaster.UpdateCityAsync(request);
                return Ok("City Updated Sucessfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating city: {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves a list of all cities.
        /// </summary>
        /// <remarks>This method returns all city details available in the system. The result is returned
        /// as an HTTP 200 OK response containing the city data. If no cities are found, an empty collection is
        /// returned.</remarks>
        /// <returns>An <see cref="IActionResult"/> containing an HTTP 200 OK response with the list of cities.</returns>
        [HttpGet("GetAllCity")]
        public async Task<IActionResult> GetAllCity()
        {
            var result = await _CityMaster.GetAllCompanyDetailsAsync();
            return Ok(result);
        }
        /// <summary>
        /// Retrieves the details of a city based on the specified city ID.
        /// </summary>
        /// <param name="CityId">The unique identifier of the city to retrieve.</param>
        /// <returns>An <see cref="IActionResult"/> containing the city details if the city is found,  or a status code
        /// indicating an error if the operation fails.</returns>
        [HttpGet("GetCityById/{CityId}")]
        public async Task<IActionResult> GetCityById(int CityId)
        {
            try
            {
                var result= await _CityMaster.GetCityByID(CityId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $" ID Is Invalid: {ex.Message}");
            }
            
        }

        /// <summary>
        /// Deletes a city with the specified identifier.
        /// </summary>
        /// <remarks>This method attempts to delete a city by its identifier. If the operation fails,  an
        /// error message is returned with a status code of 500.</remarks>
        /// <param name="CityId">The unique identifier of the city to delete.</param>
        /// <returns>An <see cref="IActionResult"/> indicating the result of the operation.  Returns <see cref="OkObjectResult"/>
        /// with a success message if the deletion is successful.  Returns <see cref="ObjectResult"/> with a status code
        /// of 500 if an error occurs.</returns>
        [HttpDelete("DeleteCity/{CityId}")]
        public async Task<IActionResult> DeleteCity(int CityId)
        {
            try
            {
                await _CityMaster.DeleteCompanyAsync(CityId);
                return Ok("Deleted Sucessfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting city: {ex.Message}");
            }   
        }
    }
}