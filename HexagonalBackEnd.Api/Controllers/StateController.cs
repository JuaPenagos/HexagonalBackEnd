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
    public class StateController : ControllerBase
    {

        private readonly IStateService _stateService;
        public StateController(IStateService stateService) {

            _stateService = stateService;
        }

        [AllowAnonymous]
        [HttpGet("")]
        public async Task<IActionResult> GetStatesAsync()
        {
            var stateDB = await _stateService.GetAllStateAsync();
            return Ok(stateDB);
        }



    }
}
