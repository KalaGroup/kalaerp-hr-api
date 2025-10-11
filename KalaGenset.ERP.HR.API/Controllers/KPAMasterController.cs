using FluentValidation;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.KPAMaster;
using KalaGenset.ERP.HR.Core.Validation.KPAMaster;
using KalaGenset.ERP.HR.Data.DbContexts;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KalaGenset.ERP.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KPAMasterController : BaseController
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
                var errors = validationResult.Errors
                .Select(e => new { field = e.PropertyName, message = e.ErrorMessage })
                .FirstOrDefault();
                return BadRequest(errors);
            }

            try
            {
                await _kpaMasterService.InsertKPAMasterAsync(request);
                return Ok(new { message = "KPA Master added successfully" });
            }
            catch (Exception ex)
            {
                // You could also log ex here
                return StatusCode(500, $"An error occurred while adding KPA Master: {ex.Message}");
            }
        }

        /// <summary>
        /// get all KPA Masters
        /// </summary>
        /// <returns>List of KPA Masters</returns>
        [HttpGet("getallkpamaster")]
        public async Task<IActionResult> GetAllKPAMaster()
        {
            try
            {
                var kpa = await _kpaMasterService.GetAllKPAMasterAsync();

                if (kpa == null || !kpa.Any())
                {
                    return NotFound("No KPA found.");
                }

                return Ok(kpa);
            }
            catch (Exception ex)
            {
                // Ideally log the exception with ILogger here
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Internal server error: {ex.Message}");
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
                return Ok();
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
                var errors = validationResult.Errors
                .Select(e => new { field = e.PropertyName, message = e.ErrorMessage })
                .FirstOrDefault();
                return BadRequest(errors);
            }
            try
            {
                await _kpaMasterService.UpdateKPAMasterAsync(request);
                return Ok();
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
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting KPA Master: {ex.Message}");
            }
        }

        [HttpGet("getkpadetailbymasterid/{KpaMstId}")]
        public async Task<IActionResult>GetKpadetail(int kpaMstId)
        {
            try
            {
                var KPA = await _kpaMasterService.GetKpaDetailsByMsaterId(kpaMstId);
                if (KPA == null)
                {
                    return NotFound("KPA not found.");
                }
                return Ok(KPA);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving KPA: {ex.Message}");
            }
        }
        }

    }

     
