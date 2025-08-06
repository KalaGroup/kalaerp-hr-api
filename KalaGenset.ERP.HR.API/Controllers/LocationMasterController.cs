using FluentValidation;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.LocationRequest;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KalaGenset.ERP.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationMasterController : ControllerBase
    {
        private readonly ILocationMaster _locationMaster;
        private readonly IValidator<InsertLocationRequest> _insertLocationValidator;
        private readonly IValidator<UpdateLocationRequest> _updateLocationValidator;

        public LocationMasterController(ILocationMaster locationMaster, IValidator<InsertLocationRequest> InsertLocationvalidator, IValidator<UpdateLocationRequest> UpdateLocationValidator)
        {
            _locationMaster = locationMaster;
            _insertLocationValidator = InsertLocationvalidator;
           _updateLocationValidator = UpdateLocationValidator;

        }
         /// <summary>
         /// create location
         /// </summary>
         /// <param name="request"></param>
         /// <returns></returns>
        [HttpPost("CreateLocation")]
        public async Task<IActionResult> CreateLocation([FromBody] InsertLocationRequest request)
        {
            var validationResult = await _insertLocationValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            try
            {
                await _locationMaster.AddLocationAsync(request);
                return Ok("Location Added successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding Location: {ex.Message}");
            }
        }

        /// <summary>
        /// update location
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("UpdateState")]
        public async Task<IActionResult> UpdateLocation([FromBody] UpdateLocationRequest request)
        {
            var validationResult = await _updateLocationValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await _locationMaster.UpdateLocationAsync(request);
                return Ok("Location Updated Sucessfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating Location: {ex.Message}");
            }

        }

        /// <summary>
        /// get all location
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllLocation")]
        public async Task<IActionResult> GetAllLocation()
        {
            try
            {
                var location = await _locationMaster.GetLocationDetailsAsync();
                return Ok(location);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// delete location by id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteLocation/{Id}")]
        public async Task<IActionResult> DeleteLocation(int Id)
        {
            try
            {
                await _locationMaster.DeleteLocationAsync(Id);
                return Ok("Deleted Sucessfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting Location: {ex.Message}");
            }
        }
        /// <summary>
        /// get location by id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("GetLocationByID/{Id}")]

        public async Task<IActionResult> GetLocationByID(int Id)
        {
            try
            {
                var result = await _locationMaster.GetLocationByID(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Id is Invalid : {ex.Message}");
            }
        }
    }
}