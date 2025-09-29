using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.RoleDetails;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KalaGenset.ERP.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesDetailsController : BaseController
    {
        private readonly IRoleDetails _roleDetailsService;
        public RolesDetailsController(IRoleDetails roleDetailsService)
        {
            _roleDetailsService = roleDetailsService;
        }
        /// <summary>
        /// add Role Details controller
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("AddRoleDetails")]
        public async Task<IActionResult> AddRoleDetails([FromBody] InsertRoleDetailsRequest request)
        {
            try
            {
                await _roleDetailsService.AddRoleDetailsAsync(request);
                return Ok("Role details added successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error adding role details: {ex.Message}");
            }
        }
        /// <summary>
        /// update Role Details controller
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("UpdateRoleDetails")]
        public async Task<IActionResult> UpdateRoleDetails([FromBody] UpdateRoleDetailsRequest request)
        {
            try
            {
                await _roleDetailsService.UpdateRoleDetailsAsync(request);
                return Ok("Role details updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error updating role details: {ex.Message}");
            }
        }
        /// <summary>
        /// get All Role Details controller
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllRoleDetails")]
        public async Task<IActionResult> GetAllRoleDetails()
        {
            try
            {
                var roleDetails = await _roleDetailsService.GetAllRoleDetailsAsync();
                return Ok(roleDetails);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error retrieving role details: {ex.Message}");
            }
        }
        /// <summary>
        /// role details by ID from RolesDetails table
        /// </summary>
        /// <param name="RolesDetailsId"></param>
        /// <returns></returns>
        [HttpGet("GetRoleDetailsByID/{RolesDetailsId}")]
        public async Task<IActionResult> GetRoleDetailsByID(int RolesDetailsId)
        {
            try
            {
                var roleDetail = await _roleDetailsService.GetRoleDetailsByID(RolesDetailsId);
                if (roleDetail == null)
                {
                    return NotFound("Role details not found.");
                }
                return Ok(roleDetail);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error retrieving role details: {ex.Message}");
            }
        }
        /// <summary>
        ///  delete a role 
        /// </summary>
        /// <param name="RolesDetailsId"></param>
        /// <returns></returns>
        [HttpDelete("DeleteRoleDetails/{RolesDetailsId}")]
        public async Task<IActionResult> DeleteRoleDetails(int RolesDetailsId)
        {
            try
            {
                await _roleDetailsService.DeleteRoleDetailsAsync(RolesDetailsId);
                return Ok("Role details deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error deleting role details: {ex.Message}");
            }
        }

        [HttpGet("getrolesdetails/{gradeId}/{designationId}/{divisionId}")]
        public async Task<IActionResult> GetRolesDetailsByCombination(int gradeId, int designationId, int divisionId)
        {
            try
            {
                var details = await _roleDetailsService.GetRolesDetailsByCombination(gradeId, designationId, divisionId);
                return Ok(details);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error fetching role details: {ex.Message}");
            }
        }

    }
}
