using HexagonalBackEnd.Application.Dtos;
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
    public class OvertimeHoursController : ControllerBase
    {

        private readonly IOvertimeHoursService _overtimeHoursService;
        public OvertimeHoursController(IOvertimeHoursService overtimeHoursService) {

            _overtimeHoursService = overtimeHoursService;
        }

        [AllowAnonymous]
        [HttpPost("AddOverTimeHour")]
        public async Task<IActionResult> AddOverTimeHourAsync(OverTimeHourReportDto overTimeHourReport)
        {
            var overtimeHours = await _overtimeHoursService.CreateOvertimeHoursAsync(overTimeHourReport);
            return Ok(overtimeHours);
        }

        [AllowAnonymous]
        [HttpPost("ApproveOvertimeHours")]
        public async Task<IActionResult> AApproveOvertimeHoursAsync(OverTimeHourApproveDto overTimeHourReport)
        {
            await _overtimeHoursService.ApproveOrRejectOvertimeHoursAsync(overTimeHourReport);
            return Ok();
        }

    }
}
