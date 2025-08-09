using FluentValidation;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.KPAMaster;
using KalaGenset.ERP.HR.Core.Validation.KPAMaster;
using KalaGenset.ERP.HR.Data.DbContexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KalaGenset.ERP.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KPAMasterController : ControllerBase
    {
        /// <summary>
        /// method to initialize KPAMasterController
        /// </summary>
        private readonly IKPAMaster _kpaMasterService;
        private readonly IValidator<InsertKPAMasterRequest> _insertKPAValidator;
        private readonly IValidator<UpdateKPAMasterRequest> _updateKPAValidator;
        /// <summary>
        /// constructor for KPAMasterController
        /// </summary>
        /// <param name="kpaMasterService"></param>
        /// <param name="insertKPAValidator"></param>
        /// <param name="updateKPAValidator"></param>
        public KPAMasterController(IKPAMaster kpaMasterService,
                                   IValidator<InsertKPAMasterRequest> insertKPAValidator,
                                   IValidator<UpdateKPAMasterRequest> updateKPAValidator)
        {
            _kpaMasterService = kpaMasterService;
            _insertKPAValidator = insertKPAValidator;
            _updateKPAValidator = updateKPAValidator;
        }
        /// <summary>
        /// add KPA Master
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("addkpamaster")]
        public async Task<IActionResult> AddKPAMaster([FromBody] InsertKPAMasterRequest request)
        {
            var validationResult = await _insertKPAValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await _kpaMasterService.InsertKPAMasterAsync(request);
                return Ok("KPA Master Added successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding KPA Master: {ex.Message}");
            }
        }
        /// <summary>
        /// get all KPA Masters
        /// </summary>
        /// <returns></returns>
        [HttpGet("getallkpamaster")]
        public async Task<IActionResult> GetAllKPAMaster()
        {
            try
            {
                var kpaMasters = await _kpaMasterService.GetAllKPAMasterAsync();
                return Ok(kpaMasters);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving KPA Masters: {ex.Message}");
            }
        }
        /// <summary>
        /// get KPA Master by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("getkpamasterbyid/{id}")]
        public async Task<IActionResult> GetKPAMasterByID(int id)
        {
            try
            {
                var kpaMaster = await _kpaMasterService.GetKPAMasterByID(id);
                if (kpaMaster == null)
                {
                    return NotFound($"KPA Master with ID {id} not found.");
                }
                return Ok(kpaMaster);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving KPA Master: {ex.Message}");
            }
        }
        /// <summary>
        /// update KPA Master
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("updatekpamaster")]
        public async Task<IActionResult> UpdateKPAMaster([FromBody] UpdateKPAMasterRequest request)
        {
            var validationResult = await _updateKPAValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await _kpaMasterService.UpdateKPAMasterAsync(request);
                return Ok("KPA Master Updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating KPA Master: {ex.Message}");
            }
        }
        /// <summary>
        /// delete KPA Master by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("deletekpamaster/{id}")]
        public async Task<IActionResult> DeleteKPAMaster(int id)
        {
            try
            {
                await _kpaMasterService.DeleteKPAMasterAsync(id);
                return Ok("KPA Master Deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting KPA Master: {ex.Message}");
            }
        }
    }
           
}
