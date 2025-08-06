using Azure.Core;
using FluentValidation;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.StateRequest;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KalaGenset.ERP.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateMasterController : ControllerBase
    {
        private readonly IStateMaster _stateMaster;
        private readonly IValidator<InsertStateRequest> _insertStateValidator;
        private readonly IValidator<UpdateStateRequest> _updateStateValidator;

        public StateMasterController(IStateMaster stateMaster, IValidator<InsertStateRequest> InsertStatevalidator, IValidator<UpdateStateRequest> updateStateValidator)
        {
            _stateMaster = stateMaster;
            _insertStateValidator = InsertStatevalidator;
            _updateStateValidator = updateStateValidator;
        }

        /// <summary>
        /// Create STATE
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("CreateState")]
        public async Task<IActionResult> CreateState([FromBody] InsertStateRequest request)
        {
            var validationResult = await _insertStateValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            try
            {
                await _stateMaster.AddStateAsync(request);
                return Ok("State Added successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding city: {ex.Message}");
            }
        }
        /// <summary>
        /// get State 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllState")]
        public async Task<IActionResult> GetAllState()
        {
            var states = await _stateMaster.GetStateDetailsAsync();
            return Ok(states);
        }
        /// <summary>
        /// update state
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("UpdateState")]
        public async Task<IActionResult> UpdateState([FromBody] UpdateStateRequest request)
        {
            var validationResult = await _updateStateValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await _stateMaster.UpdateStateAsync(request);
                return Ok("State Updated Sucessfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating State: {ex.Message}");
            }


        }

        /// <summary>
        /// delete state
        /// </summary>
        /// <param name="StateId"></param>
        /// <returns></returns>
        [HttpDelete("DeleteState/{StateId}")]
        public async Task<IActionResult> DeleteCity(int StateId)
        {
            try
            {
                await _stateMaster.DeleteStateAsync(StateId);
                return Ok("Deleted Sucessfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting State: {ex.Message}");
            }
        }
        /// <summary>
        /// get state by id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>

        [HttpGet("GetStateByID/{Id}")]

        public async Task<IActionResult> GetStateByID(int Id)
        {
            try
            {
                var result = await _stateMaster.GetStateByID(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Id is Invalid : {ex.Message}");
            }
        }
    }
}
