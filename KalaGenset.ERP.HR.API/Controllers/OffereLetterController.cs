using FluentValidation;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.ActivityMaster;
using KalaGenset.ERP.HR.Core.Request.OfferLetter;
using KalaGenset.ERP.HR.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KalaGenset.ERP.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferLetterController : BaseController
    {
        private readonly IOfferLetter offerLetter;
        private readonly IValidator<InsertOfferLetterRequest> validator;
        private readonly IValidator<UpdateOfferLetterRequest> updateValidator;
        public OfferLetterController(IOfferLetter offerLetter,
                                         IValidator<InsertOfferLetterRequest> validator,
                                         IValidator<UpdateOfferLetterRequest> updateValidator)
        {
            this.offerLetter = offerLetter;
            this.validator = validator;
            this.updateValidator = updateValidator;
        }

        [HttpPost("addofferletter")]
        public async Task<IActionResult> AddOfferLetterAsync([FromBody] InsertOfferLetterRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request data.");
            }

            // validate using FluentValidation
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            try
            {
                await offerLetter.AddOfferLetterAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                // log error here if needed
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet("getofferletters")]
        public async Task<IActionResult> GetAllOfferLetters()
        {
            try
            {
                var offer = await offerLetter.GetAllOfferLetterAsync();

                if (offer == null || !offer.Any())
                    return NotFound(new { Message = "No offer letters found." });

                return Ok(offer);
            }
            catch (Exception ex)
            {
                // You can log the exception here if needed
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { Message = "Internal server error", Details = ex.Message });
            }
        }

        /// <summary>
        /// Get offer letter by Id along with CTC details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("getofferletterbyid/{id}")]
        public async Task<IActionResult> GetOfferLetterById(int id)
        {
            try
            {
                var offerletter = await offerLetter.GetOfferLetterById(id);

                if (offerletter == null)
                {
                    return NotFound($"Offer letter with Id {id} not found.");
                }

                return Ok(offerletter);
            }
            catch (Exception ex)
            {
                // Log exception here if needed
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut("updateofferletter")]
        public async Task<IActionResult> UpdateOfferLetter([FromBody] UpdateOfferLetterRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request data.");
            }

            // Validate using FluentValidation
            var validationResult = await updateValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            try
            {
                await offerLetter.UpdateOfferLetterAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                // Log exception here if needed
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"An error occurred while updating: {ex.Message}");
            }
        }

        [HttpDelete("deleteofferletter/{id}")]
        public async Task<IActionResult> DeleteOfferLetter(int id)
        {
            try
            {
                await offerLetter.DeleteOfferLetterAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"An error occurred while soft-deleting: {ex.Message}");
            }
        }


    }
}
