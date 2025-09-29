using FluentValidation;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.ERPPageDetails;
using Microsoft.AspNetCore.Mvc;

namespace KalaGenset.ERP.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ERPPageDetailsController : BaseController
    {
        private readonly IERPPageDetails _erpPageDetails;
        private readonly IValidator<InsertERPPageDetailsRequest> _insertValidator;
        private readonly IValidator<UpdateERPPageDetailsRequest> _updateValidator;

        public ERPPageDetailsController(
            IERPPageDetails erpPageDetails,
            IValidator<InsertERPPageDetailsRequest> insertValidator,
            IValidator<UpdateERPPageDetailsRequest> updateValidator)
        {
            _erpPageDetails = erpPageDetails;
            _insertValidator = insertValidator;
            _updateValidator = updateValidator;
        }

        /// <summary>
        /// Creates a new ERP Page Details record.
        /// </summary>
        /// <param name="request">The ERP Page Details request object.</param>
        /// <returns>Returns 200 OK if successful, otherwise validation or error details.</returns>
        [HttpPost("createerppagedetails")]
        public async Task<IActionResult> CreateERPPageDetails([FromBody] InsertERPPageDetailsRequest request)
        {
            var validationResult = await _insertValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            try
            {
                await _erpPageDetails.AddERPPageDetailsAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding ERP Page Details: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates an existing ERP Page Details record.
        /// </summary>
        /// <param name="request">The ERP Page Details update request object.</param>
        /// <returns>Returns 200 OK if successful, otherwise validation or error details.</returns>
        [HttpPut("updateerppagedetails")]
        public async Task<IActionResult> UpdateERPPageDetails([FromBody] UpdateERPPageDetailsRequest request)
        {
            var validationResult = await _updateValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            try
            {
                await _erpPageDetails.UpdateERPPageDetailsAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating ERP Page Details: {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves all ERP Page Details records.
        /// </summary>
        /// <returns>A list of ERP Page Details.</returns>
        [HttpGet("getAllerppagedetails")]
        public async Task<IActionResult> GetAllERPPageDetails()
        {
            try
            {
                var result = await _erpPageDetails.GetERPPageDetailsAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving ERP Page Details: {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves an ERP Page Details record by its ID.
        /// </summary>
        /// <param name="Id">The ERP Page Details ID.</param>
        /// <returns>The ERP Page Details object.</returns>
        [HttpGet("geterppagedetailsbyid/{Id}")]
        public async Task<IActionResult> GetERPPageDetailsByID(int Id)
        {
            try
            {
                var result = await _erpPageDetails.GetERPPageDetailsByID(Id);
                if (result == null)
                {
                    return NotFound("ERP Page Details not found.");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Invalid Id: {ex.Message}");
            }
        }

        /// <summary>
        /// Deletes an ERP Page Details record by its ID (soft delete).
        /// </summary>
        /// <param name="Id">The ERP Page Details ID.</param>
        /// <returns>Returns 200 OK if successful, otherwise error details.</returns>
        [HttpDelete("deleteerppagedetails/{Id}")]
        public async Task<IActionResult> DeleteERPPageDetails(int Id)
        {
            try
            {
                await _erpPageDetails.DeleteERPPageDetailsAsync(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting ERP Page Details: {ex.Message}");
            }
        }
    }
}

