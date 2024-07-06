using HexagonalBackEnd.Application.Dtos;
using HexagonalBackEnd.Application.Interfaces;
using HexagonalBackEnd.Domain.Entities;
using HexagonalBackEnd.Infrastructure.SQL.Repository;
using HexagonalBackEnd.Infrastructure.SQL.Repository.Base;
using HexagonalBackEnd.Utility;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalBackEnd.Application.Services
{
    public class EmployeeService :IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        private readonly IRoleRepository _roleRepository;

        private readonly Encrypt _encrypt;

        private readonly ILog _logger;

        private readonly IUtilityJWT _utility;

        public EmployeeService(IEmployeeRepository employeeRepository, IRoleRepository roleRepository, 
            ILog logger, IUtilityJWT utilityJWT) {
            _employeeRepository = employeeRepository;
            _encrypt = new Encrypt();
            _roleRepository = roleRepository;
            _utility = utilityJWT;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<EmployeeResponseDto> CreateEmployee(EmployeeDto employee)
        {
            await ValidateEmployeeNeedLeader(employee.IdRole, employee.IdLeader);

            Employee employeeEntity = new Employee
            {
                Name = employee.Name,
                LastName = employee.LastName,
                UserName = employee.UserName,
                Password = _encrypt.encriptSHA256(employee.Password),
                IdRole = employee.IdRole,
                IdAreaLeader = employee.IdArea,
                IdLeader = employee.IdLeader
            };  
            return createEmployeeDto(await _employeeRepository.CreateEmployeeAsync(employeeEntity));
        }

        private EmployeeResponseDto createEmployeeDto(Employee employee)
        {
            EmployeeResponseDto employeeDto = new EmployeeResponseDto()
            {
                Id = employee.Id,
                Name = employee.Name,
                LastName = employee.LastName,
                UserName = employee.UserName,
                IdRole = employee.IdRole,
                IdLeader = employee.IdLeader
            };
            return employeeDto;
        }

        private async Task ValidateEmployeeNeedLeader(int idrole, int? idLeader)
        {
            var role = await _roleRepository.GetARoleByIdAsync(idrole);
            if (role.Priority != 4 && idLeader==null)
            {
                _logger.Error("The employee nedd leader to register in the system.");
                throw new Exception("The employee nedd leader to register in the system\".");
            }  
        }

        public async Task<EmployeeResponseDto> GetEmployeeByIdAsync(int id)
        {
            return  createEmployeeDto(await _employeeRepository.GetEmployeeByIdAsync(id));
        }

        public async Task<Employee> GetEmployeeRoleByIdAsync(int id)
        {
            return await _employeeRepository.GetEmployeeByIdAsync(id);
        }

        public async Task UpdateEmployeeAsync(EmployeeUpdateDto employee)
        {
            
            Employee employeeEntity = await _employeeRepository.GetEmployeeByIdAsync(1);
            CreateEmployeeEntity(employee, employeeEntity);

            try
            {
                await _employeeRepository.UpdateEmployeeAsync(employeeEntity);
            }
            catch (Exception)
            {

                _logger.Error("An error occurred while updating.");
                throw new Exception("An error occurred while updating.");
            }
        }

        public async Task<bool>  ValidateEmployeeHasLeader(int idEmployee)
        {
            var employeeDB = await _employeeRepository.GetEmployeeByIdAsync(idEmployee);
            return employeeDB.IdLeader == null ? false : true;
        }

        private static void CreateEmployeeEntity(EmployeeUpdateDto employee, Employee employeeEntity)
        {
            employeeEntity.Name = employee.Name == null ? employeeEntity.Name : employee.Name;
            employeeEntity.LastName = employee.LastName == null ? employeeEntity.LastName : employee.LastName;
            employeeEntity.IdRole = employee.IdRole == null ? employeeEntity.IdRole : (int)employee.IdRole;
            employeeEntity.IdLeader = employee.IdLeader == null ? employeeEntity.IdLeader : employee.IdLeader;
        }

        public async Task<AuthenticateDto> LoginAsync(string user, string password)
        {
            var employee = await _employeeRepository.LoginAsync(user, _encrypt.encriptSHA256(password));
            if (employee != null)
            {
                return new AuthenticateDto()
                {
                    IsSuccess = true,
                    Token = _utility.GenerateJWTToken(employee),
                };
            }
            else {
                return new AuthenticateDto()
                {
                    IsSuccess = false,
                    Token = "",
                };
            }
            
        }

    }
}
