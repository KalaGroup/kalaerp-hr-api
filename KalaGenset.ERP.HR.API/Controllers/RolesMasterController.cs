using FluentValidation;
using KalaGenset.ERP.HR.Core.Interface;
using KalaGenset.ERP.HR.Core.Request.RolesMaster;
using KalaGenset.ERP.HR.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KalaGenset.ERP.HR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesMasterController : ControllerBase
    {
        private readonly IRolesMaster _rolesMaster;
        private readonly IValidator<InsertRolesMasterRequest> _insertRolesValidator;
        private readonly IValidator<UpdateRolesMasterRequest> _updateRolesValidator;
        public RolesMasterController(IRolesMaster rolesMaster, IValidator<InsertRolesMasterRequest> insertRolesValidator, IValidator<UpdateRolesMasterRequest> updateRolesValidator)
        {
            _rolesMaster = rolesMaster;
            _insertRolesValidator = insertRolesValidator;
            _updateRolesValidator = updateRolesValidator;

        }

        /// <summary>
        /// Add Roles Master controller
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("AddRoles")]
        public async Task<IActionResult> AddRoles([FromBody] InsertRolesMasterRequest request)
        {
            var validationResult = await _insertRolesValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await _rolesMaster.AddRolesAsync(request);
                return Ok("Role added successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding the role: {ex.Message}");
            }
        }

        /// <summary>
        /// update Roles Master controller
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("UpdateRoles")]
        public async Task<IActionResult> UpdateRoles([FromBody] UpdateRolesMasterRequest request)
        {
            var validationResult = await _updateRolesValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            try
            {
                await _rolesMaster.UpdateRolesAsync(request);
                return Ok("Role Updated Sucessfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating Role: {ex.Message}");
            }


        }

        /// <summary>
        /// get all Roles Master controller
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllRoles")]
        public async Task<IActionResult> GetAllRoles()
        {
            var result = await _rolesMaster.GetAllRolesAsync();
            return Ok(result);
        }

        /// <summary>
        /// get role by ID from Roles Master controller
        /// </summary>
        /// <param name="RolesId"></param>
        /// <returns></returns>
        [HttpGet("GetRoleById/{RolesId}")]
        public async Task<IActionResult> GetRoleById(int RolesId)
        {
            try
            {
                var result = await _rolesMaster.GetRoleByID(RolesId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $" ID Is Invalid: {ex.Message}");
            }

        }

        /// <summary>
        /// soft delete a role by setting RolesIsDiscard to true from Roles Master controller
        /// </summary>
        /// <param name="RolesId"></param>
        /// <returns></returns>
        [HttpDelete("DeleteRole/{RolesId}")]
        public async Task<IActionResult> DeleteRole(int RolesId)
        {
            try
            {
                await _rolesMaster.DeleteRoleAsync(RolesId);
                return Ok("Role Deleted Sucessfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting Role: {ex.Message}");
            }
        }

    }
}
