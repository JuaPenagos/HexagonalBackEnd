using HexagonalBackEnd.Application.Dtos;
using HexagonalBackEnd.Application.Interfaces;
using HexagonalBackEnd.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HexagonalBackEnd.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class AreaLeaderController : ControllerBase
    {

        private readonly IAreaLeaderService _areaLeaderService;
        public AreaLeaderController(IAreaLeaderService areaLeaderService) {

            _areaLeaderService = areaLeaderService;
        }

        [AllowAnonymous]
        [HttpGet("")]
        public async Task<IActionResult> GetAreasLeadersAsync()
        {
            var areasLeadersDB = await _areaLeaderService.GetAllAreaLeaderAsync();
            return Ok(areasLeadersDB);
        } 

        [AllowAnonymous]
        [HttpPost("CreateAreaLeader")]
        public async Task<IActionResult> CreateAreaLeaderAsync(AreaLeaderDto areaLeader)
        {
            var areasLeadersDB = await _areaLeaderService.CreateAreaLeaderAsync(areaLeader);
            return Ok(areasLeadersDB);
        }

    }
}
