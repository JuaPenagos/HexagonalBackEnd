using HexagonalBackEnd.Application.Interfaces;
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
    public class HistoryOvertimeController : ControllerBase
    {

        private readonly IHistoryOvertimeService _historyOvertimeService;
        public HistoryOvertimeController(IHistoryOvertimeService historyOvertimeService) {

            _historyOvertimeService = historyOvertimeService;
        }

        //[AllowAnonymous]
        //[HttpPost("AddEmployee")]
        //public async Task<IActionResult> AddHistory(Employee employee)
        //{
        //    var employeeCreated = await _areaService.CreateEmployee(employee);
        //    return Ok(employeeCreated);
        //}


    }
}
