using HexagonalBackEnd.Application.Dtos;
using HexagonalBackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalBackEnd.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<EmployeeResponseDto> CreateEmployee(EmployeeDto employee);

        Task UpdateEmployeeAsync(EmployeeUpdateDto employee);

        Task<bool> ValidateEmployeeHasLeader(int idEmployee);

        Task<EmployeeResponseDto> GetEmployeeByIdAsync(int id);

        Task<Employee> GetEmployeeRoleByIdAsync(int id);

        Task<AuthenticateDto> LoginAsync(string user, string password);
    }
}
