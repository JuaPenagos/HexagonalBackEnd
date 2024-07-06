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
    public class AreaController : ControllerBase
    {

        private readonly IAreaService _areaService;
        public AreaController(IAreaService areaService) {

            _areaService = areaService;
        }

        [AllowAnonymous]
        [HttpGet("")]
        public async Task<IActionResult> GetAreasAsync()
        {
            var areasDB = await _areaService.GetAreasAsync();
            return Ok(areasDB);
        }


    }
}
