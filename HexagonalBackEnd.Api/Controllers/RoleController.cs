using HexagonalBackEnd.Application.Interfaces;
using HexagonalBackEnd.Application.Services;
using HexagonalBackEnd.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HexagonalBackEnd.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class RoleController : ControllerBase
    {

        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService) {

            _roleService = roleService;
        }

        [AllowAnonymous]
        [HttpGet("")]
        public async Task<IActionResult> GetRolesAsyc()
        {
            var rolesDB = await _roleService.GetAllRoleAsync();
            return Ok(rolesDB);
        }



    }
}
