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

        [HttpGet("GetAllCity")]
        public async Task<IActionResult> GetAllCity()
        {
            var result = await _CityMaster.GetAllCompanyDetailsAsync();
            return Ok(result);
        }

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