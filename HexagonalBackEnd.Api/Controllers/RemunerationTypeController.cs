using HexagonalBackEnd.Application.Interfaces;
using HexagonalBackEnd.Application.Services;
using HexagonalBackEnd.Domain.Entities;
using HexagonalBackEnd.Infrastructure.SQL.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HexagonalBackEnd.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]

    [ApiController]
    public class RemunerationTypeController : ControllerBase
    {

        private readonly IRemunerationTypeService _remunerationTypeService;
        public RemunerationTypeController(IRemunerationTypeService remunerationTypeService) {

            _remunerationTypeService = remunerationTypeService;
        }

        [AllowAnonymous]
        [HttpGet("")]
        public async Task<IActionResult> GetRemuneratonTypesAsync()
        {
            var remunerationTypesDB = await _remunerationTypeService.GetAllRemunerationTypeAsync();
            return Ok(remunerationTypesDB);
        }
    }
}
