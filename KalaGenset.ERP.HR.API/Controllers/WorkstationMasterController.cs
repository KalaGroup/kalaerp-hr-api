using FluentValidation;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.Workstation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KalaGenset.ERP.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkstationMasterController : ControllerBase
    {
        private readonly IWorkstationMaster _workstationmaster;
        private readonly IValidator<InsertWorkstationRequest> _insertWorkstationValidator;
        private readonly IValidator<UpdateWorkstationRequest> _updateWorkstationValidator;

        public WorkstationMasterController(IWorkstationMaster workstationmaster, IValidator<InsertWorkstationRequest> InsertWorkstationvalidator, IValidator<UpdateWorkstationRequest> UpdateWorkstationValidator)
        {
            _workstationmaster = workstationmaster;
            _insertWorkstationValidator = InsertWorkstationvalidator;
            _updateWorkstationValidator = UpdateWorkstationValidator;

        }

        /// <summary>
        /// Creates a new workstation.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("CreateWorkstation")]
        public async Task<IActionResult> CreateLocation([FromBody] InsertWorkstationRequest request)
        {
            var validationResult = await _insertWorkstationValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            try
            {
                await _workstationmaster.AddWorkStationAsync(request);
                return Ok("Workstation Added successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding Location: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates an existing workstation.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("UpdateWorkstation")]
        public async Task<IActionResult> UpdateWorkstation([FromBody] UpdateWorkstationRequest request)
        {
            var validationResult = await _updateWorkstationValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await _workstationmaster.UpdateWorkStationAsync(request);
                return Ok("Workstation Updated Sucessfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating Workstation: {ex.Message}");
            }

        }
        /// <summary>
        /// Get All Workstation Details
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllWorkstation")]
        public async Task<IActionResult> GetAllWorkstation()
        {
            try
            {
                var workstationmaster = await _workstationmaster.GetWorkStationDetailsAsync();
                return Ok(workstationmaster);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Deletes a workstation by its ID.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteWorkstation/{Id}")]
        public async Task<IActionResult> DeleteWorkstation(int Id)
        {
            try
            {
                await _workstationmaster.DeleteWorkStationAsync(Id);
                return Ok("Deleted Sucessfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting Workstation: {ex.Message}");
            }
        }
        /// <summary>
        /// Retrieves a workstation by its ID.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("GetWorkstationByID/{Id}")]

        public async Task<IActionResult> GetWorkstationByID(int Id)
        {
            try
            {
                var result = await _workstationmaster.GetWorkStationByID(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Id is Invalid : {ex.Message}");
            }
        }
    }
}

