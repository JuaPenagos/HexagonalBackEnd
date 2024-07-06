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
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService) {
        
            _employeeService = employeeService;
        }

        [HttpPost("AddEmployee")]
        public async Task<IActionResult> AddEmployeeAsync(EmployeeDto employee)
        {
            var employeeCreated = await _employeeService.CreateEmployee(employee);

            return Ok(employeeCreated);
        }

        
        [HttpPost("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployeeAsync(EmployeeUpdateDto employee)
        {
            await _employeeService.UpdateEmployeeAsync(employee);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("LogIn")]
        public async Task<IActionResult> LogInAsync(LoginDto login)
        {
            var employeeCreated = await _employeeService.LoginAsync(login.UserName, login.Password);

            return Ok(employeeCreated);
        }

    }
}
